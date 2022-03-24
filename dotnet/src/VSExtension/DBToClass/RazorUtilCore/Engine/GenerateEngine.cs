using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Pipe;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Engine
{
    public class GenerateEngine
    {
        private static ConcurrentDictionary<string, Object> templates =
                    new ConcurrentDictionary<string, Object>();

        public static void Do<W>(W work) where W : Work
        {

            work.Prepare();

            foreach (PipeBase pipe in work.Pipes)
            {
                pipe.PrePareModel(work, pipe);
                pipe.PrepareVar(work, pipe);

                string razorTplPath = pipe.getRazorFilePath(work);
                if (string.IsNullOrEmpty(razorTplPath) || false == File.Exists(razorTplPath))
                {
                    throw new CodeGenerateException(string.Format("模板路径错误:{0}", razorTplPath));
                }

                object template = null;

                if (false == templates.ContainsKey(razorTplPath))
                {

                    lock (typeof(GenerateEngine))
                    {
                        if (false == templates.ContainsKey(razorTplPath))
                        {
                            string templateContent = File.ReadAllText(razorTplPath);
                            IRazorEngine razorEngine = new RazorEngine();
                            template = pipe.PrepareTemplate(razorEngine, templateContent);
                            templates[razorTplPath] = template;
                        }
                        else
                        {
                            template = templates[razorTplPath];
                        }

                    }
                }
                else
                {
                    template = templates[razorTplPath];
                }
                if (template == null)
                {
                    throw new CodeGenerateException("template == null");
                }

                lock (template)
                {
                    IEnumerable<object> models = pipe.GetModels(work, pipe);
                    pipe.PrepareVar(work, pipe);

                    foreach (var model in models)
                    {
                        pipe.BeforeEachModel(work, model);
                        pipe.Generate(work, template, model);
                    }


                }
            }
        }


        public static void Do<W, T>(W work, WorkPipeBaseT<W, T> pipe) where W : Work
        {
            work.Prepare();
            pipe.PrePareModel(work, pipe);
            pipe.PrepareVar(work, pipe);

            string razorTplPath = pipe.getRazorFilePath(work);

            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template = null;

            if (false == templates.ContainsKey(razorTplPath))
            {

                lock (typeof(GenerateEngine))
                {
                    if (false == templates.ContainsKey(razorTplPath))
                    {
                        string templateContent = File.ReadAllText(razorTplPath);
                        IRazorEngine razorEngine = new RazorEngine();
                        template
                           = razorEngine.Compile<RazorEngineTemplateBase<T>>(templateContent, builder =>
                           {
                               //builder.AddAssemblyReferenceByName("System.Security"); // by name
                               //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                               //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
                               //builder.AddAssemblyReferenceByName("System.Collections");

                               pipe.AddTemplateReference(builder);

                           });

                        templates[razorTplPath] = template;
                    }
                    else
                    {
                        template = (IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>)templates[razorTplPath];
                    }




                }
            }


            lock (template)
            {
                IEnumerable<object> models = pipe.GetModels(work, pipe);
                pipe.PrepareVar(work, pipe);
                foreach (var model in models)
                {
                    pipe.BeforeEachModel(work, model);
                    pipe.GenerateT(work, template, (T)model);
                }


            }


        }



    }
}

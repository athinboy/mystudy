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
        private static ConcurrentDictionary<string, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<Work>>> templates =
                    new ConcurrentDictionary<string, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<Work>>>();


        public static void Do(Work work, WorkPipeBase pipe)
        {

            pipe.PrePareModel(work);


            string razorTplPath = pipe.getRazorFilePath(work);

              

            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<Work>> template = null;

            if (false == templates.ContainsKey(razorTplPath))
            {

                lock (typeof(GenerateEngine))
                {
                    if (false == templates.ContainsKey(razorTplPath))
                    {
                        string templateContent = File.ReadAllText(razorTplPath);
                        IRazorEngine razorEngine = new RazorEngine();
                        template
                           = razorEngine.Compile<RazorEngineTemplateBase<Work>>(templateContent, builder =>
                           {
                           //builder.AddAssemblyReferenceByName("System.Security"); // by name
                           //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                           //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
                           builder.AddAssemblyReferenceByName("System.Collections");

                               pipe.AddTemplateReference(builder);

                           });

                        templates[razorTplPath] = template;
                    }
                    else
                    {
                        template = templates[razorTplPath];
                    }

                  


                }
            }



            lock (template)
            {
                pipe.Generate(work,template);               

            }





        }









    }
}

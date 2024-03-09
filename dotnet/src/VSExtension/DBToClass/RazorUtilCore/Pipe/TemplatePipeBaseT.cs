using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public abstract class TemplatePipeBaseT<W, T> : OutputPipe
        where W : Work.Work
        where T : BaseModel
    {
        protected IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> _template = null;

        protected static ConcurrentDictionary<string, Object> templateCache =
            new ConcurrentDictionary<string, Object>();

        protected TemplatePipeBaseT() : base()
        {
        }

        public string RazorTplFilePath { get; set; }

        protected virtual string GetInternalTplFileName()
        {
            return null;
        }

        protected TemplatePipeBaseT(string templatefilepath, string outputPath) : this()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
            RazorTplFilePath = (string.IsNullOrEmpty(templatefilepath) ? null : templatefilepath) ?? throw new ArgumentNullException(nameof(templatefilepath));
        }

        internal override void Init(Work.Work work)
        {
            base.Init(work);
            PrepareTemplate();

        }




        public virtual string getRazorTplFilePath()
        {
             

            if (string.IsNullOrEmpty(RazorTplFilePath))
            {
                return FileUtil.GetInternalTemplateFilePath(GetInternalTplFileName());
            }
            else
            {
                return RazorTplFilePath;
            }
            
        }


        //public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template);

        public abstract void GenerateT(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T t);


        internal override void DoOutput(Work.Work work, BaseModel model)
        {

            GenerateT((W)work, _template, (T)model);
        }

        public void Generate(Work.Work work, object template, object t)
        {
            GenerateT((W)work, (IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>)template, (T)t);
        }

        internal object PrepareTemplate()
        {

            string razorTplPath = getRazorTplFilePath();
            if (string.IsNullOrEmpty(razorTplPath) || false == File.Exists(razorTplPath))
            {
                throw new CodeGenerateException(string.Format("模板路径错误:{0}", razorTplPath));
            }

            object template = null;

            if (false == templateCache.ContainsKey(razorTplPath))
            {

                lock (templateCache)
                {
                    if (false == templateCache.ContainsKey(razorTplPath))
                    {
                        string templateContent = File.ReadAllText(razorTplPath);
                        IRazorEngine razorEngine = new RazorEngine();

                        template = razorEngine.Compile<RazorEngineTemplateBase<T>>(templateContent, builder =>
                        {
                            //builder.AddAssemblyReferenceByName("System.Security"); // by name
                            //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                            //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
                            //builder.AddAssemblyReferenceByName("System.Collections");
                            this.AddTemplateReference(builder);


                        });
                        templateCache[razorTplPath] = template;
                    }
                    else
                    {
                        template = templateCache[razorTplPath];
                    }

                }
            }
            else
            {
                template = templateCache[razorTplPath];
            }
            if (template == null)
            {
                throw new CodeGenerateException("template == null");
            }



            return template;



        }


    }




}

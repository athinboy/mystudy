using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Util;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public abstract class TemplatePipeBaseT<W, T, M> : OutputPipe<T, M>
        where W : Work.Work
        where T : BaseModel
        where M : BaseModel
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

        public override void Init(Work.Work work)
        {
            base.Init(work);
          _template=  PrepareTemplate();

        }




        public virtual string getRazorTplFilePath()
        {


            if (string.IsNullOrEmpty(RazorTplFilePath))
            {
                return TemplateFileUtil.GetInternalTemplateFilePath(GetInternalTplFileName());
            }
            else
            {
                return RazorTplFilePath;
            }

        }


        //public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template);

        protected virtual string GetOutputFilePath(T t)
        {
            return "";
        }

        public virtual void GenerateT(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T t)
        {
			string filePath=GetOutputFilePath(t);
            if (string.IsNullOrEmpty(filePath ?? ""))
            {
                throw new Exception("output file path is empty!");
            }
			string result = string.Empty;
 

			result = template.Run(instance =>
			{
				instance.Model = t;
			});

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			File.WriteAllText(filePath, result, new UTF8Encoding(false));
		}


        public override void DoOutput(Work.Work work, M model)
        {

            GenerateT((W)work, _template, model as T);
        }

        public void Generate(Work.Work work, object template, object t)
        {
            GenerateT((W)work, (IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>)template, (T)t);
        }

        protected IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> PrepareTemplate()
        {

            string razorTplPath = getRazorTplFilePath();
            if (string.IsNullOrEmpty(razorTplPath) || false == File.Exists(razorTplPath))
            {
                throw new CodeGenerateException(string.Format("模板路径错误:{0}", razorTplPath));
            }

			IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template = null;

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
                        template = templateCache[razorTplPath] as IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>;
                    }

                }
            }
            else
            {
                template = templateCache[razorTplPath] as IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>;
            }
            if (template == null)
            {
                throw new CodeGenerateException("template == null");
            }



            return template;



        }


    }




}

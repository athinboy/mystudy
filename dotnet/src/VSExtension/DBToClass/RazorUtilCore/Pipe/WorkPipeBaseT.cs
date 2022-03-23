using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public abstract class WorkPipeBaseT<W, T> : PipeBase where W : Work
    {

        protected WorkPipeBaseT() : base()
        {
        }

        protected WorkPipeBaseT(string templatefilepath, string outputPath) : this()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
            RazorTplFilePath = (string.IsNullOrEmpty(templatefilepath) ? null : templatefilepath) ?? throw new ArgumentNullException(nameof(templatefilepath));
        }



        //public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template);

        public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T t);

        public override void Generate(Work work, object template, object t)
        {
            Generate(work, (IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>>)template, (T)t);
        }

        internal override object PrepareTemplate(IRazorEngine razorEngine, string templateContent)
        {


            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template = razorEngine.Compile<RazorEngineTemplateBase<T>>(templateContent, builder =>
      {
          //builder.AddAssemblyReferenceByName("System.Security"); // by name
          //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
          //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
          //builder.AddAssemblyReferenceByName("System.Collections");
          this.AddTemplateReference(builder);


      });
            return template;



        }

  
    }




}

using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    internal class SimplePipe<T> : WorkPipeBaseT<Work, T>
    {

        public T MyT { get; set; }




        public SimplePipe(T t, string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {
            MyT = t;
        }

        public override void Generate(Work work, RazorEngineCore.IRazorEngineCompiledTemplate<RazorEngineCore.RazorEngineTemplateBase<T>> template)
        {

            IRazorEngine razorEngine = new RazorEngine();

            IRazorEngineCompiledTemplate i = razorEngine.Compile("", delegate (IRazorEngineCompilationOptionsBuilder x)
            {

            });
            i.Run();

            var s
              = razorEngine.Compile<RazorEngineTemplateBase<T>>("", builder =>
              {
                  //builder.AddAssemblyReferenceByName("System.Security"); // by name
                  //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                  //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
                  builder.AddAssemblyReferenceByName("System.Collections");


              });
            throw new NotImplementedException();
        }

        public override string getRazorFilePath(Work work)
        {
            throw new NotImplementedException();
        }

        internal override void PrePareModel(Work work)
        {
            throw new NotImplementedException();
        }

       
    }
}

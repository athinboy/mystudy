using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using RazorEngineCore;
using System;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class SimpleInstancePipe<T> : TemplatePipeBaseT<Work.Work, T> where T:BaseModel
    {

        public T MyT { get; set; }


        public SimpleInstancePipe(T t, string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {
            MyT = t;
        }

        public override void GenerateT(Work.Work work, RazorEngineCore.IRazorEngineCompiledTemplate<RazorEngineCore.RazorEngineTemplateBase<T>> template, T t)
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

 

       
    }
}

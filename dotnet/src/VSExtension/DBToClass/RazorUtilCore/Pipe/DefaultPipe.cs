using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class DefaultPipe<T> : WorkPipeBaseT<Work, T>
    {

        public DefaultPipe(string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {

        }

        public DefaultPipe() : base("", "")
        {
        }

        public override void Generate(Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T w)
        {

        }

        public override string getRazorFilePath(Work work)
        {
            return RazorTplFilePath;
        }

        public override void PrePareModel(Work work, PipeBase pipe)
        {
            if (PrepareModelAction != null)
            {
                PrepareModelAction(work, pipe);
            }
        }

        public override void PrepareVar(Work work, PipeBase pipe)
        {
        }
    }
}

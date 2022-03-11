using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class DefaultPipe : WorkPipeBase
    {

        public DefaultPipe(string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {

        }

        public override void Generate(Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<Work>> template)
        {


        }

        public override string getRazorFilePath(Work work)
        {
            return RazorTplFilePath;
        }

        internal override void PrePareModel(Work work)
        {
            throw new NotImplementedException();
        }
    }
}

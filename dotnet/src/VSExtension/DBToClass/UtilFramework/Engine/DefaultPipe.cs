using Org.FGQ.CodeGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Engine
{
    public class DefaultPipe : WorkPipeBase
    {

        public DefaultPipe(string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {

        }

        public override void Generate(Work work)
        {

        }

        public override string getRazorFilePath(Work work)
        {
            return this.RazorTplFilePath;
        }
    }
}

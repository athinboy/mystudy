using Org.FGQ.CodeGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Engine
{
    public abstract class WorkPipeBase
    {

        protected WorkPipeBase()
        {

        }


        protected WorkPipeBase(string templatefilepath, string outputPath) : this()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
            RazorTplFilePath = (string.IsNullOrEmpty(templatefilepath) ? null : templatefilepath) ?? throw new ArgumentNullException(nameof(templatefilepath));
        }

        public string OutputPath { get; protected set; }

        public string RazorTplFilePath { get; protected set; }

        public abstract string getRazorFilePath(Work work);
        public abstract void Generate(Work work);
    }


}

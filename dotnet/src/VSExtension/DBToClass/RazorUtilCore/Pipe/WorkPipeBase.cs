using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public abstract class WorkPipeBase<W,T> where W:Work
    {

        protected WorkPipeBase()
        {

        }


        protected WorkPipeBase(string templatefilepath, string outputPath) : this()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
            RazorTplFilePath = (string.IsNullOrEmpty(templatefilepath) ? null : templatefilepath) ?? throw new ArgumentNullException(nameof(templatefilepath));
        }

        internal abstract void PrePareModel(W work);

        public string OutputPath { get; protected set; }

        public string RazorTplFilePath { get; protected set; }

        public abstract string getRazorFilePath(W work);
        public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template);
        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            return;
        }
    }


}

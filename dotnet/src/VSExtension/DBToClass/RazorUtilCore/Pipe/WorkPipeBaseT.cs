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

        internal abstract void PrePareModel(W work);


        public abstract string getRazorFilePath(W work);
        public abstract void Generate(W work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template);

         

    }


}

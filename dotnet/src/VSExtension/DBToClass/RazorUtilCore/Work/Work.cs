using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Work
{
    public class Work
    {
 

        public DDLModel ddlModel { get; set; }

        public List<PipeBase> Pipes { get; set; } = new List<PipeBase>();

        public WorkAction PrepareAction { get; set; } = null;

        internal void Prepare()
        {
            if (PrepareAction != null)
            {
                PrepareAction(this);
            }
        }
    }
}

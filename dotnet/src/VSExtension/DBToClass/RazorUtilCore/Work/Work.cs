using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Work
{
    public class Work
    {
        public DDLModel ddlModel { get; set; }

        public List<OutputPipe> OutPipes { get; set; } = new List<OutputPipe>();

        public List<InputPipe> InPipes { get; set; } = new List<InputPipe> { };

        public WorkAction PrepareAction { get; set; } = null;

        internal List<BaseModel> GetModel()
        {
            throw new NotImplementedException();
        }

        internal void Prepare()
        {
            if (PrepareAction != null)
            {
                PrepareAction(this);
            }
        }
    }
}

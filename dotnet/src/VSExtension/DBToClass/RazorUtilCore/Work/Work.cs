using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Work
{
    public class Work
    {
        public Work(GenerateConfig generateConfig)
        {
            GenerateConfig = generateConfig;
        }

        public WareDDL DDLModel { get; set; }

        public List<OutputPipe> OutPipes { get; set; } = new List<OutputPipe>();

        public List<InputPipe> InPipes { get; set; } = new List<InputPipe> { };

        public WorkAction PrepareAction { get; set; } = null;
        public GenerateConfig GenerateConfig { get; protected set; }

        internal List<BaseModel> PrepareModel()
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

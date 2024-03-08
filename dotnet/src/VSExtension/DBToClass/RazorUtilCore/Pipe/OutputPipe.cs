using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using RazorEngineCore;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class OutputPipe : PipeBase
    {
        protected OutputPipe() : base()
        {
        }

        public string OutputPath { get; set; }



        public Action2 GetModelsAction { get; set; } = null;


        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null;


        public Action PickCurrent { get; set; }

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            builder.AddAssemblyReferenceByName("System.Collections");

            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public Action4 PrepareModelAction { get; set; } = null;



        public virtual BaseModel PrepareModel(Work.Work work, BaseModel model)
        {
            if (PrepareModelAction != null)
            {
                return PrepareModelAction(work, this, model);
            }
            return null;
        }





        internal virtual void DoOutput(Work.Work work, BaseModel model)
        {

        }
        internal virtual void FinishOutput(Work.Work work, BaseModel model)
        {

        }

        public Action4 PrepareOutputAction { get; set; } = null;

        internal virtual void PrepareOutput(Work.Work work, BaseModel model)
        {
            if (PrepareOutputAction != null)
            {
                PrepareOutputAction(work, this, model);
            }
        }

        public Action4 PrepareVarAction { get; set; } = null;

        internal virtual BaseModel PrepareVar(Work.Work work, BaseModel model)
        {
            if (PrepareVarAction != null)
            {
                return PrepareVarAction(work, this, model);
            }
            return model;
        }

 
    }
}

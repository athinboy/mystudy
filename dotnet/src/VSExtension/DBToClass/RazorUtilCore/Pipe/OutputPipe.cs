using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using RazorEngineCore;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public class OutputPipe<T, M> : PipeBase, IOutputPipe<T, M>
        where T : BaseModel
        where M : BaseModel
    {
		public OutputPipe() : base()
        {
        }

        public string OutputPath { get; set; }



        public Action2 GetModelsAction { get; set; } = null;

        public Action4T<BaseModel, BaseModel> ReceiptModelAction { get; set; }

        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null;

        public Action4 PrepareVarAction { get; set; } = null;
         

        public Action PickCurrent { get; set; }

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            builder.AddAssemblyReferenceByName("System.Collections");

            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public Action4 PrepareOutputAction { get; set; } = null;

        public virtual void PrepareOutput(Work.Work work, M model)
        {
            if (PrepareOutputAction != null)
            {
                PrepareOutputAction(work, this, model);
            }
        }



        public virtual T ReceiptModel(Work.Work work, M model)
        {
            if (ReceiptModelAction != null)
            {
                return ReceiptModelAction(work, this,model) as T;
            }
            return model as T;
        }

        public virtual void DoOutput(Work.Work work, M model)
        {
             
        }

        public virtual void FinishOutput(Work.Work work, M model)
        {
        }



        public virtual T PrepareVar(Work.Work work, M model)
        {
            if (PrepareVarAction != null)
            {
                return (T)PrepareVarAction(work, this, model);
            }
            return model as T;
        }

        public virtual void  Init(Work.Work work)
        {
             _work = work;
        }
    }
}

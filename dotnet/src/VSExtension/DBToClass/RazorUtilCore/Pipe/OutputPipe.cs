using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using RazorEngineCore;

namespace Org.FGQ.CodeGenerate.Pipe
{

	public class OutputPipe<T, M> : PipeBase, IOutputPipe<out T,in M>
		where T : BaseModel
		where M : BaseModel
	{
		protected OutputPipe() : base()
		{
		}

		public string OutputPath { get; set; }



		public Action2 GetModelsAction { get; set; } = null;
		public Action4T<BaseModel, BaseModel> ReceiptModelAction { get; set; }



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

 

		public Action4 PrepareOutputAction { get; set; } = null;

		internal virtual void PrepareOutput(Work.Work work, M model)
		{
			if (PrepareOutputAction != null)
			{
				PrepareOutputAction(work, this, model);
			}
		}

		public Action4 PrepareVarAction { get; set; } = null;

		internal virtual T PrepareVar(Work.Work work, M model)
		{
			if (PrepareVarAction != null)
			{
				return PrepareVarAction(work, this, model);
			}
			return model;
		}



	}
}

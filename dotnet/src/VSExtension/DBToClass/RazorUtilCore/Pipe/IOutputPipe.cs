using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using RazorEngineCore;

namespace Org.FGQ.CodeGenerate.Pipe
{
	public interface IOutputPipe<out T, in M> where T : BaseModel where M : BaseModel
	{


		

		public string OutputPath { get; set; }

		T ReceiptModel(Work.Work work, M model);

		void DoOutput(Work.Work work, BaseModel model);

		void FinishOutput(Work.Work work, BaseModel model);


		void PrepareOutput(Work.Work work, BaseModel model);

		BaseModel PrepareVar(Work.Work work, BaseModel model);


	}
}

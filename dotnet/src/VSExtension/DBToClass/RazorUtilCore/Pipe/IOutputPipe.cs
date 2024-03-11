using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using RazorEngineCore;

namespace Org.FGQ.CodeGenerate.Pipe
{
	public interface IOutputPipe<out T, in M> :IGeneratePipe where T : BaseModel where M : BaseModel
	{


 

		T ReceiptModel(Work.Work work, M model);

		void DoOutput(Work.Work work, M model);

		void FinishOutput(Work.Work work, M model);


		void PrepareOutput(Work.Work work, M model);

		T PrepareVar(Work.Work work, M model);


	}
}

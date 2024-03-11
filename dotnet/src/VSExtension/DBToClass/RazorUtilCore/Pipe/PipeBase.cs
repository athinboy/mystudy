using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

 


	public abstract class PipeBase
	{
		protected Work.Work _work;

		protected PipeBase()
		{
	 

		}

		public bool ValidateConfig()
		{
			return true;
		}

		internal virtual void Init(Work.Work work)
		{
			_work = work;
		}
	}
}

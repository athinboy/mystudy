using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Pipe.Delegate;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class PipeBase
    {
        protected PipeBase()
        {

        }

        public bool ValidateConfig()
        {
            return true;
        }

        internal virtual void Init(Work.Work work)
        {

        }
    }
}

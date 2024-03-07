using Org.FGQ.CodeGenerate.Pipe.Delegate;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class PipeBase
    {



        protected PipeBase()
        {

        }

        public Action3 PrepareVarAction { get; set; } = null;


        public abstract void Generate(Work.Work work, object template, object t);
 

        public bool ValidateConfig()
        {
            return true;
        }

        /// <summary>
        /// prepare the variable/environment.
        /// </summary>
        /// <param name="work"></param>
        /// <param name="pipe"></param>
        /// <remarks>the override method of this need call this method。</remarks>
        public virtual void PrepareVar(Work.Work work)
        {
            if (PrepareVarAction != null)
            {
                PrepareVarAction(work, this);
            }
        }

    }
}

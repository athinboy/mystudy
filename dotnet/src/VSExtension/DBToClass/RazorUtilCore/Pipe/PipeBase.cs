using Org.FGQ.CodeGenerate.Work;
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

    }
}

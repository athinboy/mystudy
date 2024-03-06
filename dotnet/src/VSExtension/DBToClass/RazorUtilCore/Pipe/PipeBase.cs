using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class PipeBase
    {



        protected PipeBase()
        {

        }

  
        public abstract void Generate(Work.Work work, object template, object t);
 

        public bool ValidateConfig()
        {
            return true;
        }

    }
}

using Org.FGQ.CodeGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Engine
{
    public abstract class GenerateEngineBase
    {
        public void Do(Work work, WorkPipeBase pipe)
        {

            string razorTplPath = pipe.getRazorFilePath(work);


            pipe.Generate(work);


             

        }


         






    }
}

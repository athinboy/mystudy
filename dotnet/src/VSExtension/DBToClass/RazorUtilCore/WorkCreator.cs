using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate
{
    public class WorkCreator
    {
        public Work.Work Create(GenerateConfig generateConfig)
        {
            Work.Work work=null;
            switch (generateConfig.Mode)
            {
                case GenerateMode.DBToCode:
                    if (generateConfig.codeConfig.CSharpConfig != null)
                    {
                        work = new CSharpWork();
                    }
                    break;
            }
            return null;
        }
    }
}

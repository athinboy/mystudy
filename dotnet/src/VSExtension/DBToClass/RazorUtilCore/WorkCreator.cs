using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate
{
    public class WorkCreator
    {
        public Work Create(GenerateConfig generateConfig)
        {
            Work work=null;
            switch (generateConfig.Mode)
            {
                case GenerateMode.DBToCode:
                    if (generateConfig.codeConfig.CSharpConfig != null)
                    {
                        work = new CSharpWorkModel();
                    }
                    break;
            }
            return null;
        }
    }
}

using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Dispatch
{
    internal class DefaultDispatch : DispatchBase
    {

        void DispatchBase.Dispatch(GenerateConfig generateConfig)
        {

            if (generateConfig.codeConfig.CSharpConfig != null)
            {
                CSharpGenerator cSharpGenerator = new CSharpGenerator();

            }
        }
    }
}

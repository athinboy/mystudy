using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Dispatch
{
    internal interface DispatchBase
    {
        void Dispatch(GenerateConfig generateConfig);
    }
}

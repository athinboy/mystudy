using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
    public class JavaConfigBase : BaseModel
    {
        
        public string PackageName { get; set; }
        public string JavaDiretory { get; set; }  
        public JavaClass JavaClass { get; set; }

    }
}

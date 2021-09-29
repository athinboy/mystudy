using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
    public class JavaBeanConfig: JavaConfigBase
    {

        public DDLConfig DDLConfig { get; set; }

        public string OmmitPrefix { get; set; } = string.Empty;
        public DDLTable Table { get; set; }
        public ClassBase ClassBase { get; set; }
    }
}

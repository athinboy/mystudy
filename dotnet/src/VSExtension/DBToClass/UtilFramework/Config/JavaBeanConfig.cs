using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.config
{
    public class JavaBeanConfig
    {

        public DDLConfig DDLConfig { get; set; }
        public string PackageName { get; set; }
        public string JavaDiretory { get; set; }
        public string OmmitPrefix { get; set; } = string.Empty;
        public DDLTable Table { get; set; }
        public ClassBase ClassBase { get; set; }
    }
}

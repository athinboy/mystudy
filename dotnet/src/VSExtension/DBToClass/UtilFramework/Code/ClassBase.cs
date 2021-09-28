using Org.FGQ.CodeGenerate.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class ClassBase
    {
        public ClassBase(DDLTable dDLTable)
        {
            DDLTable = dDLTable ?? throw new ArgumentNullException(nameof(dDLTable));
        }

        public List<FieldBase> Fields { get; set; } = new List<FieldBase>();

        public DDLTable DDLTable { get; set; }



        public string ClassName { get; protected set; }



    }
}

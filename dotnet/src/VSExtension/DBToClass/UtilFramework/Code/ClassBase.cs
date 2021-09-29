using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class ClassBase
    {

        public string PackageName { get; set; }


        public ClassBase(string packageName, DDLTable dDLTable)
        {
            PackageName = packageName ?? throw new ArgumentNullException(nameof(packageName));
            DDLTable = dDLTable ?? throw new ArgumentNullException(nameof(dDLTable));
        }

        public List<FieldBase> Fields { get; set; } = new List<FieldBase>();

        public DDLTable DDLTable { get; set; }


        public string ClassName { get; protected set; }

        public bool HasKeyField
        {

            get
            {
                return Fields.Any(f => f.IsKeyField);
            }
        }

        public List<FieldBase> KeyFileds
        {
            get
            {
                return Fields.FindAll(x => x.IsKeyField);
            }
        }




    }
}

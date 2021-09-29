using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Util.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class FieldBase
    {

        public FieldTypes FieldType { get; set; } = FieldTypes.String;
        public bool IsKeyField { get; private set; } = false;

        public DDLColumn DDLColumn { get; set; }


        public string Desc { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string FiledTypeStr { get; internal set; }
        public string DDLName
        {
            get
            {
                return this.DDLColumn == null ? "" : DDLColumn.Name;
            }
            private set { }
        }


        internal static FieldBase Create(DDLColumn c)
        {

            FieldBase fieldBase = new FieldBase();
            fieldBase.Name = CodeUtil.GetFieldName(c);
            fieldBase.Desc = c.Desc;
            fieldBase.Remark = c.Remark;
            fieldBase.DDLColumn = c;
            fieldBase.FieldType = DDLUtil.AnalysisFieldType(c);
            fieldBase.IsKeyField = c.IsKeyColumn();
            return fieldBase;

        }
         
    }
}

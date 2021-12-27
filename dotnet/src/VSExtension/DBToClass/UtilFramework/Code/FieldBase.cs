using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Util.DB;
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
        public bool IsPrimaryKeyColumn { get; private set; } = false;
        public bool IsUniqueKeyColumn { get; private set; } = false;
        public bool IsParentKey { get; private set; } = false;
        public DDLColumn DDLColumn { get; set; }


        public string Desc { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string JDBCType { get; set; } = string.Empty;

        public string FiledTypeStr { get; internal set; }


        public string JsonFieldName
        {
            get
            {
                return this.DDLColumn == null ? "丢失的JSON名称" : DDLColumn.JsonFieldName;
            }
            private set { }
        }

        public string DBColName
        {
            get
            {
                return this.DDLColumn == null ? "丢失的列名称" : DDLColumn.NameSql;
            }
            private set { }
        }

        public string GetPropertyName()
        {
            return this.Name.Length == 1 ? this.Name.ToUpper() : (this.Name.Substring(0, 1).ToUpper() + this.Name.Substring(1));
        }


        internal static FieldBase Create(DDLColumn c)
        {

            FieldBase fieldBase = new FieldBase();
            fieldBase.Name = CodeUtil.GetFieldName(c);
            fieldBase.Desc = c.Desc;
            fieldBase.Remark = c.Remark;
            fieldBase.DDLColumn = c;
            fieldBase.FieldType = DDLUtil.AnalysisFieldType(c);
            fieldBase.JDBCType = DBUtil.AnalysisJDBCType(fieldBase.FieldType);
            fieldBase.IsKeyField = c.IsKeyColumn();
            fieldBase.IsPrimaryKeyColumn = c.IsPrimaryKeyColumn();
            fieldBase.IsUniqueKeyColumn = c.IsUniqueKeyColumn();
            fieldBase.IsParentKey = c.IsParentKey;
            return fieldBase;

        }

    }
}

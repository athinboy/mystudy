using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Util.DB;
using Org.FGQ.CodeGenerate.Util.Util;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class FieldBase
    {

        public FieldTypes FieldType { get; set; } = FieldTypes.String;
        public bool IsKeyField { get; private set; } = false;
        public bool IsPrimaryKeyColumn { get; private set; } = false;
        public bool IsUniqueKeyColumn { get; private set; } = false;
        public bool IsParentKey { get; private set; } = false;
        public FieldColumn Column { get; set; }


        public string Desc { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string JDBCType { get; set; } = string.Empty;

        public string FiledTypeStr { get; internal set; }


        public string JsonFieldName
        {
            get
            {
                return this.Column == null ? "丢失的JSON名称" : Column.JsonFieldName;
            }
            private set { }
        }

        public string DBColName
        {
            get
            {
                return this.Column == null ? "丢失的列名称" : Column.NameSql;
            }
            private set { }
        }

        public string GetPropertyName()
        {
            return this.Name.Length == 1 ? this.Name.ToUpper() : (this.Name.Substring(0, 1).ToUpper() + this.Name.Substring(1));
        }


        internal static FieldBase Create(FieldColumn c)
        {

            FieldBase fieldBase = new FieldBase();
            fieldBase.Name = CodeUtil.GetFieldName(c);
            fieldBase.Desc = c.Desc;
            fieldBase.Remark = c.Remark;
            fieldBase.Column = c;
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

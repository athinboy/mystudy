using Org.FGQ.CodeGenerate.Util.Code;
using System;

namespace Org.FGQ.CodeGenerate.Util.DB
{
    public class DBColumn
    {

        public bool IsPriKey { get; set; } = false;

        public bool IsNullable { get; set; } = true;

        public string ColName { get; set; } = string.Empty;

        public string ColumnType { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public FieldTypes FieldType { get; set; } = FieldTypes.String;

        public int Position { get; set; }

        public DBColumn(string colName, string columnType, string dataType, bool isPriKey, bool isNullable, int position, FieldTypes fieldTypes, string comment)
        {
            ColName = colName ?? throw new ArgumentNullException(nameof(colName));
            ColumnType = columnType ?? throw new ArgumentNullException(nameof(columnType));
            DataType = dataType ?? throw new ArgumentNullException(nameof(dataType));
            IsPriKey = isPriKey;
            IsNullable = isNullable;
            Position = position;
            Comment = comment ?? "";
            FieldType = fieldTypes;
        }
    }
}
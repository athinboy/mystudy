using System;

namespace UtilFramework
{
    public class Column
    {

        public bool IsPriKey { get; set; } = false;

        public bool IsNullable { get; set; } = true;

        public string ColName { get; set; } = string.Empty;

        public FieldTypes FieldType { get; set; } = FieldTypes.String;

        public string ColumnType { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;


        public int Position { get; set; }

        public Column(string colName, string columnType, string dataType, bool isPriKey, bool isNullable, int position, FieldTypes fieldType)
        {
            ColName = colName ?? throw new ArgumentNullException(nameof(colName));
            ColumnType = columnType ?? throw new ArgumentNullException(nameof(columnType));
            DataType = dataType ?? throw new ArgumentNullException(nameof(dataType));
            IsPriKey = isPriKey;
            IsNullable = isNullable;
            Position = position;
            FieldType = fieldType;
        }
    }
}
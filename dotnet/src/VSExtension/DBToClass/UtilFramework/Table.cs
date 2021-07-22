using System;
using System.Collections.Generic;

namespace UtilFramework
{
    public class Table
    {
        public Table(string tableName)
        {
            TableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
        }

        public string TableName { get; set; } = string.Empty;

        public List<Column> Columns { get; set; } = new List<Column>();
    }
}
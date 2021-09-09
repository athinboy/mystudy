using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Util.DB
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
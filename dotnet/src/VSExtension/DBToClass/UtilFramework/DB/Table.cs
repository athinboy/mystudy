using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Util.DB
{
    public class Table
    {
        public Table(string tableName, string comment)
        {
            TableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            Comment = comment ?? "";
        }

        public string TableName { get; set; } = string.Empty;


        public string Comment { get; set; } = string.Empty;

        public List<Column> Columns { get; set; } = new List<Column>();
    }
}
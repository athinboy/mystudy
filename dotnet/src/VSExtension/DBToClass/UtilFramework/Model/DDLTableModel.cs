using Org.FGQ.CodeGenerate.Config;
using System;

namespace Org.FGQ.CodeGenerate.Model
{
    public class DDLTableModel : BaseModel
    {
        public DDLTable Table { get; set; }

        public DDLTableModel(DDLTable table)
        {
            Table = table ?? throw new ArgumentNullException(nameof(table));
        }
    }
}

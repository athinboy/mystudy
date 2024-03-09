using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model.DDL;
using System;

namespace Org.FGQ.CodeGenerate.Model
{
    public class TableModel : BaseModel
    {
        public EntityTable Table { get; set; }

        public TableModel(EntityTable table)
        {
            Table = table ?? throw new ArgumentNullException(nameof(table));
        }
    }
}

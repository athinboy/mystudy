
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilFramework
{
    public class DB
    {
        public DB(string dbname)
        {            
            DBName = dbname ?? throw new ArgumentNullException(nameof(dbname));
        }

        public string DBName { get; set; } = string.Empty;

        public List<Table> Tables { get; set; } = new List<Table>();


        public Table this[string tableName]
        {
            get
            {
                for (int i = 0; i < this.Tables.Count; i++)
                {
                    if (Tables[i].TableName == tableName)
                    {
                        return Tables[i];
                    }
                }
                return null;
            }
            private set { }

        }



    }
}

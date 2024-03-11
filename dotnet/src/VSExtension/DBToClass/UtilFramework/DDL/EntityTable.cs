using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Model.DDL
{
    public class EntityTable
    {

        public string TableName { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;

        public string DBName { get; set; } = string.Empty;

        private string tablenameSql;

        public string TableNameSQL
        {
            get { return tablenameSql ?? DBName; }
            set { tablenameSql = value; }
        }


        public string Desc { get; set; } = string.Empty;

        public List<FieldColumn> FieldColumns { get; set; } = new List<FieldColumn>();
        public ClassBase RelatedClsss { get; set; } = null;
        public WareDDL DDLConfig { get; internal set; }

        private EntityTable()
        {


        }

        public EntityTable(string dbName, string tableName, string desc)
        {
            DBName = dbName?.Trim() ?? throw new ArgumentNullException(nameof(dbName));
            TableName = tableName?.Trim() ?? throw new ArgumentNullException(nameof(tableName));
            TableNameSQL = tableName;
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));

        }
        public EntityTable(string dbName, string tableName, string desc, string classname) : this(dbName, tableName, desc)
        {
            ClassName = classname?.Trim() ?? throw new ArgumentNullException(nameof(classname));
        }

        public EntityTable CreateForCalss(string dbName, string prefix, string classname, string desc, bool supperDBName)
        {
            string dbname = prefix + "_" + classname;


            return new EntityTable(dbName, supperDBName ? dbname.ToUpper() : dbName, desc, classname);

        }


        internal bool HasKeyCol()
        {
            foreach (FieldColumn col in FieldColumns)
            {
                if (col.IsKeyColumn())
                {
                    return true;
                }
            }
            return false;


        }
        public List<string> getPrimaryKeyNames()
        {
            return this.FieldColumns.FindAll(x => x.IsPrimaryKeyColumn()).ConvertAll<string>(x => { return x.NameSql; }).ToList();
        }

        public List<string> getUniqueKeyNames()
        {
            return this.FieldColumns.FindAll(x => x.IsUniqueKeyColumn()).ConvertAll<string>(x => { return x.NameSql; }).ToList();
        }


    }
}

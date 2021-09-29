using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Org.FGQ.CodeGenerate.Config
{

    public class DDLTable
    {

        public string TableName { get; set; } = string.Empty;

        public string DBName { get; set; } = string.Empty;

        public string Desc { get; set; } = string.Empty;

        public List<DDLColumn> Columns { get; set; } = new List<DDLColumn>();
        public JavaClass CreatedJavaBean { get; set; } = null;

        public DDLTable(string dbName, string tableName, string desc)
        {
            DBName = dbName?.Trim() ?? throw new ArgumentNullException(nameof(dbName));
            TableName = tableName?.Trim() ?? throw new ArgumentNullException(nameof(tableName));
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));

        }

        internal bool HasKeyCol()
        {
            foreach (DDLColumn col in Columns)
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
            List<string> s = null;             
            return this.Columns.FindAll(x => x.IsKeyColumn()).ConvertAll<string>(x => { return x.Name; }).ToList();
        }


    }

    public class DDLColumn
    {

        public string Desc { get; set; } = string.Empty;

        public string TypeName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;

        public string KeySign { get; set; } = string.Empty;
        public string SqlType { get; internal set; }

        public bool IsKeyColumn()
        {

            return KeySign.ToLower() == "是"
                || KeySign.ToLower() == "y"
                || KeySign.ToLower() == "true";

        }

        public string NullStr()
        {
            return IsKeyColumn() ? " not null" : "null";
        }

        public string CommentStr()
        {

            return this.Desc + "   " + this.Remark;
        }

        public bool Validate()
        {
            return false == (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TypeName));
        }



        public DDLColumn(string desc, string name, string type, string keySign, string remark)
        {
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));
            Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            TypeName = type?.Trim() ?? throw new ArgumentNullException(nameof(type));
            KeySign = keySign?.Trim() ?? throw new ArgumentNullException(nameof(keySign));
            Remark = remark?.Trim() ?? throw new ArgumentNullException(nameof(remark));
        }
    }


    public class DDLConfig
    {
        private bool prepared=false;

        public enum DBType
        {
            Oracle
        }



        public void Prepare()
        {
            if (this.prepared == true)
            {
                return;
            }

            foreach (var table in Tables)
            {
                if (false == table.HasKeyCol())
                {
                    table.Columns.Insert(0, new DDLColumn("ID", "id", "bigint(20)", "是", ""));
                }
                else
                {
                    table.Columns.Insert(0, new DDLColumn("ID", "id", "bigint(20)", "", ""));
                }
                table.Columns.ForEach(x =>
                {
                    x.SqlType = getSqlDBType(x.TypeName, this.MyDBType);
                });
            }
            this.prepared = true;





        }

        private string getSqlDBType(string type, DBType myDBType)
        {
            string longstr = "";
            if (type.Contains("("))
            {
                longstr = type.Substring(type.IndexOf("(") + 1, type.IndexOf(")") - type.IndexOf("(") - 1);
            }

            switch (myDBType)
            {
                case DBType.Oracle:

                    if (type.ToLower().Contains("varchar"))
                    {

                        return "varchar2(" + int.Parse(longstr) + " CHAR)";
                    }
                    if (type.ToLower().Contains("bigint"))
                    {
                        return "number(20,0)";
                    }
                    if (type.ToLower().Contains("long"))
                    {
                        return "number(20,0)";
                    }
                    return type;



                default:
                    throw new ArgumentNullException(nameof(myDBType));
            }
        }

        public List<DDLTable> Tables { get; set; } = new List<DDLTable>();


        public DBType MyDBType { get; set; } = DDLConfig.DBType.Oracle;




    }

}

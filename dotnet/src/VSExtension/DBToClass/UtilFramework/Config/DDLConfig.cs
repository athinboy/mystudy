using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Org.FGQ.CodeGenerate.Config
{

    public class DDLTable
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

        public List<DDLColumn> Columns { get; set; } = new List<DDLColumn>();
        public JavaClass CreatedJavaBean { get; set; } = null;


        private DDLTable()
        {


        }

        public DDLTable(string dbName, string tableName, string desc)
        {
            DBName = dbName?.Trim() ?? throw new ArgumentNullException(nameof(dbName));
            TableName = tableName?.Trim() ?? throw new ArgumentNullException(nameof(tableName));
            TableNameSQL = tableName;
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));

        }
        public DDLTable(string dbName, string tableName, string desc, string classname) : this(dbName, tableName, desc)
        {
            ClassName = classname?.Trim() ?? throw new ArgumentNullException(nameof(classname));
        }

        public DDLTable CreateForCalss(string dbName, string prefix, string classname, string desc, bool supperDBName)
        {
            string dbname = prefix + "_" + classname;


            return new DDLTable(dbName, supperDBName ? dbname.ToUpper() : dbName, desc, classname);

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
            return this.Columns.FindAll(x => x.IsKeyColumn()).ConvertAll<string>(x => { return x.NameSql; }).ToList();
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

        /// <summary>
        /// 是否父对象的外键
        /// </summary>
        public bool IsParentKey { get; set; } = false;

        private string nameSql;

        public string NameSql
        {
            get { return nameSql ?? Name; }
            set { nameSql = value; }
        }

        private string jsonFieldName;

        public string JsonFieldName
        {
            get { return jsonFieldName ?? Name; }
            set { jsonFieldName = value; }
        }



        public string CommentStr()
        {

            return this.Desc + "   " + this.Remark + (string.IsNullOrEmpty(jsonFieldName) ? " " : " json字段:" + jsonFieldName);
        }

        public bool Validate()
        {
            return false == (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TypeName));
        }

        public DDLColumn(string desc, string name, string type, string keySign, string remark, bool isparentkey)
        {
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));
            Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            TypeName = type?.Trim() ?? throw new ArgumentNullException(nameof(type));
            KeySign = keySign?.Trim() ?? throw new ArgumentNullException(nameof(keySign));
            Remark = remark?.Trim() ?? throw new ArgumentNullException(nameof(remark));
            IsParentKey = isparentkey;

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
        private bool prepared = false;

        public enum DBType
        {
            Oracle
        }


        public DDLTable GetTable(string tableName)
        {
            return Tables.Find(x => x.TableName == tableName);
        }

        public void Prepare()
        {
            if (this.prepared == true)
            {
                return;
            }

            foreach (var table in Tables)
            {

                if (table.Columns.FindAll(x => x.Validate()).ConvertAll<string>(x => x.Name).Distinct<string>().Count<string>()
                    != table.Columns.FindAll(x => x.Validate()).Count)
                {
                    throw new Exception(String.Format("表：{0}存在重复列", table.TableName));
                }

                if (this.MyDBType == DBType.Oracle)
                {
                    table.TableNameSQL = table.TableName.ToUpper();

                    if (table.TableName.Length > 30)
                    {
                        throw new Exception(String.Format("表名称：{0}过长", table.TableName));
                    }

                }

                bool idexists = table.Columns.Exists(x => x.Name.ToLower() == "id");

                if (false == idexists)
                {
                    if (false == table.HasKeyCol())
                    {
                        table.Columns.Insert(0, new DDLColumn("ID", "id", "bigint(20)", "是", ""));
                    }
                    else
                    {
                        table.Columns.Insert(0, new DDLColumn("ID", "id", "bigint(20)", "", ""));
                    }
                }
                table.Columns.ForEach(x =>
                {
                    x.SqlType = getSqlDBType(x.TypeName, this.MyDBType);
                    if (this.MyDBType == DBType.Oracle)
                    {
                        x.NameSql = x.Name.ToUpper();
                        if (x.NameSql.Length > 30)
                        {
                            throw new Exception(String.Format("列名称：{0} {1}过长", table.TableName, x.NameSql));
                        }
                    }
                });
            }
            this.prepared = true;





        }

        private string getSqlDBType(string type, DBType myDBType)
        {
            string longstr = null;
            if (type.Contains("("))
            {

                if (type.IndexOf(")") - type.IndexOf("(") <= 1)
                {
                    throw new ArgumentException(nameof(type) + ":" + type);
                }

                longstr = type.Substring(type.IndexOf("(") + 1, type.IndexOf(")") - type.IndexOf("(") - 1);

            }

            switch (myDBType)
            {
                case DBType.Oracle:

                    if (type.ToLower().Contains("varchar"))
                    {

                        return "varchar2(" + int.Parse(longstr ?? "10") + " CHAR)";
                    }
                    if (type.ToLower().Contains("bigint"))
                    {
                        return "number(20,0)";
                    }
                    if (type.ToLower().Contains("long"))
                    {
                        return "number(20,0)";
                    }
                    if (type.ToLower().Contains("bigint") || type.ToLower().Contains("big int"))
                    {
                        return "number(20)";
                    }
                    if (type.ToLower().Contains("int"))
                    {

                        return "number(" + (longstr ?? "10") + ")";
                    }
                    if (type.ToLower().TrimEnd() == "text")
                    {
                        return "varchar2(2000 CHAR)";
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

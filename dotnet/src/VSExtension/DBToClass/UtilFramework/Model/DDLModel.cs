using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Util.Util;
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
        public ClassBase RelatedClsss { get; set; } = null;
        public DDLModel DDLConfig { get; internal set; }

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
            return this.Columns.FindAll(x => x.IsPrimaryKeyColumn()).ConvertAll<string>(x => { return x.NameSql; }).ToList();
        }

        public List<string> getUniqueKeyNames()
        {
            return this.Columns.FindAll(x => x.IsUniqueKeyColumn()).ConvertAll<string>(x => { return x.NameSql; }).ToList();
        }


    }

    public class DDLColumn
    {

        public string Desc { get; set; } = string.Empty;

        public string TypeName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;

        public string PrimaryKeySign { get; set; } = string.Empty;


        public string UniqueKeySign { get; set; } = string.Empty;

        /// <summary>
        /// 唯一键，但是否在数据表中建立唯一键约束？
        /// </summary>
        public bool UniqueForDB { get; set; } = true;


        public string SqlType { get; internal set; }


        public bool IsPrimaryKeyColumn()
        {

            return PrimaryKeySign.ToLower().Trim() == "是"
                || PrimaryKeySign.ToLower().Trim() == "y"
                || PrimaryKeySign.ToLower().Trim() == "true";

        }

        public bool IsUniqueKeyColumn()
        {

            return UniqueKeySign.ToLower().Trim() == "是"
                || UniqueKeySign.ToLower().Trim() == "y"
                || UniqueKeySign.ToLower().Trim() == "true";

        }


        public bool IsKeyColumn()
        {

            return IsPrimaryKeyColumn() || IsUniqueKeyColumn();

        }

        public string NullStr()
        {
            return IsKeyColumn() ? " not null" : "null";
        }

        public string KeyStr()
        {
            if (false == IsKeyColumn())
            {
                return String.Empty;
            }
            if (IsPrimaryKeyColumn() && this.DDLTable.DDLConfig.MyDBType == DDLModel.DBType.MySql)
            {
                return "primary key";
            }
            if (IsUniqueKeyColumn() && this.DDLTable.DDLConfig.MyDBType == DDLModel.DBType.MySql)
            {
                if (this.UniqueForDB)
                {
                    return "unique key";
                }
                else
                {
                    return String.Empty;
                }


            }
            throw new Exception("非支持的操作");

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

        public DDLTable DDLTable { get; internal set; }
        public int? Length { get; internal set; }

        public string CommentStr()
        {

            return this.Desc + "   " + this.Remark + (string.IsNullOrEmpty(jsonFieldName) ? " " : " json字段:" + jsonFieldName);
        }

        public bool Validate()
        {
            return false == (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(TypeName));
        }

        public DDLColumn(string desc, string name, string type, string primarykeySign, string remark, bool isparentkey)
        {
            Desc = desc?.Trim() ?? throw new ArgumentNullException(nameof(desc));
            Name = name?.Trim() ?? throw new ArgumentNullException(nameof(name));
            TypeName = type?.Trim() ?? throw new ArgumentNullException(nameof(type));
            PrimaryKeySign = primarykeySign?.Trim() ?? throw new ArgumentNullException(nameof(primarykeySign));
            Remark = remark?.Trim() ?? throw new ArgumentNullException(nameof(remark));
            IsParentKey = isparentkey;

        }

        public DDLColumn(string desc, string name, string type, string primarykeySign, string remark) : this(desc, name, type, primarykeySign, remark, false)
        {

        }
        public DDLColumn(string desc, string name, string type) : this(desc, name, type, "N", "")
        {

        }

        public DDLColumn(string desc, string name, string type, int length) : this(desc, name, type, "N", "")
        {
            Length = length;
        }
    }


    public class DDLModel
    {
        private bool prepared = false;

        public enum DBType
        {
            Oracle, MySql
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
                table.DDLConfig = this;

                table.Columns.ForEach(x => { x.DDLTable = table; });

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (table.Columns[i].Validate() == false)
                    {
                        throw new Exception(String.Format("表：{0} 存在无效列", table.TableName));
                    }
                }



                if (table.Columns.FindAll(x => x.Validate()).ConvertAll<string>(x => x.Name).Distinct<string>().Count<string>()
                    != table.Columns.FindAll(x => x.Validate()).Count)
                {

                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        for (int j = i + 1; j < table.Columns.Count; j++)
                        {
                            if (table.Columns[i].Name == table.Columns[j].Name)
                            {
                                throw new Exception(String.Format("表：{0}存在重复列{1}", table.TableName, table.Columns[i].Name));
                            }
                        }
                       

                    }


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
                    x.SqlType = GetSqlDBType(x.TypeName, this.MyDBType, x.Length);
                    x.NameSql = DDLUtil.InferColName(x.Name, this.UnifyName, this.DBColSeparator);


                    if (this.MyDBType == DBType.Oracle)
                    {
                        x.NameSql = x.NameSql.ToUpper();
                        if (x.NameSql.Length > 30)
                        {
                            throw new Exception(String.Format("列名称：{0} {1}过长", table.TableName, x.NameSql));
                        }
                    }
                });
            }
            this.prepared = true;





        }

        private string GetSqlDBType(string type, DBType myDBType, int? length)
        {
            string longstr = null;

            int stringLength = length.HasValue ? length.Value : 100;

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

                    if (type.ToLower().Contains("varchar")
                        || type.ToLower().Contains("string")
                        )
                    {
                        return "varchar2(" + int.Parse(longstr ?? stringLength.ToString()) + " CHAR)";
                    }
                    if (type.ToLower().Contains("bigint"))
                    {
                        return "number(20,0)";
                    }
                    if (type.ToLower().Contains("bigint")
                        || type.ToLower().Contains("big int")
                        || type.ToLower().Contains("long"))
                    {
                        return "number(20,0)";
                    }

                    if (type.ToLower().Contains("decimal"))
                    {
                        return "number(20,2)";
                    }
                    if (type.ToLower().Contains("numeric"))
                    {
                        return "number(20,2)";
                    }


                    if (type.ToLower().Contains("int"))
                    {
                        return "number(" + (longstr ?? "10") + ")";
                    }
                    if (type.ToLower().Trim() == "text")
                    {
                        return "varchar2(2000 CHAR)";
                    }

                    throw new ArgumentException(type, nameof(type));

                case DBType.MySql:

                    if (type.ToLower().Contains("varchar")
                        || type.ToLower().Contains("string"))
                    {
                        return "varchar(" + int.Parse(longstr ?? stringLength.ToString()) + ")";
                    }
                    if (type.ToLower().Contains("bigint")
                        || type.ToLower().Contains("big int")
                        || type.ToLower().Contains("long"))
                    {
                        return "bigint(20)";
                    }
                    if (type.ToLower().Contains("int"))
                    {
                        return "integer(" + (longstr ?? "10") + ")";
                    }
                    if (type.ToLower().Trim() == "text")
                    {
                        return "text";
                    }

                    if (type.ToLower().Trim() == "mediumtext")
                    {
                        return "MEDIUMTEXT";
                    }
                    if (type.ToLower().Trim() == "longtext")
                    {
                        return "LONGTEXT";
                    }
                    if (type.ToLower().Trim() == "datetime")
                    {
                        return "datetime";
                    }
                    if (type.ToLower().Trim() == "decimal" || type.ToLower().Trim().Contains("金额"))
                    {
                        return "decimal(10,2)";
                    }


                    throw new ArgumentException(type, nameof(type));



                default:
                    throw new ArgumentException(myDBType.ToString(), nameof(myDBType));
            }
        }

        public List<DDLTable> Tables { get; set; } = new List<DDLTable>();

        public DBType MyDBType { get; set; } = DDLModel.DBType.Oracle;

        public string DBColSeparator { get; set; } = "_";

        /// <summary>
        /// names of field and db column are  same to ddl name。
        /// </summary>
        public bool UnifyName { get; set; } = false;


    }

}

using Org.FGQ.CodeGenerate.Util.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Org.FGQ.CodeGenerate.Model.DDL
{
 
    public class WareDDL
    {
        private bool prepared = false;

        public enum DBType
        {
            Oracle, MySql
        }

        public EntityTable GetTable(string tableName)
        {
            return EntityTables.Find(x => x.TableName == tableName);
        }

        public void Prepare()
        {
            if (this.prepared == true)
            {
                return;
            }

            foreach (var table in EntityTables)
            {
                table.DDLConfig = this;


                for (int i = 0; i < table.FieldColumns.Count; i++)
                {
                    if (table.FieldColumns[i].Validate() == false)
                    {
                        throw new Exception(String.Format("表：{0} 存在无效列", table.TableName));
                    }
                }



                if (table.FieldColumns.FindAll(x => x.Validate()).ConvertAll<string>(x => x.Name).Distinct<string>().Count<string>()
                    != table.FieldColumns.FindAll(x => x.Validate()).Count)
                {

                    for (int i = 0; i < table.FieldColumns.Count; i++)
                    {
                        for (int j = i + 1; j < table.FieldColumns.Count; j++)
                        {
                            if (table.FieldColumns[i].Name == table.FieldColumns[j].Name)
                            {
                                throw new Exception(String.Format("表：{0}存在重复列{1}", table.TableName, table.FieldColumns[i].Name));
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

                bool idexists = table.FieldColumns.Exists(x => x.Name.ToLower() == "id");

                if (false == idexists)
                {
                    if (false == table.HasKeyCol())
                    {
                        table.FieldColumns.Insert(0, new FieldColumn("ID", "id", "bigint(20)", "是", ""));
                    }
                    else
                    {
                        table.FieldColumns.Insert(0, new FieldColumn("ID", "id", "bigint(20)", "", ""));
                    }
                }
                table.FieldColumns.ForEach(x =>
                {
                    x.SqlType = GetSqlDBType(x.DataTypeDesc, this.MyDBType, x.Length);
                    x.NameSql = DDLUtil.InferColName(x.Name, this.UnifyName, this.DBColSeparator);


                    if (this.MyDBType == DBType.Oracle)
                    {
                        x.NameSql = x.NameSql.ToUpper();
                        if (x.NameSql.Length > 30)
                        {
                            throw new Exception(String.Format("列名称：{0} {1}过长", table.TableName, x.NameSql));
                        }
                    }

                    x.Table = table;
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

        public List<EntityTable> EntityTables { get; set; } = new List<EntityTable>();

        public DBType MyDBType { get; set; } = WareDDL.DBType.Oracle;

        public string DBColSeparator { get; set; } = "_";

        /// <summary>
        /// names of field and db column are  same to ddl name。
        /// </summary>
        public bool UnifyName { get; set; } = false;


    }

}

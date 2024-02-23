
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Org.FGQ.CodeGenerate.Engine
{
    internal class DBToDDLEngine : EngineBase
    {
        private GenerateConfig generateConfig;

        DBToDDLEngine(GenerateConfig generateConfig)
        {
            this.generateConfig = generateConfig ?? throw new ArgumentNullException(nameof(generateConfig));
        }

        internal void Generate()
        {
            DB db = LoadDBMeta();
            List<Table> tables = db.Tables.FindAll(x =>
            x.TableName.StartsWith(generateConfig.TableNameFilter) || Regex.IsMatch(x.TableName, generateConfig.TableNameFilter));
            if (tables.Count == 0)
            {
                return;
            }
            DDLModel ddlModel = new DDLModel();
            DDLTable newtable;
            DDLColumn ddlColumn;
            foreach (var table in tables)
            {
                newtable = new DDLTable(db.DBName, table.TableName, table.Comment);
                ddlModel.Tables.Add(newtable);
                foreach (var column in table.Columns)
                {
                    ddlColumn = new DDLColumn(column.Comment, column.ColName, column.ColumnType);
                    newtable.Columns.Add(ddlColumn);

                }
            }

            GenerateEngine.Do<Work, DDLTable>(new CodeGenerate.Model.Work() { ddlModel = ddlModel }, new SQLWorkPipe(""));





        }

        internal DB LoadDBMeta()
        {

            // https://learn.microsoft.com/zh-CN/dotnet/csharp/language-reference/preprocessor-directives
#if (NET)
            MySqlDBConfig mySqlDBConfig = generateConfig.dbConfig?.MySqlDBConfig ?? throw new ArgumentNullException(nameof(generateConfig.dbConfig));
#else
            MySqlDBConfig mySqlDBConfig = generateConfig.dbConfig?.MySqlDBConfig ?? throw new ArgumentNullException(nameof(generateConfig.dbConfig));
#endif



            MySqlUtil mySqlUtil = MySqlUtil.GetOne(mySqlDBConfig.Server, mySqlDBConfig.Port, mySqlDBConfig.UserId, mySqlDBConfig.Pwd);
            List<DB> dbs = mySqlUtil.LoadMeta();
            return dbs.Find(x => x.DBName == generateConfig.dbConfig.DataBaseName);
        }

        public override bool ValidateConfig()
        {
            if (GenerateMode.DBToCode != generateConfig.Mode)
            {
                Console.WriteLine("wrong mode!");
                return false;
            }

            return true;
        }
    }
}

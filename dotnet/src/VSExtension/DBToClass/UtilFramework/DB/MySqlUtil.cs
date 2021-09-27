using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Util.DB
{
    public class MySqlUtil
    {

        public string Server { get; private set; }
        public uint Port { get; private set; }
        public string UserId { get; private set; }
        public string Pwd { get; private set; }

        public string ConnectStr { get; private set; } = string.Empty;




        public static MySqlUtil GetOne(string server, uint port, string userId, string pwd)
        {

            return new MySqlUtil(server, port, userId, pwd);
        }

        protected MySqlUtil(string server, uint port, string userId, string pwd)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
            Port = port;
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Pwd = pwd ?? throw new ArgumentNullException(nameof(pwd));

            this.ConnectStr = GenConnectionStr(this.Server, this.Port, this.UserId, this.Pwd);
        }

        protected static string metaSql = @"

 select ta.TABLE_SCHEMA, ta.TABLE_NAME,co.COLUMN_NAME,co.DATA_TYPE,co.COLUMN_TYPE ,co.ORDINAL_POSITION,co.COLUMN_KEY,co.IS_NULLABLE,ta.TABLE_COMMENT,co.COLUMN_COMMENT
from TABLES ta
left join COLUMNS co on co.TABLE_SCHEMA = ta.TABLE_SCHEMA and co.TABLE_NAME=ta.TABLE_NAME
where ta.TABLE_SCHEMA not in (
    'information_schema',
    'mysql',
    'performance_schema',
    'sys'
)
order by ta.TABLE_SCHEMA,ta.TABLE_NAME,co.COLUMN_NAME,co.ORDINAL_POSITION
";


        public List<DB> LoadMeta()
        {

            List<DB> dbs = new List<DB>();


            DB currentDB = null;
            Table currentTable = null;

            using (var connection = new MySqlConnection(this.ConnectStr))
            {
                connection.Open();

                connection.ChangeDatabase("information_schema");

                using (var command = new MySqlCommand(metaSql, connection))
                using (var reader = command.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        string dbname = reader.GetString("TABLE_SCHEMA");
                        string tablename = reader.GetString("TABLE_NAME");
                        string tableComment = reader.GetString("TABLE_COMMENT");

                        if (currentDB == null || currentDB.DBName != dbname)
                        {
                            currentDB = new DB(dbname);
                            dbs.Add(currentDB);
                            currentTable = null;
                        }
                        if (currentTable == null || currentTable.TableName != tablename)
                        {
                            currentDB.Tables.Add(currentTable = new Table(tablename, tableComment));
                        }
                        currentTable.Columns.Add(new Column(
                            reader.GetString("COLUMN_NAME")
                            , reader.GetString("COLUMN_TYPE")
                            , reader.GetString("DATA_TYPE")
                            , CheckPriKey(reader.GetString("COLUMN_KEY"))
                            , CheckNullable(reader.GetString("IS_NULLABLE"))
                            , reader.GetInt32("ORDINAL_POSITION")
                            , AnalysisFieldType(reader.GetString("DATA_TYPE"), reader.GetString("COLUMN_TYPE"))
                            ,reader.GetString("COLUMN_COMMENT")
                            ));



                    }

                }


            }

            return dbs;



        }

        private bool CheckNullable(string v)
        {
            return string.IsNullOrEmpty(v) && v.ToUpper() == "YES";
        }

        private bool CheckPriKey(string v)
        {
            return string.IsNullOrEmpty(v) && v.ToUpper() == "PRI";
        }

        private FieldTypes AnalysisFieldType(string dataType, string columnType)
        {

            if (columnType.ToLower().IndexOf("int(1)") != -1)
            {
                return FieldTypes.Bool;
            }

            switch (dataType.ToLower())
            {
                case "char":
                case "blob":
                case "longtext":
                case "mediumblob":
                case "text":
                case "longblob":
                case "mediumtext":
                case "varchar":
                case "enum":
                    return FieldTypes.String;
                case "decimal":
                    return FieldTypes.Decimal;
                case "int":
                case "smallint":
                case "tinyint":
                    return FieldTypes.Int32;
                case "double":
                    return FieldTypes.Double;
                case "float":
                    return FieldTypes.Float;
                case "bigint":
                    return FieldTypes.Long;
                case "datetime":
                case "time":
                case "date":
                case "timestamp":
                    return FieldTypes.DateTime;

                default:
                    throw new ArgumentException(nameof(dataType) + ":" + dataType ?? "");
            }
        }

        public string GenConnectionStr(string server, uint port, string userId, string pwd)
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.UserID = userId;
            connectionStringBuilder.Password = pwd;
            connectionStringBuilder.Server = server;
            connectionStringBuilder.Port = port;

            return connectionStringBuilder.ConnectionString;

        }

        public bool ConnectTest(out string errorMsg)
        {
            return TestConnect(GenConnectionStr(this.Server, this.Port, this.UserId, this.Pwd), out errorMsg);
        }

        public bool TestConnect(string connstr, out string errorMsg)
        {
            using (var connection = new MySqlConnection(this.ConnectStr))
            {
                try
                {

                    connection.Open();
                    errorMsg = string.Empty;
                    return true;
                }
                catch (Exception e)
                {
                    errorMsg = e.ToString();
                    return false;
                }


            }


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Oracle.ManagedDataAccess.Client;

namespace Org.FGQ.CodeGenerate.Util.DB
{
    public class OracleUtil
    {

        protected static ILogger log = NLog.LogManager.GetCurrentClassLogger();


        public string Server { get; private set; }
        public uint Port { get; private set; }
        public string UserId { get; private set; }
        public string Pwd { get; private set; }



        public string ConnectStr { get; private set; } = string.Empty;


        public static OracleUtil GetOne(string server, uint port, string userId, string pwd)
        {

            return new OracleUtil(server, port, userId, pwd);
        }



        public OracleUtil(string server, uint port, string userId, string pwd)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
            Port = port;
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            Pwd = pwd ?? throw new ArgumentNullException(nameof(pwd));
            this.ConnectStr = GenConnectionStr();
        }

        protected string GenConnectionStr()
        {


            Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder connStrBuilder = new OracleConnectionStringBuilder();

            connStrBuilder.DataSource = Server + ":" + Port + @"/ORCL";

            connStrBuilder.UserID = UserId;
            connStrBuilder.Password = this.Pwd;

            log.Info(connStrBuilder.ConnectionString);
            return connStrBuilder.ConnectionString;


        }

        public bool ConnectTest(out string errorMsg)
        {
            return TestConnect(GenConnectionStr(), out errorMsg);
        }


        public bool TestConnect(string connstr, out string errorMsg)
        {

            using (var connection = new OracleConnection(this.ConnectStr))
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

        protected static string metaSql = @"
select c.TNAME,c.COLNO,c.CNAME,c.COLTYPE,c.WIDTH,c.SCALE,c.PRECISION,c.NULLS,CC.comments ,colc.constraint_type,utc.comments as tablecomment
from SYS.COL c left join all_col_comments cc on c.CNAME=cc.Column_name and c.TNAME=cc.table_name 

left join (
	select  col.table_name,col.column_name,con.constraint_type
	from  user_cons_columns col  
	inner join  user_constraints con on con.constraint_name=col.constraint_name and con.constraint_type='P'
) colc on colc.table_name=c.TNAME and colc.column_name=c.cname
left join user_tab_comments utc on utc.table_name=c.TNAME
where c.TNAME like '%tablePrefix%'
order by c.TNAME,c.COLNO asc
";


        public List<DB> LoadMeta(string tablePrefix, string dbName)
        {

            List<DB> dbs = new List<DB>();


            DB currentDB = null;
            Table currentTable = null;

            using (var connection = new OracleConnection(this.ConnectStr))
            {
                connection.Open();
                currentDB = new DB(dbName);
                dbs.Add(currentDB);

                //connection.ChangeDatabase("information_schema");
                metaSql = metaSql.Replace("tablePrefix", tablePrefix);
                log.Info(metaSql);

                using (var command = new OracleCommand(metaSql, connection))

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string tablename = reader.GetString(reader.GetOrdinal("TNAME"));
                        string tableComment = reader.GetString(reader.GetOrdinal("tablecomment"));


                        if (currentTable == null || currentTable.TableName != tablename)
                        {
                            currentDB.Tables.Add(currentTable = new Table(tablename, tableComment));
                        }

                        currentTable.Columns.Add(new Column(
                                                   reader.GetString(reader.GetOrdinal("CNAME"))
                                                   , reader.GetString(reader.GetOrdinal("COLTYPE"))
                                                   , reader.GetString(reader.GetOrdinal("COLTYPE"))
                                                   , CheckPriKey(reader.GetString(reader.GetOrdinal("constraint_type")))
                                                   , CheckNullable(reader.GetString(reader.GetOrdinal("NULLS")))
                                                   , reader.GetInt32(reader.GetOrdinal("COLNO"))
                                                   , AnalysisFieldType(reader.GetString(reader.GetOrdinal("COLTYPE")))
                                                  , reader.GetString(reader.GetOrdinal("comments"))
                                                   ));



                    }

                }


            }

            return dbs;



        }

        private FieldTypes AnalysisFieldType(string coltype)
        {
            return FieldTypes.Int32;
        }

        private bool CheckNullable(string v)
        {
            return false == v.ToLower().Contains("NOT".ToLower());
        }

        private bool CheckPriKey(string v)
        {
            return v.ToLower().Trim() == "p";
        }
    }
}

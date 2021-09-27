using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;
 

namespace UtilFrameworkUnitTest
{
    [TestClass]
    public class OracleUtilTest
    {
        private const int Port = 1521;
        private const string Server = "192.168.22.210";
        private const string UserId = "ODS_BMW_SPARK";
        private const string Pwd = "BMW_SPARK";
 


        [TestMethod]
        public void TestConnectTest()
        {

            OracleUtil oracleUtil = OracleUtil.GetOne(Server, Port, UserId, Pwd);
            string errmsg = "";
            Console.WriteLine(oracleUtil.ConnectStr);
            bool condition = oracleUtil.ConnectTest(out errmsg);
            Console.WriteLine(errmsg);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void TestLoadMeta()
        {
            OracleUtil util = OracleUtil.GetOne(Server, Port, UserId, Pwd);

            List<DB> dbs = util.LoadMeta("ODS","");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dbs, Newtonsoft.Json.Formatting.Indented));
            Assert.IsTrue(true);

        }




    }
}

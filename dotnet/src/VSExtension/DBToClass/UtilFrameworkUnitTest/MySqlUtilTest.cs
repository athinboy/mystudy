using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UtilFramework;

namespace UtilFrameworkUnitTest
{
    [TestClass]
    public class MySqlUtilTest
    {
        private const int Port = 3306;
        private const string Server = "localhost";
        private const string UserId = "root";
        private const string Pwd = "123";

        [TestMethod]
        public void TestMethod1()
        {

            MySqlUtil mySqlUtil = MySqlUtil.GetOne(Server, Port, UserId, Pwd);
            string errmsg = "";
            Console.WriteLine(mySqlUtil.ConnectStr);
            bool condition = mySqlUtil.TestConnect(out errmsg);
            Console.WriteLine(errmsg);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void TestMethod2()
        {

            MySqlUtil mySqlUtil = MySqlUtil.GetOne(Server, Port, UserId, Pwd);

            List<DB> dbs = mySqlUtil.LoadMeta();
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dbs));
        }




    }
}

﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;
 

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
        public void TestConnectTest()
        {

            MySqlUtil mySqlUtil = MySqlUtil.GetOne(Server, Port, UserId, Pwd);
            string errmsg = "";
            Console.WriteLine(mySqlUtil.ConnectStr);
            bool condition = mySqlUtil.ConnectTest(out errmsg);
            Console.WriteLine(errmsg);
            Assert.IsTrue(condition);
        }

        [TestMethod]
        public void TestLoadMeta()
        {

            MySqlUtil mySqlUtil = MySqlUtil.GetOne(Server, Port, UserId, Pwd);

            List<DB> dbs = mySqlUtil.LoadMeta();
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dbs,Newtonsoft.Json.Formatting.Indented));
            Assert.IsTrue(true);
        }




    }
}

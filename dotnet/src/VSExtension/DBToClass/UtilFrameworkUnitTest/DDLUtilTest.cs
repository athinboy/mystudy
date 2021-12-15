using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;


namespace UtilFrameworkUnitTest
{
    [TestClass]
    public class DDLUtilTest
    {


        [TestMethod]
        public void InferColNameTest()
        {

            string result;
            Assert.IsTrue((result = Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("User_Name", false, "_")) == "User_Name");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("user_name", false, "_")) == "user_name");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("userName", false, "_")) == "user_name");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("UserName", false, "_")) == "user_name");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("Urlabc", false, "_")) == "urlabc");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("webUrl", false, "_")) == "web_url");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("abcABCName", false, "_")) == "abc_ABC_name");
            Console.WriteLine(result);
            Assert.IsTrue((result =Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("abcABC", false, "_")) == "abc_ABC");
            Console.WriteLine(result);
            Assert.IsTrue((result = Org.FGQ.CodeGenerate.Util.Util.DDLUtil.InferColName("ABC", false, "_")) == "ABC");
            Console.WriteLine(result);
        }





    }
}

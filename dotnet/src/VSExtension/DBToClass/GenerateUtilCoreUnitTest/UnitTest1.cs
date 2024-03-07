using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Xunit;

namespace Org.FGQ.CodeGenerateTest
{
    [TestClass]
    public class UnitTest1
    {

        MysqlConfig mysqlConfig = new MysqlConfig();
        System.IO.StringReader consoleInput = new System.IO.StringReader("");

        [SetUp]
        public void Init()
        {
            Console.SetIn(consoleInput);             
        }



        [Test]
        public void Test1()
        {
            string[] args = new string[] { "-c", @"config\conf.json" };
            Org.FGQ.CodeGenerate.Program.Main(args);          
            Console.WriteLine("");

        }
    }
}

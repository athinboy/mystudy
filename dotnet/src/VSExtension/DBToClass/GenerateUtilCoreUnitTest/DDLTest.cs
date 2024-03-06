﻿using Org.FGQ.CodeGenerate.Config;
using NUnit.Framework;
using System;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Work;
using Org.FGQ.CodeGenerate.Generator;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTest
    {


        DDLModel ddlModel;
        CSharpBeanModel beanConfig;


        [SetUp]
        public void Init()
        {
            ddlModel = new DDLModel();
            ddlModel.MyDBType = DDLModel.DBType.MySql;



            DDLTable newtable;
            DDLColumn column;

            ddlModel.Tables.Add(newtable = new DDLTable("base_info", "wx_user", "微信用户"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "Y", ""));
            newtable.Columns.Add(column = new DDLColumn("unionid", "unionid", "varchar(255)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));



        }


        [Test]
        public void DDLToSQLTest()
        {

            const string outputpath = @"c:\1\2.txt";
            GenerateGenerator.Do<Work, DDLTable>(new CodeGenerate.Work.Work() { ddlModel = ddlModel }, new SQLWorkPipe(outputpath));


        }


        [Test]
        public void DDLToCSharpAll()
        {

            beanConfig = new CSharpBeanModel();
            beanConfig.DDLConfig = ddlModel;
            beanConfig.NamespaceName = "com.wintop.third.bmwspark.bean";

            beanConfig.CodeDiretory = @"D:\fgq\temp\codegeneratetest\bean\third-bmwspark-bean\src\main\java";
            beanConfig.OmmitPrefix = "ODS";

            CSharpGenerator cSharpGenerator = new CSharpGenerator();
            cSharpGenerator.GenerateBean(beanConfig);


        }
        [Test]
        public void DBToCSharpAll()
        {
            GenerateConfig generateConfig = new GenerateConfig();
        
            generateConfig.codeConfig.CSharpConfig = new CSharpConfig
            {
                NamespacePathLowerCase = true,
                NamespacePathOmmit = ""
            };

            generateConfig.dbConfig.MySqlDBConfig = new MySqlDBConfig
            {
                Port = 3306,
                Pwd = "123",
                UserId = "root",
                Server = "localhost"
            };

            generateConfig.codeConfig = new CodeConfig();
            CSharpConfig cSharpConfig = (generateConfig.codeConfig.CSharpConfig = new CSharpConfig());
            cSharpConfig.NamespacePathLowerCase = true;
            cSharpConfig.NamespaceName = "Org.Fgq.Code";



            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(generateConfig, Newtonsoft.Json.Formatting.Indented));

            Assert.IsTrue(true);



        }

    }
}

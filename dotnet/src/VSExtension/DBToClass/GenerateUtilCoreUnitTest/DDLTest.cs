using Org.FGQ.CodeGenerate.Config;
using NUnit.Framework;
using System;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Work;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Dispatch;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;


namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTest
    {


        WareDDL ddlModel;
        CSharpBeanModel beanConfig;


        [SetUp]
        public void Init()
        {
            WareDDL ddl = new WareDDL();
            ddlModel.MyDBType = WareDDL.DBType.MySql;


            EntityTable newtable;
            FieldColumn column;

            ddlModel.Tables.Add(newtable = new EntityTable("base_info", "wx_user", "微信用户"));
            newtable.Columns.Add(new FieldColumn("id", "id", "varchar(64)", "Y", ""));
            newtable.Columns.Add(column = new FieldColumn("unionid", "unionid", "varchar(255)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new FieldColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.Columns.Add(new FieldColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));



        }


        [Test]
        public void DDLToSQLTest()
        {

            const string outputpath = @"c:\1\2.txt";
            DefaultDispatch.DispathWork(new CodeGenerate.Work.Work(null)
            {
                DDLModel = ddlModel,
                OutPipes = { new SQLWorkPipe(outputpath) }
            });


        }


        [Test]
        public void DDLToCSharpAll()
        {

            beanConfig = new CSharpBeanModel();
            beanConfig.DDL = ddlModel;
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

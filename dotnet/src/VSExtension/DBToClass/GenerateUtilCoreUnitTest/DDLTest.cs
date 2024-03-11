using NUnit.Framework;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Dispatch;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using System;


namespace Org.FGQ.CodeGenerateTest
{




	public class DDLTest
    {


        WareDDL ddlModel;
        CSharpBeanModel beanConfig;


        [SetUp]
        public void Init()
        {
            ddlModel = new WareDDL();
            ddlModel.MyDBType = WareDDL.DBType.MySql;


            EntityTable newtable;
            FieldColumn column;

            ddlModel.EntityTables.Add(newtable = new EntityTable("base_info", "wx_user", "微信用户"));
            newtable.FieldColumns.Add(new FieldColumn("id", "id", "varchar(64)", "Y", ""));
            newtable.FieldColumns.Add(column = new FieldColumn("unionid", "unionid", "varchar(255)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.FieldColumns.Add(new FieldColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.FieldColumns.Add(new FieldColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));



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


    }
}

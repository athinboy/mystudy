
using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.Config;
using NUnit;
using static Org.FGQ.CodeGenerate.Config.DDLModel;
using NUnit.Framework;
using System;
using Org.FGQ.CodeGenerate.Engine;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Model;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTest
    {


        DDLModel ddlModel;
        CSharpBeanConfig beanConfig;


        [SetUp]
        public void Init()
        {
            ddlModel = new DDLModel();
            ddlModel.MyDBType = DDLModel.DBType.MySql;



            DDLTable newtable;
            DDLColumn column;

            ddlModel.Tables.Add(newtable = new DDLTable("base_info", "wx_user", "微信用户"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "Y", ""));
            newtable.Columns.Add(column=new DDLColumn("unionid", "unionid", "varchar(255)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));



        }


        [Test]
        public void DDLToSQLTest()
        {             

            const string outputpath = @"c:\1\2.txt";
            GenerateEngine.Do<Work,Work>(new CodeGenerate.Model.Work() { ddlModel = ddlModel }, new SQLWorkPipe(outputpath));             


        }


        [Test]
        public void DDLToCSharpAll()
        {

            beanConfig = new CSharpBeanConfig();
            beanConfig.DDLConfig = ddlModel;
            beanConfig.NamespaceName = "com.wintop.third.bmwspark.bean";
            beanConfig.NamespacePath = "";
            beanConfig.CodeDiretory = @"D:\fgq\temp\codegeneratetest\bean\third-bmwspark-bean\src\main\java";
            beanConfig.OmmitPrefix = "ODS";

            CSharpGenerator cSharpGenerator = new CSharpGenerator();
            cSharpGenerator.GenerateBean(beanConfig);
             




        }


    }
}

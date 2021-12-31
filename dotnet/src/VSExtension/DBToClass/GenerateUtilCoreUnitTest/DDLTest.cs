
using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.Config;
using NUnit;
using static Org.FGQ.CodeGenerate.Config.DDLConfig;
using NUnit.Framework;
using System;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTest
    {


        DDLConfig ddlConfig;
        CSharpBeanConfig beanConfig;


        [SetUp]
        public void Init()
        {
            ddlConfig = new DDLConfig();
            ddlConfig.MyDBType = DDLConfig.DBType.MySql;



            DDLTable newtable;
            DDLColumn column;

            ddlConfig.Tables.Add(newtable = new DDLTable("base_info", "wx_user", "微信用户"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "Y", ""));
            newtable.Columns.Add(column=new DDLColumn("unionid", "unionid", "varchar(255)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));



        }


        [Test]
        public void DDLToSQLTest()
        {

            DDLToSQL toSQL = new DDLToSQL();
            toSQL.GenerateSql(ddlConfig, @"c:\1\2.txt");


        }


        [Test]
        public void DDLToCSharpAll()
        {

            beanConfig = new CSharpBeanConfig();
            beanConfig.DDLConfig = ddlConfig;
            beanConfig.NamespaceName = "com.wintop.third.bmwspark.bean";
            beanConfig.NamespacePath = "";
            beanConfig.CodeDiretory = @"D:\fgq\work\code\wintop-third-eas\bean\third-bmwspark-bean\src\main\java";
            beanConfig.OmmitPrefix = "ODS";

            CSharpGenerator cSharpGenerator = new CSharpGenerator();
            cSharpGenerator.GenerateBean(beanConfig);
             




        }


    }
}

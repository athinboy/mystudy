
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
        JavaBeanConfig javaBeanConfig;




        [SetUp]
        public void Init()
        {
            ddlConfig = new DDLConfig();
            ddlConfig.MyDBType = DDLConfig.DBType.MySql;



            DDLTable newtable;
            DDLColumn column;

            ddlConfig.Tables.Add(newtable = new DDLTable("WeiXin", "wx_user", "微信用户"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("unionid", "unionid", "varchar(255)", "Y", ""));
            newtable.Columns.Add(new DDLColumn("用户昵称", "nickName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("用户头像图片的 URL", "avatarUrl", "varchar(500)", "", ""));





        }


        [Test]
        public void DDLToSQLTest()
        {

            DDLToSQL toSQL = new DDLToSQL();
            toSQL.GenerateSql(ddlConfig, @"c:\1\2.txt");


        }


        //[Test]
        public void DDLToJavaBeanTest()
        {

            javaBeanConfig = new JavaBeanConfig();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.bmwspark.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.bmwspark.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\bean\third-bmwspark-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            JavaGenerator toJavaBean = new JavaGenerator();
            toJavaBean.GenerateBean(javaBeanConfig);

        }

        //[Test]
        public void DDLToJavaAll()
        {

            javaBeanConfig = new JavaBeanConfig();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.bmwspark.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.bmwspark.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\bean\third-bmwspark-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            JavaGenerator javaGenerator = new JavaGenerator();
            javaGenerator.GenerateBean(javaBeanConfig);

            JavaDaoConfig javaDaoConfig = new JavaDaoConfig(null);

            javaDaoConfig.PackageName = "com.wintop.third.bmwspark.mapper";
            javaDaoConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\dao\third-bmwspark-dao\src\main\java";


            JavaMapperConfig javaMapperConfig = new JavaMapperConfig(javaDaoConfig);
            javaMapperConfig.MapperDirectory = @"D:\fgq\work\code\wintop-third-eas\dao\third-bmwspark-dao\src\main\resources\mybatis\mapper";

            JavaCodeConfig javaCodeConfig = new JavaCodeConfig(javaDaoConfig);

            javaCodeConfig.ModelPackageName = "com.wintop.third.bmwspark.model";
            javaCodeConfig.ModelJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ServicePackageName = "com.wintop.third.bmwspark.service";
            javaCodeConfig.ServiceJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ServiceImplPackageName = "com.wintop.third.bmwspark.service.impl";
            javaCodeConfig.ServiceImplJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ControllerPackageName = "com.wintop.third.bmwspark.controller";
            javaCodeConfig.ControllerJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-bmwspark-service-api\src\main\java";



            ddlConfig.Tables.ForEach(t =>
            {
                javaDaoConfig.JavaClass = t.CreatedJavaBean;
                javaGenerator.GenerateDao(javaDaoConfig, javaMapperConfig);

                javaGenerator.GenerateCode(javaCodeConfig, t.CreatedJavaBean);

            });




        }


    }
}

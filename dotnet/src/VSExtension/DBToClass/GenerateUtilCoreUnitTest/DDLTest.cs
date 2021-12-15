
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
            ddlConfig.MyDBType = DDLConfig.DBType.Oracle;



            DDLTable newtable;
            DDLColumn column;

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_JSXL_REPORT", "26.AS103011005-同步技师效率信息-报告"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "是", "")); 
            newtable.Columns.Add(new DDLColumn("owner_name", "owner_name", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("create_time", "create_time", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("owner_code", "owner_code", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("begin", "begin", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("end", "end", "varchar(100)", "", ""));
 






        }


        [Test]
        public void DDLToSQLTest()
        {

            DDLToSQL toSQL = new DDLToSQL();
            toSQL.GenerateSql(ddlConfig, @"c:\1\2.txt");


        }


        [Test]
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








        [Test]
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


using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.Config;
using NUnit;
using static Org.FGQ.CodeGenerate.Config.DDLConfig;
using NUnit.Framework;
using System;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTestCBS
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

            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_invoke_log", "调用日志"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("url", "url", "varchar(1000)", "", ""));
            newtable.Columns.Add(new DDLColumn("方向:in、out", "direction", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("日志类型", "data_type", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("data1", "data1", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("data2", "data2", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("请求信息", "request_data", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("响应信息", "response_data", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("错误信息", "err_msg", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("请求时间", "request_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("响应时间", "response_time", "datetime", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_base_report", "基础版报告"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("车辆识别码", "vin", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licenseplate", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("中介ID", "middleagentid", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机号", "enginno", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶证照片链接", "drivingpic", "varchar(100)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("orderId", "orderId", "varchar(100)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("购买调用Id", "buy_invoke_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("wap端报告url", "wap_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端报告url", "pc_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端New报告url", "pc_new_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告", "jsorn_report", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告_invoke_id", "jsorn_report_invoke_id", "bigint", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_new_report", "综合版报告"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("车辆识别码", "vin", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licenseplate", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机号", "Enginno", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶证照片链接", "drivingpic", "varchar(100)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("orderId", "orderId", "varchar(100)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("购买调用Id", "buy_invoke_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("wap端报告url", "wap_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端报告url", "pc_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端New报告url", "pc_new_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告", "jsorn_report", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告_invoke_id", "jsorn_report_invoke_id", "bigint", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_collision_report", "碰撞版报告"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("车辆识别码", "vin", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licenseplate", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机号", "Enginno", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶证照片链接", "drivingpic", "varchar(100)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("orderId", "orderId", "varchar(100)", "", ""));
            column.UniqueKeySign = "Y";
            newtable.Columns.Add(new DDLColumn("购买调用Id", "buy_invoke_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("wap端报告url", "wap_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端报告url", "pc_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端New报告url", "pc_new_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告", "jsorn_report", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告_invoke_id", "jsorn_report_invoke_id", "bigint", "", ""));













        }


        [Test]
        public void DDLToSQLTest()
        {

            DDLToSQL toSQL = new DDLToSQL();
            toSQL.GenerateSql(ddlConfig, @"c:\1\" + DateTime.Now.ToLongDateString() + ".txt");
        }


        [Test]
        public void DDLToJavaBeanTest()
        {

            javaBeanConfig = new JavaBeanConfig();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.cbs.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.cbs.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\bean\third-cbs-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            JavaGenerator toJavaBean = new JavaGenerator();
            toJavaBean.GenerateBean(javaBeanConfig);

        }








        [Test]
        public void DDLToJavaAll()
        {

            javaBeanConfig = new JavaBeanConfig();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.cbs.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.cbs.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\bean\third-cbs-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            JavaGenerator javaGenerator = new JavaGenerator();
            javaGenerator.GenerateBean(javaBeanConfig);

            JavaDaoConfig javaDaoConfig = new JavaDaoConfig(null);

            javaDaoConfig.PackageName = "com.wintop.third.cbs.mapper";
            javaDaoConfig.JavaDiretory = @"D:\fgq\work\code\wintop-third-eas\dao\third-cbs-dao\src\main\java";


            JavaMapperConfig javaMapperConfig = new JavaMapperConfig(javaDaoConfig);
            javaMapperConfig.MapperDirectory = @"D:\fgq\work\code\wintop-third-eas\dao\third-cbs-dao\src\main\resources\mybatis\mapper";

            JavaCodeConfig javaCodeConfig = new JavaCodeConfig(javaDaoConfig);

            javaCodeConfig.ModelPackageName = "com.wintop.third.cbs.model";
            javaCodeConfig.ModelJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-cbs-service-api\src\main\java";

            javaCodeConfig.ServicePackageName = "com.wintop.third.cbs.service";
            javaCodeConfig.ServiceJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-cbs-service-api\src\main\java";

            javaCodeConfig.ServiceImplPackageName = "com.wintop.third.cbs.service.impl";
            javaCodeConfig.ServiceImplJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-cbs-service-api\src\main\java";

            javaCodeConfig.ControllerPackageName = "com.wintop.third.cbs.controller";
            javaCodeConfig.ControllerJavaDiretory = @"D:\fgq\work\code\wintop-third-eas\third-cbs-service-api\src\main\java";



            ddlConfig.Tables.ForEach(t =>
            {
                javaDaoConfig.JavaClass = t.CreatedJavaBean;
                javaGenerator.GenerateDao(javaDaoConfig, javaMapperConfig);

                javaGenerator.GenerateCode(javaCodeConfig, t.CreatedJavaBean);

            });




        }


    }
}

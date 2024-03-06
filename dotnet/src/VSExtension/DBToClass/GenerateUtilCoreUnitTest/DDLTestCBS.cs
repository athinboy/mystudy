
using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.Config;
using NUnit;
using static Org.FGQ.CodeGenerate.Config.DDLModel;
using NUnit.Framework;
using System;
using Org.FGQ.CodeGenerate.Engine;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Util.Code;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTestCBS
    {


        DDLModel ddlConfig;
        JavaBeanModel javaBeanConfig;

        public void B()
        {

            DDLTable newtable;
            DDLColumn column;

            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_invoke_log", "调用日志"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("url", "url", "varchar(1000)", "", ""));
            newtable.Columns.Add(new DDLColumn("方向:in、out", "direction", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("日志类型", "data_type", "varchar(50)", "", ""));
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
            newtable.Columns.Add(new DDLColumn("创建人", "cre_person", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "cre_person_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "cre_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("修改日期", "modify_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺", "service_network_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺姓名", "service_network_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态", "query_status", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态code", "query_status_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态message", "query_status_msg", "varchar(200)", "", ""));




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
            newtable.Columns.Add(new DDLColumn("创建人", "cre_person", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "cre_person_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "cre_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("修改日期", "modify_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺", "service_network_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺姓名", "service_network_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态", "query_status", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态code", "query_status_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态message", "query_status_msg", "varchar(200)", "", ""));



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
            newtable.Columns.Add(new DDLColumn("创建人", "cre_person", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "cre_person_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "cre_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("修改日期", "modify_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺", "service_network_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺姓名", "service_network_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态", "query_status", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态code", "query_status_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态message", "query_status_msg", "varchar(200)", "", ""));


        }


        private void c()
        {

            DDLTable newtable;
            DDLColumn column;
            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_eval_info", "evaluationInfo"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("新车指导价", "sellPrice", "金额"));
            newtable.Columns.Add(new DDLColumn("车商收购价", "dealerBuyPrice", "String"));
            newtable.Columns.Add(new DDLColumn("车商收购中间价", "dealerBuyPriceMin", "String"));
            newtable.Columns.Add(new DDLColumn("车商收购最高价", "dealerBuyPriceMax", "String"));
            newtable.Columns.Add(new DDLColumn("个人卖车价", "personSoldPrice", "String"));
            newtable.Columns.Add(new DDLColumn("个人卖车中间价", "personSoldPriceMin", "String"));
            newtable.Columns.Add(new DDLColumn("个人卖车最高价", "personSoldPriceMax", "String"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_basic_info", "basicInfo"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("vin 码", "vin", "String"));
            newtable.Columns.Add(new DDLColumn("车辆评级", "carLevel", "String"));
            newtable.Columns.Add(new DDLColumn("车型", "modelName", "String"));
            newtable.Columns.Add(new DDLColumn("上牌年份", "plateYear", "String"));
            newtable.Columns.Add(new DDLColumn("表显里程(单位/万公里)", "watchMile", "Int"));
            newtable.Columns.Add(new DDLColumn("车牌号", "carNo", "String"));
            newtable.Columns.Add(new DDLColumn("对应的 58 品牌车系车型和颜色", "extend", "String"));
            newtable.Columns.Add(new DDLColumn("检测师总评", "evaluateContent", "String"));
            newtable.Columns.Add(new DDLColumn("发动机号", "engineNo", "String"));
            newtable.Columns.Add(new DDLColumn("维保报告链接地址", "reportUrl", "String"));
            newtable.Columns.Add(new DDLColumn("承保开始时间", "acceptInsuranceStartTime", "String"));
            newtable.Columns.Add(new DDLColumn("承保结束时间", "acceptInsuranceEndTime", "String"));
            newtable.Columns.Add(new DDLColumn("是否承保 1是 0否", "isAcceptInsurance", "Integer"));
            newtable.Columns.Add(new DDLColumn("重要车况评分", "carScore", "String"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_car_config", "carConfig"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("年检期限", "annualInspectionDate", "String"));
            newtable.Columns.Add(new DDLColumn("车辆性质", "carProperty", "String"));
            newtable.Columns.Add(new DDLColumn("车型（如两厢、 三厢）", "carType", "String"));
            newtable.Columns.Add(new DDLColumn("过户次数", "dealNum", "int"));
            newtable.Columns.Add(new DDLColumn("排放标准", "emissionStandard", "String"));
            newtable.Columns.Add(new DDLColumn("发动机缸数", "engineBlocks", "int"));
            newtable.Columns.Add(new DDLColumn("发动机位置： 横置， 纵置", "enginePosition", "String"));
            newtable.Columns.Add(new DDLColumn("发动机类型： 直列， v 型， 水平， 其他）", "engineType", "String"));
            newtable.Columns.Add(new DDLColumn("初登日期", "firstRegDate", "String"));
            newtable.Columns.Add(new DDLColumn("强制报废日期", "forceScrapDate", "String"));
            newtable.Columns.Add(new DDLColumn("燃料类型", "fuelType", "String"));
            newtable.Columns.Add(new DDLColumn("变速箱类型", "gearBox", "String"));
            newtable.Columns.Add(new DDLColumn("内饰颜色", "inColor", "String"));
            newtable.Columns.Add(new DDLColumn("出厂日期", "manufactureDate", "String"));
            newtable.Columns.Add(new DDLColumn("铭牌 ： 正常， 无， 破损， 更换", "nameplate", "String"));
            newtable.Columns.Add(new DDLColumn("外观颜色", "outColor", "String"));
            newtable.Columns.Add(new DDLColumn("车主性质： 公车； 私车", "ownerProperty", "String"));
            newtable.Columns.Add(new DDLColumn("车牌归属地城市", "plateCity", "String"));
            newtable.Columns.Add(new DDLColumn("钢印状态： 完整 ， 损坏", "steelVin", "String"));
            newtable.Columns.Add(new DDLColumn("排量", "sweptVolume", "String"));
            newtable.Columns.Add(new DDLColumn("保险期限", "warrantyDate", "String"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_order_info", "orderInfo"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("下单检测地址", "address", "String"));
            newtable.Columns.Add(new DDLColumn("检测师姓名", "checkName", "String"));
            newtable.Columns.Add(new DDLColumn("检测开始时间", "startTime", "String"));
            newtable.Columns.Add(new DDLColumn("检测结束时间", "finishTime", "Int"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_accidents", "accidents"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("事故 1是 0否", "sg", "Int"));
            newtable.Columns.Add(new DDLColumn("火烧 1是 0否", "hs", "Int"));
            newtable.Columns.Add(new DDLColumn("水泡 1是 0否", "sp", "Int"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_data", "data"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("部件 ID", "componmentId", "Int"));
            //newtable.Columns.Add(new DDLColumn("部件的具体描述(详见 descs 说明)", "descs", "List"));
            newtable.Columns.Add(new DDLColumn("分组 ID", "cbs_id", "int"));
            newtable.Columns.Add(new DDLColumn("部件名称", "nameComponment", "String"));
            newtable.Columns.Add(new DDLColumn("分组名称", "nameGroup", "String"));
            newtable.Columns.Add(new DDLColumn("图片地址多个地址逗号分割", "picture", "String"));
            newtable.Columns.Add(new DDLColumn("一级系统名称", "firstSysName", "String"));
            newtable.Columns.Add(new DDLColumn("二级系统名称", "secondSysName", "String"));
            newtable.Columns.Add(new DDLColumn("数据类型 0:漆膜数据 2:部件描述和照片", "type", "int"));
            newtable.Columns.Add(new DDLColumn("漆膜数据,list<string>的json字符串", "qmInfos", "text"));//list<string>的json字符串



            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_ins_report_descs", "descs"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("报告id", "insurance_report_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("report_data_id", "report_data_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("描述", "description", "String"));
            newtable.Columns.Add(new DDLColumn("详见 descs 说明", "descriptionList", "text"));
        }


        private void D()
        {

            DDLTable newtable;
            DDLColumn column;




            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_cbs_city", "查博士城市"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("城市名称", "city", "String"));
            newtable.Columns.Add(new DDLColumn("城市编号", "cityId", "int"));
            newtable.Columns.Add(new DDLColumn("顺序号", "cbs_id", "int"));
            newtable.Columns.Add(new DDLColumn("省份名称", "province", "String"));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_insurance_report", "查博士交通费版"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("姓名", "name", "String"));
            newtable.Columns.Add(new DDLColumn("手机号", "phone", "String"));
            newtable.Columns.Add(new DDLColumn("城市 ID(通过接口获取)", "cityid", "String"));
            newtable.Columns.Add(new DDLColumn("检测地址", "address", "String"));
            newtable.Columns.Add(new DDLColumn("回调地址", "callbackurl", "String"));
            newtable.Columns.Add(new DDLColumn("产品SKU", "skuno", "String"));
            newtable.Columns.Add(new DDLColumn("车辆 vin 码", "vin", "String"));
            newtable.Columns.Add(new DDLColumn("车牌号", "carno", "String"));
            newtable.Columns.Add(new DDLColumn("期望检测时间(“2019-08-17”)", "expecttime", "String"));
            newtable.Columns.Add(new DDLColumn("经度", "longitude", "String"));
            newtable.Columns.Add(new DDLColumn("纬度", "latitude", "String"));
            newtable.Columns.Add(new DDLColumn("交通费金额", "travelcost", "金额"));
            newtable.Columns.Add(new DDLColumn("第三方订单号", "thirdpartorderid", "String"));
            newtable.Columns.Add(column = new DDLColumn("orderId", "orderId", "varchar(100)", "", ""));
            column.UniqueKeySign = "Y";
            column.UniqueForDB = false;
            newtable.Columns.Add(new DDLColumn("购买调用Id", "buy_invoke_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("wap端报告url", "wap_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("PC端报告url", "pc_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("报告url", "insurance_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("抖音报告url", "tiktok_report_url", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告", "jsorn_report", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("json报告_invoke_id", "jsorn_report_invoke_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "cre_person", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "cre_person_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "cre_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("修改日期", "modify_time", "datetime", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺", "service_network_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("店铺姓名", "service_network_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态", "query_status", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态code", "query_status_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("查询状态message", "query_status_msg", "varchar(200)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_skuno", "查博士skuNO"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("code", "code", "String", 20));
            newtable.Columns.Add(new DDLColumn("skuno", "skuno", "string", 200));
            newtable.Columns.Add(new DDLColumn("说明", "name", "string"));
            newtable.Columns.Add(new DDLColumn("启用标志，1：启用 0：禁用", "enable_flag", "int", 3));
        }


        [SetUp]
        public void Init()
        {
            ddlConfig = new DDLModel();
            ddlConfig.MyDBType = DDLModel.DBType.MySql;


            DDLTable newtable;
            DDLColumn column;




            ddlConfig.Tables.Add(newtable = new DDLTable("wintop_cbs", "cbs_callback", "查博士回调"));
            newtable.Columns.Add(new DDLColumn("id", "id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("单据类型", "order_type", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("调用记录", "invoke_log_id", "bigint", "", ""));
            newtable.Columns.Add(new DDLColumn("orderId", "order_id", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("结果码", "result", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("结果描述", "message", "varchar(500)", "", ""));
            newtable.Columns.Add(new DDLColumn("退款方式", "refund_type", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "cre_time", "datetime", "", ""));


        }


        [Test]
        public void DDLToSQLTest()
        {

 
              string outputpath = @"c:\1\" + DateTime.Now.ToLongDateString() + ".txt";
            GenerateEngine.Do(new CodeGenerate.Work.Work() { ddlModel = ddlConfig }, new SQLWorkPipe(outputpath));
        }


        [Test]
        public void DDLToJavaBeanTest()
        {

            javaBeanConfig = new JavaBeanModel();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.cbs.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.cbs.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\bean\third-cbs-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            //JavaGenerator toJavaBean = new JavaGenerator();
            //toJavaBean.GenerateBean(javaBeanConfig);

            GenerateEngine.Do<JavaWorkModel, JavaClass>(new JavaWorkModel() { BeanConfig = javaBeanConfig }, new CodeGenerate.Pipe.Java.JavaBeanPipe());

        }








        //[Test]
        //public void DDLToJavaAll()
        //{

        //    javaBeanConfig = new JavaBeanConfig();
        //    javaBeanConfig.DDLConfig = ddlConfig;
        //    javaBeanConfig.PackageName = "com.wintop.third.cbs.bean";
        //    javaBeanConfig.VOPackageName = "com.wintop.third.cbs.vo";
        //    javaBeanConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\bean\third-cbs-bean\src\main\java";
        //    javaBeanConfig.OmmitPrefix = "ODS";

        //    JavaGenerator javaGenerator = new JavaGenerator();
        //    javaGenerator.GenerateBean(javaBeanConfig);

        //    JavaDaoConfig javaDaoConfig = new JavaDaoConfig(null);

        //    javaDaoConfig.PackageName = "com.wintop.third.cbs.mapper";
        //    javaDaoConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\dao\third-cbs-dao\src\main\java";


        //    JavaMapperConfig javaMapperConfig = new JavaMapperConfig(javaDaoConfig);
        //    javaMapperConfig.MapperDirectory = @"D:\fgq\temp\codegeneratetest\dao\third-cbs-dao\src\main\resources\mybatis\mapper";

        //    JavaCodeConfig javaCodeConfig = new JavaCodeConfig(javaDaoConfig);

        //    javaCodeConfig.ModelPackageName = "com.wintop.third.cbs.model";
        //    javaCodeConfig.ModelJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-cbs-service-api\src\main\java";

        //    javaCodeConfig.ServicePackageName = "com.wintop.third.cbs.service";
        //    javaCodeConfig.ServiceJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-cbs-service-api\src\main\java";

        //    javaCodeConfig.ServiceImplPackageName = "com.wintop.third.cbs.service.impl";
        //    javaCodeConfig.ServiceImplJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-cbs-service-api\src\main\java";

        //    javaCodeConfig.ControllerPackageName = "com.wintop.third.cbs.controller";
        //    javaCodeConfig.ControllerJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-cbs-service-api\src\main\java";

        //    javaCodeConfig.GeneralController = true;
        //    javaCodeConfig.GeneralService = true;
        //    javaCodeConfig.GeneralServiceImpl = true;
        //    javaCodeConfig.GeneralModel = true;


        //    ddlConfig.Tables.ForEach(t =>
        //    {
        //        javaDaoConfig.JavaClass = t.CreatedClass;
        //        javaGenerator.GenerateDao(javaDaoConfig, javaMapperConfig);

        //        javaGenerator.GenerateCode(javaCodeConfig, t.CreatedClass);

        //    });




        //}


    }
}

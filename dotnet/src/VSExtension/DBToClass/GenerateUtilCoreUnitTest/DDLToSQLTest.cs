 
using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.config;
using NUnit;
using static Org.FGQ.CodeGenerate.config.DDLConfig;
using NUnit.Framework;
using System;

namespace Org.FGQ.CodeGenerateTest
{

  


    public class DDLToSQLTest
    {

       
        DDLConfig config;

        [SetUp]
        public void Init()
        {
            config = new DDLConfig();
            config.MyDBType = DDLConfig.DBType.Oracle;

            DDLTable newtable;


            config.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_Booking","预约单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约单号", "booking_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("", "", "", "", ""));
            newtable.Columns.Add(new DDLColumn("", "", "", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约日期", "booking_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约时间", "booking_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问", "sa_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约来源", "booking_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("里程", "mile", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆描述", "service_vehicle_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约状态", "booking_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进店状态", "in_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修工单号", "ro_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记进场日期", "enter_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记进场时间", "enter_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除原因", "remove_reason_descr", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除备注", "remove_remark", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("", "", "", "", ""));
            newtable.Columns.Add(new DDLColumn("", "", "", "", ""));
            newtable.Columns.Add(new DDLColumn("预约客户 ID", "customer_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约客户称呼", "customer_sex", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约车辆 ID", "dealer_vehicle_id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问 ID", "sa_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人 ID", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人姓名", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人 ID", "updated_by", "varchar(64)", "", ""));



  


        }



        [Test]
        public void Test1()
        {

            DDLToSQL toSQL= new DDLToSQL();
            toSQL.GenerateSql(config, @"c:\1\2.txt");
          

        }




    }
}

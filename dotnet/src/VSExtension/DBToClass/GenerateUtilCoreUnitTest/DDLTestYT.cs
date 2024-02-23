
using Org.FGQ.CodeGenerate;
using Org.FGQ.CodeGenerate.Config;
using NUnit;
using static Org.FGQ.CodeGenerate.Config.DDLModel;
using NUnit.Framework;
using System;
using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Engine;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Model;
using System.Collections.Generic;
using System.IO;
using Org.FGQ.CodeGenerate.Pipe.Java;

namespace Org.FGQ.CodeGenerateTest
{




    public class DDLTestYT
    {


        DDLModel ddlConfig;
        JavaBeanModel javaBeanConfig;


        void initPart()
        {


            DDLTable newtable;



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Purchase", "1.PA106011000-同步零件采购"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(150)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购订单号", "purchase_order_no", "varchar(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("供应商来源", "supplier_source", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单类型", "order_type", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商/往来名称", "supplier_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商/往来代码", "supplier_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单状态", "order_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("参考订单号", "reference_info", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("BBA 订单号", "reference_order_no", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单预计金额", "estimated_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单创建信息", "create_info", "varchar(100)", "", "创建时间+创建人"));
            newtable.Columns.Add(new DDLColumn("订单提交信息", "submit_info", "varchar(100)", "", "提交时间+提交人"));
            newtable.Columns.Add(new DDLColumn("提交人", "submit_name", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否索赔", "is_return_order", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("订货数量", "order_num", "decimal(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_purchase_item", "1.PA106011000-同步零件采购明细"));
            newtable.Columns.Add(new DDLColumn("part_parchase_id", "part_parchase_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("行号", "line_number", "int(8)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件名称", "part_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单类型", "order_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("订货数量", "purchase_qty", "decimal(12,0)", "", ""));
            newtable.Columns.Add(new DDLColumn("接收数量", "in_qty", "decimal(12,0)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购实际金额", "in_cost_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "order_dep_no", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单行状态", "order_line_status", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("三包类型", "rrr_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否安全件", "is_safety", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否地图码", "is_activation", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否 3C 件", "is_ccc", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(17)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计到货时间", "expect_arrive_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("GRN 号", "grn", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购成本单价", "in_cost", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("明细创建人", "created_name", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("明细修改人", "updated_name", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("明细创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("明细修改时间", "updated_at", "varchar(30)", "", ""));





            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Sale", "2.PA106011001-同步零件销售"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户 ID", "customer_id", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司名称", "company_name", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "vin", "varchar(17)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("车款", "series_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件总价", "part_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他总价", "add_item_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("优惠金额", "total_discount_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("总价", "sum_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "customer_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否更新需求", "is_update_need", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单类型", "order_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单状态", "ro_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单备注", "ro_remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("申请方订单号", "purchase_order_no", "varchar(64)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Sale_Item", "2.PA106011001-同步零件销售明细"));
            newtable.Columns.Add(new DDLColumn("parts_sale_id", "parts_ro_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("原行号", "original_item_seq", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("类型", "item_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("工项号", "part_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("工项描述", "part_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "part_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("单价", "part_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣", "discount_rate", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际金额", "part_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("固定价", "is_fixed_price", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户", "account_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sales_type_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算状态", "balance_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单行状态", "dispatch_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计到货日期", "expect_arrive_date", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否更新需求", "is_update_need", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否 3C 件", "is_ccc", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人", "out_user", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(200)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库成本", "part_cost", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("family_code", "family_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类型", "part_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("ALOIS 大类", "alois_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("ALOIS 小类", "alois_sub_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修类型", "repair_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库日期", "out_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("拆分比例", "split_per", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("建议零售价", "recommend_price", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款代码", "pay_type_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料单号", "pick_list_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人", "picker_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算单号", "balance_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库仓库", "storage_code", "varchar(36)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Transfer", "3.PA106011002-同步零件移库"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(150)", "", ""));
            newtable.Columns.Add(new DDLColumn("移库单号", "transfer_no", "varchar(24)", "是", ""));
            newtable.Columns.Add(new DDLColumn("移库单状态", "transfer_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Transfer_Item", "3.PA106011002-同步零件移库明细"));
            newtable.Columns.Add(new DDLColumn("transfer_id", "transfer_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("原仓库代码", "old_storage_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("新仓库代码", "storage_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("移库数量", "transfer_qty", "decimal(21,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件描述", "part_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否删除", "is_deleted", "int(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Inventory", "4.PA106011003-同步零件盘点"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(150)", "", ""));
            newtable.Columns.Add(new DDLColumn("盘点单号", "inventory_no", "varchar(24)", "是", ""));
            newtable.Columns.Add(new DDLColumn("盘点单描述", "inventory_descr", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("盘点单状态", "inventory_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("盘点方式", "inventory_way", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(3000)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Inventory_Item", "4.PA106011003-同步零件盘点明细"));
            newtable.Columns.Add(new DDLColumn("inventory_no_id", "inventory_no_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("仓库代码", "storage_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库名称", "storage_name", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("货位", "storage_position_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件描述", "part_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("系统库存", "system_stock", "decimal(12,0)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际库存", "real_stock", "decimal(12,0)", "", ""));
            newtable.Columns.Add(new DDLColumn("差异数量", "difference_counts", "decimal(12,0)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("货位备注", "position_remark", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本单价", "average_cost", "decimal(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Stock", "5.PA106011004-同步零件库存"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(150)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(24)", "是", ""));
            newtable.Columns.Add(new DDLColumn("零件描述", "part_name_zh", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(200)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类型", "part_type", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("平均成本", "average_cost", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("最新成本", "latest_cost", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("建议零售价", "recommend_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("含税价格", "tax_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("建议零售价更新日期", "rcmd_price_date", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("上次建议零售价", "last_recommend_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("上次含税价格", "last_tax_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("特价销售价格（不含税）", "special_sales_price", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("特价销售开始日期", "special_sales_start", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("特价销售结束日期", "special_sales_end", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("BBA 成本", "bba_cost", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("总库存数量", "total_stock_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("可用库存数量", "total_available_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("在途库存", "transit_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("预留库存", "total_reserve_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("B/O", "lack_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("最大库存", "max_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("最小库存", "min_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购因子", "purchase_id", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购计量单位", "unit", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型代码", "model_class_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣", "discount_code", "varchar(5)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售代码", "family_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("补货代码", "replenishment_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("ALOIS 类别", "alois_category", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("ALOIS 子类别", "alois_subcategory", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("旧零件", "old_replace_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("新零件", "new_replace_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("替换属性", "replace_attribute", "varchar(2)", "", ""));
            newtable.Columns.Add(new DDLColumn("过去 12 个月需求", "demand_qty", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("deleted 标识", "is_deleted", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("总成/套件", "assembly_kit", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否库存项", "is_inventory", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("禁止价格更新", "prohibit_price_update", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新需求", "is_update_require", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("最后一次销售日期", "last_sales_date", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("最后一次采购日期", "last_purchase_date", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("最小订货量", "min_order_number", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("最小包装量", "prepacked_quantity", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购文本（厂商）", "purchase_text_oem", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购文本（经销商）", "purchase_text_dl", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售文本（厂商）", "sale_text_oem", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售文本（经销商）", "sales_text_dl", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("首次采购日期", "first_purchase_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("首次销售日期", "first_sales_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("上次流动日期", "last_flow_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Stock_Item", "5.PA106011004-同步零件库存明细"));
            newtable.Columns.Add(new DDLColumn("part_stock_id", "part_stock_id", "long", "是", "", true));
            newtable.Columns.Add(new DDLColumn("仓库名称", "storage_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库代码", "storage_code", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("总库存数量", "stock_qty", "numeric(12)", "是", ""));
            newtable.Columns.Add(new DDLColumn("可用库存数量", "available_qty", "numeric(12)", "", ""));
            newtable.Columns.Add(new DDLColumn("库位备注信息", "storage_position_remark", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("库位", "storage_position_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));





            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Scrap", "6.PA106011005-同步零件报废"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("报废单号", "scrap_no", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("报废单状态", "scrap_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Scrap_Item", "6.PA106011005-同步零件报废明细"));
            newtable.Columns.Add(new DDLColumn("scrap_id", "scrap_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("仓库名称", "storage_name", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库代码", "storage_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件描述", "part_name", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "scrap_counts", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本单价", "scrap_cost", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("总成本", "scrap_amount", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除标志", "is_deleted", "int", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Flow", "7.PA106011006-同步零件流动"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件号", "part_no", "varchar(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("流动序列", "flow_num", "varchar(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("流动类型", "flow_type", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("业务类型", "business_type", "varchar(24)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌代码", "brand_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户", "account", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作员", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("业务单号", "business_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料单号", "grn_pick_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "out_in_qty", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存数量", "total_stock_qty", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库", "storage_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("所在仓库数量", "storage_qty", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("出入库成本", "average_cost", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("流动日期", "flow_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Pick", "8.PA106011007-同步零件领料"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(150)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("开单日期", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "updated_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_PARTS_Pick_Item", "8.PA106011007-同步零件领料明细"));
            newtable.Columns.Add(new DDLColumn("pick_id", "pick_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("是否出库", "dispatch_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库", "storage_code", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("库位代码", "storage_position_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件代码", "part_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件名称", "part_name", "varchar(120)", "", ""));
            newtable.Columns.Add(new DDLColumn("单位", "unit", "varchar(15)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "part_qty", "numeric(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣", "discount_rate", "numeric(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("单价", "part_price", "numeric(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("金额", "part_amount", "numeric(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人姓名", "out_user", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人姓名", "picker_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件成本单价", "part_cost", "numeric(12,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件成本金额", "cost_sum", "numeric(23,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库时间", "out_date", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料单号", "pick_list_no", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("流动号", "flow_num", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));





        }

        void initAC()
        {

            DDLTable newtable;
            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_General", "9.AC102011000-同步分录明细"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "DMSCode", "varchar(20)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "DMSTitle", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司代码", "CompanyCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司名称", "CompanyTitle", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建日期时间", "CreatDateTime", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "Creator", "varchar(8)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_General_Detail", "9.AC102011000-同步分录明细分录"));
            newtable.Columns.Add(new DDLColumn("ac_id", "ac_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("公司编码", "companyCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("主体账簿", "accBook", "varchar(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("会计期间", "period", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("凭证类别", "voucherType", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("制单日期", "maketime", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("凭证号", "displayname", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("分录号", "recordnumber", "varchar(10)", "是", ""));
            newtable.Columns.Add(new DDLColumn("摘要", "description", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("一级科目", "firstAccsubjectCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("科目编码", "accsubjectCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("科目名称", "accsubjectName", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("辅助项", "clientauxiliary", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("辅助项类型", "clientauxiliaryDocType", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("辅助项名称", "clientauxiliaryName", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("币种", "currencyCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("借方数量", "debitQuantity", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("借方原币", "debitOriginal", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("贷方数量", "creditQuantity", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("贷方原币", "creditOriginal", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("贷方本币", "creditOrg", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("主表科目", "masterAccsubjectCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("主表流量金额", "masterFlowMoney", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("附表项目", "secondAccsubjectCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("附表流量金额", "secondFlowMoney", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("制单人", "makerName", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("签字人", "signerName", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("审核人", "auditorName", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("记账人", "tallymanName", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("记账人", "cancelSign", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("作废标识", "depositsign", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源系统", "srcsystem", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源单据类型", "srcsystemidCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源单据号", "srctplid", "varchar(20)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_FA_Detail", "10.AC102011001-同步固定资产分录"));
            newtable.Columns.Add(new DDLColumn("ac_id", "ac_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("固定资产编号", "FANo", "varchar(20)", "是", ""));
            newtable.Columns.Add(new DDLColumn("描述", "Description", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("序列号", "SerialNo", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("闲置标记", "Inactive", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("禁用标记", "Blocked", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("分类代码", "FAClassCode", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("子类代码", "FASubclassCode", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("固定资产位置代码", "FALocationCode", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商编号", "VendorNo", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("维护供应商编号", "MaintenanceVendorNo", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否正在维护", "UnderMaintenance", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("下次维护日期", "NextServiceDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("维保日期", "WarrantyDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("折旧期间（按月份计算）", "DepreciationPeriod", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("折旧起始日期", "DepreciationStartingDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心代码", "CostCenterCode", "varchar(20)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_Cust_Vend_Info", "11.AC102011002-同步客户和供应商信息"));
            newtable.Columns.Add(new DDLColumn("ac_id", "ac_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("类型", "Type", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("编号", "No", "varchar(20)", "是", ""));
            newtable.Columns.Add(new DDLColumn("姓名", "Name", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("地址", "Address", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("地址 2", "Address2", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("电话号码", "PhoneNo", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("传真号码", "FaxNo", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("禁用", "Blocked", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("电子邮件", "Email", "varchar(80)", "", ""));
            newtable.Columns.Add(new DDLColumn("邮政编码", "PostCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("城市", "City", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("国家", "Country", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("币种", "Currency", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("（应收应付）帐号", "ARAPAccountNo", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("价格是否包含增值税", "PricesIncludingVAT", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("方式", "ApplicationMethod", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款期限代码", "PaymentTermsCode", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("支付方式代码", "PaymentMethodCode", "varchar(10)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心代码", "CostCenterCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("关联方代码", "ICPartnerCode", "varchar(50)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_Invoice", "12.AC102011003-同步发票Invoice信息"));
            newtable.Columns.Add(new DDLColumn("ac_id", "ac_id", "long", "", "", true));
            newtable.Columns.Add(new DDLColumn("发票编码", "InvoiceNo", "varchar(20)", "是", ""));
            newtable.Columns.Add(new DDLColumn("过账日期", "PostingDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("文档日期", "DocumentDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("到期日", "DueDate", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款：供应商编码，收款：客户编码", "PayToBillToNo", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售：客户编码，采购：供应商编码", "SellToBuyFromNoString", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心代码", "CostCenterCode", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系（型号代码）", "VehicleSeries", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("外部文档编码", "ExtDocumentNo", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("价格是否包含增值税", "PriceIncludeVAT", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("地点", "Location", "varchar(20)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票类型", "InvoiceType", "varchar(10)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_Invoice_Item", "12.AC102011003-同步发票Invoice信息Item"));
            newtable.Columns.Add(new DDLColumn("invoice_id", "invoice_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("行编号", "LineNo", "varchar(50)", "是", ""));
            newtable.Columns.Add(new DDLColumn("空", "DMSItemType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("会计科目", "GLAccount", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("描述（摘要）", "Description", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心代码", "CostCenterCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系代码", "VehicleSeries", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆识别号", "VINNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "QTY", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("行金额", "LineAmount", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("交易类型", "TransactionType", "varchar(50)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_Invoice_Other", "13.AC102011004-同步发票Other信息"));
            newtable.Columns.Add(new DDLColumn("发票类型", "DaybookNo", "varchar(10)", "是", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_Invoice_Other_Item", "13.AC102011004-同步发票Other信息Item"));
            newtable.Columns.Add(new DDLColumn("daybook_id", "daybook_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("交易类型", "TransactionType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("行编码", "LineNo", "varchar(50)", "是", ""));
            newtable.Columns.Add(new DDLColumn("过账日期", "PostingDate", "varchar(50)", "是", ""));
            newtable.Columns.Add(new DDLColumn("文档日期", "DocumentDate", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("外部文档编码", "ExtDocumentNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("针对 DMS，此字段只能为”G/L Account”", "AccountType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("会计科目编号", "AccountNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("描述 （摘要）", "Description", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("贷方金额", "DebitValue", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("借方金额", "CreditValue", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心代码", "CostCenterCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系（车型号）", "VehicleSeries", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN 车辆识别号", "VINNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("WIP No. WIP 编码", "WIPNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("固定资产过账类型", "FAPostingType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("分录类型", "EntryType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("发起公司代码", "FromCompanyCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("接收公司代码", "ToCompanyCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("源类型", "SourceType", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("源编码", "SourceNo", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("地点", "Location", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("变动类型", "MovementType", "varchar(50)", "", ""));






            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_part_invoice", "14.AC102011005-同步零件采购发票录入"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商商代码", "supplier_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商名称", "supplier_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("系统发票号", "invoice_flow_no", "varchar(36)", "是", ""));
            newtable.Columns.Add(new DDLColumn("票据方向", "bill_direction", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票类型", "invoice_type", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票代码", "invoice_code", "varchar(12)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号码", "invoice_no", "varchar(8)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额（含税）", "invoice_tax_amount", "decimal(14,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率（%）", "tax_rate", "decimal(14,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额（未税）", "invoice_amount", "decimal(14,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "decimal(14,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票日期", "invoice_date", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记日期", "register_date", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("记账日期", "account_date", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票状态", "invoice_status", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("经手人", "handler", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(300)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否红冲", "is_red", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_After_sale_invoice_reg", "15.AC102011006-同步售后开票登记"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("应收发票 id", "pub_invoice_id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("结算申请单单号", "business_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票客户", "invoice_customer", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票代码", "invoice_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号码", "invoice_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票日期", "invoice_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否红冲", "is_red", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("票据方向", "bill_direction", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票类型", "invoice_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额（含税", "invoice_tax_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("经手人", "handler", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记日期", "register_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算单号", "balance_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否全部开票", "invoice_tag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算时间", "billmaker_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问 ID", "sa_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问名称", "sa_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("应开票金额", "receivable_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额（未税）", "invoice_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("已开票金额", "invoiced_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("未开票金额", "not_invoice_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率（%）", "tax_rate", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_car_sale_invoice_reg", "16.AC102011007-同步整车开票登记"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票类型", "invoice_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号码", "invoice_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("开票客户", "invoice_customer", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票日期", "invoice_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否红冲", "is_red", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额（含税）", "invoice_tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率%", "tax_rate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经手人", "handler", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记日期", "register_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单号", "business_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票代码", "invoice_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "brand_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "series_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单开单日期", "billmaker_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单应收金额", "total_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单已收金额", "receive_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_CP_Invoice", "17.AC102011008-同步整车采购发票录入"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商编号", "supplier_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商名称", "supplier_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号码", "invoice_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("发票代码", "invoice_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("票据方向", "bill_direction", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票类型", "invoice_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额(未税)", "invoice_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率（%）", "tax_rate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额(含税)", "invoice_tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票日期", "invoice_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经手人", "handler", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("红冲发票号码", "red_invoice_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("红冲发票代码", "red_invoice_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_CP_Invoice_Item", "17.AC102011008-同步整车采购发票录入明细"));
            newtable.Columns.Add(new DDLColumn("car_purchase_invoice_id", "car_purchase_invoice_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("入库单号", "in_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购未税价", "purchase_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率", "tax_rate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购含税价", "purchase_tax_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "brand_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进口/国产", "ckd_or_cbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否新车", "new_car", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "series_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("年款", "model_year", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "config_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_maintain_pay", "18.AC102011009-同步维修收款"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算申请单号", "business_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算单号", "balance_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("结算时间", "balance_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型代码", "pay_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型名称", "pay_type_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("应收金额", "receivable_amount", "decimal(12,3)", "", ""));
            newtable.Columns.Add(new DDLColumn("已收金额", "receive_amount", "decimal(12,3)", "", ""));
            newtable.Columns.Add(new DDLColumn("已免金额", "derate_amount", "decimal(12,3)", "", ""));
            newtable.Columns.Add(new DDLColumn("未收金额", "unpay_amount", "decimal(12,3)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否结清", "pay_off", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算日期", "pay_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结清日期", "pay_off_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("业务类型", "order_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN 号", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_maintain_pay_item", "18.AC102011009-同步维修收款明细"));
            newtable.Columns.Add(new DDLColumn("maintain_pay_id", "maintain_pay_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("收银员", "handler", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款方式", "payment_way_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收/退款金额", "receive_amount", "decimal(12,3)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款时间", "receive_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批次号", "batch_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("单号", "pub_pay_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("操作类型", "pub_pay_item_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("支付状态", "pay_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作时间", "operate_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("银行卡号/支票号", "check_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入账科目编号", "subject_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入账科目名称", "subject_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退款原因", "return_reason", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("事由", "reason", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_pre_order", "19.AC102011010-同步预收款"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预收款单号", "pre_order_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("手机号", "customer_phone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("登记日期", "payment_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否结清", "pay_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预收款金额", "receivable_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("已收金额", "receive_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("未收金额", "not_receive_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("业务人员", "payment_user_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("用途", "purpose", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户余额", "remian_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单状态", "ro_stauts", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("已用金额", "used_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("已退金额", "return_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订金状态", "payment_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "business_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问", "sa_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_pre_order_item", "19.AC102011010-同步预收款明细"));
            newtable.Columns.Add(new DDLColumn("pre_order_id", "pre_order_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("付款方式", "payment_way_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款金额", "receive_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("银行卡号/支票号", "check_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("事由", "reason", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款日期", "receive_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收银员", "handler", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批次号", "batch_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("单号", "pub_pay_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退款金额", "return_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("支付状态", "pay_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作时间", "operate_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作类型", "pub_pay_item_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_business", "20.AC102011011-同步整车收款"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单号", "business_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("单据日期", "billmaker_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款类型", "receive_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("手机号", "customer_phone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("应收金额", "receivable_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("已收金额", "receive_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("已免金额", "derate_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("未收金额", "unpay_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单是否结清", "pay_off", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结清时间", "pay_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_business_car_info", "20.AC102011011-同步整车收款车辆信息"));
            newtable.Columns.Add(new DDLColumn("business_id", "business_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("订单状态", "order_status", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sales_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件类型", "credentials_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件号码", "credentials_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户地址", "customer_address", "varchar(256)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "sales_adviser", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("支付方式", "pay_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车报价", "whole_sale_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("精品报价", "boutique_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他项目费用", "other_project_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订金", "deposit_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单优惠金额合计", "discount_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单总额", "total_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换金额", "displace_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("机动车大票金额", "vehicle_invoice_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单已收", "receive_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("欠款总额", "derate_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单是否结清", "pay_off", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("开单日期", "billmaker_date", "varchar(36)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AC_business_item", "20.AC102011011-同步整车收款收款/退款"));
            newtable.Columns.Add(new DDLColumn("business_id", "business_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("付款方式", "payment_way_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款金额", "receive_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("银行卡号/支票号", "check_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("事由", "reason", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款时间", "receive_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("收银员", "handler", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remark", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("批次号", "batch_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款单号", "pub_pay_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("退款金额", "return_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作类型", "pub_pay_item_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("支付状态", "pay_status", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("操作时间", "operate_date", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(30)", "", ""));







        }

        void initASF()
        {
            DDLTable newtable;

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_Booking", "21.AS103011000-同步预约单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约单号", "booking_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
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
            newtable.Columns.Add(new DDLColumn("预约客户 ID", "customer_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约客户称呼", "customer_sex", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约车辆 ID", "dealer_vehicle_id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问 ID", "sa_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人姓名", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人 ID", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人姓名", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人 ID", "updated_by", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_RO", "22.AS103011001-同步工单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "series_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否本店", "vehicle_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户姓名", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户手机号", "mobile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进厂计划时间", "plan_in_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出厂计划时间", "plan_out_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计维修时长", "labour_count", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进厂实际时间", "last_in_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出厂实际时间", "last_out_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("保修到期日", "wrt_end_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("延保到期日", "extend_wrt_end_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("保险到期日", "insurance_end_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("保险公司", "insuration_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上次进厂", "last_repair_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上次维修里程", "last_local_mile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计下次维修日期", "next_repair_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计下次维修里程", "next_repair_mile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("月均里程", "average_mile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("所属 SA", "sa_name", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("定金", "earnest_money", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单备注", "ro_remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("调整胎压", "is_tire_pressure", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("洗车", "is_wash", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("旧件带走", "is_take", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("在店等待", "is_waiting", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("路试", "is_road", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工时总价", "labour_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件总价", "part_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他总价", "add_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("优惠金额", "discount_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("总价", "sum_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单创建人 ID", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单更新时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单更新人姓名", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单更新人 ID", "updated_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆 ID", "dealer_vehicle_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆品牌", "brand_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆描述", "vehicle_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆描述", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp1", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp2", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp3", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp4", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp5", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp6", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp7", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp8", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp9", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆自定义", "temp10", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户 ID", "customer_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户称呼", "customer_sex", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户地址（省）", "province_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户地址(市)", "city_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司名称", "company_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司地址", "company_address", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单状态", "ro_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单零件状态", "part_order_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预约单号", "booking_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("在修已出库零件成本", "part_cost_amount", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_RO_Pkg", "22.AS103011001-同步工单套餐"));
            newtable.Columns.Add(new DDLColumn("ro_id", "ro_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("套餐行号", "pkg_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐代码", "pkg_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修类型", "repair_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("描述", "pkg_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("状态", "pkg_status", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_RO_Item", "22.AS103011001-同步工单项目"));
            newtable.Columns.Add(new DDLColumn("ro_id", "ro_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("套餐代码", "pkg_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("类型", "item_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目号", "item_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目描述", "item_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "item_count", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("单价", "item_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣", "discount_rate", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("拆分百分比", "split_per", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("固定价", "is_fixed_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("总价", "item_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("调度", "dispatch_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算", "balance_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源", "created_from", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率", "tax", "decimal(8,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型名称", "pay_type_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户代码", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户描述", "account_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户销售类型", "sales_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户销售类型描述", "sales_type_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本单价", "labour_cost", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本总价", "labour_cost_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目创建人ID", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目修改人ID", "updated_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目修改人", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目修改时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工时率代码", "labour_rate_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开放工时标记", "is_open_labour", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("打卡技师", "clock_user_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("打卡时间", "repair_minute", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件品牌", "brand_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人 ID", "out_user_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人姓名", "out_user", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人 ID", "piciker_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人姓名", "picker_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库时间", "out_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类型", "part_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件零售价", "recommend_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类别", "alois_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心", "cost_center_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商代码", "supplier_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商描述", "supplier_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动号", "activity_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动类型", "activity_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动描述", "activity_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动来源", "activity_data_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("核销码", "redeem_code", "varchar(64)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_RO_job", "23.AS103011002-同步施工单"));
            newtable.Columns.Add(new DDLColumn("施工单 id", "ro_job_id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("施工单号", "ro_job_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("服务顾问", "sa_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计交车时间", "plan_out_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "brand_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("里程数", "repair_mile", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("保修起始日期", "wrt_begin_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进场日期", "last_in_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("充电意愿", "charge_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否调整胎压", "is_tire_pressure", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否洗车", "is_wash", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("同意路试", "is_road", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("旧件带走", "is_take", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("班组标签", "team_group_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("施工单生成时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("施工单生成人 ID", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("施工单生成人姓名", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("施工单更新时间", "updated_at", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_RO_job_item", "23.AS103011002-同步施工单item"));
            newtable.Columns.Add(new DDLColumn("施工单 id", "ro_job_id", "long(30)", "", "", true));
            newtable.Columns.Add(new DDLColumn("类型", "item_type", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("项目号", "item_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目描述", "item_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "item_count", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("代码", "labour_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("套餐行号", "pkg_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐代码", "set_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐描述", "set_type_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐来源", "created_from", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修类型", "repair_type", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_balance_apply", "24.AS103011003-同步结算申请"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算申请单号", "balance_apply_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算状态", "balance_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工时总价", "labour_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件总价", "part_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他总价", "add_item_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("优惠金额", "total_discount_amount", "varchar(64)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_balance_apply_item", "24.AS103011003-同步结算申请item"));
            newtable.Columns.Add(new DDLColumn("balance_apply_id", "balance_apply_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单行结算状态", "balance_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("类型", "item_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源", "created_from", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目号", "project_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目描述", "project_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "item_qty", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("单价", "item_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣百分比", "discount_rate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣百分比", "split_per", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否固定价", "is_fixed_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("总价", "item_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率", "tax", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户代码", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户描述", "account_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户销售类型", "sales_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本单价", "item_cost", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本总价", "item_cost_amount", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_balance_apply_pkg", "24.AS103011003-同步结算申请套餐"));
            newtable.Columns.Add(new DDLColumn("balance_apply_id", "balance_apply_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("套餐行号", "pkg_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐代码", "pkg_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修类型", "repair_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐描述", "pkg_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐来源", "data_source", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_MB", "25.AS103011004-同步维修结算单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算单号", "balance_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("结算时间", "balance_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算人 ID", "account_created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算人姓名", "account_created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("保修申请单号", "claim_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("取消结算原因", "cancel_reason", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sales_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单创建人 ID", "apply_created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单创建人姓名", "apply_created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否取整", "is_round", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算申请单号", "balance_apply_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("状态", "balance_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户代码", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心", "cost_center_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户描述", "account_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户姓名", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("称谓", "customer_sex", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户电话", "mobile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("省/市", "province_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("往来单位编码", "contact_customer_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("往来单位名称", "contact_customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司名称", "company_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司地址", "address_Detail", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("开户行", "bank_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开户行账户", "bank_account", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司注册地址", "registered_address", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("工单号", "ro_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提交结算人", "balance_apply_user_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提交结算时间", "balance_apply_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("所属 SA", "sa_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提交结算人 ID", "balance_apply_user_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照号", "license", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "vin", "varchar(17)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型系列", "series_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆描述", "vehicle_descr", "varchar(255)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_MB_Account", "25.AS103011004-同步维修结算单account"));
            newtable.Columns.Add(new DDLColumn("maintain_balance_id", "maintain_balance_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("费用类型", "fee_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("原价", "original_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("优惠金额", "total_discount_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("含税金额", "sum_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率 s", "tax", "decimal(6,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("税额", "tax_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("未税金额", "total_pretax_amount", "decimal(12,2)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_MB_PKG", "25.AS103011004-同步维修结算单套餐"));
            newtable.Columns.Add(new DDLColumn("maintain_balance_id", "maintain_balance_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("套餐代码", "pkg_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修类型", "repair_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("描述", "pkg_descr", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐来源", "created_from", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("套餐行号", "pkg_seq", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_AFS_MB_Item", "25.AS103011004-同步维修结算单item"));
            newtable.Columns.Add(new DDLColumn("maintain_balance_id", "maintain_balance_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("行号", "item_seq", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("类型", "item_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("来源", "created_from", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目号", "item_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目描述", "item_desc", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("数量", "item_count", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("单价", "item_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣", "discount_rate", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("拆分百分比", "split_per", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("总价", "item_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率", "tax", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款类型", "pay_type_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户代码", "account_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算账户描述", "account_descr", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("账户销售类型", "sales_type_descr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件品牌", "brand_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人 ID", "out_user_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库人姓名", "out_user", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人 ID", "piciker_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("领料人姓名", "picker_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库时间", "out_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类型", "part_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件零售价", "recommend_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零件类别", "alois_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本中心", "cost_center_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商代码", "supplier_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商描述", "supplier_name", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动号", "activity_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动类型", "activity_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动描述", "activity_descr", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动来源", "activity_data_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("核销码", "redeem_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("结算状态", "balance_status", "varchar(64)", "", ""));









        }



        [SetUp]
        public void Init()
        {
            ddlConfig = new DDLModel();
            ddlConfig.MyDBType = DDLModel.DBType.Oracle;

            initPart();
            initAC();
            initASF();
            initRS();
            initWS();
            initUC();
            initDMO();


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

        private void initDMO()
        {
            DDLTable newtable;
            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_Customer", "44.DMO10901001-同步个⼈客户"));
            newtable.Columns.Add(new DDLColumn("客户 ID", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("客户 Spark Id", "sparkId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "typeCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("姓密】", "fullName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("名【加密】", "firstName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("性别", "genderCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("客档来源", "sourceCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("省份", "provinceCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("城市", "cityCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("详细地址【加密】", "addressDetail", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件类型", "identificationType", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件号码【加密】", "identificationNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照状态", "plateTypeCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("微信号", "weChatId", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("邮箱", "email", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("出⽣⽇期【加密】", "birthDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("国籍⺠族", "nationality", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("集团内客户", "ssaCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("客档备注", "Remarks", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("主⼿机号【加密】", "phoneNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("副⼿机号 1【加密】", "phoneNumberSub1", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("副⼿机号 2【加密】", "phoneNumberSub2", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("KR Block", "krBlock", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("隐私协议状态", "customerDcaStatus", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("隐私协议签署状态", "customerAgreementDcaStatus", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("签名⽂件 Id", "signatureFileId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建⼈", "userCreatedId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "timeCreated", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("门店代码 cbu", "cbuCode", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_Company", "45.DMO10901002-同步公司客户"));
            newtable.Columns.Add(new DDLColumn("公司 ID", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("公司名称", "name", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("统⼀社会信⽤代码", "taxpayerIdentityNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司电话", "phoneNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司注册地址", "registeredAddress", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司备注", "remark", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "timeCreated", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建⼈", "userCreatedId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "companyTypeCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("集团内客户", "ssaCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("联系⼈Id", "customerId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开户⾏", "bankName", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("开户⾏账号【加密】", "bankAccount", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("门店 cbu", "cbuCode", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_opportunity", "46.DMO10901003-同步机会"));
            newtable.Columns.Add(new DDLColumn("机会 ID", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("客户 Id", "sparkId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户 Id", "customerId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会来源", "opportunitySourceCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动 Id", "campaignId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("信息来源", "leadsInfoSourceCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计购 时间", "expectedBuyTimeCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("预算下限", "budgetFloor", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("预算上限", "budgetCeiling", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否重购", "rebuy", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("BDC 线索", "leadOfBdc", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会备注", "comment", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会归属⼈", "followUserId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会等级", "priorityLevelCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("下次跟进时间", "nextFollowTime", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("意向 型", "intentions", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("门店 cbu", "cbuCode", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_opportunity_Follow", "47.DMO10901004-同步机会跟进"));
            newtable.Columns.Add(new DDLColumn("跟进 ID", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("机会 ID", "opportunityId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("跟进类型", "followTypeCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("跟进内容", "content", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("跟进时间", "followTime", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("下次跟进时间", "bizTime", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("活动 ID", "campId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("跟进执⾏⼈", "createUserId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("门店 cbu", "cbuCode", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_ZhanTing", "48.DMO10901005-同步客流展厅"));
            newtable.Columns.Add(new DDLColumn("id", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商", "dealershipId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("联系电话（⼿机号+固话）,【加密】", "phone", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("业务线：", "bizCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("姓, 【加密】", "lastName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("名,【加密】", "firstName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("性别", "genderCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("隐私政策级别", "privacyLevelCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客流阶段归属⼈", "followUserId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("接待状态（1 待服务 2接待中 3 接待完成 4 未接待）", "receptionCode", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计购买时间枚举编码", "expectedBuyTimeCode", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会 id", "opportunityId", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("机会关联的客档 id，冗余字段", "customerId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("离店状态(1：未离店 2：已离店)", "leaveCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("签名 pdf 路径", "signUrl", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("签名状态", "signCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("描述", "leadsInfoSourceCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("客流到店时间", "arrivalDate", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("客流离店时间", "leaveDate", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("到店⼈数", "visitPeopleCode", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("到访⽬的 1⾸次到访 2再次到访 3 订单后 4 其它", "purposeCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("到访原因 1⾃⾏ 2邀约", "reasonsCode", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("接待开始时间", "receptionStartTime", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("接待结束时间", "receptionEndTime", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createDate", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建⼈", "createUserId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "modifyDate", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新⼈", "modifyUserId", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("当⽇试驾 0 否 1 是", "oneDayDrive", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("当⽇报价 0 否 1 是", "oneDayOffer", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("隐私协议内容", "ruleContext", "text", "", ""));
            newtable.Columns.Add(new DDLColumn("隐私协议类型", "source", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("签名⽂件 id", "signatureFileId", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否有效：0-⽆效【客档已删除】，1-有效", "active", "varchar(32)", "", ""));
            newtable.Columns.Add(new DDLColumn("门店 cbu", "cbuCode", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_DMO_ShiJia", "49.DMO10901006-同步试驾乘车"));
            newtable.Columns.Add(new DDLColumn("试驾⽂档 ID", "id", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商 ID", "dealershipId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "salesConsultant", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("Spark 试驾路线 ID", "sparkRouteId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾路线名称", "routeName", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾路线描述", "routeDescribe", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("Spark 试驾 ID", "sparkVehicleId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("底盘号(vin)", "vehicleVin", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌号", "vehiclePlateNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("辆品牌", "vehicleBrandName", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("系", "vehicleSeriesName", "varchar(52)", "", ""));
            newtable.Columns.Add(new DDLColumn("型", "vehicleModelName", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("款", "vehiclePackageName", "varchar(50)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈ID", "driverId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件类型", "driverCertType", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件号码【加密】", "driverCertNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件正⾯照⽚ID", "driverFrontPictureId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件反⾯照⽚ID", "driverBackPictureId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件有效起始⽇期", "driverCertValidFrom", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈证件有效结束⽇期", "driverCertValidTo", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈地址", "driverAddress", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈名 【加密】", "driverFirstName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈姓 【加密】", "driverLastName", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈性别编码", "driverGenderCode", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈⼿机号 【加密】", "driverPhoneNumber", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈出⽣⽇期 【加密】", "driverBirthDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈国籍⺠族", "driverNationality", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈准驾类型", "driverLicenseClass", "varchar(100)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⼈驾驶证初次领证⽇期", "driverFirstIssueDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建⽤户 ID", "userCreatedId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "timeCreated", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾路线图地址", "routeUrls", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾时间", "routeTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾⾥程", "routeMileage", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾 ⾥程", "testDriveTotalMileage", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "vehicleBrandCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("系", "vehicleSeriesCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("e 系列[Body Group]", "vehicleEseriesCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("款", "vehiclePackageCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("型", "vehicleModelCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("门店 cbu", "cbuCode", "varchar(64)", "", ""));




        }

        private void initUC()
        {
            DDLTable newtable;
            DDLColumn column;

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_evaluation", "36.UC101010000-同步评估报告"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("主键", "id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("vin 号", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估单号", "evaluationNo", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_CBU", "dealerEntityCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_CKD", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("报价单号", "quotedPriceNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整体评分", "overallRating", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("综合评价", "overallEvaluation", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("事故检查分数", "accidentCheckScore", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("事故检查备注", "accidentCheckRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("外观检查分数", "exteriorCheckScore", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("外观检查备注", "exteriorCheckRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("机舱检查分数", "cabinCheckScore", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("机舱检查备注", "cabinCheckRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰检查分数", "interiorCheckScore", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰检查备注", "interiorCheckRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("电气检查分数", "electricCheckScore", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("电气检查备注", "electricCheckRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("火烧迹象", "burningSign", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("泡水迹象", "soakingSign", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("可否认证", "certifiable", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("NEV 车电池损耗", "powerloss", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计采购价格", "ppurchasePrice", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("外观维修费用", "pextmaintFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("机舱维修费用", "pbodymaintFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("电器维修费用", "elecmainFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰维修费用", "pintmaintFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("美容费用", "pmockupFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户费", "accttransferFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提档费", "upgradeFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("物流费", "logisticFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("其它费用", "otherFee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("成本费用合计", "totalCost", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计零售价格", "pretailPrice", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计利润", "pmargin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他说明", "otherDescription", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除标识", "delFlag", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updatedTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估状态", "evaluationStatus", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估日期", "evaluationDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("动力电池备注", "powerlossRemarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估人", "evaluator", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否可做 OCU 认证", "ocuFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("火烧迹象状态说明", "burningSignStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("泡水迹象状态说明", "soakingSignStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("OCU 认证状态说明", "ocuFlagStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估状态说明", "evaluationStatusStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("新车指导价", "msrp", "decimal(20,4)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Purchase", "37.UC101010001-同步采购单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("主键", "id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("单号", "orderNo", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码（cbu）", "dealerCodeCbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码（ckd）", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购类型", "purchaseType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licensePlateNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机号", "engineNum", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶里程", "travelMileage", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("车款名", "variantName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型名", "modelName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌名", "brandName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("颜色名", "colorName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上牌日期", "registerDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("逻辑删除", "delFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户姓名", "custName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户手机", "custMobilePhone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("购买日期", "purchaseDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("报价", "quotedPrice", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("收购价", "purchasePrice", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("身份证号", "idCardNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("组织机构代码", "orgCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商客户编号", "nationalId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户类型", "custType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("报价人", "quoter", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("最终采购价格", "finalPurchasePrice", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆来源", "vehicleSource", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("合同号", "contractNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车况等级", "vehicleConditionGrade", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司编码(NSC / BBA)", "company", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购人", "purchaser", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票日期", "invoiceDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号", "interiorCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "updatedTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票金额", "invoiceAmount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照性质", "formerPlateType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款状态", "payStatus", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("费用信息", "feeInfo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("UC 类别", "ucType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售价", "retailPrice", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("合同日期", "contractDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("最近同步时间", "lastSyncUpdateDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购类型描述", "purchaseTypeStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户类型描述", "custTypeStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆来源描述", "vehicleSourceStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照性质描述", "formerPlateTypeStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("UC 类别描述", "ucTypeStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款状态描述", "payStatusStr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("评估日期", "evaluate_date", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Sale", "38.UC101010002-同步销售单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("子订单 ID", "id", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("子订单编号", "subOrderNum", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("父订单编号", "orderNum", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单原价金额", "orderAmount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单状态", "orderStatus", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单类型", "orderType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单渠道", "orderChannel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("下单人", "orderer", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配送方式", "orderSendWay", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("下单时间", "orderTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("买家 ID", "buyerId", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("买家姓名", "buyerName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("买家联系电话", "buyerTel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆 ID", "vehicleId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN 码", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licensePlateNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("应付金额", "payableAmount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("实付金额", "payedAmount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否申请售后", "isAfterSales", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除标志", "delFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单扩展属性", "orderExtendAttr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收货人姓名", "receiverName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收货人电话", "receiverTel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收货地址", "receiveAddress", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updatedTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_cbu", "dealerCodeCbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_ckd", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("折扣金额", "discountAmount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "saleType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售价格信息", "saleFeeInfo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("毛利", "grossProfit", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("毛利率", "grossProfitRate", "varchar(64)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Stock", "39.UC101010003-同步车辆库存"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存 id", "id", "long(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_CBU", "dealerCodeCbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码_CKD", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库时间", "stockInDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库时间", "stockOutDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌编码", "brandCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型编码", "modelCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车款编码", "variantCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库状态", "status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库操作人", "siOperator", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库操作人", "soOperator", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updatedTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除标识", "delFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("PO 单号", "orderNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("维修出厂日期", "lastVisitDt", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购价", "purchasePrice", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("三包发票日期", "threeRInvoiceDt", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购时里程", "ucPurchaseMilage", "long(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("BSI 结束日期", "bsiEndDt", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌名称", "brandName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车款名称（中文）", "variantNmCn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车款名称（英文）", "variantNmEn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("系列", "series", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("E_SERIES", "eSeries", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("外饰编码", "exteriorCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("外饰颜色(中文)", "exteriorCn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("外饰颜色(英文)", "exteriorEn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰颜色编码", "interiorCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰颜色(中文)", "interiorCn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰颜色(英文)", "interiorEn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车类型", "ucType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购类型", "purchaseType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆来源", "vehicleSource", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("BMW 官方认证二手车（OCU）号", "ocuNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("RMS 使用", "carType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("资产车辆，库存车辆", "financeType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否在官网上架，用于返利审核", "officialPublished", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("公司编码,NSC 或者 BBA", "company", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售订单号", "saleOrderNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "licenseNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型名称", "modelName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否逾期", "overdue", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系编码", "seriesCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系名称", "seriesName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库龄超期时间", "expirationTime", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_recondition", "40.UC101010004-同步车辆整备信息"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备 id", "id", "long(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("VIN 码", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备状态", "status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备开始日期", "reconditionStartDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备完成日期", "reconditionEndDate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("费用合计", "costTotal", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码 CBU", "dealerCodeCbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码 CKD", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存 ID", "stockId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("删除标识", "delFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备状态描述", "statusStr", "varchar(255)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_recondition_item", "40.UC101010004-同步车辆整备信息Item"));
            newtable.Columns.Add(new DDLColumn("整备 id", "recondition_id", "long(30)", "是", "", true));
            newtable.Columns.Add(new DDLColumn("整备名称", "name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备成本", "cost", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备售价", "price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整备收益", "earning", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Transfer", "41.UC101010005-同步过户记录"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户 id", "id", "long", "是", ""));
            newtable.Columns.Add(new DDLColumn("逻辑删除", "delFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("现车牌", "licensePlateNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户区域", "transferArea", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提交时间", "submissionTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("完成时间", "completionTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否加急", "urgentFlag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户专员", "transferOperator", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("手续材料", "procedureMaterial", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("钥匙数", "keyQty", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("备注", "remarks", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户进度", "ntProgress", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购单编号", "orderNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户类型", "ntType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户状态", "ntStatus", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码（cbu）", "dealerCodeCbu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商编码（ckd）", "dealerCodeCkd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("买方客户姓名", "custName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("买方客户手机", "custMobilePhone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VIN", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("身份证号", "idCardNo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("组织机构代码", "orgCode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商客户编号", "nationalId", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("前车主名称", "formerCustName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("前车主电话", "formerCustMobile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("企业名称", "orgName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("联系人姓名", "contactName", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("联系人电话", "contactPhone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "createdBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "createdTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updatedBy", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updatedTime", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌类型", "plateType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("前客户信息", "formerCustomerInfo", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照性质", "custPlateType", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("现客户地址", "address", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户提档费", "ntMentionFileFee", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("过户类型描述", "custTypeStr", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("牌照性质描述", "custPlateTypeStr", "varchar(255)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Exchange", "42.UC101010006-同步置换记录"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CBU 编号", "cbu_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CKD 编号", "ckd_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换 id", "id", "long", "是", ""));
            newtable.Columns.Add(new DDLColumn("车辆状态", "vehicle_status", "varchar(64)", "", ""));
            //ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Exchange_New_Car", "42.UC101010006-同步置换记录新车"));
            //newtable.Columns.Add(new DDLColumn("exchange_id", "exchange_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("车架号", "frame_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("供应商", "supplier", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("新车车系", "new_car_series", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("新车车型", "new_models", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售发票号", "retail_invoice_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售标签价格", "retail_label_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("新车开票日期", "new_vehicle_billing_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售员姓名", "name_of_salesman", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("DMS 上报日期", "dms_report_date", "varchar(64)", "", ""));
            //ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Exchange_New_Costomer", "42.UC101010006-同步置换记录新车客户"));
            //newtable.Columns.Add(new DDLColumn("exchange_id", "exchange_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("客户/公司名称", "customer_company_name", "varchar(64)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("身份 证/机构 代码号", "card_organization_number", "varchar(64)", "", ""));
            column.JsonFieldName = "id_card_organization_code_number";
            newtable.Columns.Add(new DDLColumn("地址", "address", "varchar(255)", "", ""));
            //ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_Exchange_Old_Car", "42.UC101010006-同步置换记录二手车明细"));
            // newtable.Columns.Add(new DDLColumn("exchange_id", "exchange_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("原车主电话", "original_owner_phone_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车品牌", "used_car_brand", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车模型", "used_car_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("17 位车架号", "digit_frame_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号码", "license_plate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上牌时间", "licensing_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车新车客户相同", "second_and_new_customers_same", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("里程数（公里）", "mileage", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商评估价格（元）", "dealer_evaluation_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际收购价（元）", "actual_purchase_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车零售价格", "used_car_retail_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车采购来源", "source_of_used_car_purchase", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车销售渠道", "used_car_sales_channels", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆过户日期", "vehicle_transfer_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("资源调配日期", "deployment_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车龄月", "vehicle_age_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("资源调配接收方", "resource_allocation_receiver", "varchar(64)", "", ""));
            //newtable.Columns.Add(new DDLColumn("客户/公司名称", "customer_company_name", "varchar(64)", "", ""));
            //newtable.Columns.Add(column = new DDLColumn("身份证/机构代码号", "card_organization_number", "varchar(64)", "", ""));
            column.JsonFieldName = "id_card_organization_code_number";
            newtable.Columns.Add(new DDLColumn("二手车客户电话", "used_car_customer_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换项目名称", "replacement_project_name", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_YanBao", "43.UC101010007-同步记录延保"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("延保 id", "id", "long", "是", ""));
            newtable.Columns.Add(new DDLColumn("二手车车架号", "used_car_frame_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("购买失败原因", "purchase_fail_reason", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sales_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("首次注册日期", "date_of_first_registration", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("UC 车里程", "uc_vehicle_mileage", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库日期", "delivery_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CBU 编号", "cbu_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CKD 编号", "ckd_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("区域", "region", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("UC 类别", "uc_category", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_YanBao_Vehicle", "43.UC101010007-同步记录延保车辆信息"));
            newtable.Columns.Add(new DDLColumn("yanbao_id", "yanbao_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("UC 车系", "uc_series", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购类型", "purchase_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进口/国产", "imported_domestic", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车车况", "second_hand_car_condition", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆来源", "vehicle_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号码", "license_plate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "frame_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车身颜色", "body_color", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰颜色", "interior_color", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生产日期", "date_of_manufacture", "varchar(64)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("新车首次注册日期", "first_reg_date_of_new_car", "varchar(64)", "", ""));
            column.JsonFieldName = "first_registration_date_of_new_car";
            newtable.Columns.Add(new DDLColumn("公里数", "km", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_YanBao_Other", "43.UC101010007-同步记录延保其他信息"));
            newtable.Columns.Add(new DDLColumn("yanbao_id", "yanbao_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("原车主姓名", "original_owner_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("原车主电话", "original_owner_phone_number", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_YanBao_Stock", "43.UC101010007-同步记录延保库存信息"));
            newtable.Columns.Add(new DDLColumn("yanbao_id", "yanbao_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("车龄月", "vehicle_age_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库日期", "storage_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存位置", "inventory_location", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存天数", "days_in_stock", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("场租和利率（元）", "market_rent_and_interest_rate", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购过户费", "purchase_transfer_fee", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售佣金", "sales_commission", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("其他（市场费，赠品等）", "others", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("延保费用", "cost_of_extended_insurance", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("360 安全检测费", "safety_inspection_fee", "decimal(20,4)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("整备维修费", "servicing_maintenance_costs", "decimal(20,4)", "", ""));
            column.JsonFieldName = "servicing_and_maintenance_costs";
            newtable.Columns.Add(new DDLColumn("美容费", "beauty_fee", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购价格", "purchase_price", "decimal(20,4)", "", ""));




            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_UC_YanBao_Warranty", "43.UC101010007-同步记录延保保修信息"));
            newtable.Columns.Add(new DDLColumn("yanbao_id", "yanbao_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("二手车销售发票日期", "used_car_sales_invoice_date", "varchar(64)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("延保购买状态", "status_of_extended_warranty", "varchar(64)", "", ""));
            column.JsonFieldName = "purchase_status_of_extended_warranty";
            newtable.Columns.Add(new DDLColumn("新车保修费用", "new_car_warranty_fee", "varchar(64)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("新车保修起始日期", "new_car_warranty_start_date", "varchar(64)", "", ""));
            column.JsonFieldName = "new_vehicle_warranty_start_date";
            newtable.Columns.Add(new DDLColumn("保修结束日期", "warranty_end_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("保修剩余天数", "remaining_days_of_warranty", "varchar(64)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("是否需要购买延保", "need_extended_insurance", "varchar(64)", "", ""));
            column.JsonFieldName = "do_you_need_to_buy_extended_insurance";
            newtable.Columns.Add(column = new DDLColumn("延保包类型", "type_extended_warranty_pkg", "varchar(64)", "", ""));
            column.JsonFieldName = "type_of_extended_warranty_package";
            newtable.Columns.Add(new DDLColumn("延保价格（元）", "extended_insurance_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("延保有效期（月）", "extended_period_of_validity", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("最新密钥数据读取时间", "latest_key_data_read_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("最新钥匙数据读取里程", "latest_key_data_read_mileage", "varchar(64)", "", ""));







        }

        private void initWS()
        {
            DDLTable newtable;

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_WS_Order", "35.WS105011000-同步批售订单"));
            newtable.Columns.Add(new DDLColumn("生产订单号", "order_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "vin", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("系列", "wit_series_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型代码", "wit_model_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置代码", "variant_line_addi_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型描述", "vairnat_desc_zh", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("驱动方式", "drive_mode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("SABI/SOWU", "is_sabi_sowu", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("排量属性", "code_cn_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置描述中文", "variant_des_lc_zh", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置变更月", "profile", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否为 GKL+车型", "gkl_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车身漆代码", "option_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车身漆描述", "body_paint_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰代码", "interior_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰描述", "interior_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("轮毂", "hub", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("轮毂描述", "hub_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰条", "interior_trim_strip", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰条描述", "interior_trim_strip_desc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否加装", "product_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否选装", "w_ttl_flex_optn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("加装代码", "flex_optn_string", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("加装描述", "flex_optndes_string", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置参数", "optionc_string", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生产订单类型", "processing_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("运输类型", "transport_flag", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售订单提报日期", "order_entry_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "cu_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("IVSR 状态", "ivsr_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("WIT 状态", "wit_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售状态", "sales_stts", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("需求生产周", "demand_production_week", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("确认生产周", "confirm_production_week", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配额月", "quota_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("计划生产日期", "planned_f2d", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际生产日期", "actual_f2d", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("延迟生产", "delayed_production", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提前生产", "advance_production", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VDC 入库时间", "vdc_goods_recvd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入 HUB 日期", "dda_hub_entryd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("当前位置", "location_id_description", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上一位置", "location_from_description", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("下一位置", "location_to_description", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售锁定状态", "hold_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车龄", "veh_age", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆 VDC 库龄", "aging", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆经销商库龄", "dlr_age", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计批售日期", "pw", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计零售日期", "pr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计批售月", "pw_year_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计零售月", "pr_year_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("物流到店时间", "dlr_sto_age", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售付款方式", "payment", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("基础车型批售价", "base_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("基础车型建议零售价", "base_price_msrp", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售价格", "veh_ws_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车建议零售价", "veh_msrp", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("财务释放日期", "frd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售付款提交日期", "ws_payment_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("互联驾驶状态", "cd_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("财务库龄", "ws_py_age", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库日期", "sto_ind", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售订单状态", "rt_custr_order_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("售后召回标识", "ds_remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售订单创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际零售经销商代码", "rt_dealer_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称缩写", "company_short_name_en", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商中文简称名称", "company_short_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "customer_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("二手车", "is_used_car", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机型号", "engine_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("新能源类型", "fuel_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CKD 车型", "ckd_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("CKD 批号", "ckd_lot_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("搜索代码-C1", "search_code1", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("搜索代码-C2", "search_code2", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("共享车辆", "sharing_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计到港日期", "eta", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际到港/下线日期", "ata", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售锁车类型", "hold_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("港口", "warehouse_desc_zh", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制建议零售价选装", "option_total_price", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制建议零售价加装", "flex_optn_msrp", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售日期", "wsd", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售日期", "retial_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单原始创建者类型", "order_crtn_dlr", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("记录最后修改时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("国产/进口", "bba_nsc", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("全部专属定制批售价", "option_total_wsprice", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("加装部分专属定制批售价", "flex_optn_wsprice", "varchar(64)", "", ""));




        }

        private void initRS()
        {
            DDLTable newtable;
            DDLColumn column;
            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_stock", "27.RS104011000-同步整车库存"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("vs_stock_id", "vs_stock_id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("底盘号", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存状态", "own_stock_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("系列组", "second_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系列", "third_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "four_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "five_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("年款", "year_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车身颜色", "body_color", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰", "interior", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否配车锁定", "occupancy_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("驱动方式", "drive_way", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("排量属性", "exhaust_quantity", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否 NEV", "is_nev", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("新能源类型", "nev_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车龄", "vehicle_years", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机功率", "engine_power", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机型号", "engine_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆备注", "remark_one", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库名称", "storage_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库日期", "first_stock_in_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("再次入库日期", "latest_stock_in_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库类型", "entry_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商实际库龄", "really_stock_in_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("财务库龄", "finance_release_date_years", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("质损状态", "traffic_mar_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("共享车辆", "is_shared_vehicles", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开放销售", "is_open_sales", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆来源", "vehicle_sources", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("调拨经销商", "ws_dealer_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生产订单号", "product_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购订单号", "ws_order_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("IVSR 状态", "ws_status_three", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("WIT 状态", "ws_status_one", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("WIT 次状态", "ws_status_two", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购订单状态", "ws_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售订单类型", "ws_order_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配额类型", "quota_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("需求生产周", "req_prod_week", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际生产周", "conf_prod_week", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配额月", "quota_month", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售订单提报日期", "ws_order_sub_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际生产日期", "actual_product_day", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("实际到港/下线日期", "actual_arrival_day", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("VDC 入库时间", "vdc_entry_day", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("DDA/HUB 入库时间", "ddahub_entry_day", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("港口", "port_lctn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("物流到店时间", "dlr_ari_day", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售付款方式", "ws_py_method", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售付款提交日期", "ws_py_sub_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("财务释放日期", "finance_release_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制进价", "customized_input_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制建议零售价", "customized_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("裸车进价", "naked_input_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("裸车建议零售价", "naked_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("批售价格", "purchase_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车建议零售价", "complete_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车采购发票价格", "purchase_invoice_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制价格占总价百分比", "customized_sale_price_per", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("税率", "tax_rate", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("颜色价格", "color_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰价格", "interior_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("轮毂价格", "hub_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(column = new DDLColumn("内饰条价格", "Inter_decoration_strip_price", "decimal(20,4)", "", ""));
            column.JsonFieldName = "Interior_decoration_strip_price";
            newtable.Columns.Add(new DDLColumn("客户订单号", "so_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sale_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户订单状态", "so_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "consultant", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户签单日期", "contract_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票日期", "invoicing_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售上报日期", "presentation_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("交车日期", "confirmed_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("购车人手机号", "customer_tel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("购车人姓名", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票人姓名", "drawer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票人手机号", "drawer_tel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("机动车发票号", "invoice_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预留状态", "reserve_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预留销售顾问", "reserved_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("PDI 状态", "pdi_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("PDI 完成时间", "pdi_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("售后召回标识", "is_deleted", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("三包打印时间", "printing_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进口/国产", "vehicle_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆类型", "vehicle_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆库存_id", "vehicle_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(30)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_stock_individual", "27.RS104011000-同步整车库存个性选装列表"));
            newtable.Columns.Add(new DDLColumn("cs_id", "cs_id", "bigint", "是", "", true));
            newtable.Columns.Add(new DDLColumn("选装代码", "option_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("选装描述", "option_name_zh", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_stock_standard", "27.RS104011000-同步整车库存标配列表"));
            newtable.Columns.Add(new DDLColumn("cs_id", "cs_id", "bigint", "是", "", true));
            newtable.Columns.Add(new DDLColumn("标配代码", "standard_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("标配描述", "standard_des", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_so", "28.RS104011001-同步零售订单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单号", "so_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("订单状态", "so_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("合同号", "contract_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生成时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("首付款金额", "initial_payment", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("贷款金额", "loan_amounts", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("金融机构", "financial_institutions", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订金", "contract_earnest", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单优惠金额合计", "offset_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("机动车大票金额", "vehicle_ticket_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户订单总金额", "order_all_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("手机号", "customer_tel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("姓", "customer_surnames", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("名", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件类型", "customer_ctcode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件号码", "customer_certificate_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("省", "customer_province_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("市", "customer_city_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("地址", "customer_address", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "customer_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("手机号", "drawer_tel", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("姓", "drawer_surnames", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("名", "drawer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件类型", "drawer_ctcode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件号码", "drawer_certificate_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("省", "drawer_province_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("市", "drawer_city_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("地址", "drawer_address", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("付款方式", "pay_mode", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("开票时间", "invoicing_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("系统发票号", "invoice_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("增值税发票", "invoice_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "second_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系列代码", "third_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "fourth_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "five_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车身颜色", "body_color", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰", "interior", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆类别", "vehicle_purpose", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计交车时间", "delivering_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("轮毂", "hub", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰条", "interior_trim_strip", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("个性选装", "individual_options", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("裸车建议零售价", "naked_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("裸车报价", "naked_car_quotation", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制建议零售价", "customized_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属定制报价", "customized_quotation", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车建议零售价", "complete_sale_price", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("整车报价", "vehicle_quotation", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("精品建议零售总价", "boutique_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("精品报价总价", "boutique_quotation", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("一口价", "first_price_mark", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目名称", "other_fee", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否代收", "agency_receivable_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目报价", "other_services_amount", "decimal(20,4)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换类型", "whether_to_replace", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换品牌", "replacement_brand", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换车系", "replacement_series", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换车型", "replacement_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换底盘号", "replacement_vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换车首登日期", "replacement_time", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("置换车里程", "replacement_mileage", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否新车车主一致", "is_owner", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_so_jptc", "28.RS104011001-同步零售订单精品套餐"));
            newtable.Columns.Add(new DDLColumn("so_id", "so_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("精品套餐编码", "option_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("精品套餐名称", "option_name_zh", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_so_jp", "28.RS104011001-同步零售订单精品"));
            newtable.Columns.Add(new DDLColumn("so_id", "so_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("精品编码", "option_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("精品名称", "option_name_zh", "varchar(64)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_so_qtfw", "28.RS104011001-同步零售订单其他服务"));
            newtable.Columns.Add(new DDLColumn("so_id", "so_id", "bigint", "", "", true));
            newtable.Columns.Add(new DDLColumn("项目名称", "service_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否代收", "is_collecting", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("项目报价", "project_quotation", "varchar(64)", "", ""));

            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Order_Approve", "29.RS104011002-同步零售审批信息"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单号", "so_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批 ID", "order_approval_id", "long(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("订金状态", "deposit_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款状态", "payment_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退车状态", "vehicle_return_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否配车", "dispatched_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单来源", "order_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("合同号", "contract_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生成时间", "contract_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单价格合计", "order_all_amount", "decimal(12,2)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批类型", "audit_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批状态", "audit_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批意见", "audit_postil", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批人", "audit_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批时间", "audit_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_Delivery", "30.RS104011003-同步零售交车记录"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售订单号", "so_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("零售订单类型", "order_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆用途", "vehicle_use", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆当前里程", "current_mileage", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车牌号", "license_plate_number", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("上牌时间", "registration_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶证号", "registration_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("行驶证注册时间", "registration_created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("专属服务顾问", "service_consultant", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("驾照号", "driving_license_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票日期", "invoice_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("三包凭证打印时间", "three_guarantees_print_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户编号", "drawer_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "customer_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sale_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "consultant", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生产订单号", "product_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订金状态", "deposit_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("收款状态", "payment_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退车状态", "vehicle_return_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否配车", "dispatched_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单来源", "order_source", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批类型", "audit_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批状态", "audit_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批意见", "audit_postil", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批人", "audit_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("审批时间", "audit_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("激活码", "activation_code", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("主区域", "main_area", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("推荐联系方式", "recommended_contact", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("激活状态", "activation_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("失败原因", "failed_reason", "varchar(255)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_InOutRecord", "31.RS104011004-同步车辆出入库记录"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库单号", "in_out_stock_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("底盘号", "vin", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "second_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "third_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "four_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "five_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("年款", "year_model", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("颜色", "color", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("内饰", "interior", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库时间", "out_stock_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("仓库", "storage_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购订单号", "product_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库类型", "out_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否开放销售", "is_open_sales", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库类型", "in_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_by", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("进口/国产", "vehicle_sources", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("出库金额（含税）", "vehicle_ticket_amount", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("发动机号", "engine_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("采购入库备注", "remark", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("入库日期", "in_stock_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("品牌", "first_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("是否新车", "invoice_category", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("更新人", "updated_by", "varchar(64)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_Car_reback", "32.RS104011005-同步零售客户退车单"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退车单号", "so_no", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("退车状态", "vehicle_return_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("原销售单号", "old_so_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "consultant", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "drawer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "second_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系列代码", "third_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "four_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "five_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("底盘号", "sales_vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退车申请日期", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("退车原因", "return_reason", "varchar(255)", "", ""));
            newtable.Columns.Add(new DDLColumn("发票号码", "invoice_no", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));



            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_retail", "33.RS104011006-同步零售记录"));
            newtable.Columns.Add(new DDLColumn("经销商代码", "owner_code", "varchar(64)", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("零售提报 id", "retail_presentation_id", "int(30)", "是", ""));
            newtable.Columns.Add(new DDLColumn("零售类型", "retail_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提报人", "presentation_operator", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("提报日期", "presentation_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("底盘号", "vin", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("生产订单号", "product_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("库存状态", "own_stock_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车辆类型", "vehicle_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系", "second_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车系列代码", "third_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("车型", "four_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("配置", "five_id", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户订单号", "so_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("订单状态", "so_status", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售类型", "sale_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("预计交车时间", "delivering_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("交车时间", "confirmed_date", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("销售顾问", "consultant", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户类型", "customer_type", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("证件号码", "certificate_no", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("手机号", "customer_phone", "varchar(64)", "", ""));
            newtable.Columns.Add(new DDLColumn("地址", "address", "varchar(255)", "", ""));


            ddlConfig.Tables.Add(newtable = new DDLTable("ODS_BMW_SPARK", "ODS_RS_SJZY", "34.RS104011007-同步试驾和占用记录"));
            newtable.Columns.Add(new DDLColumn("record_id", "record_id", "bigint", "是", ""));
            newtable.Columns.Add(new DDLColumn("经销商代码", "company_code", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("经销商名称", "company_name_cn", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("车架号", "vs_stock_id", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("开始时间", "use_start_time", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("开始里程", "use_mileage", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("试驾路线代码", "way_id", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户名称", "customer_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("客户 ID", "customer_id", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("顾问名称", "consultant_id", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("占用类型", "use_type", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建人", "created_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("创建时间", "created_at", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改人", "updated_name", "varchar(36)", "", ""));
            newtable.Columns.Add(new DDLColumn("修改时间", "updated_at", "varchar(36)", "", ""));



        }

        [Test]
        public void DDLToSQLTest()
        {

            const string outputpath = @"c:\1\2.txt";
            GenerateEngine.Do<Work, DDLTable>(new Work() { ddlModel = ddlConfig }, new SQLWorkPipe(outputpath));


        }


        [Test]
        public void DDLToJavaBeanTest()
        {


            javaBeanConfig = new JavaBeanModel();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.bmwspark.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.bmwspark.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\bean\third-bmwspark-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            //JavaGenerator toJavaBean = new JavaGenerator();
            //toJavaBean.GenerateBean(javaBeanConfig);

            GenerateEngine.Do<JavaWorkModel, JavaClass>(new JavaWorkModel() { BeanConfig = javaBeanConfig }, new JavaBeanPipe());


        }





        [Test]
        public void DDLToJavaAll()
        {

            javaBeanConfig = new JavaBeanModel();
            javaBeanConfig.DDLConfig = ddlConfig;
            javaBeanConfig.PackageName = "com.wintop.third.bmwspark.bean";
            javaBeanConfig.VOPackageName = "com.wintop.third.bmwspark.vo";
            javaBeanConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-bean\src\main\java";
            javaBeanConfig.OmmitPrefix = "ODS";

            //JavaGenerator javaGenerator = new JavaGenerator();
            //javaGenerator.GenerateBean(javaBeanConfig);

            //GenerateEngine.Do<JavaWorkModel, JavaClass>(new JavaWorkModel() { BeanConfig = javaBeanConfig }, new JavaBeanPipe());

            JavaDaoModel javaDaoConfig = new JavaDaoModel(null);

            javaDaoConfig.PackageName = "com.wintop.third.bmwspark.mapper";
            javaDaoConfig.JavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-dao\src\main\java";


            JavaMapperModel javaMapperConfig = new JavaMapperModel(javaDaoConfig);
            javaMapperConfig.MapperDirectory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-dao\src\main\resources\mybatis\mapper";

            JavaCodeConfig javaCodeConfig = new JavaCodeConfig(javaDaoConfig);

            javaCodeConfig.ModelPackageName = "com.wintop.third.bmwspark.model";
            javaCodeConfig.ModelJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ServicePackageName = "com.wintop.third.bmwspark.service";
            javaCodeConfig.ServiceJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ServiceImplPackageName = "com.wintop.third.bmwspark.service.impl";
            javaCodeConfig.ServiceImplJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java";

            javaCodeConfig.ControllerPackageName = "com.wintop.third.bmwspark.controller";
            javaCodeConfig.ControllerJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java";
            //            javaCodeConfig.ServiceCodeTemplateFile =javaCodeConfig.ServiceImplCodeTemplateFile = javaCodeConfig.ControllerCodeTemplateFile = "JavaCodeBWM.cshtml";


            if ("".Length == 20)
            {

                ddlConfig.Tables.ForEach(t =>
                {
                    javaDaoConfig.JavaClass = t.RelatedClsss as JavaClass;
                    //javaGenerator.GenerateDao(javaDaoConfig, javaMapperConfig);
                    //javaGenerator.GenerateCode(javaCodeConfig, t.RelatedClsss as JavaClass);

                });
            }

            GenerateEngine.Do(new JavaWorkModel()
            {
                PrepareAction = (w) =>
                {
                    (w as JavaWorkModel).ddlModel.Prepare();
                },
                BeanConfig = javaBeanConfig,
                ddlModel = ddlConfig,


                MapperDirectory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-dao\src\main\resources\mybatis\mapper",
                
                DaoPackageName = "com.wintop.third.bmwspark.mapper",
                DaoJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-dao\src\main\java",

                ServicePackageName = "com.wintop.third.bmwspark.service",
                ServiceJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java",

                ModelPackageName = "com.wintop.third.bmwspark.model",
                ModelJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java",

                ServiceImplPackageName = "com.wintop.third.bmwspark.service.impl",
                ServiceImplJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java",

                ControllerPackageName = "com.wintop.third.bmwspark.controller",
                ControllerJavaDiretory = @"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\src\main\java",


                Pipes = {
                new SQLWorkPipe(@"D:\fgq\temp\codegeneratetest\third-bmwspark-service-api\sql.txt"),
                    new JavaBeanPipe(),
                    new DefaultPipe<JavaDaoModel>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaDao.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {
                            (m as JavaDaoModel).PackageName = (w as JavaWorkModel).DaoPackageName;
                            string rootDir = CodeUtil.PrepareJavaRoot((w as JavaWorkModel).DaoJavaDiretory, (m as JavaDaoModel).DaoPackageName);
                            string filePath = rootDir + Path.DirectorySeparatorChar + (m as JavaDaoModel).DaoName + ".java";
                            p.OutputPath = filePath;
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaDaoModel> models = new List<JavaDaoModel>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass) { SplitReadWrite = true, ForRead = true, ForWrite = false });
                                models.Add((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass) { SplitReadWrite = true, ForRead = false, ForWrite = true });
                            }));
                            return models;

                        }
                    },
                    new DefaultPipe<JavaMapperModel>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaMapper.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {

                            string rootDir = (w as JavaWorkModel).MapperDirectory + ((m as JavaMapperModel).SplitReadWrite ? ((m as JavaMapperModel).ForRead ? "\\read" : "\\write") : "");
                            string filePath = rootDir + Path.DirectorySeparatorChar + (m as JavaMapperModel).MapperName + ".xml";
                            p.OutputPath = filePath;
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaMapperModel> models = new List<JavaMapperModel>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add((CodeGenerate.Config.JavaMapperModel)new CodeGenerate.Config.JavaMapperModel(new JavaDaoModel(t.RelatedClsss as JavaClass)) { SplitReadWrite = true, ForRead = true, ForWrite = false });
                                models.Add((CodeGenerate.Config.JavaMapperModel)new CodeGenerate.Config.JavaMapperModel(new JavaDaoModel(t.RelatedClsss as JavaClass)) { SplitReadWrite = true, ForRead = false, ForWrite = true });
                            }));
                            return models;

                        }
                    },
                    new DefaultPipe<JavaCodeConfig>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaCode.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {
                            (m as JavaCodeConfig).ModelPackageName = (w as JavaWorkModel).ModelPackageName;
                            string rootDir = CodeUtil.PrepareCodeRoot((w as JavaWorkModel).ModelJavaDiretory, (w as JavaWorkModel).ModelPackageName);
                            p.OutputPath = rootDir + Path.DirectorySeparatorChar + (m as JavaCodeConfig).ModelName + ".java";
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaCodeConfig> models = new List<JavaCodeConfig>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add(new JavaCodeConfig((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass)) { JavaClass = t.RelatedClsss as JavaClass, ForModel = true });
                            }));
                            return models;

                        }
                    },
                    new DefaultPipe<JavaCodeConfig>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaCode.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {
                            (m as JavaCodeConfig).ServicePackageName = (w as JavaWorkModel).ServicePackageName;
                            string rootDir = CodeUtil.PrepareCodeRoot((w as JavaWorkModel).ServiceJavaDiretory, (w as JavaWorkModel).ServicePackageName);
                            p.OutputPath = rootDir + Path.DirectorySeparatorChar + (m as JavaCodeConfig).ServiceName + ".java";
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaCodeConfig> models = new List<JavaCodeConfig>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add(new JavaCodeConfig((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass)) { JavaClass = t.RelatedClsss as JavaClass, ForService = true });
                            }));
                            return models;

                        }
                    },
                    new DefaultPipe<JavaCodeConfig>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaCode.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {
                            (m as JavaCodeConfig).ServiceImplPackageName = (w as JavaWorkModel).ServiceImplPackageName;
                            string rootDir = CodeUtil.PrepareCodeRoot((w as JavaWorkModel).ServiceImplJavaDiretory, (w as JavaWorkModel).ServiceImplPackageName);
                            p.OutputPath = rootDir + Path.DirectorySeparatorChar + (m as JavaCodeConfig).ServiceImplName + ".java";
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaCodeConfig> models = new List<JavaCodeConfig>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add(new JavaCodeConfig((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass)) { JavaClass = t.RelatedClsss as JavaClass, ForServiceImpl = true });
                            }));
                            return models;

                        }
                    },
                    new DefaultPipe<JavaCodeConfig>()
                    {
                        PrepareVarAction = (w, p) =>
                        {
                            p.RazorTplFilePath = FileUtil.GetInternalTemplateFilePath("JavaCode.cshtml");
                        },
                        BeforeEachModelAction = (w, p, m) =>
                        {
                            (m as JavaCodeConfig).ControllerPackageName = (w as JavaWorkModel).ControllerPackageName;
                            string rootDir = CodeUtil.PrepareCodeRoot((w as JavaWorkModel).ControllerJavaDiretory, (w as JavaWorkModel).ControllerPackageName);
                            p.OutputPath = rootDir + Path.DirectorySeparatorChar + (m as JavaCodeConfig).ControllerName + ".java";
                        },
                        GetModelsAction = (w, p) =>
                        {
                            List<JavaCodeConfig> models = new List<JavaCodeConfig>();
                            (w as JavaWorkModel).ddlModel.Tables.ForEach((Action<DDLTable>)((t) =>
                            {
                                models.Add(new JavaCodeConfig((CodeGenerate.Config.JavaDaoModel)new CodeGenerate.Config.JavaDaoModel(t.RelatedClsss as JavaClass)) { JavaClass = t.RelatedClsss as JavaClass, ForController = true });
                            }));
                            return models;

                        }
                    }



                }
        });
            Console.WriteLine("done");
            Assert.Pass();




        }


}
}

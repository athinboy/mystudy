package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfTextPosition;

import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class CommecialDocument extends InsOrderDocument {

    public CommecialDocument(int pageIndex) {
        super(pageIndex);
        init();
    }

    private void init() {
        this.orderItemInfos.add(new OrderItemInfo("policyNumber", "保险单号"));
        this.orderItemInfos.add(new OrderItemInfo("effectiveDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date
        this.orderItemInfos.add(new OrderItemInfo("expireDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date
        this.orderItemInfos.add(new OrderItemInfo("insuredName", "被保险人"));
        this.orderItemInfos.add(new OrderItemInfo("insuredPhone", "联系电话"));
        //证件号
        this.orderItemInfos.add(new OrderItemInfo("insuredIDNumer", "被保险人((身份证)|(证件))号码"));
        //性别
        this.orderItemInfos.add(new OrderItemInfo("insuredSex", false, "性别"));
        //出生日期
        this.orderItemInfos.add(new OrderItemInfo("insuredBirthday", false, "出生日期"));//string
        this.orderItemInfos.add(new OrderItemInfo("insuredEMail", "[Mm]ail"));
        //通讯地址
        this.orderItemInfos.add(new OrderItemInfo("insuredContactAddress", "(通讯){0,1}地址"));
        this.orderItemInfos.add(new OrderItemInfo("platNum", "号牌号码"));
        this.orderItemInfos.add(new OrderItemInfo("vin", "vin", "VIN", "车架号"));
        //发动机号
        this.orderItemInfos.add(new OrderItemInfo("engineNumber", "发动机号"));
        //初登日期
        this.orderItemInfos.add(new OrderItemInfo("initialRegistration", "初登日期", "初次登记日期"));//String
        //厂牌型号
        this.orderItemInfos.add(new OrderItemInfo("factoryPlateModel", "厂牌型号"));
        //核定载质量
        this.orderItemInfos.add(new OrderItemInfo("approvedLoad", true, true, "(核定载质量)|(核定载客/载质量)"));
        //核定载客人数
        this.orderItemInfos.add(new OrderItemInfo("approvedPassengersCapacity", "核定载客"));//
        //使用性质
        this.orderItemInfos.add(new OrderItemInfo("useCharacter", "使用性质"));//
        //机动车种类
        this.orderItemInfos.add(new OrderItemInfo("vehicleType", "机动车种类"));//

        /**
         * 排量
         */
        this.orderItemInfos.add(new OrderItemInfo("displacement", "排量"));//

        /**
         * 功率
         */
        this.orderItemInfos.add(new OrderItemInfo("capacityFactor", "功率"));//

        /**
         * 车损险每次事故绝对免赔额
         */
        this.orderItemInfos.add(new OrderItemInfo("deductible", false, "车损险每次事故绝对免赔额"));//

        /**
         * 商业险保险费合计
         */
        this.orderItemInfos.add(new OrderItemInfo("insuranceFee", ContentValueTypeEnum.Money, "保险{0,1}费合计"));//BigDecimal

        /**
         * 银行流水号
         */
        this.orderItemInfos.add(new OrderItemInfo("bankSerialNumber", false, "(银行){0,1}流水号"));//

        /**
         * 收费确认时间
         */
        this.orderItemInfos.add(new OrderItemInfo("chargeConfirmationTime", ContentValueTypeEnum.DateTime, "[收保]费确认时间"));//Date

        /**
         * 投保确认时间
         */
        this.orderItemInfos.add(new OrderItemInfo("insuranceConfirmationTime", ContentValueTypeEnum.DateTime, "生成有效保单时间", "有效保单生成时间"));//Date

        /**
         * 经办人
         */
        this.orderItemInfos.add(new OrderItemInfo("agentName", "经办(人{0,1})"));//String

        /**
         * 出单日期
         */
        this.orderItemInfos.add(new OrderItemInfo("agentDate", ContentValueTypeEnum.Date, "[出签]单日期"));//Date

    }

    @Override
    public void parseContent(final List<PdfTextPosition> textPositions) {
        super.parseContent(textPositions);
    }
}

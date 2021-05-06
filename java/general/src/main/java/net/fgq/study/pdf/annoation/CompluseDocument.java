package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.pdfbox.pdmodel.PDDocument;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class CompluseDocument extends InsOrderDocument {

    public CompluseDocument(int pageIndex) {
        super(pageIndex);
        init();
    }

    private void init() {

        OrderItemInfo itemInfo;
        /**
         * 死亡伤残赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("deathCompensation", ContentValueTypeEnum.Money, "([^任]|^)死亡伤残赔偿限额"));//BigDecimal

        /**
         * 无责任死亡伤残赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("noLiabilityDeathCompensation", ContentValueTypeEnum.Money, "无责任死亡伤残赔偿限额"));//BigDecimal

        /**
         * 医疗费用赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("medicalCompensation", ContentValueTypeEnum.Money, "([^任]|^)医疗费用赔偿限额"));//BigDecimal

        /**
         * 无责任医疗费用赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("noLiabilityMedicalCompensation", ContentValueTypeEnum.Money, "无责任医疗费用赔偿限额"));//BigDecimal

        /**
         * 财产损失赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("propertyCompensation", ContentValueTypeEnum.Money, "([^任]|^)财产损失赔偿限额"));//BigDecimal

        /**
         * 无责任财产损失赔偿限额
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("noLiabilityPropertyCompensation", ContentValueTypeEnum.Money, "无责任财产损失赔偿限额"));//BigDecimal

        /**
         * 与道路交通安全违法行为和道路交通事故相联系的浮动比率
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("floatingRate", false,
                "与道路交通安全违法行为和道路交通事故相联系的浮动比率："));//

        /**
         * 交强险保费合计
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("totalCompulsoryFee", ContentValueTypeEnum.Money, "保(险{0,1})费合计"));//BigDecimal

        /**
         * 车船税费用合计
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vehicleTaxFee", ContentValueTypeEnum.Money, "(车船税费用){0,1}合计"));//BigDecimal

        /**
         * 代收车船税-整备质量
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtCurbWeight", false, "整备质量"));//

        /**
         * 代收车船税-纳税人识别号
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtTaxpayerIdentification", false, "纳税人识别号"));//

        /**
         * 代收车船税-当年应缴
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtCurrentPayable", ContentValueTypeEnum.Money, false, "当年应缴"));//

        /**
         * 代收车船税-往年应缴
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtPastPayable", ContentValueTypeEnum.Money, false, "往年[应补]缴"));//

        /**
         * 代收车船税-滞纳金
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtLateFee", ContentValueTypeEnum.Money, false, "滞纳金"));//

        /**
         * 代收车船税-完税凭证号
         */
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtPaymentNo", false, "完税凭证号([（\\(]减免税证明号[\\)）])?"));//
        itemInfo.getValueRegstr().add("[0-9a-zA-Z]+");

        //代收车船税-开具税务机关
        this.orderItemInfos.add(itemInfo = new OrderItemInfo("vtKJSWJG", false, "开具税务机关"));//

        this.constructItemArea(this.addInfoArea("DSCCS", "代收车船税", "代收车船")
                , "vehicleTaxFee"
                , "vtCurbWeight"
                , "vtTaxpayerIdentification"
                , "vtCurrentPayable"
                , "vtPastPayable"
                , "vtLateFee"
                , "vtPaymentNo"

        );

    }

    @Override
    protected void specialOrder(PDDocument pdfDocument) throws Exception {

        super.specialOrder(pdfDocument);
        switch (this.insCompanyType) {
            case tpyang:
                this.getOrderItemInfo("platNum").setRequire(false);
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(ArrayUtils.addAll(
                        this.getOrderItemInfo("insuranceConfirmationTime").getKeySigns(), "[收保]费确认时间"));
//                this.getOrderItemInfo("insuredContactAddress").setKeySigns(new String[]{"被保险人地址"});

                break;
            case renshou:
                OrderItemInfo o = this.getOrderItemInfo("platNum");
                o.setRequire(false);
                break;
            case taiping:
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(new String[]{"保费确认时间"});
                break;
        }
    }

}

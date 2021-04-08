package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfTextPosition;

import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class CompluseDocument extends InsOrderDocument {

    public CompluseDocument(int pageIndex) {
        super(pageIndex);
        init();
    }

    private void init() {

        /**
         * 死亡伤残赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("deathCompensation", ContentValueTypeEnum.Money, "死亡伤残赔偿限额"));//BigDecimal

        /**
         * 无责任死亡伤残赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("noLiabilityDeathCompensation", ContentValueTypeEnum.Money, "无责任死亡伤残赔偿限额"));//BigDecimal

        /**
         * 医疗费用赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("medicalCompensation", ContentValueTypeEnum.Money, "医疗费用赔偿限额"));//BigDecimal

        /**
         * 无责任医疗费用赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("noLiabilityMedicalCompensation", ContentValueTypeEnum.Money, "无责任医疗费用赔偿限额"));//BigDecimal

        /**
         * 财产损失赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("propertyCompensation", ContentValueTypeEnum.Money, "财产损失赔偿限额"));//BigDecimal

        /**
         * 无责任财产损失赔偿限额
         */
        this.orderItemInfos.add(new OrderItemInfo("noLiabilityPropertyCompensation", ContentValueTypeEnum.Money, "无责任财产损失赔偿限额"));//BigDecimal

        /**
         * 与道路交通安全违法行为和道路交通事故相联系的浮动比率
         */
        this.orderItemInfos.add(new OrderItemInfo("floatingRate", false, "与道路交通安全违法行为和道路交通事故"));//

        /**
         * 交强险保费合计
         */
        this.orderItemInfos.add(new OrderItemInfo("totalCompulsoryFee", ContentValueTypeEnum.Money, "保(险{0,1})费合计"));//BigDecimal

        /**
         * 车船税费用合计
         */
        this.orderItemInfos.add(new OrderItemInfo("vehicleTaxFee", ContentValueTypeEnum.Money, "(车船税费用){0,1}合计"));//BigDecimal

        /**
         * 代收车船税-整备质量
         */
        this.orderItemInfos.add(new OrderItemInfo("vtCurbWeight", false, "整备质量"));//

        /**
         * 代收车船税-纳税人识别号
         */
        this.orderItemInfos.add(new OrderItemInfo("vtTaxpayerIdentification", false, "纳税人识别号"));//

        /**
         * 代收车船税-当年应缴
         */
        this.orderItemInfos.add(new OrderItemInfo("vtCurrentPayable", false, "当年应缴"));//

        /**
         * 代收车船税-往年应缴
         */
        this.orderItemInfos.add(new OrderItemInfo("vtPastPayable", false, "往年应缴"));//

        /**
         * 代收车船税-滞纳金
         */
        this.orderItemInfos.add(new OrderItemInfo("vtLateFee", false, "滞纳金"));//

        /**
         * 代收车船税-完税凭证号
         */
        this.orderItemInfos.add(new OrderItemInfo("vtPaymentNo", false, "完税凭证号"));//

        this.setItemGroup(this.addInfoGroup("DSCYS", "代收车船税")
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
    public void parseContent(final List<PdfTextPosition> textPositions) {
        super.parseContent(textPositions);
    }
}

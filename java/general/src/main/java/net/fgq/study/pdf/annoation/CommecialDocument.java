package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfTextPosition;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.pdfbox.pdmodel.PDDocument;

import java.util.Arrays;
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

        /**
         * 车损险每次事故绝对免赔额
         */
        this.orderItemInfos.add(new OrderItemInfo("deductible", false, "车损险每次事故绝对免赔额"));//

        /**
         * 保险费合计
         */
        this.orderItemInfos.add(new OrderItemInfo("insuranceFee", ContentValueTypeEnum.Money, "保险{0,1}费合计"));//BigDecimal

    }

    @Override
    protected void specialOrder() {
        super.specialOrder();
        switch (this.insCompanyType) {

            case taiping:
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(new String[]{"保费确认时间"});
                break;
            case pingan:
                this.getOrderItemInfo("insuredName").setKeySigns(ArrayUtils.addAll(
                        this.getOrderItemInfo("insuredName").getKeySigns(), "正式名称"));
                this.getOrderItemInfo("insuredName").setValueMultiLine(true);
                break;
            case tpyang:
                this.getOrderItemInfo("platNum").setRequire(false);

                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(ArrayUtils.addAll(
                        this.getOrderItemInfo("insuranceConfirmationTime").getKeySigns(), "[收保]费确认时间"));

                //this.getOrderItemInfo("insuredContactAddress").setKeySigns(new String[]{"被保险人地址"});

                break;
            case renshou:

                this.getCombineLabelSign().add("姓名/名称");

                OrderItemInfo o = this.getOrderItemInfo("platNum");
                o.setRequire(false);
                this.getOrderItemInfo("insuredName").setKeySigns(new String[]{"姓名/名称"});
                this.getOrderItemInfo("engineNumber").setValueMultiLine(true);
                this.getOrderItemInfo("vin").setRequire(false);


                //不可使用，人寿的 被保险人 只占用一行文字，无法提取右侧的三行文本
//                this.constructItemArea(this.addInfoArea("BBXR", "被保险人")
//                        , "insuredName"
//                        , "insuredPhone"
//                        , "insuredIDNumer"
//                        , "insuredSex"
//                        , "insuredBirthday"
//                        , "insuredEMail"
//                        , "insuredContactAddress");


                break;
            case renbao:
                this.getOrderItemInfo("insuredIDNumer").setRequire(false);
                this.getOrderItemInfo("insuredContactAddress").setRequire(false);
                this.getOrderItemInfo("insuredPhone").setRequire(false);
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(new String[]{"收费确认时间"});
                break;
        }
    }

}

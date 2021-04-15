package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfTextPosition;
import org.apache.pdfbox.pdmodel.PDDocument;

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

        switch (this.insCompanyType) {
            case tpyang:
                this.getOrderItemInfo("platNum").setRequire(false);
                break;
            case renshou:
                OrderItemInfo o = this.getOrderItemInfo("platNum");
                o.setRequire(false);
                break;
        }
    }

}

package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class RenBaoTable extends Table {

    public RenBaoTable(int pageIndex, Rectangle headRect,  String jsonKey) {

        super(pageIndex, headRect, "提示：除法律法规另有约定外，投保人拥有保险合同解除",  jsonKey);
        this.init();
        this.setLeftReferenceText("本保单投保人为");
        this.setTopReferenceText("年平均行驶里程");
        this.getRightReferenceText().add("单有效期内全国城市中心区100公里以内不限次免费故障车救");
    }

    private void init() {

    }

}

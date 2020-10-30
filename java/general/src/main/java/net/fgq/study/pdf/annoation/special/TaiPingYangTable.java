package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class TaiPingYangTable extends Table {

    public TaiPingYangTable(int pageIndex, Rectangle headRect, String jsonKey) {

        super(pageIndex, headRect, "保险期间：自",  jsonKey);
        this.init();
//        this.setLeftReferenceText("被保险人证件号码");
//        this.setTopReferenceText("核定载质量");
//        this.getRightReferenceText().add("本保单承保非营业车辆");
//        this.getRightReferenceText().add("故障救援服务仅限");
//        this.getRightReferenceText().add("投保车辆在当地覆盖区域使用");

    }

    private void init() {
        this.setCellLineSpace(1);
    }

}

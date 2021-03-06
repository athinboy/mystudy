package net.fgq.study.pdf.annoation.special.table;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/29
 */
public class RenBaoNewTable extends Table {

    public RenBaoNewTable(int pageIndex, Rectangle headRect, String footSign) {

        super(pageIndex, headRect, footSign);
        this.init();

    }

    public RenBaoNewTable(int pageIndex, Rectangle headRect, List<Column> columns) {
        super(pageIndex, headRect);
        this.init();

    }

    private void init() {
        this.setCellLineSpace(3);
    }
}

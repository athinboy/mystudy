package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/29
 */
public class RenBaoNewTable extends Table {

    public RenBaoNewTable(int pageIndex, Rectangle headRect, String footSign, List<Column> columns, String jsonKey) {

        super(pageIndex, headRect, footSign, columns, jsonKey);
        this.init();

    }

    public RenBaoNewTable(int pageIndex, Rectangle headRect, Rectangle footRect, List<Column> columns, String jsonKey) {
        super(pageIndex, headRect, footRect, columns, jsonKey);
        this.init();

    }

    private void init() {
        this.setCellLineSpace(2.5F);
    }
}

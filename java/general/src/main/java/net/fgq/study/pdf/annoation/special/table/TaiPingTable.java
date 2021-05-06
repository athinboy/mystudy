package net.fgq.study.pdf.annoation.special.table;

import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class TaiPingTable extends Table {

    public TaiPingTable(int pageIndex, Rectangle headRect) {

        super(pageIndex, headRect, "除法律法规另有约定外，涉及本保险");
        this.init();

    }

    private void init() {
        this.setCellLineSpace(1);
    }

}

package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class PingAnNewTable extends Table {

    public PingAnNewTable(int pageIndex, Rectangle headRect, String footSign, List<Column> columns, String jsonKey) {

        super(pageIndex, headRect, footSign, columns, jsonKey);
        this.init();

    }

    public PingAnNewTable(int pageIndex, Rectangle headRect, Rectangle footRect, List<Column> columns, String jsonKey) {
        super(pageIndex, headRect, footRect, columns, jsonKey);
        this.init();

    }

    private void init() {
        this.setCellLineSpace(0F);
    }

    @Override
    public void adjustCellText(List<List<PdfTextPosition>> tabCellTexts) {
        super.adjustCellText(tabCellTexts);
        List<PdfTextPosition> col0Texts = tabCellTexts.get(0);
        PdfTextPosition zzfw = null;
        for (int i = 0; i < col0Texts.size() - 1; i++) {
            if ("增值服务".equals(col0Texts.get(i).getText())) {
                zzfw = col0Texts.get(i);
                col0Texts.remove(i);
                break;
            }
        }

        for (int i = 0; i < col0Texts.size() - 1; i++) {
            if (col0Texts.get(i).getText().contains("附加机动车增值服务特约")
                    && false == col0Texts.get(i + 1).getText().contains("附加机动车增值服务")) {
                col0Texts.get(i).setText(col0Texts.get(i).getText() + col0Texts.get(i + 1).getText());
                if (zzfw != null) {
                    col0Texts.get(i).getRectangle().x = zzfw.getRectangle().x;
                    col0Texts.get(i).getRectangle().width += zzfw.getRectangle().width;
                }
                col0Texts.remove(i + 1);
                continue;

            }
        }

    }

}

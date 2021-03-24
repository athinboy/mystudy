package net.fgq.study.pdf.annoation.special.table;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class PingAnNewTable extends Table {

    public PingAnNewTable(int pageIndex, Rectangle headRect, String jsonKey) {

        super(pageIndex, headRect, "车损险每次事故绝对免赔额", jsonKey);
        this.init();
        this.getFootSigns().add("保险费合计");
       this.setLeftReferenceText("争议解决方式");
       this.getRightReferenceText().add("保及理赔等信息您可通过本公司网页www");
        this.getRightReferenceText().add("险合同约定的保险事故造成被保险车辆损失");
        this.getRightReferenceText().add("援服务区域覆盖全国城市中心区100公里以内可");
       this.setTopReferenceText("保险期间");
    }

    private void init() {
        this.setCellLineSpace(0);
    }

    @Override
    public void adjustColCellText(List<List<PdfTextPosition>> tabCellTexts) {
        super.adjustColCellText(tabCellTexts);
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

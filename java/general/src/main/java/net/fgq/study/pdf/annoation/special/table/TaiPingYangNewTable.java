package net.fgq.study.pdf.annoation.special.table;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.TableParse;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.Arrays;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/30
 */
public class TaiPingYangNewTable extends Table {

    public TaiPingYangNewTable(int pageIndex, Rectangle headRect) {

        super(pageIndex, headRect, "保险费合计（人民币大写）");
        this.init();
        this.setLeftReferenceText("保险费合计（人民币大写）");
        this.setTopReferenceText("核定载质量");
        this.getRightReferenceText().add("尊敬的客户：投保次日起，您可以通过本公司");
        this.getRightReferenceText().add("发生本保险合同约定的保险事故造成被保险车辆损失或第三者财产");
        this.getRightReferenceText().add("本保险单项下增值服务特约条款及其相关服务获取");
    }

    private void init() {
        this.setHeaderLineSpace(0);
        this.setDouleColumn(true);
    }

    @Override
    public void filterCell(List<PdfTextPosition> tabCellTexts) {

        super.filterCell(tabCellTexts);
        PdfTextPosition lvfd = null;

        for (int i = 0; i < tabCellTexts.size(); i++) {
            if ("费率浮动（+/-）".equals(tabCellTexts.get(i).getText())) {
                lvfd = tabCellTexts.get(i);
                tabCellTexts.remove(i--);
                continue;
            }
            if (lvfd != null
                    && TableParse.sameRow(this, lvfd, tabCellTexts.get(i))
                    && lvfd.getRectangle().getX() < tabCellTexts.get(i).getRectangle().getX()) {
                tabCellTexts.remove(i--);
            }

        }

    }

    @Override
    public void adjustColCellText(List<List<PdfTextPosition>> tabCellTexts) {
        super.adjustColCellText(tabCellTexts);
        //清除 费率浮动（+/- 及其右侧内容

    }

    @Override
    protected void adjustJsonItem(JSONArray tableJsonArr, JSONObject jsonitem) {

        Object v;
        JSONObject newJson = null;

        for (String s : Arrays.asList(new String[]{
                "insuranceType" + Column.dumplicateColSuffix,
                "liability" + Column.dumplicateColSuffix,
                "noDeductiblePercent" + Column.dumplicateColSuffix,
                "fee" + Column.dumplicateColSuffix})) {
            v = jsonitem.get(s);
            if (v != null) {
                newJson = newJson == null ? new JSONObject() : newJson;
                newJson.put(s.replace("1", ""), v);
                jsonitem.remove(s);
            }
        }
        if (newJson != null) {
            tableJsonArr.add(newJson);
        }

    }
}

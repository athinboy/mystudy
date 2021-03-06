package net.fgq.study.pdf.annoation.special.table;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;

import java.awt.*;
import java.util.Arrays;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/28
 */
public class TaiPingYangTable extends Table {

    public TaiPingYangTable(int pageIndex, Rectangle headRect) {

        super(pageIndex, headRect, "保险期间：自");
        this.init();
        this.setLeftReferenceText("被保险人地址");
        this.setTopReferenceText("初次登记日期");
        this.getRightReferenceText().add("本保单承保非营业车辆");
        this.getRightReferenceText().add("故障救援服务仅限");
        this.getRightReferenceText().add("投保车辆在当地覆盖区域使用");

    }

    private void init() {
        this.setCellLineSpace(1);
        this.setDouleColumn(true);
    }

    @Override
    protected void adjustJsonItem(JSONArray tableJsonArr, JSONObject jsonitem) {

        Object v;
        JSONObject newJson = null;

        for (String s : Arrays.asList(new String[]{
                "insuranceType" + Column.dumplicateColSuffix,
                "liability" + Column.dumplicateColSuffix,
                "fee" + Column.dumplicateColSuffix
        })) {
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

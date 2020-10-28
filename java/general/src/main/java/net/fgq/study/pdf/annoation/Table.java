package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Table {

    /**
     * 单元格行间最大空白
     */
    private float cellLineSpace = 2;

    /**
     * 列头区域
     */
    private Rectangle headRect;

    /**
     * 表尾区域
     */
    private Rectangle footRect;

    /**
     * 表尾文字标记
     */
    private String footSign;

    /**
     * 列
     */
    private List<Column> columns = new ArrayList<>();

    /**
     * json key name
     */
    private String jsonKey;

    private int pageIndex;

    public Table(int pageIndex, Rectangle headRect, String footSign, List<Column> columns, String jsonKey) {

        if (StringUtils.isBlank(jsonKey)
                || headRect == null
                || StringUtils.isBlank(footSign)
                || CollectionUtils.isEmpty(columns)) {
            throw new IllegalArgumentException();
        }

        this.headRect = headRect;
        this.footSign = footSign;
        this.columns = columns;
        this.jsonKey = jsonKey;
        this.pageIndex = pageIndex;
    }

    public Table(int pageIndex, Rectangle headRect, Rectangle footRect, List<Column> columns, String jsonKey) {
        if (StringUtils.isBlank(jsonKey)
                || headRect == null
                || footRect == null
                || CollectionUtils.isEmpty(columns)) {
            throw new IllegalArgumentException();
        }
        this.headRect = headRect;
        this.footRect = footRect;
        this.columns = columns;
        this.jsonKey = jsonKey;
        this.pageIndex = pageIndex;
    }

    /**
     * 调整单元格内文字信息。
     * 子类重新此方法，用于特殊格式的调整。
     */
    public void adjustCellText(List<List<PdfTextPosition>> tabCellTexts) {

    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public Rectangle getHeadRect() {
        return headRect;
    }

    public void setHeadRect(Rectangle headRect) {
        this.headRect = headRect;
    }

    public Rectangle getFootRect() {
        return footRect;
    }

    public void setFootRect(Rectangle footRect) {
        this.footRect = footRect;
    }

    public String getFootSign() {
        return footSign;
    }

    public void setFootSign(String footSign) {
        this.footSign = footSign;
    }

    public List<Column> getColumns() {
        return columns;
    }

    public void setColumns(List<Column> columns) {
        this.columns = columns;
    }

    public String getJsonKey() {
        return jsonKey;
    }

    public void setJsonKey(String jsonKey) {
        this.jsonKey = jsonKey;
    }

    public float getCellLineSpace() {
        return cellLineSpace;
    }

    public void setCellLineSpace(float cellLineSpace) {
        this.cellLineSpace = cellLineSpace;
    }
}

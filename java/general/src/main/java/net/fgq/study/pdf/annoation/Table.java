package net.fgq.study.pdf.annoation;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.TableParse;
import org.apache.commons.lang3.StringUtils;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Table {

    /**
     * 重复列。
     */
    private boolean douleColumn = false;

    /**
     * 单元格行间最大空白
     */
    protected int cellLineSpace = 2;

    /**
     * 列头行间最大空白
     */
    protected int headerLineSpace = 2;

    /**
     * 列头区域
     */
    protected Rectangle headRect;

    /**
     * 推测表格区域时，表格上方参考文字
     */
    protected String topReferenceText;
    /**
     * 推测表格区域时，参考文字右边界限为表格右边界限
     */
    protected List<String> rightReferenceText = new ArrayList<>();
    /**
     * 测表格区域时，参考文字左边距为表格左边距
     */
    protected String leftReferenceText;

    /**
     * 表尾文字标记
     */
    protected List<String> footSigns = new ArrayList<>();

    /**
     * 列
     */
    protected List<Column> columns = new ArrayList<>();

    /**
     * json key name
     */
    protected String jsonKey="items";

    protected int pageIndex;

    /**
     * 单元格需要重新排列。
     * 类似下列情况需要把内容调整到中间去：
     * --------------------------------
     * -|------a-------|--b--|---------
     * -|-------------0|----0|---------
     * -|-------------0|----0|---------
     */
    //protected boolean needRangeCell = false;

    /**
     * 推测的区域
     */
    protected Rectangle runtimeParseRectangle = null;

    public Table(int pageIndex, Rectangle headRect, String footSign) {

        if (StringUtils.isBlank(jsonKey)
                || StringUtils.isBlank(footSign)) {
            throw new IllegalArgumentException();
        }

        this.headRect = headRect;
        this.footSigns.add(footSign);

        this.jsonKey = jsonKey;
        this.pageIndex = pageIndex;
    }

    public Table(int pageIndex, Rectangle headRect) {
        if (StringUtils.isBlank(jsonKey)) {
            throw new IllegalArgumentException();
        }
        this.headRect = headRect;
        this.jsonKey = jsonKey;
        this.pageIndex = pageIndex;
    }

    public Column addColumn(int index, Column column) {
        column.setIndex(index);
        this.columns.add(column);
        return column;
    }

    public Column addColumn(Column column) {
        this.columns.add(column);
        return column;
    }

    /**
     * 调整单元格内文字信息。
     * 子类重新此方法，用于特殊格式的调整。
     */
    public void adjustColCellText(List<List<PdfTextPosition>> tabCellTexts) {

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

    public List<String> getFootSigns() {
        return footSigns;
    }

    public void setFootSigns(List<String> footSigns) {
        this.footSigns = footSigns;
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

    public int getCellLineSpace() {
        return cellLineSpace;
    }

    public void setCellLineSpace(int cellLineSpace) {
        this.cellLineSpace = cellLineSpace;
    }

    public int getHeaderLineSpace() {
        return headerLineSpace;
    }

    public void setHeaderLineSpace(int headerLineSpace) {
        this.headerLineSpace = headerLineSpace;
    }

    public String getTopReferenceText() {
        return topReferenceText;
    }

    public void setTopReferenceText(String topReferenceText) {
        this.topReferenceText = topReferenceText;
    }

    public List<String> getRightReferenceText() {
        return rightReferenceText;
    }

    public void setRightReferenceText(List<String> rightReferenceText) {
        this.rightReferenceText = rightReferenceText;
    }

    public String getLeftReferenceText() {
        return leftReferenceText;
    }

    public void setLeftReferenceText(String leftReferenceText) {
        this.leftReferenceText = leftReferenceText;
    }

    public Rectangle getRuntimeParseRectangle() {
        return runtimeParseRectangle;
    }

    public void setRuntimeParseRectangle(Rectangle runtimeParseRectangle) {
        this.runtimeParseRectangle = runtimeParseRectangle;
    }

    /**
     * 排列单元格
     *
     * @param textPositions
     */
    public List<List<PdfTextPosition>> rangeCellToCol(List<PdfTextPosition> textPositions, List<List<PdfTextPosition>> headTexts) {

        List<List<PdfTextPosition>> colTexts = new ArrayList<>();
        List<List<PdfTextPosition>> rowTexts;

        for (int i = 0; i < headTexts.size(); i++) {
            colTexts.add(new ArrayList<>());
        }
        rowTexts = rangeRow(new ArrayList<>(textPositions));
        for (int i = 0; i < rowTexts.size(); i++) {
            if (rowTexts.get(i).size() == this.columns.size()) {
                for (int j = 0; j < colTexts.size(); j++) {
                    try {
                        colTexts.get(j).add(rowTexts.get(i).get(j));
                    } catch (IndexOutOfBoundsException e) {
                        System.out.println(i);
                    }

                }
                rowTexts.remove(i--);
            }
        }

        updateColRuntime(colTexts, headTexts);

        int lastCount = rowTexts.stream().mapToInt(x -> x.size()).sum();
        while (lastCount > 0) {
            for (int i = 0; i < rowTexts.size(); i++) {
                for (int j = 0; j < rowTexts.get(i).size(); j++) {

                    if (fillToCol(rowTexts.get(i).get(j), colTexts, headTexts)) {

                        rowTexts.get(i).remove(j--);
                    }

                }

            }
            if (rowTexts.stream().mapToInt(x -> x.size()).sum() == lastCount) {
                throw new PdfException(String.valueOf(lastCount));
            } else {
                updateColRuntime(colTexts, headTexts);
                lastCount = rowTexts.stream().mapToInt(x -> x.size()).sum();
            }
        }

        for (List<PdfTextPosition> colText : colTexts) {
            TableParse.mergeCellText(colText, this);
        }
        return colTexts;

    }

    private void updateColRuntime(List<List<PdfTextPosition>> colTexts, List<List<PdfTextPosition>> headTexts) {

        Column column;

        int minX;
        int maxX;
        List<PdfTextPosition> col;
        int charWidth = 0;

        for (int i = 0; i < this.getColumns().size(); i++) {
            minX = Integer.MAX_VALUE;
            maxX = 0;
            charWidth = 0;

            column = this.getColumns().get(i);
            List<PdfTextPosition> colHeaders = headTexts.get(i);
            minX = colHeaders.get(0).getRectangle().x;
            maxX = colHeaders.get(0).getRectangle().x + colHeaders.get(0).getRectangle().width;

            int m = colHeaders.get(0).getRectangle().getMiddleX();
            this.getColumns().get(i).setRuntimeHeaderMiddleX(m);

            col = colTexts.get(i);
            for (int j = 0; j < col.size(); j++) {
                minX = Math.min(minX, col.get(j).getRectangle().x);
                maxX = Math.max(maxX, (new Double(col.get(j).getRectangle().getMaxX()).intValue()));

                charWidth = Math.max(charWidth, col.get(0).getRectangle().width / col.get(0).getText().length());
            }
            column.setRuntimeMaxX(maxX);
            column.setRuntimeMinX(minX);
            column.setRuntimeWidth(maxX - minX);
            column.setRuntimeCellCharWidth(charWidth);

        }

    }

    private boolean fillToCol(PdfTextPosition text, List<List<PdfTextPosition>> colTexts,
                              List<List<PdfTextPosition>> headTexts) {

        int minX;
        int maxX;
        int headerMiddleX = 0;
        int charWidth = 0;
        if (headTexts.size() != colTexts.size()) {
            throw new PdfException("");
        }
        boolean middleCol;
        boolean leftestCol;
        boolean rightestCol;
        boolean find = false;
        Column currentColumn;
        for (int i = 0; i < colTexts.size(); i++) {
            find = false;
            currentColumn = this.columns.get(i);
            leftestCol = i == 0;
            rightestCol = i == colTexts.size() - 1;
            middleCol = false == (i == 0 || i == colTexts.size() - 1);
            minX = currentColumn.getRuntimeMinX();
            maxX = currentColumn.getRuntimeMaxX();
            headerMiddleX = currentColumn.getRuntimeHeaderMiddleX();
            charWidth = currentColumn.getRuntimeCellCharWidth();
            if (maxX < minX) {
                throw new PdfException(String.valueOf(i));
            }
            if (text.getRectangle().x >= minX + charWidth / 2 && text.getRectangle().getMaxX() <= maxX + charWidth / 2) {//左右均位于现有区域内
                find = true;
            } else if (i == 0 && text.getRectangle().x <= minX) {//最左边列
                find = true;

            } else if (i == colTexts.size() - 1 && text.getRectangle().getMaxX() >= maxX) {//最右面列
                find = true;

            } else if (text.getRectangle().x - minX < charWidth || Math.abs(text.getRectangle().getMaxX() - maxX) < charWidth) {
                //接近现有文字的左边缘或者右边缘。
                find = true;

            } else {

                if (currentColumn.getCellHoriztalAlignment() == TextHorizontalAlignEnum.LEFT) {
                    if (leftestCol) {
                        if (text.getRectangle().x <= currentColumn.getRuntimeHeaderMiddleX()) {
                            find = true;
                        } else {

                        }
                    } else if (middleCol) {
                        if (this.columns.get(i - 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.LEFT ||
                                this.columns.get(i - 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.CENTER) {

                            if (text.getRectangle().x > this.columns.get(i - 1).getRuntimeHeaderMiddleX() + charWidth
                                    && text.getRectangle().x <= currentColumn.getRuntimeHeaderMiddleX()) {
                                find = true;
                            }

                        } else if (this.columns.get(i - 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {

                        } else {

                        }
                    }

                } else if (currentColumn.getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {
                    if (text.getRectangle().getMaxX() <= currentColumn.getRuntimeHeaderMiddleX()) {
                        find = false;
                    } else {
                        if (middleCol || leftestCol) {
                            if (this.columns.get(i + 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.LEFT) {
                                if (text.getRectangle().x >= headerMiddleX
                                        && text.getRectangle().getMaxX() < this.columns.get(i + 1).getRuntimeMinX()) {

                                    find = true;
                                } else if (text.getRectangle().x < currentColumn.getRuntimeMaxX()) {
                                    find = true;
                                }
                            } else if (this.columns.get(i + 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {
                                if (text.getRectangle().getMaxX() > currentColumn.getRuntimeHeaderMiddleX()
                                        //&& text.getRectangle().x > currentColumn.getRuntimeMinX()
                                        && text.getRectangle().getMaxX() < this.columns.get(i + 1).getRuntimeMinX()) {
                                    find = true;
                                }

                            } else if (this.columns.get(i + 1).getCellHoriztalAlignment() == TextHorizontalAlignEnum.CENTER) {
                                if (text.getRectangle().getMaxX() > currentColumn.getRuntimeHeaderMiddleX()
                                        //&& text.getRectangle().x > currentColumn.getRuntimeMinX()
                                        && text.getRectangle().getMaxX() < this.columns.get(i + 1).getRuntimeMinX()) {
                                    find = true;
                                }
                            }
                        }
                    }

                } else if (currentColumn.getCellHoriztalAlignment() == TextHorizontalAlignEnum.CENTER) {
                    if (middleCol) {
                        if (text.getRectangle().getMiddleX() - currentColumn.getRuntimeHeaderMiddleX() <= charWidth) {
                            find = true;
                        }
                    }

                }
            }
            if (find) {
                colTexts.get(i).add(text);
                return true;
            }
        }

        return false;
    }

    /**
     * 排列为行
     *
     * @param textPositions
     * @return
     */
    private List<List<PdfTextPosition>> rangeRow(List<PdfTextPosition> textPositions) {
        //排列优先级很重要。确保为：先列1从上到下，再列2从上到下。
        TableParse.sortByXY(textPositions);
        List<PdfTextPosition> currentRow = null;
        PdfTextPosition currentText = null;
        List<List<PdfTextPosition>> rows = new ArrayList<>();

        while (textPositions.size() > 0) {
            currentText = null;
            for (int i = 0; i < textPositions.size(); i++) {
                if (currentText == null) {
                    currentText = textPositions.get(i);
                    currentRow = new ArrayList<>();
                    currentRow.add(currentText);
                    textPositions.remove(i--);
                    continue;
                }
                if (TableParse.sameRow(this, currentText, textPositions.get(i))) {
                    currentRow.add(textPositions.get(i));
                    textPositions.remove(i--);
                }
            }
            rows.add(currentRow);
        }

        return rows;

    }

    public void adjustJson(JSONArray tableJsonArr) {
        JSONObject jsonitem;

        for (int i = 0; i < tableJsonArr.size(); i++) {
            Object o = tableJsonArr.get(i);
            jsonitem = (JSONObject) o;
            adjustJsonItem(tableJsonArr, jsonitem);
            if (jsonitem.size() == 0) {
                tableJsonArr.remove(i--);
            }
        }

    }

    protected void adjustJsonItem(JSONArray tableJsonArr, JSONObject jsonitem) {

    }

    public boolean isDouleColumn() {
        return douleColumn;
    }

    public void setDouleColumn(boolean douleColumn) {
        this.douleColumn = douleColumn;
    }

    public void filterCell(List<PdfTextPosition> tabCellTexts) {
    }
}

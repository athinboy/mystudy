package net.fgq.study.pdf;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.*;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.awt.*;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfToJson {

    private PDFTextPositionStripper textPositionStripper;

    private static Logger logger = LoggerFactory.getLogger(PdfToJson.class);

    private Document document;

    private PDDocument pdDocument;

    public PdfToJson() throws IOException {
        this.textPositionStripper = new PDFTextPositionStripper();
        textPositionStripper.setSortByPosition(true);
        textPositionStripper.setSortByPosition(true);
    }

    public JSONObject parse(PDDocument pdDocument, Document document) {
        this.document = document;
        this.pdDocument = pdDocument;

        try {
            JSONObject jsonObject = new JSONObject();
            if (pdDocument.getPages().getCount() == 0) {
                return jsonObject;
            }

            List<PdfTextPosition> textPositions = textPositionStripper.stripPosition(pdDocument);
            if (CollectionUtils.isNotEmpty(document.getContents())) {
                for (Content content : document.getContents()) {
                    for (PdfTextPosition textPosition : textPositions) {
                        if (content.getPageIndex() == textPosition.getPageIndex()
                                && content.getRectangle().contains(textPosition.getRectangle())) {
                            jsonObject.put(content.getJsonKey(), textPosition.getText());
                        }
                    }
                }
            }
            if (CollectionUtils.isNotEmpty(document.getTables())) {
                for (Table table : document.getTables()) {
                    parseTable(textPositions.stream().filter(x -> {
                                return x.getPageIndex() == table.getPageIndex() && x.getText().trim().length() > 0;
                            }).collect(Collectors.toList()),
                            table, jsonObject);
                }
            }
            return jsonObject;
        } catch (Exception ex) {
            logger.error("识别pdf失败", ex);
            System.out.println(ExceptionUtils.getStackTrace(ex));
            throw new PdfException(ex.getMessage());
        }

    }

    private void parseTable(List<PdfTextPosition> textPositions, Table table, JSONObject jsonObject) {
        if (StringUtils.isBlank(table.getFootSign()) && table.getFootRect() == null) {
            throw new IllegalArgumentException();
        }

        List<List<PdfTextPosition>> tabCellTexts = parseColumn(textPositions, table);

        //各个单元格文字，从上到下排序
        for (List<PdfTextPosition> colTexts : tabCellTexts) {
            colTexts.sort(new Comparator<PdfTextPosition>() {
                @Override
                public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                    return new Double(o1.getRectangle().getY()).compareTo(new Double(o2.getRectangle().getY()));
                }
            });
        }

        table.adjustCellText(tabCellTexts);

        JSONArray tableJsonArr = jsonObject.getJSONArray(table.getJsonKey());
        if (tableJsonArr == null) {
            tableJsonArr = new JSONArray();
            jsonObject.put(table.getJsonKey(), tableJsonArr);
        }

        JSONObject newitem;
        List<PdfTextPosition> colTexts;
        PdfTextPosition currentCellText;
        while (true) {
            newitem = new JSONObject();
            currentCellText = null;
            for (int j = 0; j < table.getColumns().size(); j++) {
                colTexts = tabCellTexts.get(j);
                if (colTexts.size() == 0) {
                    continue;
                } else {
                    if (currentCellText == null) {
                        currentCellText = colTexts.get(0);
                        newitem.put(table.getColumns().get(j).getJsonKey(), currentCellText.getText());
                        colTexts.remove(0);
                        continue;
                    } else {
                        for (int i = 0; i < colTexts.size(); i++) {
                            if (sameRow(table, currentCellText, colTexts.get(i))) {
                                newitem.put(table.getColumns().get(j).getJsonKey(), colTexts.get(i).getText());
                                colTexts.remove(i);
                                break;
                            }
                        }
                    }
                }

            }
            if (currentCellText != null) {
                tableJsonArr.add(newitem);
            } else {
                break;
            }

        }
    }

    /**
     * 调整列头区域。
     * 假设列头文字水平居中
     *
     * @param headerPositions
     * @param table
     */
    private void adjustHeadRect(List<PdfTextPosition> headerPositions, Table table) {

        Rectangle rectangle;
        for (int i = 0; i < headerPositions.size(); i++) {
            rectangle = headerPositions.get(i).getRectangle();
            if (table.getColumns().get(i).getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {
                rectangle.x = new Double(rectangle.getMaxX() - rectangle.getWidth()).intValue();
            } else {
                if (table.getColumns().get(i).getWidth() > rectangle.getWidth()) {
                    rectangle.x = new Double(rectangle.x - (table.getColumns().get(i).getWidth() - rectangle.getWidth()) / 2).intValue();
                    rectangle.width = table.getColumns().get(i).getWidth();
                }
            }
        }

    }

    private List<List<PdfTextPosition>> parseColumn(List<PdfTextPosition> textPositions, Table table) {

        Rectangle headerRect = table.getHeadRect();
        List<PdfTextPosition> headerPositions = new ArrayList<>();

        for (int i = 0; i < table.getColumns().size(); i++) {
            for (PdfTextPosition textPosition : textPositions) {
                if (table.getPageIndex() != textPosition.getPageIndex()) {
                    continue;
                }
                if (headerRect.contains(textPosition.getRectangle())) {
                    if (table.getColumns().get(i).getSignPatter().asPredicate().test(textPosition.getText())) {
                        headerPositions.add(textPosition);
                        break;
                    }
                }
            }
        }

        if (headerPositions.size() != table.getColumns().size()) {
            throw new PdfException("无法确定表格列:" + table.getJsonKey());
        }

        adjustHeadRect(headerPositions, table);

        float leftX;
        float rightX;
        float topY = (float) table.getHeadRect().getMaxY();
        float bottomY;
        if (table.getFootRect() == null) {
            bottomY = getTableFootTop(textPositions, table.getFootSign());
        } else {
            bottomY = table.getFootRect().y;
        }
        Rectangle colRect;

        List<PdfTextPosition> colTexts;

        List<List<PdfTextPosition>> tableCellTexts = new ArrayList<>();

        for (int i = 0; i < table.getColumns().size(); i++) {

            if (i == 0) {
                leftX = (float) table.getHeadRect().getX();
            } else {
                leftX = (float) headerPositions.get(i - 1).getRectangle().getMaxX();
            }
            if (i == table.getColumns().size() - 1) {
                rightX = (float) (table.getHeadRect().getMaxX());
            } else {
                rightX = (float) headerPositions.get(i + 1).getRectangle().getX();
            }
            colRect = new Rectangle(
                    new Float(leftX).intValue(),
                    new Float(topY).intValue(),
                    new Float(rightX - leftX).intValue(),
                    new Float(bottomY - topY).intValue());

            colTexts = new ArrayList<>();
            for (PdfTextPosition textPosition : textPositions) {
                if (catainCell(table.getColumns().get(i), colRect, textPosition)) {
                    colTexts.add(textPosition);
                }
            }
            merbeCellText(colTexts, table);
            tableCellTexts.add(colTexts);
        }
        return tableCellTexts;

    }

    //合并单元格中多行
    private void merbeCellText(List<PdfTextPosition> colTexts, Table table) {

        PdfTextPosition o1;
        PdfTextPosition o2;

        for (int i = 0; i < colTexts.size(); i++) {
            if (i == colTexts.size() - 1) {
                break;
            }
            for (int j = i + 1; j < colTexts.size(); j++) {
                o1 = colTexts.get(i);
                o2 = colTexts.get(j);
                if (table.getCellLineSpace() > Math.abs(o1.getRectangle().getMaxY() - o2.getRectangle().getY())) {
                    o1.getRectangle().width = Math.max(o1.getRectangle().width, o2.getRectangle().width);
                    o1.getRectangle().x = Math.max(o1.getRectangle().x, o2.getRectangle().x);
                    o1.getRectangle().height = new Double(o2.getRectangle().getMaxY() - o1.getRectangle().getY()).intValue();
                    o1.setText(o1.getText() + o2.getText());
                    colTexts.remove(j);
                    j--;
                }
            }

        }

    }

    //是否同行
    private boolean sameRow(Table table, PdfTextPosition o1, PdfTextPosition o2) {
        double o1m = o1.getRectangle().getY() + o1.getRectangle().getHeight() / 2;
        double o2m = o2.getRectangle().getY() + o2.getRectangle().getHeight() / 2;
        if (Math.abs(o1m - o2m) <= table.getCellLineSpace()) {
            return true;
        }
        if (Math.abs(o1.getRectangle().getY() - o2.getRectangle().getY()) <= table.getCellLineSpace()) {
            return true;
        }
        return false;

    }

    /**
     * 是否包含为单元格文字
     * 考虑存在文字过长而跨单元格情况
     *
     * @param colRect
     * @param textPosition
     * @return
     */
    private boolean catainCell(Column column, Rectangle colRect, PdfTextPosition textPosition) {
        if (false == colRect.intersects(textPosition.getRectangle())) {
            return false;
        }
        if (column.getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {
            if (textPosition.getRectangle().getX() > colRect.getMaxX()) {//最左文字在区域中线右边
                return false;
            }
            if (textPosition.getRectangle().getMaxX() < colRect.getX()) {//最右文字在区域左边
                return false;
            }
            if (textPosition.getRectangle().getMaxX() < (colRect.getX() + colRect.getWidth() / 2)) {//最右文字在区域中线左边
                return false;
            }

        } else {
            if (textPosition.getRectangle().getX() < colRect.getX()) {
                return false;
            }

            if (textPosition.getRectangle().getX() > (colRect.getX() + colRect.getWidth() * 3 / 4)) {
                return false;
            }

        }

        if (colRect.getMaxY() < textPosition.getRectangle().getMaxY()) {//文字下边界出界限
            return false;
        }

        return true;
    }

    /**
     * 获取表格尾的上边距
     *
     * @return
     */
    private float getTableFootTop(List<PdfTextPosition> textPositions, String footsign) {

        for (PdfTextPosition textPosition : textPositions) {
            if (textPosition.getText().indexOf(footsign) != -1) {
                return (float) textPosition.getRectangle().getY();
            }
        }
        throw new PdfException("无法确定表格尾的上边距：" + footsign);

    }

}

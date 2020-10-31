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

    private boolean showSystemOut = false;

    public boolean isShowSystemOut() {
        return showSystemOut;
    }

    public void setShowSystemOut(boolean showSystemOut) {
        this.showSystemOut = showSystemOut;
        textPositionStripper.ShouwSystemOut = this.showSystemOut;
    }

    public PdfToJson() throws IOException {
        this.textPositionStripper = new PDFTextPositionStripper();
        textPositionStripper.setSortByPosition(true);
        textPositionStripper.setSortByPosition(true);
        textPositionStripper.ShouwSystemOut = this.showSystemOut;
    }

    public JSONObject parse(PDDocument pdDocument, Document document) {

        //todo 因为运行时生成数据，加锁，避免多线程，

        //todo 清理运行时生成数据
        document.getTableGroups().forEach(x->{
            x.getTables().forEach(t->{
                t.setRuntimeParseRectangle(null);
                t.getColumns().forEach(c->{

                });
            });
        });

        this.document = document;
        this.pdDocument = pdDocument;

        try {
            JSONObject jsonObject = new JSONObject();
            if (pdDocument.getPages().getCount() == 0) {
                return jsonObject;
            }

            List<PdfTextPosition> textPositions = textPositionStripper.stripPosition(pdDocument);

            if (StringUtils.isNotBlank(document.getPageIndexSign())) {
                for (PdfTextPosition textPosition : textPositions) {
                    if (textPosition.getText().contains(document.getPageIndexSign())) {
                        document.changePageIndex(textPosition.getPageIndex());
                    }
                }

            }

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
            if (CollectionUtils.isNotEmpty(document.getTableGroups())) {
                int errcount = 0;
                TableGroup tableGroup;
                for (int i = 0; i < document.getTableGroups().size(); i++) {
                    tableGroup = document.getTableGroups().get(i);
                    try {
                        for (Table table : tableGroup.getTables()) {
                            parseTable(textPositions.stream().filter(x -> {
                                        return x.getPageIndex() == table.getPageIndex() && x.getText().trim().length() > 0;
                                    }).collect(Collectors.toList()),
                                    table, jsonObject);

                        }
                    } catch (PdfException pdfex) {
                        logger.error("识别表格组失败", pdfex);
                        errcount++;
                    }
                    if (errcount < i + 1) {
                        break;
                    }

                }

                if (errcount == document.getTableGroups().size()) {
                    throw new PdfException("识别失败");
                }
            }
            return jsonObject;
        } catch (Exception ex) {
            logger.error("识别pdf失败", ex);
            System.out.println(ExceptionUtils.getStackTrace(ex));
            throw new PdfException(ex.getMessage());
        } finally {

        }

    }

    private void parseTable(List<PdfTextPosition> textPositions, Table table, JSONObject jsonObject) {
        if (CollectionUtils.isEmpty(table.getFootSigns())) {
            throw new IllegalArgumentException();
        }

        List<PdfTextPosition> tabCellTexts = TableParse.parseCell(textPositions, table);
        List<List<PdfTextPosition>> headTexts = TableParse.parseHeader(textPositions, table);
        table.filterCell(tabCellTexts);
        List<List<PdfTextPosition>> colCellTexts;// = parseColumn(textPositions, table);
        colCellTexts = table.rangeCellToCol(tabCellTexts, headTexts);

        //各个单元格文字，从上到下排序
        for (List<PdfTextPosition> colTexts : colCellTexts) {
            TableParse.sortByY(colTexts);
        }

        table.adjustColCellText(colCellTexts);

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
                colTexts = colCellTexts.get(j);
                if (colTexts.size() == 0) {
                    continue;
                } else {
                    if (currentCellText == null) {
                        currentCellText = colTexts.get(0);
                        newitem.put(table.getColumns().get(j).getJsonKey(),
                                table.getColumns().get(j).parseValue(currentCellText.getText()));
                        colTexts.remove(0);
                        continue;
                    } else {
                        for (int i = 0; i < colTexts.size(); i++) {
                            if (TableParse.sameRow(table, currentCellText, colTexts.get(i))) {
                                newitem.put(table.getColumns().get(j).getJsonKey(),
                                        table.getColumns().get(j).parseValue(colTexts.get(i).getText()));
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
        table.adjustJson(tableJsonArr);
    }

    /**
     * 调整列头区域。
     * 假设列头文字水平居中
     *
     * @param headerPositions
     * @param table
     */
    private void adjustHeadRect(List<List<PdfTextPosition>> headerPositions, Table table) {

        Rectangle rectangle;
        List<PdfTextPosition> colHeader;
        for (int i = 0; i < headerPositions.size(); i++) {
            colHeader = headerPositions.get(i);
            for (int j = 0; j < colHeader.size(); j++) {
                rectangle = colHeader.get(j).getRectangle();
                if (table.getColumns().get(i).getCellHoriztalAlignment() == TextHorizontalAlignEnum.RIGHT) {
                    rectangle.x = new Double(rectangle.getMaxX() - rectangle.getWidth()).intValue();
                } else {
                    if (table.getColumns().get(i).getRuntimeWidth() > rectangle.getWidth()) {
                        rectangle.x = new Double(rectangle.x - (table.getColumns().get(i).getRuntimeWidth() - rectangle.getWidth()) / 2).intValue();
                        rectangle.width = table.getColumns().get(i).getRuntimeWidth();
                    }
                }
            }

        }

    }

    private List<List<PdfTextPosition>> parseColumn(List<PdfTextPosition> textPositions, Table table) {

        List<List<PdfTextPosition>> headerPositions = TableParse.parseHeader(textPositions, table);

        adjustHeadRect(headerPositions, table);

        float leftX;
        float rightX;
        float topY = (float) table.getHeadRect().getMaxY();
        float bottomY;

        bottomY = TableParse.getTableFootTop(textPositions, table);

        Rectangle colRect;

        List<PdfTextPosition> colTexts;

        List<List<PdfTextPosition>> tableCellTexts = new ArrayList<>();

        for (int i = 0; i < table.getColumns().size(); i++) {

            if (i == 0) {
                leftX = (float) table.getHeadRect().getX();
            } else {
                leftX = (float) headerPositions.get(i - 1).get(0).getRectangle().getMaxX();
            }
            if (i == table.getColumns().size() - 1) {
                rightX = (float) (table.getHeadRect().getMaxX());
            } else {
                rightX = (float) headerPositions.get(i + 1).get(0).getRectangle().getX();
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
            TableParse.mergeCellText(colTexts, table);
            tableCellTexts.add(colTexts);
        }
        return tableCellTexts;

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
            if (textPosition.getRectangle().getX() > colRect.getMaxX()) {//最左文字在区域右边
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
        if (colRect.getMaxX() - textPosition.getRectangle().getX() <
                textPosition.getRectangle().width / textPosition.getText().length() / 2) {//文字左边半个字在区域内
            return false;
        }

        return true;
    }

}

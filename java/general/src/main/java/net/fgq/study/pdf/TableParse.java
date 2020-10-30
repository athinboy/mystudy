package net.fgq.study.pdf;

import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Table;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;

import java.awt.*;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2020/10/29
 */
public class TableParse {

    /**
     * 根据列头区域具体列头位置
     *
     * @param textPositions
     * @param table
     * @return
     */
    private static List<List<PdfTextPosition>> parseHeaderByRect(List<PdfTextPosition> textPositions, Table table) {

        Rectangle headerRect = table.getHeadRect();
        List<List<PdfTextPosition>> headerPositions = new ArrayList<>();

        List<PdfTextPosition> colHead;

        for (int i = 0; i < table.getColumns().size(); i++) {
            colHead = new ArrayList<>();
            for (PdfTextPosition textPosition : textPositions) {
                if (table.getPageIndex() != textPosition.getPageIndex()) {
                    continue;
                }
                if (headerRect.contains(textPosition.getRectangle())) {
                    if (table.getColumns().get(i).getSignPattern().asPredicate().test(textPosition.getText())) {
                        colHead.add(textPosition);
                    }
                }
            }
            if (colHead.size() == 0) {
                throw new PdfException("无法确定表格列:" + table.getColumns().get(i).getJsonKey());
            }
            headerPositions.add(colHead);
        }

        return headerPositions;
    }

    /**
     * 根据列头区域具体列头位置
     *
     * @param textPositions
     * @param table
     * @return
     */
    private static List<List<PdfTextPosition>> parseHeaderByTexts(List<PdfTextPosition> textPositions, Table table) {

        List<List<PdfTextPosition>> headTexts = new ArrayList<>();
        List<PdfTextPosition> colHeaderTexts;
        Column column;
        for (int i = 0; i < table.getColumns().size(); i++) {
            column = table.getColumns().get(i);
            colHeaderTexts = new ArrayList<>();
            for (PdfTextPosition textPosition : textPositions) {
                if (table.getPageIndex() != textPosition.getPageIndex()) {
                    continue;
                }

                Pattern signPatter = column.getSignPattern();
                if (signPatter.asPredicate().test(textPosition.getText())) {
                    colHeaderTexts.add(textPosition);
                    //break;
                }
            }
            if (colHeaderTexts.size() == 0 || colHeaderTexts.size() < column.getSigns().size()) {
                throw new PdfException(String.valueOf(i));
            } else {
                headTexts.add(colHeaderTexts);
            }
        }

        int minY = Integer.MAX_VALUE;
        int maxY = 0;

        for (int i = 0; i < headTexts.size(); i++) {
            column = table.getColumns().get(i);
            colHeaderTexts = headTexts.get(i);
            if (colHeaderTexts.size() == column.getSigns().size()) {
                for (int j = 0; j < colHeaderTexts.size(); j++) {
                    minY = Math.min(minY, colHeaderTexts.get(j).getRectangle().y);
                    maxY = Math.max(maxY, (new Float(colHeaderTexts.get(j).getRectangle().getMaxY()).intValue()));
                }
            }
        }
        if (minY == Integer.MAX_VALUE || maxY == 0) {
            throw new PdfException("");
        }
        for (int i = 0; i < headTexts.size(); i++) {
            colHeaderTexts = headTexts.get(i);
            column = table.getColumns().get(i);
            for (int j = 0; j < colHeaderTexts.size(); j++) {
                if (colHeaderTexts.get(j).getRectangle().y < minY || colHeaderTexts.get(j).getRectangle().y > maxY) {
                    //todo 当前仅根据数量排除异常，增加根据位置是否同一行判断？
                    colHeaderTexts.remove(j--);
                }
            }
            if (colHeaderTexts.size() == 0 || colHeaderTexts.size() > column.getSigns().size()) {
                throw new PdfException(String.valueOf(i));
            }
        }
        return headTexts;

    }

    public static List<List<PdfTextPosition>> parseHeader(List<PdfTextPosition> textPositions, Table table) {

        try {
            return parseHeaderByTexts(textPositions, table);
        } catch (PdfException pdfex) {
            if (table.getHeadRect() != null) {
                return parseHeaderByRect(textPositions, table);
            } else {
                throw pdfex;
            }
        }
    }

    public static void sortByY(List<PdfTextPosition> texts) {
        texts.sort(new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                int i = (new Double(o1.getRectangle().getY())).compareTo(new Double(o2.getRectangle().getY()));
                if (i == 0) {
                    return o1.getText().compareTo(o2.getText());
                } else {
                    return i;
                }
            }
        });
    }

    public static void sortByX(List<PdfTextPosition> texts) {
        texts.sort(new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                int i = (new Double(o1.getRectangle().getX())).compareTo(new Double(o2.getRectangle().getX()));
                if (i == 0) {
                    return o1.getText().compareTo(o2.getText());
                } else {
                    return i;
                }
            }
        });
    }

    public static void sortByXY(List<PdfTextPosition> texts) {
        texts.sort(new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                int i = (new Double(o1.getRectangle().getX())).compareTo(new Double(o2.getRectangle().getX()));
                if (i == 0) {
                    i = (new Double(o1.getRectangle().getY())).compareTo(new Double(o2.getRectangle().getY()));
                    if (i == 0) {
                        return o1.getText().compareTo(o2.getText());
                    } else {
                        return i;
                    }

                } else {
                    return i;
                }
            }
        });
    }

    /**
     * 推测表格列头区域
     *
     * @param textPositions
     * @param table
     * @return
     */
    public static Rectangle parseHeaderRectangle2(List<PdfTextPosition> textPositions, Table table) {

        Rectangle headerRect = new Rectangle();
        List<PdfTextPosition> colHeaderTexts;
        List<List<PdfTextPosition>> headTexts = parseHeader(textPositions, table);
        for (int i = 0; i < headTexts.size(); i++) {
            colHeaderTexts = headTexts.get(i);
            for (int j = 0; j < colHeaderTexts.size(); j++) {
                headerRect.add(colHeaderTexts.get(j).getRectangle());
            }
        }
        return headerRect;
    }

    /**
     * 推测表格列头区域
     *
     * @param textPositions
     * @param table
     * @return
     */
    public static Rectangle parseHeaderRectangle(List<PdfTextPosition> textPositions, Table table) {

        parseTableRectByReference(table, textPositions);

        Column column;
        List<List<PdfTextPosition>> headTexts = new ArrayList<>();

        List<PdfTextPosition> colHeaderTexts;
        int y;

        int minY = Integer.MAX_VALUE;
        int maxY = 0;

        for (int i = 0; i < table.getColumns().size(); i++) {
            column = table.getColumns().get(i);
            colHeaderTexts = new ArrayList<>();
            for (PdfTextPosition textPosition : textPositions) {
                if (table.getPageIndex() != textPosition.getPageIndex()) {
                    continue;
                }
                if (false == table.getParseRectangle().intersects(textPosition.getRectangle())) {
                    continue;
                }
                Pattern signPatter = column.getSignPattern();
                if (signPatter.asPredicate().test(textPosition.getText())) {
                    colHeaderTexts.add(textPosition);
                    //break;
                }
            }
            if (colHeaderTexts.size() == 0) {
                throw new PdfException(String.valueOf(i));
            }
            sortByY(colHeaderTexts);

            y = 0;
            for (int j = 0; j < colHeaderTexts.size(); j++) {
                if (y == 0) {
                    y = (new Double(colHeaderTexts.get(j).getRectangle().getMaxY())).intValue();
                    minY = Math.min(minY, (new Double(colHeaderTexts.get(j).getRectangle().getY())).intValue());
                    maxY = Math.max(maxY, y);
                    continue;
                }
                if (colHeaderTexts.get(j).getRectangle().getY() - y > table.getHeaderLineSpace()) {//j行距离太远
                    colHeaderTexts.remove(j--);
                } else {
                    minY = Math.min(minY, (new Double(colHeaderTexts.get(j).getRectangle().getY())).intValue());
                    y = (new Double(colHeaderTexts.get(j).getRectangle().getMaxY())).intValue();
                    maxY = Math.max(maxY, y);
                }
            }
            if (maxY <= minY) {
                throw new PdfException(String.valueOf(i));
            }
            if (colHeaderTexts.size() == 0) {
                throw new PdfException(String.valueOf(i));
            }
            headTexts.add(colHeaderTexts);
        }

        Rectangle headerRect = new Rectangle();
        if (StringUtils.isNotBlank(table.getLeftReferenceText())) {
            headerRect.x = table.getParseRectangle().x;
        }
        if (StringUtils.isNotBlank(table.getTopReferenceText())) {

            int spaceGap = (minY - table.getParseRectangle().y) / 2;

            //table.getParseRectangle().y  表格之上文字的下边缘
            //minY 单元格文字的上边缘
            headerRect.y = minY - spaceGap;
            headerRect.height = maxY - headerRect.y + spaceGap;
        }
        if (StringUtils.isNotBlank(table.getLeftReferenceText())
                && CollectionUtils.isNotEmpty(table.getRightReferenceText())) {
            headerRect.width = table.getParseRectangle().width;
        }
        return headerRect;
    }

    //合并单元格中多行
    public static void merbeCellText(List<PdfTextPosition> colTexts, Table table) {

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
    public static boolean sameRow(Table table, PdfTextPosition o1, PdfTextPosition o2) {
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
     * @param table
     * @param textPositions
     */
    public static void parseTableRectByReference(Table table, List<PdfTextPosition> textPositions) {

        if (table.getParseRectangle() != null) {
            return;
        }
        table.setParseRectangle(new Rectangle());

        if (StringUtils.isBlank(table.getLeftReferenceText()) ||
                StringUtils.isBlank(table.getTopReferenceText()) ||
                CollectionUtils.isEmpty(table.getRightReferenceText())) {
            throw new PdfException("需要设置");
        }

        int left = Integer.MAX_VALUE;
        int minY = Integer.MAX_VALUE;
        int right = 0;
        int maxY = 0;
        for (PdfTextPosition textPosition : textPositions) {
            if (textPosition.getPageIndex() != table.getPageIndex()) continue;
            if (StringUtils.isNotBlank(table.getLeftReferenceText())) {
                if (textPosition.getText().contains(table.getLeftReferenceText())) {
                    left = Math.min(left, textPosition.getRectangle().x);
                }
            }
            if (StringUtils.isNotBlank(table.getTopReferenceText())) {
                if (textPosition.getText().contains(table.getTopReferenceText())) {
                    minY = Math.min(minY, (new Double(textPosition.getRectangle().getMaxY())).intValue()) + table.getCellLineSpace();
                }
            }
            if (CollectionUtils.isNotEmpty(table.getRightReferenceText())) {
                for (String s : table.getRightReferenceText()) {
                    if (textPosition.getText().contains(s)) {
                        right = Math.max(right, (new Double(textPosition.getRectangle().getMaxX()).intValue()));
                    }
                }

            }

        }
        maxY = getTableFootTop(textPositions, table);
        if (right == 0) {
            //throw new PdfException("无法确定表格右边位置");
        }

        if (StringUtils.isNotBlank(table.getLeftReferenceText())) {
            table.getParseRectangle().x = left;
        }
        if (StringUtils.isNotBlank(table.getTopReferenceText())) {
            table.getParseRectangle().y = minY;
        }
        if (StringUtils.isNotBlank(table.getLeftReferenceText())
                && CollectionUtils.isNotEmpty(table.getRightReferenceText())) {
            table.getParseRectangle().width = Math.max(0, right - left);

        }
        table.getParseRectangle().height = Math.max(0, maxY - minY);

    }

    /**
     * 获取表格尾的上边距
     *
     * @return
     */
    public static int getTableFootTop(List<PdfTextPosition> textPositions, Table table) {
        List<String> footsigns = table.getFootSigns();
        for (PdfTextPosition textPosition : textPositions) {
            if (textPosition.getPageIndex() == table.getPageIndex()) {
                for (String footsign : footsigns) {
                    if (textPosition.getText().indexOf(footsign) != -1) {
                        return textPosition.getRectangle().y;
                    }

                }
            }
        }
        throw new PdfException("无法确定表格尾的上边距：" + String.join(",", footsigns));

    }

    public static List<PdfTextPosition> parseCell(List<PdfTextPosition> textPositions, Table table) {

        Rectangle headerRect = parseHeaderRectangle2(textPositions, table);

        int minY = (new Double(headerRect.getMaxY()).intValue());
        int maxY = getTableFootTop(textPositions, table);
        PdfTextPosition textPosition;
        List<PdfTextPosition> cellTexts = new ArrayList<>();
        for (int i = 0; i < textPositions.size(); i++) {
            textPosition = textPositions.get(i);
            if (textPosition.getRectangle().y > minY && textPosition.getRectangle().y < maxY) {
                cellTexts.add(textPosition);
            }
        }
        return cellTexts;

    }
}

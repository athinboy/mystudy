package net.fgq.study.pdf;

import net.fgq.study.pdf.Item.OrderItemInfo;
import org.apache.commons.lang3.StringUtils;
import org.apache.pdfbox.text.TextPosition;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfTextPosition {

    private String text;

    /**
     * 最原始的内容。
     */
    private String originalStr;

    /**
     * 去除空格的内容。
     */
    private String trimedText;

    /**
     * 行数
     */
    private int lineNumber = 1;

    private PdfRectangle rectangle = null;

    private int pageIndex;

    private List<TextPositionEx> textPositions = new ArrayList<>();

    /**
     * 可能的OrderItemInfo。
     */
    private List<OrderItemInfo> candidateOrderItems = new ArrayList<>();

    private List<PdfTextPosition> origTexts = new ArrayList<>();

    /**
     *
     */
    private boolean structed = false;

    /**
     * 作为信息标签的可能性。
     */
    private int keyPercent = 0;
    /**
     * 是否信息区域
     */
    private boolean isAreaInfo = false;

    private List<PdfTextPosition> groupItems;
    /**
     * 内容是否已经规格化
     */
    private boolean standaredized = false;

    public PdfTextPosition(int pageIndex, String text, PdfRectangle rectangle) {
        this.text = text;
        this.rectangle = rectangle;
        this.pageIndex = pageIndex;
    }

    public PdfTextPosition(int pageIndex, String text, int x, int y, int width, int height) {
        this(pageIndex, text, new PdfRectangle(x, y, width, height));
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getTrimedText() {
        if (trimedText == null) {
            trimedText = this.getText();
            trimedText = trimedText
                    .replaceAll("\\s", "")
                    .replaceAll("\\u00A0+", "");//特殊的空格-ASCII码值160
        }
        return trimedText;
    }

    public void setTrimedText(String trimedText) {
        this.trimedText = trimedText;
    }

    public PdfRectangle getRectangle() {
        return rectangle;
    }

    public void setRectangle(PdfRectangle rectangle) {
        this.rectangle = rectangle;
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public int getLineNumber() {
        return lineNumber;
    }

    public void setLineNumber(int lineNumber) {
        this.lineNumber = lineNumber;
    }

    @Override
    public String toString() {
        return "PdfTextPosition{" +
                "text='" + text + '\'' +
                "trimedText='" + trimedText + '\'' +
                ", rectangle=" + rectangle +
                ", pageIndex=" + pageIndex +
                ", keyPercent=" + keyPercent +
                '}';
    }

    public int lineHeight() {
        return this.getRectangle().height / this.lineNumber;
    }

    /**
     * 是否同一行
     *
     * @param other
     * @return
     */
    public boolean checkSameLine(PdfTextPosition other) {
        int lineheight = Math.min(this.lineHeight() / 2, other.lineHeight() / 2);
        return this.pageIndex == other.pageIndex &&
                (this.getRectangle().checkSameLine(other.getRectangle(), lineheight)
                || (Math.abs(this.rectangle.y - other.getRectangle().y) < lineheight && this.lineNumber == other.lineNumber));//因为高度可能不准确。所以依据上边缘比较。
    }

    /**
     * 在右侧，且同一行
     *
     * @param other
     * @return
     */
    public boolean checkRightSameLine(PdfTextPosition other) {
        return this.pageIndex == other.pageIndex
                && (this.getRectangle().x < other.getRectangle().x) && checkSameLine(other);
    }

    public int getKeyPercent() {
        return keyPercent;
    }

    public void setKeyPercent(int keyPercent) {
        this.keyPercent = keyPercent;
    }

    /**
     * 是否左边距相同
     *
     * @param other
     * @return
     */
    public boolean checkSameLeft(PdfTextPosition other) {
        int lineheight = (this.lineHeight() + other.lineHeight()) / 2 / 2;
        return this.pageIndex == other.pageIndex &&
                Math.abs(this.getRectangle().x - other.getRectangle().x) < lineheight;
    }

    public boolean isStructed() {
        return structed;
    }

    public void setStructed(boolean structed) {
        this.structed = structed;
    }

    public List<PdfTextPosition> getOrigTexts() {
        return origTexts;
    }

    public void setOrigTexts(List<PdfTextPosition> origTexts) {
        this.origTexts = origTexts;
    }

    public List<OrderItemInfo> getCandidateOrderItems() {
        return candidateOrderItems;
    }

    public void setCandidateOrderItems(List<OrderItemInfo> candidateOrderItems) {
        this.candidateOrderItems = candidateOrderItems;
    }

    public boolean isAreaInfo() {
        return isAreaInfo;
    }

    public void setAreaInfo(boolean areaInfo) {
        isAreaInfo = areaInfo;
    }

    public boolean isStandaredized() {
        return standaredized;
    }

    public void setGroupItems(List<PdfTextPosition> groupItems) {
        this.groupItems = groupItems;
    }

    public List<PdfTextPosition> getGroupItems() {
        return groupItems;
    }

    public void setOriginalStr(String originalStr) {

        this.originalStr = originalStr;
    }

    public String getOriginalStr() {
        return originalStr;
    }

    public boolean getStandaredized() {
        return standaredized;
    }

    public void setStandaredized(boolean standaredized) {
        this.standaredized = standaredized;
    }

    public List<TextPositionEx> getTextPositions() {
        return textPositions;
    }

    public void setTextPositions(List<TextPositionEx> textPositions) {
        this.textPositions = textPositions;
    }

    public void addOrigTexts(List<PdfTextPosition> mergedTexts) {
        this.getOrigTexts().addAll(mergedTexts);

    }

//    /**
//     * 合并信息来替代现在的空白区域。
//     *
//     * @param o
//     * @return
//     */
//    public boolean mergeBlack(TextPosition o) {
//
//        int oHeight = (new Double(Math.ceil(PDFTextPositionStripper.getHeight(o))).intValue());
//        int oX = (new Double(Math.ceil(o.getX())).intValue());
//        int oY = (new Double(Math.ceil(o.getY())).intValue());
//        int oWidth = (new Double(Math.ceil(o.getWidth())).intValue());
//        int oMiddleX = (new Double(Math.ceil(o.getX() + o.getWidth() / 2)).intValue());
//        int oMiddleY = (new Double(Math.ceil(o.getY() + oHeight / 2)).intValue());
//
//        Rectangle oRec = new Rectangle(oX, oY, oWidth, oHeight);
//        for (int i = 0; i < this.getTextPositions().size(); i++) {
//            TextPositionEx textPosition = this.getTextPositions().get(i);
//
//            if (StringUtils.isNotBlank(textPosition.getTextPosition().getUnicode())) {
//                continue;
//            }
//            int tHeight = (new Double(Math.ceil(PDFTextPositionStripper.getHeight(textPosition))).intValue());
//            int tX = (new Double(Math.ceil(textPosition.getX())).intValue());
//            int tY = (new Double(Math.ceil(textPosition.getY())).intValue());
//            int tWidth = (new Double(Math.ceil(textPosition.getWidth())).intValue());
//            int tMiddleX = (new Double(Math.ceil(textPosition.getX() + textPosition.getWidth() / 2)).intValue());
//            int tMiddleY = (new Double(Math.ceil(textPosition.getY() + tHeight / 2)).intValue());
//            Rectangle tRec = new Rectangle(tX, tY, tWidth, tHeight);
//            if (tRec.contains(oMiddleX, oMiddleY) && tRec.contains(oRec)) {
//                Rectangle interRec = tRec.intersection(oRec);
//                if (interRec.width * interRec.height > oRec.width * oRec.height * 0.8
//                        || interRec.width * interRec.height > tRec.width * tRec.height * 0.8) {
//                    this.getTextPositions().set(i, o);
//                    this.setTrimedText(null);
//                    String val = "";
//                    for (int j = 0; j < this.getTextPositions().size(); j++) {
//                        val += this.getTextPositions().get(j).getUnicode();
//                    }
//                    this.setText(val);
//                    return true;
//                }
//            }
//        }
//
//        return false;
//    }
}

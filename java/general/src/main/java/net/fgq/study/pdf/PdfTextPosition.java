package net.fgq.study.pdf;

import net.fgq.study.pdf.Item.OrderItemInfo;

import java.awt.*;
import java.util.ArrayList;
import java.util.Comparator;
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
     * 是否信息组
     */
    private boolean isGroupInfo = false;
    private List<PdfTextPosition> groupItems;
    /**
     * 内容是否已经规格化
     */
    private boolean standaredized=false;

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
            trimedText = trimedText.replaceAll("\\s", "");
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
        int lineheight = (this.lineHeight() + other.lineHeight()) / 2 / 2;

        return this.pageIndex == other.pageIndex &&
                this.getRectangle().checkSameLine(other.getRectangle(), lineheight)
                || (Math.abs(this.rectangle.y - other.getRectangle().y) < lineheight && this.lineNumber == other.lineNumber);//因为高度可能不准确。所以依据上边缘比较。
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

    public void setIsGroupInfo(boolean isGroupInfo) {
        this.isGroupInfo = isGroupInfo;
    }

    public boolean getIsGroupInfo() {
        return isGroupInfo;
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
}

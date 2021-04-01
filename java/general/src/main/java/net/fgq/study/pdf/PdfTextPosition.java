package net.fgq.study.pdf;

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
     * 去除空格的内容。
     */
    private String trimedText;

    /**
     * 行数
     */
    private int lineNumber = 1;

    private PdfRectangle rectangle = null;

    private int pageIndex;

    private PdfTextPosition origText = null;

    /**
     *
     */
    private boolean structed = false;

    /**
     * 作为信息标签的可能性。
     */
    private int keyPercent = 0;

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
                ", origText=" + (origText == null ? "" : origText.toString()) +
                '}';
    }

    public int lineHeight() {
        return this.getRectangle().height / this.lineNumber;
    }

    /**
     * 是否同一行
     *
     * @param textPosition
     * @return
     */
    public boolean checkSameLine(PdfTextPosition textPosition) {
        int lineheight = (this.lineHeight() + textPosition.lineHeight()) / 2 / 2;
        return this.getRectangle().checkSameLine(textPosition.getRectangle(), lineheight);
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
        return Math.abs(this.getRectangle().x - other.getRectangle().x) < lineheight;
    }

    public boolean isStructed() {
        return structed;
    }

    public void setStructed(boolean structed) {
        this.structed = structed;
    }

    public PdfTextPosition getOrigText() {
        return origText;
    }

    public void setOrigText(PdfTextPosition origText) {
        this.origText = origText;
    }
}

package net.fgq.study.pdf;

import java.awt.*;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfTextPosition {

    private String text;

    /**
     * 去除空格的内容。
     */
    private String trimedText;

    private PdfRectangle rectangle;

    private int pageIndex;

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

    @Override
    public String toString() {
        return "PdfTextPosition{" +
                "text='" + text + '\'' +
                ", rectangle=" + rectangle +
                ", pageIndex=" + pageIndex +
                '}';
    }
}

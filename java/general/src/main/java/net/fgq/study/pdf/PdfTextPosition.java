package net.fgq.study.pdf;

import java.awt.*;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfTextPosition {

    private String text;

    private Rectangle rectangle;

    private int pageIndex;

    public PdfTextPosition(int pageIndex, String text, Rectangle rectangle) {
        this.text = text;
        this.rectangle = rectangle;
        this.pageIndex = pageIndex;
    }

    public PdfTextPosition(int pageIndex, String text, int x, int y, int width, int height) {
        this(pageIndex, text, new Rectangle(x, y, width, height));
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public Rectangle getRectangle() {
        return rectangle;
    }

    public void setRectangle(Rectangle rectangle) {
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

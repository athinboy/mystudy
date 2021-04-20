package net.fgq.study.pdf;

import org.apache.pdfbox.text.TextPosition;

import java.awt.*;

/**
 * Created by fengguoqiang 2021/4/13
 */
public class TextPositionEx {

    private TextPosition textPosition;
    private PdfRectangle rectangle = null;
    private int pageIndex;

    public TextPositionEx(int pageIndex, TextPosition textPosition) {
        this.textPosition = textPosition;
        this.pageIndex = pageIndex;
    }

    public TextPosition getTextPosition() {
        return textPosition;
    }

    public void setTextPosition(TextPosition textPosition) {
        this.textPosition = textPosition;
    }

    /**
     * 采用矮的垂直中线在高的垂直中部（）。
     *
     * @param o2
     * @return
     */
    public boolean checkSameLine(TextPositionEx o2) {
        PdfRectangle r = this.getRectangle();
        PdfRectangle or = o2.getRectangle();
        if (Math.abs(r.y - or.y) <= r.height / 2
                && Math.abs(r.getMiddleY() - or.getMiddleY()) <= r.height / 2) {
            return true;
        }

        PdfRectangle lowR = this.getRectangle().height > o2.getRectangle().height ? o2.getRectangle() : this.getRectangle();
        PdfRectangle tallR = this.getRectangle().height > o2.getRectangle().height ? this.getRectangle() : o2.getRectangle();
        if (tallR.height - lowR.height >= lowR.height * 2) {
            return false;
        }

        int middleY = lowR.getMiddleY();
        if (middleY >= (tallR.y) && middleY <= tallR.maxY() - tallR.height / 4) {
            return true;
        }

        return false;
    }

    public PdfRectangle getRectangle() {
        if (this.rectangle == null) {
            this.rectangle = new PdfRectangle(this.pageIndex
                    , Double.valueOf(this.textPosition.getX()).intValue()
                    , Double.valueOf(this.textPosition.getY()).intValue()
                    , Double.valueOf(this.textPosition.getWidth()).intValue()
                    , Double.valueOf(TextPositionExHelper.getHeight(this.textPosition)).intValue());
        }
        return rectangle;
    }

    public void setRectangle(PdfRectangle rectangle) {
        this.rectangle = rectangle;
    }

    @Override
    public String toString() {
        return "TextPositionEx{" +
                "textPosition=" + textPosition +
                '}';
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public boolean checkSameLeft(TextPositionEx o) {
        if (this.getPageIndex() != o.getPageIndex()) {
            throw new IllegalArgumentException();
        }
        return Math.abs(this.getRectangle().x - o.getRectangle().x)
                < Math.min(this.getRectangle().width, o.getRectangle().width) / 4;

    }

    private String trimedText = null;

    public String getTrimedText() {

        if (trimedText == null) {
            trimedText = this.getTextPosition().getUnicode()
                    .replaceAll("\\s", "")
                    .replaceAll("\\u00A0+", "");//特殊的空格-ASCII码值160
        }
        return trimedText;
    }
}

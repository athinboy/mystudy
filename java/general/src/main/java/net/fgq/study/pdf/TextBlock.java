package net.fgq.study.pdf;

/**
 * Created by fengguoqiang 2021/4/13
 */
public class TextBlock extends PdfTextPosition {

    public TextBlock(int pageIndex, String text, PdfRectangle rectangle) {
        super(pageIndex, text, rectangle);
    }

    public TextBlock(int pageIndex, String text, int x, int y, int width, int height) {
        super(pageIndex, text, x, y, width, height);
    }

}

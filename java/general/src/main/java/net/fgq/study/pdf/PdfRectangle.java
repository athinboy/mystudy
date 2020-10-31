package net.fgq.study.pdf;

import java.awt.*;
import java.awt.Point;

/**
 * Created by fengguoqiang 2020/10/31
 */
public class PdfRectangle extends Rectangle {

    public int getMiddleX() {
        return this.x + this.width / 2;
    }

    public int getMiddleY() {
        return this.y + this.height / 2;
    }

    public PdfRectangle() {
    }

    public PdfRectangle(Rectangle r) {
        super(r);
    }

    public PdfRectangle(int x, int y, int width, int height) {
        super(x, y, width, height);
    }

    public PdfRectangle(int width, int height) {
        super(width, height);
    }

    public PdfRectangle(Point p, Dimension d) {
        super(p, d);
    }

    public PdfRectangle(Point p) {
        super(p);
    }

    public PdfRectangle(Dimension d) {
        super(d);
    }
}

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

    /**
     * 是否同一行
     *
     * @param o
     * @param lineheight 行高
     * @return
     */
    public boolean checkSameLine(PdfRectangle o, int lineheight) {
        return Math.abs(this.getMiddleY() - o.getMiddleY()) < lineheight / 2;
    }

    /**
     * 是否在右侧
     *
     * @param o
     * @return
     */
    public boolean checkRightSide(PdfRectangle o) {
        return o.x > this.x;
    }

    public int maxY() {
        return this.y + this.height;
    }

    public int maxX() {
        return this.x + this.width;
    }

    /**
     * 获取垂直的距离。
     *
     * @param o
     * @return
     */
    public int getYDistinct(PdfRectangle o) {

        if (this.intersects(o)) {
            return 0;
        }
        if (this.maxY() <= o.y) {
            return o.y - this.maxY();
        }
        if (o.maxY() <= this.y) {
            return this.y - o.maxY();
        }
        return 0;

    }

    /**
     * 面积
     * @return
     */
    public int area() {
        return this.width*this.height;
    }
}

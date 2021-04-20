package net.fgq.study.pdf;

import java.awt.*;
import java.awt.Point;

/**
 * Created by fengguoqiang 2020/10/31
 */
public class PdfRectangle extends Rectangle {

    private int pageIndex;

    public int getMiddleX() {
        return this.x + this.width / 2;
    }

    public int getMiddleY() {
        return this.y + this.height / 2;
    }

    public PdfRectangle() {
    }

    public PdfRectangle(int pageIndex, Rectangle r) {
        super(r);
        this.pageIndex = pageIndex;
        if (r.height <= 0) {
            throw new IllegalArgumentException();
        }
    }

    public PdfRectangle(int pageIndex, int x, int y, int width, int height) {
        super(x, y, width, height);
        this.pageIndex = pageIndex;
        if (height <= 0) {
            throw new IllegalArgumentException();
        }
    }

    public PdfRectangle(int pageIndex, int width, int height) {
        super(width, height);
        this.pageIndex = pageIndex;
        if (height <= 0) {
            throw new IllegalArgumentException();
        }
    }

    public PdfRectangle(int pageIndex, Point p, Dimension d) {
        super(p, d);
        this.pageIndex = pageIndex;
    }

    public PdfRectangle(int pageIndex, Point p) {
        super(p);
        this.pageIndex = pageIndex;
    }

    public PdfRectangle(int pageIndex, Dimension d) {
        super(d);
        this.pageIndex = pageIndex;
    }

    public boolean intersects(PdfRectangle r) {
        if (this.pageIndex != r.pageIndex) {
            return false;
        }
        return super.intersects(r);
    }

    public PdfRectangle union(PdfRectangle r) {
        if (this.pageIndex != r.pageIndex) {
            throw new IllegalArgumentException();
        }
        return new PdfRectangle(this.getPageIndex(), super.union(r));
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
     *
     * @return
     */
    public int area() {
        return this.width * this.height;
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }
}

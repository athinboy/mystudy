package net.fgq.study.pdf;

import java.awt.*;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class Cell {

    private Line lineC1;//上方水平线
    private Line lineV1;//左侧垂直线
    private Line lineC2;//下方水平线
    private Line lineV2;//右侧垂直线

    private float startX;
    private float startY;
    private float endX;
    private float endY;

    public Cell(Line lineC1, Line lineV1, Line lineC2, Line lineV2) {
        this.lineC1 = lineC1;
        this.lineV1 = lineV1;
        this.lineC2 = lineC2;
        this.lineV2 = lineV2;
        startX = lineV1.getX1();
        startY = lineC1.getY1();
        endX = lineC2.getY1();
        endY = lineC2.getY1();
    }

    public Rectangle getRect() {
        return new Rectangle(Math.round(startX), Math.round(startY), Math.round(endX - startX), Math.round(endY - startY));
    }

    /**
     * 检查是否相近。
     *
     * @param o
     * @return
     */
    public boolean checkSimilarity(Cell o) {
        float gap = 1;
        return Math.abs(o.startX - this.startX) <= gap
                && Math.abs(o.startY - this.startY) <= gap
                && Math.abs(o.endX - this.endX) <= gap
                && Math.abs(o.endY - this.endY) <= gap;
    }

    @Override
    public String toString() {
        return "Cell{" +
                "startX=" + String.valueOf(startX) +
                ", startY=" + String.valueOf(startY) +
                ", endX=" + String.valueOf(endX) +
                ", endY=" + String.valueOf(endY) +
                '}';
    }
}

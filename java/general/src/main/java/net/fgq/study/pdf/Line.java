package net.fgq.study.pdf;

import java.awt.geom.Point2D;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class Line implements Comparable {

    public static enum DirectEnum {
        vertical, crosswise, slant
    }

    private float x1;
    private float y1;
    private float x2;
    private float y2;

    private DirectEnum directEnum;

    public Line(float x1, float y1, float x2, float y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Point2D.Float getStartPoint() {
        return new Point2D.Float(x1, y1);
    }

    public Point2D.Float getEndStartPoint() {
        return new Point2D.Float(x2, y2);
    }

    public float getX1() {
        return x1;
    }

    public void setX1(float x1) {
        this.x1 = x1;
    }

    public float getY1() {
        return y1;
    }

    public void setY1(float y1) {
        this.y1 = y1;
    }

    public float getX2() {
        return x2;
    }

    public void setX2(float x2) {
        this.x2 = x2;
    }

    public float getY2() {
        return y2;
    }

    public void setY2(float y2) {
        this.y2 = y2;
    }

    public DirectEnum getDirectEnum() {
        if (this.directEnum == null) {
            if (this.x1 == this.x2) {
                this.directEnum = DirectEnum.vertical;
            } else {
                this.directEnum = DirectEnum.crosswise;
            }
        }
        return directEnum;
    }

    public void setDirectEnum(DirectEnum directEnum) {
        this.directEnum = directEnum;
    }

    /**
     * 是否十字交叉
     *
     * @param o
     * @return
     */
    public boolean checkCross(Line o) throws Exception {

        if (this.getDirectEnum() == o.getDirectEnum()) {
            return false;
        }

        int x1r = Float.compare(this.x1, o.x1);
        int y1r = Float.compare(this.y1, o.y1);
        int x2r = Float.compare(this.x2, o.x2);
        int y2r = Float.compare(this.y2, o.y2);

        if (this.getDirectEnum() == DirectEnum.crosswise) {

            if (x1r <= 0 && x2r >= 0 && y1r >= 0 && y2r <= 0) {
                return true;
            }
            return false;
        }

        if (this.getDirectEnum() == DirectEnum.vertical) {

            if (x1r >= 0 && x2r <= 0 && y1r <= 0 && y2r >= 0) {
                return true;
            }
            return false;
        }
        throw new Exception("错误数据！");

    }

    /**
     * 判断是否重复
     * -1：不重复
     * 1：this更长
     * 0：重复
     * 2：o更长
     *
     * @param o
     * @return
     */
    public int checkDumplicated(Line o) {

        int x1r = Float.compare(this.x1, o.x1);
        int y1r = Float.compare(this.y1, o.y1);
        int x2r = Float.compare(this.x2, o.x2);
        int y2r = Float.compare(this.y2, o.y2);

        if (x1r != 0 && y1r != 0 && x2r != 0 && y2r != 0) {
            return -1;
        }

        if (x1r == 0 && y1r == 0 && x2r == 0 && y2r == 0) {
            return 0;
        }
        if ((x1r == 0 && x2r == 0)) {
            if (y1r <= 0 && y2r >= 0) {
                return 1;
            }
            if (y1r >= 0 && y2r <= 0) {
                return 2;
            }
        }
        if ((y1r == 0 && y2r == 0)) {
            if (x1r <= 0 && x2r >= 0) {
                return 1;
            }
            if (x1r >= 0 && x2r <= 0) {
                return 2;
            }
        }

        return -1;

    }

    @Override
    public int compareTo(Object o) {
        if (false == o instanceof Line) {
            throw new RuntimeException("错误的对象");
        }

        Line other = (Line) o;
        int r = Float.compare(this.x1, other.x1);
        if (r != 0) {
            return r;
        }
        r = Float.compare(this.y1, other.y1);
        if (r != 0) {
            return r;
        }
        r = Float.compare(this.x2, other.x2);
        if (r != 0) {
            return r;
        }
        r = Float.compare(this.y2, other.y2);
        if (r != 0) {
            return r;
        } else {
            throw new RuntimeException("重复线条");
        }

    }
}

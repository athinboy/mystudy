package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfRectangle;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

/**
 * 信息组。
 * Created by fengguoqiang 2021/4/12
 */
public class InfoGroup {

    public InfoGroup(String key) {
        this.key = key;
    }

    private String key;
    private PdfRectangle rectangle;

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public PdfRectangle getRectangle() {
        return rectangle;
    }

    public void setRectangle(PdfRectangle rectangle) {
        this.rectangle = rectangle;
    }

    /**
     * 合并最近(仅仅考虑垂直方向的距离)的 PdfRectangle；
     *
     * @param candidateRects
     * @return
     */
    public List<PdfRectangle> mergeNear(List<PdfRectangle> candidateRects) {

        if (candidateRects == null || candidateRects.size() == 0) return candidateRects;
        if (candidateRects.size() == 1) {
            if (this.rectangle != null && candidateRects.get(0).getPageIndex() != this.rectangle.getPageIndex()) {
                return new ArrayList<>();
            }
            this.rectangle = this.rectangle == null ? new PdfRectangle(candidateRects.get(0).getPageIndex(), candidateRects.get(0))
                    : new PdfRectangle(candidateRects.get(0).getPageIndex(), this.rectangle.union(candidateRects.get(0)));
            return candidateRects;
        }
        if (this.rectangle == null) {
            return candidateRects;
        }

        List<PdfRectangle> result = new ArrayList<>();
        int minD = Integer.MAX_VALUE;
        for (PdfRectangle candidateRect : candidateRects) {
            int d = candidateRect.getYDistinct(this.rectangle);
            if (result.size() == 0) {
                minD = d;
                result.add(candidateRect);
            } else {
                if (minD > d) {
                    minD = d;
                    result.clear();
                    result.add(candidateRect);
                }
            }
        }
        return result;

    }
}

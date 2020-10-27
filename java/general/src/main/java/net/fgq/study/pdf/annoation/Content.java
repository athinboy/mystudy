package net.fgq.study.pdf.annoation;

import org.apache.commons.lang3.StringUtils;

import java.awt.*;

public class Content {

    /**
     * json key name;
     */
    private String jsonKey;

    /**
     * 区域
     */
    private Rectangle Rectangle;

    private int pageIndex;

    public Content(int pageIndex, String jsonKey, java.awt.Rectangle rectangle) {

        if (StringUtils.isBlank(jsonKey) || rectangle == null) {
            throw new IllegalArgumentException();
        }
        this.jsonKey = jsonKey;
        this.Rectangle = rectangle;
        this.pageIndex = pageIndex;
    }

    public Content(int pageIndex, String jsonKey, int x, int y, int width, int height) {
        this(pageIndex, jsonKey, new Rectangle(x, y, width, height));
    }

    public String getJsonKey() {
        return jsonKey;
    }

    public void setJsonKey(String jsonKey) {
        this.jsonKey = jsonKey;
    }

    public java.awt.Rectangle getRectangle() {
        return Rectangle;
    }

    public void setRectangle(java.awt.Rectangle rectangle) {
        Rectangle = rectangle;
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }
}

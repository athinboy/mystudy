package net.fgq.study.pdf.annoation;

import org.apache.commons.lang3.StringUtils;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/**
 * 基于位置提取的内容
 */
public class Content {

    /**
     * json key name;
     */
    private String jsonKey;

    /**
     * 区域
     */
    private Rectangle Rectangle;

    /**
     * lable标记文字（正则表达式）
     */
    private List<String> lableSigns = new ArrayList<>();

    /**
     * 值正则模式
     */
    private List<String> valueRegstr = new ArrayList<>();

    public Pattern getValuePattern() {
        String singstr = "(" + String.join(")|(", this.getValueRegstr()) + ")";
        return Pattern.compile(singstr);
    }

    public Pattern getLableSignsPattern() {
        String singstr = "(" + String.join(")|(", this.getLableSigns()) + ")";
        return Pattern.compile(singstr);
    }

    /**
     * 右侧标记文字（正则表达式）
     */
    private List<String> rightSigns = new ArrayList<>();

    public Pattern getRightSignsPattern() {
        String singstr = "(" + String.join(")|(", this.getRightSigns()) + ")";
        return Pattern.compile(singstr);
    }

    private int pageIndex;

    public Content(int pageIndex, String jsonKey, String... lablesigns) {

        if (StringUtils.isBlank(jsonKey) || lablesigns == null || lablesigns.length == 0) {
            throw new IllegalArgumentException();
        }
        this.jsonKey = jsonKey;
        for (int i = 0; i < lablesigns.length; i++) {
            this.lableSigns.add(lablesigns[i]);
        }
        this.pageIndex = pageIndex;

    }

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

    public List<String> getLableSigns() {
        return lableSigns;
    }

    public void setLableSigns(List<String> lableSigns) {
        this.lableSigns = lableSigns;
    }

    public List<String> getRightSigns() {
        return rightSigns;
    }

    public Content setRightSigns(List<String> rightSigns) {
        this.rightSigns = rightSigns;
        return this;
    }

    public void setValueRegstr(List<String> valuePattern) {
        this.valueRegstr = valuePattern;
    }

    public List<String> getValueRegstr() {
        return valueRegstr;
    }

    @Override
    public String toString() {
        return "Content{" +
                "jsonKey='" + jsonKey + '\'' +
                ", lableSigns=" + lableSigns +
                ", pageIndex=" + pageIndex +
                '}';
    }
}

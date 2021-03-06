package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import org.apache.commons.lang3.StringUtils;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Predicate;
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
     * Label标记文字（正则表达式）
     */
    private List<String> LabelSigns = new ArrayList<>();

    /**
     * 值正则模式
     */
    private List<String> valueRegstr = new ArrayList<>();
    /**
     * 列多行，需要上下扩展。
     */
    private boolean valueMultiLine = false;

    private OrderItemInfo orderItem;

    /**
     * 垂直顺序,从0到6.
     */
    private int verticalSort = -1;

    private Predicate<String> valuePredicate = null;
    private Predicate<String> labelSignsPredicate = null;
    private Predicate<String> rightSignsPredicate = null;
    private int priority = 1;

    public Predicate<String> getValuePredicate() {
        if (valuePredicate == null) {
            String singstr = "(" + String.join(")|(", this.getValueRegstr()) + ")";
            valuePredicate = Pattern.compile(singstr).asPredicate();
        }
        return valuePredicate;
    }

    public Pattern getValuePattern() {
        String singstr = "(" + String.join(")|(", this.getValueRegstr()) + ")";
        return Pattern.compile(singstr);
    }

    public Pattern getLabelSignsPattern() {
        String singstr = "(" + String.join(")|(", this.getLabelSigns()) + ")";
        return Pattern.compile(singstr);

    }

    public Predicate<String> getLabelSignsPredicate() {
        if (labelSignsPredicate == null) {
            String singstr = "(" + String.join(")|(", this.getLabelSigns()) + ")";
            labelSignsPredicate = Pattern.compile(singstr).asPredicate();
        }
        return labelSignsPredicate;
    }

    public Predicate<String> getRightSignsPredicate() {
        if (rightSignsPredicate == null) {
            String singstr = "(" + String.join(")|(", this.getRightSigns()) + ")";
            rightSignsPredicate = Pattern.compile(singstr).asPredicate();
        }
        return rightSignsPredicate;
    }

    /**
     * 右侧标记文字（正则表达式）
     */
    private List<String> rightSigns = new ArrayList<>();

    private int startPageIndex;
    private int endPageIndex;

    public Content(int startPageIndex, int endPageIndex, String jsonKey, String... Labelsigns) {

        if (StringUtils.isBlank(jsonKey) || Labelsigns == null || Labelsigns.length == 0) {
            throw new IllegalArgumentException();
        }
        this.jsonKey = jsonKey;
        for (int i = 0; i < Labelsigns.length; i++) {
            this.LabelSigns.add(Labelsigns[i]);
        }
        this.startPageIndex = startPageIndex;
        this.endPageIndex = endPageIndex;
    }

    public Content(int startPageIndex, int endPageIndex, String jsonKey, java.awt.Rectangle rectangle) {

        if (StringUtils.isBlank(jsonKey) || rectangle == null) {
            throw new IllegalArgumentException();
        }
        this.jsonKey = jsonKey;
        this.Rectangle = rectangle;
        this.startPageIndex = startPageIndex;
        this.endPageIndex = endPageIndex;

    }

    public Content(int startPageIndex, int endPageIndex, String jsonKey, int x, int y, int width, int height) {
        this(startPageIndex, endPageIndex, jsonKey, new Rectangle(x, y, width, height));
    }

    public Content(int pageIndex, String jsonKey, int x, int y, int width, int height) {
        this(pageIndex, pageIndex, jsonKey, new Rectangle(x, y, width, height));
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

    public List<String> getLabelSigns() {
        return LabelSigns;
    }

    public void setLabelSigns(List<String> LabelSigns) {
        this.LabelSigns = LabelSigns;
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
                ", LabelSigns=" + LabelSigns +
                ", valueRegstr=" + valueRegstr +
                ", priority=" + priority +
                ", startPageIndex=" + startPageIndex +
                ", endPageIndex=" + endPageIndex +
                '}';
    }

    public Object formatValue(final String valuestr) {
        return valuestr;
    }

    public boolean getValueMultiLine() {
        return valueMultiLine;
    }

    public void setValueMultiLine(boolean valueMultiLine) {
        this.valueMultiLine = valueMultiLine;
    }

    public void setOrderItem(OrderItemInfo orderItem) {
        this.orderItem = orderItem;
    }

    public OrderItemInfo getOrderItem() {
        return orderItem;
    }

    public int getPriority() {
        return priority;
    }

    public void setPriority(int priority) {
        this.priority = priority;
    }

    public boolean checkPage(int pageIndex) {
        return this.startPageIndex <= pageIndex && this.endPageIndex >= pageIndex;
    }

    public int getStartPageIndex() {
        return startPageIndex;
    }

    public void setStartPageIndex(int startPageIndex) {
        this.startPageIndex = startPageIndex;
    }

    public int getEndPageIndex() {
        return endPageIndex;
    }

    public void setEndPageIndex(int endPageIndex) {
        this.endPageIndex = endPageIndex;
    }

    public boolean isValueMultiLine() {
        return valueMultiLine;
    }

    public int getVerticalSort() {
        return verticalSort;
    }

    public void setVerticalSort(int verticalSort) {
        this.verticalSort = verticalSort;
    }
}

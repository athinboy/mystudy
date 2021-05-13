package net.fgq.study.pdf.annoation;

import javafx.scene.text.TextAlignment;
import net.fgq.study.pdf.PdfTextPosition;
import org.apache.commons.lang3.StringUtils;

import java.lang.reflect.Type;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2020/10/27
 * <p>
 * <b>要求：</b><br/>
 * 列头文字必须是居中的，否则无法确定列宽度<br/>
 * 单元格文字必须是垂直居中，否则多行内容无法确定单元格高度<br/>
 * </p>
 */
public class Column {

    public final static String dumplicateColSuffix = "1";

    private int index = 0;

    /**
     * 列头标记正则表达式，同一个表格中，必须唯一。
     * 用于多行列头。
     */
    private List<String> signs = new ArrayList<>();

    /**
     * 列json key name；
     */
    private String jsonKey;

    /**
     * 运行时-宽度。
     */
    private int runtimeWidth;

    /**
     * 运行时-左边
     */
    private int runtimeMinX;

    /**
     * 运行时-右边
     */
    private int runtimeMaxX;

    /**
     * 运行时-头中线。
     */
    private int runtimeHeaderMiddleX;

    /**
     * 运行时-单元格字符宽度。
     */
    private int runtimeCellCharWidth;

    /**
     * 值类型。
     */
    private Type valueType = String.class;

    /**
     * 是否不可为空
     */
    private boolean notEmpty = false;

    private TextHorizontalAlignEnum cellHoriztalAlignment = TextHorizontalAlignEnum.LEFT;

    private TextVerticalAlignEnum cellVerticalAlignment = TextVerticalAlignEnum.TOP;

    public Column(String sign, String jsonKey) {

        if (StringUtils.isBlank(sign) || StringUtils.isBlank(jsonKey)) {
            throw new IllegalArgumentException();
        }

        this.signs.add(sign);
        this.jsonKey = jsonKey;

    }

    public Column(String sign, String jsonKey, boolean notEmpty) {

        this(sign, jsonKey);
        this.setNotEmpty(notEmpty);
    }

    public Column(String sign, String jsonKey, TextHorizontalAlignEnum cellHoriztalAlignment, TextVerticalAlignEnum cellVerticalAlignment) {

        this(sign, jsonKey);
        this.cellHoriztalAlignment = cellHoriztalAlignment;
        this.cellVerticalAlignment = cellVerticalAlignment;
    }

    public Column(String sign, String jsonKey, TextHorizontalAlignEnum cellHoriztalAlignment,
                  TextVerticalAlignEnum cellVerticalAlignment, Type valueType) {

        this(sign, jsonKey, cellHoriztalAlignment, cellVerticalAlignment);
        this.setValueType(valueType);
    }

    public Pattern getSignPattern() {
        String singstr = "(" + String.join(")|(", this.getSigns()) + ")";
        return Pattern.compile(singstr);
    }

    public boolean isNotEmpty() {
        return notEmpty;
    }

    public void setNotEmpty(boolean notEmpty) {
        this.notEmpty = notEmpty;
    }

    public Type getValueType() {
        return valueType;
    }

    public void setValueType(Type valueType) {
        this.valueType = valueType;
    }

    public List<String> getSigns() {
        return signs;
    }

    public void setSigns(List<String> signs) {
        this.signs = signs;
    }

    public String getJsonKey() {
        return jsonKey;
    }

    public void setJsonKey(String jsonKey) {
        this.jsonKey = jsonKey;
    }

    public int getRuntimeWidth() {
        return runtimeWidth;
    }

    public void setRuntimeWidth(int runtimeWidth) {
        this.runtimeWidth = runtimeWidth;
    }

    public int getRuntimeMinX() {
        return runtimeMinX;
    }

    public void setRuntimeMinX(int runtimeMinX) {
        this.runtimeMinX = runtimeMinX;
    }

    public int getRuntimeMaxX() {
        return runtimeMaxX;
    }

    public void setRuntimeMaxX(int runtimeMaxX) {
        this.runtimeMaxX = runtimeMaxX;
    }

    public int getRuntimeHeaderMiddleX() {
        return runtimeHeaderMiddleX;
    }

    public void setRuntimeHeaderMiddleX(int runtimeHeaderMiddleX) {
        this.runtimeHeaderMiddleX = runtimeHeaderMiddleX;
    }

    public TextHorizontalAlignEnum getCellHoriztalAlignment() {
        return cellHoriztalAlignment;
    }

    public void setCellHoriztalAlignment(TextHorizontalAlignEnum cellHoriztalAlignment) {
        this.cellHoriztalAlignment = cellHoriztalAlignment;
    }

    public TextVerticalAlignEnum getCellVerticalAlignment() {
        return cellVerticalAlignment;
    }

    public void setCellVerticalAlignment(TextVerticalAlignEnum cellVerticalAlignment) {
        this.cellVerticalAlignment = cellVerticalAlignment;
    }

    /**
     * 解析值
     *
     * @param text
     * @return
     */
    public Object parseValue(final String text) {
        if (this.notEmpty && StringUtils.isBlank(text)) {
            throw new IllegalArgumentException("值不可为空:" + this.signs.get(0));
        }
        if (text == null) {
            return text;
        }
        if (this.valueType.equals(String.class)) {
            return text;
        } else if (this.valueType.equals(BigDecimal.class)) {
            try {
                String vstr = text.replace(",", "")
                        .replace("—", "")
                        .replace("—", "")
                        .replace("-", "");
                if (vstr.length() > 0) {
                    BigDecimal bgv = new BigDecimal(vstr);
                    return bgv;
                } else if (text.length() > 0 && vstr.length() == 0) {
                    return BigDecimal.ZERO;
                } else {
                    return null;
                }

            } catch (Exception ex) {
                throw new IllegalArgumentException("错误值：" + String.join("-", this.signs) + ":" + text);
            }

        } else {
            return text;
        }

    }

    public int getIndex() {
        return index;
    }

    public void setIndex(int index) {
        this.index = index;
    }

    public Column addSign(String sign) {
        this.getSigns().add(sign);
        return this;
    }

    public int getRuntimeCellCharWidth() {
        return runtimeCellCharWidth;
    }

    public void setRuntimeCellCharWidth(int runtimeCellCharWidth) {
        this.runtimeCellCharWidth = runtimeCellCharWidth;
    }

    @Override
    public String toString() {
        return "Column{" +
                "index=" + index +
                ", signs=" + signs +
                ", jsonKey='" + jsonKey + '\'' +
                '}';
    }
}

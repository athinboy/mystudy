package net.fgq.study.pdf.annoation;

import javafx.scene.text.TextAlignment;
import org.apache.commons.lang3.StringUtils;

/**
 * Created by fengguoqiang 2020/10/27
 * <p>
 * <b>要求：</b><br/>
 * 列头文字必须是居中的，否则无法确定列宽度<br/>
 * 单元格文字必须是垂直居中，否则多行内容无法确定单元格高度<br/>
 * </p>
 */
public class Column {

    /**
     * 列头标记
     */
    private String sign;

    /**
     * 列json key name；
     */
    private String jsonKey;

    /**
     * 宽度。
     */
    private int width;

    private TextAlignment cellAlignment = TextAlignment.LEFT;

    public Column(String sign, String jsonKey, int width) {

        if (StringUtils.isBlank(sign) || StringUtils.isBlank(jsonKey)) {
            throw new IllegalArgumentException();
        }

        this.sign = sign;
        this.jsonKey = jsonKey;
        this.width = width;
    }

    public Column(String sign, String jsonKey, int width, TextAlignment cellAlignment) {

        this(sign, jsonKey, width);
        this.cellAlignment = cellAlignment;
    }

    public String getSign() {
        return sign;
    }

    public void setSign(String sign) {
        this.sign = sign;
    }

    public String getJsonKey() {
        return jsonKey;
    }

    public void setJsonKey(String jsonKey) {
        this.jsonKey = jsonKey;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public TextAlignment getCellAlignment() {
        return cellAlignment;
    }

    public void setCellAlignment(TextAlignment cellAlignment) {
        this.cellAlignment = cellAlignment;
    }
}

package net.fgq.study.pdf.annoation;

import javafx.scene.text.TextAlignment;
import net.fgq.study.pdf.PdfTextPosition;
import org.apache.commons.lang3.StringUtils;

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

    /**
     * 列头标记正则表达式，同一个表格中，必须唯一
     */
    private String sign;

    private Pattern signPatter;

    /**
     * 列json key name；
     */
    private String jsonKey;

    /**
     * 宽度。
     */
    private int width;

    private TextHorizontalAlignEnum cellHoriztalAlignment = TextHorizontalAlignEnum.LEFT;

    private TextVerticalAlignEnum cellVerticalAlignment = TextVerticalAlignEnum.TOP;

    public Column(String sign, String jsonKey, int width) {

        if (StringUtils.isBlank(sign) || StringUtils.isBlank(jsonKey)) {
            throw new IllegalArgumentException();
        }

        this.setSign(sign);
        this.jsonKey = jsonKey;
        this.width = width;
    }

    public Column(String sign, String jsonKey, int width, TextHorizontalAlignEnum cellHoriztalAlignment, TextVerticalAlignEnum cellVerticalAlignment) {

        this(sign, jsonKey, width);
        this.cellHoriztalAlignment = cellHoriztalAlignment;
        this.cellVerticalAlignment = cellVerticalAlignment;
    }

    public String getSign() {
        return sign;
    }

    public void setSign(String sign) {
        this.sign = sign;
        this.signPatter = Pattern.compile(this.sign);
    }

    public Pattern getSignPatter() {
        return signPatter;
    }

    public void setSignPatter(Pattern signPatter) {
        this.signPatter = signPatter;
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

}

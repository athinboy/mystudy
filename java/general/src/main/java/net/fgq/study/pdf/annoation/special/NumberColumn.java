package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.TextHorizontalAlignEnum;

import java.math.BigDecimal;

/**
 * 数值列
 * Created by fengguoqiang 2020/10/29
 */
public class NumberColumn extends Column {

    public NumberColumn(String sign, String jsonKey) {
        super(sign, jsonKey);
        this.setCellHoriztalAlignment(TextHorizontalAlignEnum.RIGHT);
        this.setValueType(BigDecimal.class);
        this.setNotEmpty(true);
    }

    public NumberColumn(String sign, String jsonKey, TextHorizontalAlignEnum textHorizontalAlignEnum) {
        super(sign, jsonKey);
        this.setCellHoriztalAlignment(TextHorizontalAlignEnum.RIGHT);
        this.setValueType(BigDecimal.class);
        this.setNotEmpty(true);
        setCellHoriztalAlignment(textHorizontalAlignEnum);
    }

    public NumberColumn(String sign, String jsonKey, boolean notEmpty) {
        this(sign, jsonKey);
        this.setNotEmpty(notEmpty);
    }

}

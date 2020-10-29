package net.fgq.study.pdf.annoation.special;

import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.TextHorizontalAlignEnum;

import java.math.BigDecimal;

/**
 * 数值列
 * Created by fengguoqiang 2020/10/29
 */
public class NumberColumn extends Column {

    public NumberColumn(String sign, String jsonKey, int width) {
        super(sign, jsonKey, width);
        this.setCellHoriztalAlignment(TextHorizontalAlignEnum.RIGHT);
        this.setValueType(BigDecimal.class);
    }

    public NumberColumn(String sign, String jsonKey, int width, boolean notEmpty) {
        this(sign, jsonKey, width);
        this.setNotEmpty(notEmpty);
    }

}

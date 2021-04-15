package net.fgq.study.pdf.annoation.special.content;

import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import org.apache.commons.lang3.StringUtils;

import java.math.BigDecimal;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class MoneyContent extends Content {

    {
        this.getValueRegstr().add(ContentValueTypeEnum.Money.getRegexStr());
    }

    public MoneyContent(int startPageIndex, int endPageIndex, String jsonKey, String... lablesigns) {
        super(startPageIndex, endPageIndex, jsonKey, lablesigns);
    }

    public MoneyContent(int pageIndex, String jsonKey, String... lablesigns) {
        this(pageIndex, pageIndex, jsonKey, lablesigns);
    }

    public MoneyContent(int startPageIndex, int endPageIndex, String jsonKey, java.awt.Rectangle rectangle) {
        super(startPageIndex, endPageIndex, jsonKey, rectangle);
    }

    public MoneyContent(int startPageIndex, int endPageIndex, String jsonKey, int x, int y, int width, int height) {
        super(startPageIndex, endPageIndex, jsonKey, x, y, width, height);
    }

    @Override
    public Object formatValue(final String valuestr) {

        if (StringUtils.isBlank(valuestr)) {
            return null;
        }
        try {
            String str = valuestr.replace("RMB", "")
                    .replace("元", "")
                    .replace("￥", "")
                    .replaceAll(",", "");
            BigDecimal value = new BigDecimal(str);
            return value;
        } catch (Exception ex) {
            throw new PdfException("处理数值字符串异常：" + valuestr);
        }

    }

}

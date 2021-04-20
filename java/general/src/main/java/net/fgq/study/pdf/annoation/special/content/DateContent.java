package net.fgq.study.pdf.annoation.special.content;

import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.time.DateUtils;

import java.util.Date;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class DateContent extends Content {

    {
        this.getValueRegstr().add(ContentValueTypeEnum.Date.getRegexStr());
    }

    public DateContent(int startPageIndex, int endPageIndex, String jsonKey, String... labelsigns) {
        super(startPageIndex, endPageIndex, jsonKey, labelsigns);
    }

    public DateContent(int pageIndex, String jsonKey, String... labelsigns) {
        this(pageIndex, pageIndex, jsonKey, labelsigns);
    }

    public DateContent(int startPageIndex, int endPageIndex, String jsonKey, java.awt.Rectangle rectangle) {
        super(startPageIndex, endPageIndex, jsonKey, rectangle);
    }

    public DateContent(int pageIndex, String jsonKey, java.awt.Rectangle rectangle) {
        this(pageIndex, pageIndex, jsonKey, rectangle);
    }

    public DateContent(int startPageIndex, int endPageIndex, String jsonKey, int x, int y, int width, int height) {
        super(startPageIndex, endPageIndex, jsonKey, x, y, width, height);
    }

    @Override
    public Object formatValue(final String valuestr) {

        if (StringUtils.isBlank(valuestr)) {
            return null;
        }
        try {

            String str = valuestr
                    .replaceAll("/", "-")
                    .replace("年", "-")
                    .replace("月", "-")
                    .replace("日", "");
            Date value = DateUtils.parseDate(str, "yyyy-MM-dd");
            return value;
        } catch (Exception ex) {
            throw new PdfException("处理日期字符串异常：" + valuestr);
        }
    }
}

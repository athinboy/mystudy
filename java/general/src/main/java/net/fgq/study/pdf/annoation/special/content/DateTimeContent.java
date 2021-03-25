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
public class DateTimeContent extends Content {

    {
        this.getValueRegstr().add(ContentValueTypeEnum.Date.getRegexStr());
    }

    public DateTimeContent(int pageIndex, String jsonKey, String... lablesigns) {
        super(pageIndex, jsonKey, lablesigns);

    }

    public DateTimeContent(int pageIndex, String jsonKey, java.awt.Rectangle rectangle) {
        super(pageIndex, jsonKey, rectangle);
    }

    public DateTimeContent(int pageIndex, String jsonKey, int x, int y, int width, int height) {
        super(pageIndex, jsonKey, x, y, width, height);
    }

    @Override
    public Object formatValue(final String valuestr) {

        if (StringUtils.isBlank(valuestr)) {
            return null;
        }
        try {

            String str = valuestr.replace("年", "-")
                    .replace("月", "-")
                    .replace("日", " ")
                    .replaceAll("时", ":")
                    .replaceAll("分", ":")
                    .replaceAll("秒", "")
                    .replaceAll("零", "0")
                    .replaceAll("至", "")
                    .replaceAll("起", "")
                    .replaceAll("止", "");
            if (str.endsWith(":")) {
                str = str + "00";
            }
            Date value = DateUtils.parseDate(str, "yyyy-MM-dd HH:mm:ss");
            return value;
        } catch (Exception ex) {
            throw new PdfException("处理日期字符串异常：" + valuestr);
        }
    }
}

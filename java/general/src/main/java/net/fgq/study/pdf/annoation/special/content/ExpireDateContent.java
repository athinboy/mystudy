package net.fgq.study.pdf.annoation.special.content;

import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.time.DateUtils;

import java.util.Date;

/**
 * 失效日期
 * Created by fengguoqiang 2021/3/24
 */
public class ExpireDateContent extends Content {

    {
        this.getValueRegstr().add("(至|起至)\\d{4}年\\d{1,2}月\\d{1,2}日((零|(\\d{1,2}))时(\\d{1,2}分(\\d{1,2}秒){0,1}){0,1}){0,1}止{0,1}");
    }

    public ExpireDateContent(int startPageIndex, int endPageIndex, String jsonKey, String[] labelsigns) {
        super(startPageIndex, endPageIndex, jsonKey, labelsigns);
    }

    @Override
    public Object formatValue(final String value) {

        if (StringUtils.isBlank(value)) {
            return null;
        }
        String valuestr = value;
        try {

            if (valuestr.endsWith("时")
                    || valuestr.endsWith("时止")) {
                valuestr = valuestr.replace("时", ":00:00");
            }

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
            Date r = DateUtils.parseDate(str, "yyyy-MM-dd HH:mm:ss");
            return r;
        } catch (Exception ex) {
            throw new PdfException("处理日期字符串异常：" + value);
        }
    }
}

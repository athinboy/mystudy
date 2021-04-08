package net.fgq.study.pdf.annoation.special.content;

import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.time.DateUtils;

import java.util.Date;

/**
 * 生效日期
 * Created by fengguoqiang 2021/3/24
 */
public class EffectiveDateContent extends Content {

    {
        this.getValueRegstr().add("\\d{4}年\\d{2}月\\d{2}日((零|(\\d{1,2}))时(\\d{1,2}分(\\d{1,2}秒){0,1}){0,1}){0,1}起{0,1}至");
    }

    public EffectiveDateContent(int pageIndex, String jsonKey, String[] lablesigns) {
        super(pageIndex, jsonKey, lablesigns);

    }

    @Override
    public Object formatValue(final String value) {

        //2021年03月13日0时起至
        String valuestr2 = value;
        if (StringUtils.isBlank(valuestr2)) {
            return null;
        }
        try {
            if (valuestr2.endsWith("时")
                    || valuestr2.endsWith("时起")
                    || valuestr2.endsWith("时起至")) {
                valuestr2 = valuestr2.replace("时", ":00:00");
            }
            String str = valuestr2.replace("年", "-")
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

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
        this.getValueRegstr().add("\\d{4}年\\d{2}月\\d{2}日((零|(\\d{1,2}))时\\d{1,2}分(\\d{1,2}秒){0,1}){0,1}起{0,1}至");
    }

    public EffectiveDateContent(int pageIndex, String jsonKey) {
        super(pageIndex, jsonKey, "保险期间");

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

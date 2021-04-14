package net.fgq.study.pdf;

import java.util.Arrays;
import java.util.List;

/**
 * Created by fengguoqiang 2021/4/14
 */
public class LexicHelper {

    private static List<String> excludeLexics = Arrays.asList(
            "发生本保险合同约定的保险事故"
            , "在保险期间内可享受出险代步车服");

    /**
     * 检测信息项目
     *
     * @param textPosition
     * @return
     */
    public static boolean checkLabel(PdfTextPosition textPosition) {
        for (String excludeLexic : excludeLexics) {
            if (textPosition.getTrimedText().contains(excludeLexic)) {
                return false;
            }
        }
        return true;
    }
}

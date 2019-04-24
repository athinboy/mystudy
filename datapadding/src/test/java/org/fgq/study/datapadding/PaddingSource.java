package org.fgq.study.datapadding;

import org.springframework.stereotype.Component;

/**
 * @author fenggqc
 * @create 2018-10-24 15:06
 **/

@Component
public class PaddingSource {

    //region Getter And Setter
    // endregion

    public static String getStatA = "getStatA";

    /**
     * 静态对象，返回字符串
     *
     * @return
     */
    public static String getStaticString() {
        return "PaddingSource.StaticString";
    }

    /**
     * 实例对象，返回字符串
     *
     * @return
     */
    public static String getInstanceString() {
        return "PaddingSource.InstanceString";
    }

}

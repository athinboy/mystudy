package org.fgq.study.datapadding.annotation;

import java.lang.annotation.*;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-10-24 14:17
 **/


@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
@Documented
public @interface NeedPad {


    /**
     * 填充顺序。数字越高优先级越高。
     */
    int PadSort() default 1;

    Class SourceClass();

    /**
     * 获取方法。
     *
     * @return
     */
    String SourceMethod();

    /**
     * SourceMethod 方法的参数对应的字段名称。
     *
     * @return
     */
    String[] ParaFieldNames() default {};

    /**
     * 参数一样的情况下，也要每次都调用获取方法。
     *
     * @return
     */
    boolean NoCache() default false;

}

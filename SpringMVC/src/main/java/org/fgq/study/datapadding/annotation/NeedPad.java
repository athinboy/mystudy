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

    String SourceMethod();

    String[] ParaField() default {};

}

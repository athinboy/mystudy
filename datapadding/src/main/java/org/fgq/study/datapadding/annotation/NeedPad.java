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
     * 原对象为无状态对象。
     * true：常用于spring中。原对象可以一直缓存起来被调用。
     * false：原对象不能被缓存。完成一次填充调用后将被丢弃。
     *
     * @return
     */
    boolean SourceNoStatus() default true;

    /**
     * 获取方法。
     *
     * @return
     */
    String SourceMethod();

    /**
     * ParaFieldNames为空时，允许自动推断ParaFieldNames。
     * <p>
     * 暂时无法支持设置为true ，默认情况下拿到的参数名是argN
     *
     * @return
     */
    boolean enableParaFieldInfer() default false;

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

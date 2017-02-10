package org.fgq.query.annotation;


import java.lang.annotation.*;

/**
 * 标示类对应的数据表。
 * Created by fenggqc on 2016/12/13.
 */
@Deprecated
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.TYPE)
public @interface ClassTableName {
    String[] TableNames = null;
}

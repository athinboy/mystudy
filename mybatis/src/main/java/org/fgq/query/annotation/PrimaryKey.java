package org.fgq.query.annotation;

import java.lang.annotation.*;

/**
 * indicate the field is a primary column
 * Created by fenggqc on 2016/12/18.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.FIELD)
public @interface PrimaryKey {
}

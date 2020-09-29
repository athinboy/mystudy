package org.fgq.query.annotation;

import java.lang.annotation.*;

/**
 *
 * Created by fenggqc on 2016/12/18.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.FIELD)
public @interface FieldTableName {
    String value();
}

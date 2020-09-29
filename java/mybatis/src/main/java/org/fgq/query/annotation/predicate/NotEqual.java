package org.fgq.query.annotation.predicate;

import java.lang.annotation.*;

/**
 * NotEqual
 * Created by fenggqc on 2016/12/15.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface NotEqual {
    String fieldname();
}

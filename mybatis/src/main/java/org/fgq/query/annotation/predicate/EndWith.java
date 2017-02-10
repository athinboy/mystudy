package org.fgq.query.annotation.predicate;

import java.lang.annotation.*;

/**
 * end with,translate to "like %AA"
 * Created by fenggqc on 2016/12/15.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface EndWith {
    String fieldname();
}

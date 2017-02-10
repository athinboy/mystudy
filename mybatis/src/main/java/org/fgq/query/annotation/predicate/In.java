package org.fgq.query.annotation.predicate;

import java.lang.annotation.*;

/**
 * In
 * Created by fenggqc on 2016/12/16.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface In {
    String fieldname();
}

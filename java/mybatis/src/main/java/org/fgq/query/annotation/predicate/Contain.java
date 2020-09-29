package org.fgq.query.annotation.predicate;

import java.lang.annotation.*;

/**
 * Contain,,translate to "like %AA%"
 * Created by fenggqc on 2016/12/15.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface Contain {
    String fieldname();
}

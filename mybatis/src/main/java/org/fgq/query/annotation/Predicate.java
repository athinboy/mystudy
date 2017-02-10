package org.fgq.query.annotation;

import java.lang.annotation.*;

/**
 *
 * Created by fenggqc on 2016/12/15.
 */
@Documented
@Deprecated
@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface Predicate {
}

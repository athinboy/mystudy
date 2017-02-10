package org.fgq.query.annotation;

import java.lang.annotation.*;

/**
 * indicate the class is Multi  table join  DTO.
 * Created by fenggqc on 2016/12/22.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.TYPE)
public @interface MTDto {

}

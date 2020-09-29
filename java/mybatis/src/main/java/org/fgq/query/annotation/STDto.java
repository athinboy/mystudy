package org.fgq.query.annotation;

import java.lang.annotation.*;

/**
 * indicate the class is simple table  DTO.
 * Created by fenggqc on 2016/12/18.
 */
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.TYPE)
public @interface STDto {
    String  TableName();
}

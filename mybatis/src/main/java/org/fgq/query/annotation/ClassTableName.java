package org.fgq.query.annotation;


import java.lang.annotation.*;

/**
 * ��ʾ���Ӧ�����ݱ�
 * Created by fenggqc on 2016/12/13.
 */
@Deprecated
@Documented
@Retention(RetentionPolicy.RUNTIME)
@Target(value = ElementType.TYPE)
public @interface ClassTableName {
    String[] TableNames = null;
}

package org.fgq.study.datapadding.fastjson;

import com.alibaba.fastjson.annotation.JSONType;
import com.alibaba.fastjson.util.FieldInfo;

/**
 * @author fenggqc
 * @create 2018-10-26 17:56
 **/
public class SerializeBeanInfo {

    public final Class<?> beanType;
    public final String typeName;
    public final JSONType jsonType;

    public final FieldInfo[] fields;
    public final FieldInfo[] sortedFields;

    public int features;

    public SerializeBeanInfo(Class<?> beanType, //
                             JSONType jsonType, //
                             String typeName, //
                             int features,
                             FieldInfo[] fields, //
                             FieldInfo[] sortedFields
    ) {
        this.beanType = beanType;
        this.jsonType = jsonType;
        this.typeName = typeName;
        this.features = features;
        this.fields = fields;
        this.sortedFields = sortedFields;
    }
}

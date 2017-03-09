package org.fgq.query.mapping;

import org.apache.commons.lang3.NotImplementedException;
import org.fgq.query.annotation.MTDto;
import org.fgq.query.annotation.STDto;

import java.lang.annotation.Annotation;
import java.lang.reflect.Field;
import java.lang.reflect.Type;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * 元数据反射。
 * Created by fenggqc on 2016/12/27.
 */
public class DtoMetaReflect {


    private static Map<String, DtoTypeInfo> typecache = Collections.synchronizedMap(new HashMap<String, DtoTypeInfo>());

    public static void Reflect(Type type) {
        if (false == typecache.containsKey(type.getTypeName())) {
            typecache.put(type.getTypeName(), TrimType(type));
        }
    }


    private static DtoTypeInfo TrimType(Type type) {
        DtoTypeInfo result = new DtoTypeInfo();

        Annotation[] annotations = type.getClass().getAnnotations();

        boolean simpletable = IsMultiJoinDto(annotations) == false;

        if (simpletable == false) {
            throw new Error("multi table dto is not support yet!");
        }

        result.setIsSimpleTable(simpletable);

        for (Annotation annotation : annotations) {

        }
        Field[] fields = type.getClass().getFields();
        for (Field field : fields) {
            annotations = field.getAnnotations();
            for (Annotation annotation : annotations) {

            }
        }


        return result;

    }


    /**
     * 是否多表连接Dto。
     *
     * @param annotations
     * @return
     */
    private static Boolean IsMultiJoinDto(Annotation[] annotations) {

        for (Annotation annotation : annotations) {
            if (annotation.getClass().isAnnotationPresent(MTDto.class)) {
                return true;
            }
        }
        return false;
    }


    //region Getter And Setter
    // endregion

}

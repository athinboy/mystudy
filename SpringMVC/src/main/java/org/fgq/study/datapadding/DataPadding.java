package org.fgq.study.datapadding;

import com.alibaba.fastjson.JSON;


import com.alibaba.fastjson.util.JavaBeanInfo;
import org.fgq.study.datapadding.annotation.NeedPad;
import org.fgq.study.datapadding.exception.DataPaddingException;
import org.fgq.study.datapadding.fastjson.SerializeBeanInfo;
import org.fgq.study.datapadding.fastjson.TypeUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.lang.reflect.*;
import java.util.Collection;
import java.util.Iterator;


/**
 * @author fenggqc
 * @create 2018-10-24 13:52
 **/


public class DataPadding {


    static Logger logger = LoggerFactory.getLogger(DataPadding.class);

    //region Getter And Setter
    // endregion

    /**
     * 填充信息。
     *
     * @param collection
     * @throws DataPaddingException
     */
    public static <T> void PadInfo(Class<T> tClass, Collection<T> collection) throws DataPaddingException {


        try {


            if (collection == null || collection.size() == 0) return;

            System.out.println(tClass.toString());

            final Field[] fields = tClass.getDeclaredFields();


            Iterator<T> iterable = collection.iterator();

            T t;
            while (iterable.hasNext()) {
                t = iterable.next();


                NeedPad needPad = null;
                for (Field field : fields) {
                    needPad = field.getAnnotation(NeedPad.class);
                    if (needPad == null) {
                        continue;
                    }

                    Object object = InitBean.getSpringBeanFactory().getBean(needPad.SourceClass());
                    if (object == null) {
                        throw new DataPaddingException(String.format("获取对象%s失败", needPad.getClass().toString()));
                    }
                    Method[] methods = needPad.SourceClass().getMethods();
                    Method method;
                    for (int i = 0; i < methods.length; i++) {
                        method = methods[i];
                        Object[] paras = getMethodPara(t, needPad, method, fields);
                        if (method.getName().equals(needPad.SourceMethod())) {
                            method.invoke(null, new Object[]{});
                        }
                    }

                }
            }

        } catch (Exception ex) {
            if (logger.isErrorEnabled()) {
                logger.error("PadInfo", ex);
            }
            throw new DataPaddingException("", ex);
        }


    }

    /**
     * 获取方法参数。
     *
     * @return
     */
    private static <T> Object[] getMethodPara(T t, NeedPad needPad, Method method, Field[] fields) {
        if (needPad.ParaField() == null || needPad.ParaField().length == 0) {
            return new Object[]{};
        }
        Parameter[] parameters = method.getParameters();
        Parameter parameter;
        for (int i = 0; i < parameters.length; i++) {
            parameter = parameters[i];
        }
        Field field;
        for (int i = 0; i < fields.length; i++) {
            field = fields[i];
            JSON.parseArray("", t.getClass());
        }

        SerializeBeanInfo serializeBeanInfo = TypeUtils.buildBeanInfo(t.getClass(), null);
        JavaBeanInfo javaBeanInfo = JavaBeanInfo.build(t.getClass(), t.getClass());



        return null;

    }


}

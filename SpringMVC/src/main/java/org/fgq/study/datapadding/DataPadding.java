package org.fgq.study.datapadding;

import com.alibaba.fastjson.JSON;


import com.google.common.collect.Ordering;
import org.apache.commons.beanutils.PropertyUtilsBean;
import org.apache.commons.collections.CollectionUtils;
import org.fgq.study.datapadding.annotation.NeedPad;
import org.fgq.study.datapadding.exception.DataPaddingException;
import org.fgq.study.datapadding.wrap.ClassWrap;
import org.fgq.study.datapadding.wrap.FieldWrap;
import org.fgq.study.datapadding.wrap.MethodWrap;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.beans.PropertyDescriptor;
import java.lang.reflect.*;
import java.util.*;


/**
 * @author fenggqc
 * @create 2018-10-24 13:52
 **/


public class DataPadding {


    static Logger logger = LoggerFactory.getLogger(DataPadding.class);


    static PropertyUtilsBean propertyUtilsBean = org.apache.commons.beanutils.BeanUtilsBean.getInstance().getPropertyUtils();


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

            ClassWrap classWrap = ClassWrap.WrapClass(tClass);

            final Field[] fields = tClass.getDeclaredFields();

            Iterator<T> iterable;
            T t;
            Method method;
            NeedPad needPad = null;
            for (FieldWrap fieldWrap : classWrap.getFieldWraps()) {

                needPad = fieldWrap.getNeedPad();
                iterable = collection.iterator();

                while (iterable.hasNext()) {
                    t = iterable.next();
                    method = fieldWrap.getSourceMethod();
                    Object[] paras = getMethodPara(fieldWrap.getSourceMethodWrap(), t);
                    Object readvalue = method.invoke(fieldWrap.getSourceObject(), paras);
                    fieldWrap.getFieldWriteMethod().invoke(t, readvalue);
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
    private static <T> Object[] getMethodPara(MethodWrap methodWrap, T t) throws DataPaddingException {
        if (methodWrap.getParaMethods().length == 0) {
            return new Object[]{};
        }

        Object[] para = new Object[methodWrap.getParaMethods().length];

        try {

            Method method;
            for (int i = 0; i < methodWrap.getParaMethods().length; i++) {
                method = methodWrap.getParaMethods()[i];
                para[i] = method.invoke(t, null);

            }

//        SerializeBeanInfo serializeBeanInfo = TypeUtils.buildBeanInfo(t.getClass(), null);
//        JavaBeanInfo javaBeanInfo = JavaBeanInfo.build(t.getClass(), t.getClass());


        } catch (Exception e) {
            if (logger.isErrorEnabled()) {
                logger.error(e.toString());
            }
            throw new DataPaddingException("出现异常！", e);

        }
        return para;
    }
}

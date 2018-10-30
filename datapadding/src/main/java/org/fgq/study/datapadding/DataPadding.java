package org.fgq.study.datapadding;



import org.apache.commons.beanutils.PropertyUtilsBean;
import org.fgq.study.datapadding.annotation.NeedPad;
import org.fgq.study.datapadding.exception.DataPaddingException;
import org.fgq.study.datapadding.wrap.ClassWrap;
import org.fgq.study.datapadding.wrap.FieldWrap;
import org.fgq.study.datapadding.wrap.MethodWrap;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;


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


            HashMap<Field, HashMap<Integer, HashMap<String, Object>>> cache = new HashMap<>();

            if (collection == null || collection.size() == 0) return;

            ClassWrap classWrap = ClassWrap.WrapClass(tClass);

            //final Field[] fields = tClass.getDeclaredFields();

            Iterator<T> iterable;
            T t;
            Method method;
            NeedPad needPad = null;
            HashMap<Integer, HashMap<String, Object>> fieldValueCacheMapItem = new HashMap<>();
            CacheResult cacheResult;


            for (FieldWrap fieldWrap : classWrap.getFieldWraps()) {

                needPad = fieldWrap.getNeedPad();
                iterable = collection.iterator();

                fieldValueCacheMapItem = new HashMap<>();
                cache.put(fieldWrap.getField(), fieldValueCacheMapItem);

                while (iterable.hasNext()) {
                    t = iterable.next();
                    method = fieldWrap.getSourceMethod();

                    Object[] paras = getMethodPara(fieldWrap.getSourceMethodWrap(), t);


                    Object sourceValue = null;
                    if (needPad.NoCache() == false) {
                        sourceValue = method.invoke(fieldWrap.getSourceObject(), paras);
                    } else {

                        cacheResult = findCache(paras, fieldValueCacheMapItem);
                        if (cacheResult.isHit()) {
                            sourceValue = cacheResult.getValue();
                        } else {
                            sourceValue = method.invoke(fieldWrap.getSourceObject(), paras);
                            saveCache(paras, fieldValueCacheMapItem, sourceValue);
                        }
                    }
                    fieldWrap.getFieldWriteMethod().invoke(t, sourceValue);
                }
            }

        } catch (Exception ex) {
            if (logger.isErrorEnabled()) {
                logger.error("PadInfo", ex);
            }
            throw new DataPaddingException("", ex);
        }


    }


    private static void saveCache(Object[] paras, HashMap<Integer, HashMap<String, Object>> fieldValueCacheMapItem,
                                  Object value) {

        HashMap<String, Object> paraValueCacheMapItem;
        String paraStr;
        Integer paraHashCode;
        paraStr = getParaStr(paras);
        paraHashCode = paraStr.hashCode();
        if (false == fieldValueCacheMapItem.containsKey(paraHashCode)) {
            paraValueCacheMapItem = new HashMap<>();
            fieldValueCacheMapItem.put(paraHashCode, paraValueCacheMapItem);
        }
        paraValueCacheMapItem = fieldValueCacheMapItem.get(paraHashCode);
        paraValueCacheMapItem.put(paraStr, value);

    }


    private static CacheResult findCache(Object[] paras, HashMap<Integer, HashMap<String, Object>> fieldValueCacheMapItem) {

        CacheResult cacheResult = new CacheResult();
        HashMap<String, Object> paraValueCacheMapItem;
        String paraStr;
        Integer paraHashCode;
        paraStr = getParaStr(paras);
        paraHashCode = paraStr.hashCode();
        if (false == fieldValueCacheMapItem.containsKey(paraHashCode)) {
            paraValueCacheMapItem = new HashMap<>();
            fieldValueCacheMapItem.put(paraHashCode, paraValueCacheMapItem);
        }
        paraValueCacheMapItem = fieldValueCacheMapItem.get(paraHashCode);
        if (true == paraValueCacheMapItem.containsKey(paraStr)) {
            cacheResult.setHit(true);
            cacheResult.setValue(paraValueCacheMapItem.get(paraStr));
        } else {
            cacheResult.setHit(false);
        }

        return cacheResult;

    }


    private static class CacheResult {
        private boolean hit;
        private Object value;


        public Object getValue() {
            return value;
        }

        public void setValue(Object value) {
            this.value = value;
        }

        public boolean isHit() {
            return hit;
        }

        public void setHit(boolean hit) {
            this.hit = hit;
        }
    }


    private static String getParaStr(Object[] para) {

        if (para == null || para.length == 0) {
            return "";
        }
        Object p;
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < para.length; i++) {
            p = para[i];
            if (p == null) {
                continue;
            } else {
                stringBuilder.append(p.toString());
            }
        }
        return stringBuilder.toString();
    }


    public static <T> void PadInfo(Class<T> tClass, T t) throws DataPaddingException {

        List<T> tList = new ArrayList<>();
        tList.add(t);
        PadInfo(tClass, tList);

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

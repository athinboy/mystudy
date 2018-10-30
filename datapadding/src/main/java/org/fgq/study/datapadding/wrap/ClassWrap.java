package org.fgq.study.datapadding.wrap;

import com.google.common.collect.Collections2;
import org.apache.commons.beanutils.PropertyUtilsBean;
import org.apache.commons.collections.CollectionUtils;

import org.fgq.study.datapadding.InitBean;
import org.fgq.study.datapadding.annotation.NeedPad;
import org.fgq.study.datapadding.exception.DataPaddingException;
import org.fgq.study.datapadding.exception.WrongAnnotationException;
import org.fgq.study.datapadding.exception.WrongSourceClassException;
import org.fgq.study.datapadding.exception.WrongSourceMethodException;

import java.beans.PropertyDescriptor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.*;

/**
 * @author fenggqc
 * @create 2018-10-29 14:41
 **/


public final class ClassWrap {

    private static HashMap<Class, ClassWrap> classWrapHashMap = new HashMap<>();
    private static PropertyUtilsBean propertyUtilsBean = org.apache.commons.beanutils.BeanUtilsBean.getInstance().getPropertyUtils();


    private Class destClass;
    private FieldWrap[] fieldWraps;


    private ClassWrap() {

    }

    public static ClassWrap WrapClass(Class destClass) throws Exception {

        ClassWrap classWrap = classWrapHashMap.get(destClass);
        if (classWrap != null) {
            return classWrap;
        }

        classWrap = new ClassWrap();
        classWrap.destClass = destClass;
        Object sourceobject;
        final Field[] fields = destClass.getDeclaredFields();
        Field field;
        boolean findsourcemethod = false;

        List<FieldWrap> fieldWraplist = new ArrayList<>();
        FieldWrap fieldWrap;
        NeedPad needPad = null;
        MethodWrap methodWrap;
        PropertyDescriptor[] propertyDescriptors = propertyUtilsBean.getPropertyDescriptors(destClass);
        PropertyDescriptor propertyDescriptor = null;
        for (int i = 0; i < fields.length; i++) {
            field = fields[i];
            needPad = field.getAnnotation(NeedPad.class);
            if (needPad == null) {
                continue;
            }
            propertyDescriptor = null;
            for (int p = 0; p < propertyDescriptors.length; p++) {

                if (propertyDescriptors[p].getName().equals(field.getName())) {
                    propertyDescriptor = propertyDescriptors[p];
                    break;
                }

            }
            if (propertyDescriptor == null) {
                throw new DataPaddingException("运行异常！");
            }


            try {
                sourceobject = InitBean.getSpringBeanFactory().getBean(needPad.SourceClass());
            } catch (Exception ex) {
                throw new WrongSourceClassException("Spring获取对象失败：" + needPad.SourceClass().toString(), ex);
            }

            Method[] methods = needPad.SourceClass().getMethods();
            Method method = null;

            for (int m = 0; m < methods.length; m++) {

                method = methods[m];
                if (method.getName().equals(needPad.SourceMethod())) {

                    findsourcemethod = true;
                    break;
                }


            }
            if (findsourcemethod == false) {
                throw new WrongSourceMethodException(needPad.SourceClass().toString() + needPad.SourceMethod());
            }

            findsourcemethod = true;

            methodWrap = new MethodWrap(method);


            fieldWrap = new FieldWrap(needPad, method);
            fieldWrap.setField(field);
            fieldWrap.setSourceObject(sourceobject);
            fieldWrap.setFieldWriteMethod(propertyDescriptor.getWriteMethod());
            if (needPad.enableParaFieldInfer() && needPad.ParaFieldNames().length == 0 && method.getParameters().length > 0) {
                fieldWrap.inferParaField(fields);
            }

            fieldWrap.setSourceMethodWrap(methodWrap);
            methodWrap.setParaMethods(getParaMethod(fieldWrap, destClass));
            fieldWraplist.add(fieldWrap);
        }

        Collections.sort(fieldWraplist, new Comparator<FieldWrap>() {
            @Override
            public int compare(FieldWrap o1, FieldWrap o2) {
                return o1.getNeedPad().PadSort() > o2.getNeedPad().PadSort() ? -1 : 1;
            }
        });

        classWrap.setFieldWraps(fieldWraplist.toArray(new FieldWrap[fieldWraplist.size()]));
        classWrapHashMap.put(destClass, classWrap);


        return classWrap;

    }

    private static Method[] getParaMethod(FieldWrap fieldWrap, Class destClass) throws Exception {


        NeedPad needPad=fieldWrap.getNeedPad();
        Method sourceMethod=fieldWrap.getSourceMethod();

        if (fieldWrap.getParameterFields().length != sourceMethod.getParameters().length) {
            throw new WrongAnnotationException("方法参数数量不一致！" + sourceMethod.getName());
        }

        if (fieldWrap.getParameterFields() == null ||fieldWrap.getParameterFields().length == 0) {
            return new Method[]{};
        }

        List<Method> paraMethodlist = new ArrayList<>();

        Object[] para = new Object[fieldWrap.getParameterFields().length];


        PropertyDescriptor[] propertyDescriptors = propertyUtilsBean.getPropertyDescriptors(destClass);
        PropertyDescriptor propertyDescriptor;
        Method method;
        boolean finded = false;
        for (int i = 0; i < fieldWrap.getParameterFields().length; i++) {
            finded = false;
            for (int j = 0; j < propertyDescriptors.length; j++) {
                propertyDescriptor = propertyDescriptors[j];
                if (propertyDescriptor.getName().equals(fieldWrap.getParameterFields()[i])) {
                    method = propertyDescriptor.getReadMethod();
                    if (method.getParameters().length > 0) {
                        throw new WrongAnnotationException("错误的取值方法");
                    }

                    paraMethodlist.add(method);


                    finded = true;
                    break;
                }
            }
            if (false == finded) {
                throw new WrongAnnotationException("未找到配置的方法参数字段" +fieldWrap.getParameterFields()[i]);
            }

        }


        return paraMethodlist.toArray(new Method[paraMethodlist.size()]);
    }


    //region Getter And Setter


    public FieldWrap[] getFieldWraps() {
        return fieldWraps;
    }

    public void setFieldWraps(FieldWrap[] fieldWraps) {
        this.fieldWraps = fieldWraps;
    }

    public Class getDestClass() {
        return destClass;
    }

    public void setDestClass(Class destClass) {
        this.destClass = destClass;
    }


    // endregion
}

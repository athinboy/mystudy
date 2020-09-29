package org.fgq.study.datapadding.wrap;

import org.fgq.study.datapadding.InitBean;
import org.fgq.study.datapadding.annotation.NeedPad;
import org.fgq.study.datapadding.exception.WrongAnnotationException;
import org.fgq.study.datapadding.exception.WrongSourceClassException;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Parameter;

/**
 * @author fenggqc
 * @create 2018-10-29 14:42
 **/
public final class FieldWrap {

    private Field field;
    private Method fieldWriteMethod;

    private NeedPad needPad;
    private Method sourceMethod;
    private MethodWrap sourceMethodWrap;
    private Object sourceObject;
    private String[] parameterFields;

    /**
     * @param needPad
     * @param sourceMethod
     */
    protected FieldWrap(NeedPad needPad, Method sourceMethod) {
        this.setNeedPad(needPad);
        this.setSourceMethod(sourceMethod);
        parameterFields = needPad.ParaFieldNames();
    }

    //region Getter And Setter

    public Object getSourceObject() {
        return sourceObject;
    }

    public void setSourceObject(Object sourceObject) {
        this.sourceObject = sourceObject;
    }

    public String[] getParameterFields() {
        return parameterFields;
    }

    public void setParameterFields(String[] parameterFields) {
        this.parameterFields = parameterFields;
    }

    public MethodWrap getSourceMethodWrap() {
        return sourceMethodWrap;
    }

    public void setSourceMethodWrap(MethodWrap sourceMethodWrap) {
        this.sourceMethodWrap = sourceMethodWrap;
    }

    public Method getFieldWriteMethod() {
        return fieldWriteMethod;
    }

    public void setFieldWriteMethod(Method fieldWriteMethod) {
        this.fieldWriteMethod = fieldWriteMethod;
    }

    public Method getSourceMethod() {
        return sourceMethod;
    }

    public void setSourceMethod(Method sourceMethod) {
        this.sourceMethod = sourceMethod;
    }

    public Field getField() {
        return field;
    }

    public void setField(Field field) {
        this.field = field;
    }

    public NeedPad getNeedPad() {
        return needPad;
    }

    public void setNeedPad(NeedPad needPad) {
        this.needPad = needPad;
    }

    /**
     * 参数字段名称推断。
     * 推断规则：
     * 1、不考虑大小写区别。
     * 2、去掉下划线（_）。
     *
     * @param fields
     */
    public void inferParaField(Field[] fields) throws WrongAnnotationException {
        Parameter[] parameters = this.getSourceMethod().getParameters();
        String[] parafields = new String[parameters.length];
        Parameter parameter;
        String fieldname = null;
        String parameterName;
        for (int i = 0; i < parafields.length; i++) {
            parameter = parameters[i];
            for (int j = 0; j < fields.length; j++) {
                fieldname = fields[j].getName().toLowerCase().replaceAll("_", "");
                parameterName = parameter.getName().toLowerCase().replaceAll("_", "");

                if (fieldname.equals(parameterName)) {
                    fieldname = fields[j].getName();
                    break;
                }

                fieldname = null;
            }
            if (fieldname == null) {
                throw new WrongAnnotationException("无法推断方法:" + this.getSourceMethod().getName() + "的参数：" + parameter.getName());
            }
            parafields[i] = fieldname;

        }
        this.parameterFields = parafields;

    }

    public void prepare() throws WrongSourceClassException {
        if (this.sourceObject == null) {
            try {
                this.sourceObject = InitBean.getBean(needPad.SourceClass());

            } catch (Exception ex) {
                throw new WrongSourceClassException("获取对象失败：" + needPad.SourceClass().toString(), ex);
            }
        }
    }

    public void finish() {
        if (this.needPad.SourceNoStatus() == false) {
            this.sourceObject = null;
        }
    }

    // endregion
}

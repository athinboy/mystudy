package org.fgq.study.datapadding.wrap;

import org.fgq.study.datapadding.annotation.NeedPad;

import java.lang.reflect.Field;
import java.lang.reflect.Method;

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


    protected FieldWrap() {

    }


    //region Getter And Setter


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

    public Object getSourceObject() {
        return sourceObject;
    }

    public void setSourceObject(Object sourceObject) {
        this.sourceObject = sourceObject;
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


    // endregion
}

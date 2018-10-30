package org.fgq.study.datapadding.wrap;

import java.lang.reflect.Method;

/**
 * @author fenggqc
 * @create 2018-10-29 16:25
 **/


public class MethodWrap {

    private Method method;
    private Method[] paraMethods;


    protected  MethodWrap(Method method){
        this.method=method;

    }



    //region Getter And Setter

    public Method getMethod() {
        return method;
    }

    public void setMethod(Method method) {
        this.method = method;
    }

    public Method[] getParaMethods() {
        return paraMethods;
    }

    public void setParaMethods(Method[] paraMethods) {
        this.paraMethods = paraMethods;
    }


    // endregion


}

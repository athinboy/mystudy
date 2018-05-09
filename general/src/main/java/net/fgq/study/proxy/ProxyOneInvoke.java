package net.fgq.study.proxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

public class ProxyOneInvoke implements InvocationHandler {

    //region Getter And Setter
    // endregion



    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {

        if (Object.class.equals(method.getDeclaringClass())) {

        }
        System.out.println("Hello World!");

        return null;
    }
}

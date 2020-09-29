package net.fgq.study.proxy;

import java.lang.reflect.Proxy;

public class Proxy_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {


        ProxyInterface_One o = (ProxyInterface_One) Proxy.newProxyInstance(Proxy_One.class.getClassLoader(),
                new Class[]{ProxyInterface_One.class}, new ProxyOneInvoke());

        o.SayHello();
    }


}

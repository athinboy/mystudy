package org.fgq.study.datapadding;

import org.springframework.beans.BeansException;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.beans.factory.BeanFactoryAware;
import org.springframework.beans.factory.BeanFactoryUtils;

/**
 * @author fenggqc
 * @create 2018-10-24 9:18
 **/


public class InitBean  implements BeanFactoryAware {

    //region Getter And Setter
    // endregion

    private static BeanFactory springBeanFactory;

    @Override
    public void setBeanFactory(BeanFactory beanFactory) throws BeansException {

        springBeanFactory = beanFactory;
    }

    public static BeanFactory getSpringBeanFactory() {
        return springBeanFactory;
    }

    public static void setSpringBeanFactory(BeanFactory springBeanFactory) {
         springBeanFactory = springBeanFactory;
    }
}

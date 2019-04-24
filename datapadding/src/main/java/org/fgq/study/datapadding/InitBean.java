package org.fgq.study.datapadding;

import org.fgq.study.datapadding.exception.WrongSourceClassException;
import org.springframework.beans.BeansException;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.beans.factory.BeanFactoryAware;
import org.springframework.beans.factory.BeanFactoryUtils;

/**
 * @author fenggqc
 * @create 2018-10-24 9:18
 **/
public class InitBean implements BeanFactoryAware {

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

    public static <T> T getBean(Class<T> requiredType) throws WrongSourceClassException {
        if (springBeanFactory != null) {
            try {
                return springBeanFactory.getBean(requiredType);
            } catch (Exception ex) {
                throw new WrongSourceClassException("Spring获取对象失败", ex);
            }

        }

        try {
            T t = requiredType.newInstance();
            return t;
        } catch (Exception ex) {
            throw new WrongSourceClassException("构造函数实例化对象失败", ex);
        }

    }

}

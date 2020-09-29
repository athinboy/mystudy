package net.fgq.study.fastjson;

import com.alibaba.fastjson.JSON;
import org.apache.commons.beanutils.PropertyUtils;
import org.apache.commons.beanutils.PropertyUtilsBean;
import org.apache.commons.lang3.builder.CompareToBuilder;
import org.dozer.DozerBeanMapper;
import org.dozer.util.ReflectionUtils;
import sun.java2d.loops.ProcessPath;

import java.beans.PropertyDescriptor;
import java.lang.reflect.InvocationTargetException;

/**
 * @author fenggqc
 * @create 2018-10-26 15:59
 **/


public class One {

    //region Getter And Setter
    // endregion

    public static class A {


        private String name;

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }
    }

    public static void main(String[] args) throws InvocationTargetException, IllegalAccessException {


        A a = new A();
        a.setName("fweeeeeeeeerwe");

//        String s = JSON.toJSONString(a);
//        JSON.parseObject(s, A.class);


        A b = new A();

        DozerBeanMapper dozerBeanMapper = new DozerBeanMapper();

        dozerBeanMapper.map(a, b);


        PropertyUtilsBean propertyUtilsBean = org.apache.commons.beanutils.BeanUtilsBean.getInstance().getPropertyUtils();
        PropertyDescriptor[] propertyDescriptors = propertyUtilsBean.getPropertyDescriptors(A.class);
        PropertyDescriptor propertyDescriptor;
        for (int i = 0; i < propertyDescriptors.length; i++) {
            propertyDescriptor=propertyDescriptors[i];
            System.out.println( propertyDescriptor.getName());
            if(propertyDescriptor.getName().equals("name")){
                propertyDescriptor.getReadMethod().invoke(a,null);
            }
        }

//or
        PropertyDescriptor[] propertyDescriptors2 = ReflectionUtils.getPropertyDescriptors(A.class);

        //ReflectionUtils.invoke(
        try {
            String ss = ReflectionUtils.findPropertyDescriptor(A.class, "name", null).getReadMethod().invoke(a, new Object[]{}).toString();
            System.out.println(ss);
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        }

    }


}

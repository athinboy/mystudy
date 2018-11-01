package org.fgq.study.dubbo.two;

import org.fgq.study.dubbo.service.StudentService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;


/**
 * @author fenggqc
 * @create 2018-11-01 10:40
 **/


public class DubboClient {

    //region Getter And Setter
    // endregion


    static Logger logger = LoggerFactory.getLogger(DubboClient.class);


    public static void main(String[] args) throws Exception {

        try {

            ClassPathXmlApplicationContext context = new ClassPathXmlApplicationContext(new String[]{"applicationContext.xml"});
            context.start();
            // Obtaining a remote service proxy
            StudentService studentService = (StudentService) context.getBean("studentService");
            // Executing remote methods
            Integer count = studentService.getCount();
            // Display the call result
            System.out.println(count);
        } catch (Exception ex) {
            logger.error("", ex);
            throw ex;
        }

    }


}

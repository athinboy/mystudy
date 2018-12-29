package org.fgq.study.springboot;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.env.Environment;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author fenggqc
 * @create 2018-12-27 18:38
 **/

@EnableCaching
@SpringBootApplication
@EnableAutoConfiguration
@RestController
public class Application {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {

        SpringApplication.run(Application.class, args);
    }


    @RequestMapping("/")
    String home() {
        return "Hello World!";
    }
}

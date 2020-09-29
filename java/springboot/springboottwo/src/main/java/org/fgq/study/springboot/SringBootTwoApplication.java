package org.fgq.study.springboot;


import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.retry.annotation.EnableRetry;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author fenggqc
 * @create 2018-12-27 18:38
 **/

@EnableCaching
@SpringBootApplication
@RestController
@EnableRetry
public class SringBootTwoApplication {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {

        SpringApplication.run(SringBootTwoApplication.class, args);
    }


    @RequestMapping("/")
    String home() {
        return "Hello World!";
    }
}

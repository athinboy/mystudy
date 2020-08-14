package org.fgq.study.springboot;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@EnableCaching
@SpringBootApplication
@RestController
public class SprintBootThreeApplication {

    public static void main(String[] args) throws Exception {

        SpringApplication.run(SprintBootThreeApplication.class, args);
    }

    @RequestMapping("/")
    String home() {
        return "Hello World!";
    }
}

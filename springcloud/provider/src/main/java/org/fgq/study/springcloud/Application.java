package org.fgq.study.springcloud;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.cache.annotation.EnableCaching;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

/**
 * @author fenggqc
 * @create 2019-05-22 15:28
 **/
@EnableCaching
@SpringBootApplication
@RestController
@EnableEurekaServer
public class Application extends WebMvcConfigurerAdapter {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) {

        new SpringApplicationBuilder(Application.class).run(args);
    }

}

package org.fgq.study.springcloud;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
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
@EnableAutoConfiguration
@RestController
@EnableEurekaServer
//@EnableDiscoveryClient is no longer required. You can put a DiscoveryClient implementation
// on the classpath to cause the Spring Boot application to register with the service discovery server.
@EnableDiscoveryClient
public class Application extends WebMvcConfigurerAdapter {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
    }

}

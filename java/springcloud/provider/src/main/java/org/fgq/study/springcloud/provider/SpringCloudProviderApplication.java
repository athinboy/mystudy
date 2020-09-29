package org.fgq.study.springcloud.provider;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;

/**
 * @author fenggqc
 * @create 2019-05-22 15:28
 **/

@SpringBootApplication
@EnableEurekaClient
public class SpringCloudProviderApplication {


    public static void main(String[] args) {

        new SpringApplicationBuilder(SpringCloudProviderApplication.class).run(args);
    }

}

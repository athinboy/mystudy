package org.fgq.study.springcloud.consumer;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.netflix.eureka.EnableEurekaClient;
import org.springframework.cloud.openfeign.EnableFeignClients;


/**
 * @author fenggqc
 * @create 2019-05-22 15:28
 **/

@SpringBootApplication
@EnableEurekaClient
@EnableFeignClients
public class SpringCloudConsumerApplication {

    public static void main(String[] args) {

        new SpringApplicationBuilder(SpringCloudConsumerApplication.class).run(args);
    }

}

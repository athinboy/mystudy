package org.fgq.study.springcloud;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

/**
 * @author fenggqc
 * @create 2019-05-22 15:28
 **/
@SpringBootApplication
@EnableEurekaServer
public class SpringCloudServerApplication {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) {

        new SpringApplicationBuilder(SpringCloudServerApplication.class).run(args);
    }

}

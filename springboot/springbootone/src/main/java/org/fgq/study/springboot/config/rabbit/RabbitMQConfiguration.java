package org.fgq.study.springboot.config.rabbit;

import org.springframework.amqp.core.Queue;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.amqp.RabbitProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

/**
 * @author fenggqc
 * @create 2018-12-28 14:33
 **/


@Configuration
public class RabbitMQConfiguration {

    //region Getter And Setter
    // endregion


    @Autowired
    RabbitProperties rabbitProperties;


    @Bean
    public Queue Queue() {
        return new Queue("hello");
    }

}
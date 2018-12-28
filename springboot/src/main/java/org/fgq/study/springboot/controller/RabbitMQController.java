package org.fgq.study.springboot.controller;

import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author fenggqc
 * @create 2018-12-28 15:04
 **/

@RestController()
@RequestMapping("/rabbitmq")
public class RabbitMQController {


    @Autowired
    RabbitTemplate rabbitTemplate;


    //region Getter And Setter
    // endregion

    @RequestMapping("/index")
    public String index() {




        return "hello rabbitmq!";
    }






}

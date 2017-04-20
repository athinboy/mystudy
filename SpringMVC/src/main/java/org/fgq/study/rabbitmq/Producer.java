package org.fgq.study.rabbitmq;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.amqp.support.converter.JsonMessageConverter;
import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.messaging.converter.StringMessageConverter;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.Date;
import java.util.Queue;

/**
 * Created by fenggqc on 2017/4/12.
 */
@Service
public class Producer implements IProduct {

    private Logger logger = LoggerFactory.getLogger(Producer.class);


    private RabbitTemplate amqpTemplate;


    public Producer(RabbitTemplate amqpTemplate) {
        this.amqpTemplate = amqpTemplate;
    }

    private static JsonMessageConverter jsonMessageConverter = new JsonMessageConverter();

    public void sendMessage(String message) {
        logger.error("to send message:{}", message);

        // amqpTemplate.convertAndSend("myexchange","key123",converter.toMessage(message,null));
        amqpTemplate.convertAndSend("myexchange", "key123", jsonMessageConverter.toMessage(message, null));
//        amqpTemplate.convertAndSend("myexchange", "key123", jsonMessageConverter.toMessage(new Date(), null));
//
//
//        ArrayList<String> ar=new ArrayList<String>();
//        ar.add("234324");
//        ar.add("fwer");
//
//        amqpTemplate.convertAndSend("myexchange", "key123", jsonMessageConverter.toMessage(ar, null));


    }


    //region Getter And Setter
    // endregion

}

package org.fgq.study.rabbitmq;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.amqp.core.Message;
import org.springframework.amqp.core.MessageListener;
import org.springframework.amqp.rabbit.annotation.Exchange;
import org.springframework.amqp.rabbit.annotation.Queue;
import org.springframework.amqp.rabbit.annotation.QueueBinding;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.amqp.support.converter.JsonMessageConverter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.messaging.converter.StringMessageConverter;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;

/**
 * Created by fenggqc on 2017/4/13.
 */
@Service
public class Consumer implements IConsume, MessageListener {


    private Logger logger = LoggerFactory.getLogger(Consumer.class);


    private AmqpTemplate amqpTemplate;

    private  static JsonMessageConverter jsonMessageConverter=new JsonMessageConverter();


    public Consumer(AmqpTemplate amqpTemplate) {
        //logger.error("Consumer create");
        this.amqpTemplate = amqpTemplate;
    }


    @Override
    public void onMessage(Message message) {
        logger.error("receive:"+  jsonMessageConverter.fromMessage(message).toString());


    }


    //region Getter And Setter
    // endregion

}

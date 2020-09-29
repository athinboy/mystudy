package org.fgq.study.serviceimpl;

import org.fgq.study.rabbitmq.IProduct;
import org.fgq.study.service.RabbitMQService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;

/**
 * Created by fenggqc on 2017/4/19.
 */
@Service
@Transactional(rollbackFor =  Exception.class)
public class RabbitMQServiceImpl implements RabbitMQService {

    //region Getter And Setter
    // endregion


    Logger logger= LoggerFactory.getLogger(RabbitMQServiceImpl.class);

    @Autowired
    IProduct product;

    @Override
    @Transactional(rollbackFor =  Exception.class)
    public void SendMessage() {
        logger.warn("rabbit send hello world!");
        this.product.sendMessage(String.valueOf( new Date().getTime()));


    }
}

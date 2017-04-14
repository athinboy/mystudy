package org.fgq.study.controller;

import org.fgq.study.rabbitmq.IProduct;
import org.fgq.study.rabbitmq.Producer;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.MDC;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by fenggqc on 2017/4/13.
 */
@Controller()
@RequestMapping("/mvc/rabbitmq")
public class RabbitController {

    private Logger logger = LoggerFactory.getLogger(RabbitController.class);

    @Autowired
    IProduct product;


    @RequestMapping("/send")
    @ResponseBody
    public String send(HttpServletRequest request, Model model) {


        logger.warn("rabbit send");
        this.product.sendMessage("hello world!");

        return "rabbit";

    }

}

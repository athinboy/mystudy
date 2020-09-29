package org.fgq.study.controller;

import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.MDC;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;


/**
 * Created by fenggqc on 2016/3/21.
 */
@Controller()
@RequestMapping("/mvc")
//http://localhost:8084/spmvc/mv/mvc/time
public class TimeController {


    private Logger logger = LoggerFactory.getLogger(TimeController.class);

    @RequestMapping("/time")
    @ResponseBody
    public ModelAndView ShowTime(HttpServletRequest request, Model model) {


        String eventId = MDC.get("eventid");


        logger.warn("get eventid:" + eventId + ", send request to other sub system ,and with the eventid!");

        ModelAndView modelAndView = new ModelAndView("time");
        modelAndView.addObject("eventsign", eventId);
        return modelAndView;

    }

}

package org.fgq.study.springcloud.consumer.controller;

import org.fgq.study.springcloud.consumer.remoteservice.HelloRemote;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by fengguoqiang 2020/4/29
 */
@RestController()
@RequestMapping("/test")
public class TestController {

    @Autowired
    private HelloRemote helloRemote;

    @ResponseBody
    @GetMapping("/hello")
    public String hello() {
        return helloRemote.justhello();
    }
}

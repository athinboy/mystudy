package org.fgq.study.springcloud.provider.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by fengguoqiang 2020/4/29
 */
@RestController
public class TestController {
    //restful api方式
    @GetMapping("/hello/{name}")
    public String index(@PathVariable String name) {
        return "hello!" + name;
    }

    @GetMapping("/justhello")
    public String justhello() {
        return "fwewr";
    }

}

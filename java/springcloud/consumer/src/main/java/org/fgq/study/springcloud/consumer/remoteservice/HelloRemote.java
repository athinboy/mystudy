package org.fgq.study.springcloud.consumer.remoteservice;

import org.springframework.cloud.openfeign.FeignClient;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

@FeignClient(name = "eurekaprovider")
public interface HelloRemote {

    @GetMapping("/hello/{name}")
    String hello(@PathVariable("name") String name);

    @GetMapping("/justhello")
    String justhello();

}
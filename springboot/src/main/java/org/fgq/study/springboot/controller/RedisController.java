package org.fgq.study.springboot.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.connection.RedisConnection;
import org.springframework.data.redis.connection.jedis.JedisConnectionFactory;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.data.redis.core.StringRedisTemplate;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import redis.clients.jedis.JedisPool;

/**
 * @author fenggqc
 * @create 2018-12-28 11:12
 **/


@RestController()
@RequestMapping("/redis")
public class RedisController {

    //region Getter And Setter
    // endregion

    @Autowired
    private StringRedisTemplate template;

    @Autowired
    JedisPool jedisPool;





    @RequestMapping("/index")
    public String index() {
        return "hello redis!";
    }

    @RequestMapping("/doone")
    public String doOne() {


        jedisPool.getResource().set("A","A");

        return "hello redis!";
    }


}

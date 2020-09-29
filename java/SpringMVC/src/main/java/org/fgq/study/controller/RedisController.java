package org.fgq.study.controller;

import org.apache.commons.lang3.time.StopWatch;
import org.redisson.Redisson;
import org.redisson.RedissonRedLock;
import org.redisson.api.RKeys;
import org.redisson.api.RLock;
import org.redisson.api.RMap;
import org.redisson.api.RedissonClient;
import org.redisson.client.codec.ByteArrayCodec;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.context.annotation.Lazy;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPoolConfig;
import redis.clients.util.JedisByteHashMap;


import javax.servlet.http.HttpServletRequest;
import java.util.HashMap;
import java.util.Map;
import java.util.Timer;

/**
 * Created by fenggqc on 2017/4/19.
 */
@Controller()
@RequestMapping("/mvc/redis")
public class RedisController {

    private Logger logger = LoggerFactory.getLogger(RedisController.class);

    @Autowired
    @Qualifier("redissonClient")
    RedissonClient redisson;

    //region Getter And Setter
    // endregion

    @RequestMapping("/lock")
    @ResponseBody
    public String send(HttpServletRequest request, Model model) {


        RLock lock1 = redisson.getLock("lock1");
        RLock lock2 = redisson.getLock("lock2");
        RLock lock3 = redisson.getLock("lock3");

        RedissonRedLock lock = new RedissonRedLock(lock1, lock2, lock3);

        lock.lock();

        System.out.println(lock1.getHoldCount());
        System.out.println(lock2.getHoldCount());
        System.out.println(lock3.getHoldCount());

        lock.lock();
        lock.lock();
        lock.lock();

        System.out.println(lock1.getHoldCount());
        System.out.println(lock2.getHoldCount());
        System.out.println(lock3.getHoldCount());

        lock.unlock();


        System.out.println(lock1.getHoldCount());
        System.out.println(lock2.getHoldCount());
        System.out.println(lock3.getHoldCount());

        return "rabbit";

    }

    @RequestMapping("/map")
    @ResponseBody
    public String map(HttpServletRequest request, Model model) {


        StopWatch stopWatch = new StopWatch();
        stopWatch.reset();
        stopWatch.start();


        RMap<String, String> map = redisson.getMap("anyMap");

//        for (int i = 0; i < 1000; i++) {
//            map.put(String.valueOf(i), String.valueOf(i));
//        }
        Map<String, String> mapstr = new HashMap<String, String>();

        for (int i = 0; i < 1000; i++) {
            mapstr.put(String.valueOf(i), String.valueOf(i));
        }
        map.putAll(mapstr);

        System.out.println(map.get(String.valueOf(2)));

        stopWatch.reset();
        stopWatch.start();

        JedisPool pool = new JedisPool(new JedisPoolConfig(), "127.0.0.1");
        Jedis jedis = pool.getResource();
        jedis.select(3);
        Map<byte[], byte[]> map2 = new JedisByteHashMap();
        for (int i = 0; i < 1000; i++) {
            map2.put(String.valueOf(i).getBytes(), String.valueOf(i).getBytes());
        }
        jedis.hmset("23".getBytes(), map2);
        jedis.close();
        pool.destroy();

        System.out.println(stopWatch.getTime());

        return "";
    }

}

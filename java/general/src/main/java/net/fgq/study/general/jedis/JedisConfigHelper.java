package net.fgq.study.general.jedis;

import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPoolConfig;

public class JedisConfigHelper {

    //region Getter And Setter
    // endregion


    public static JedisPool GetPool() {

        JedisPoolConfig jedisPoolConfig = new JedisPoolConfig();

        JedisPool jedisPool = new JedisPool(jedisPoolConfig, "127.0.0.1", 6379);
        return  jedisPool;
    }


}

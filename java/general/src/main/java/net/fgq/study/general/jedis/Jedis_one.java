package net.fgq.study.general.jedis;

import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPoolConfig;

public class Jedis_one {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {


        Jedis jedis = JedisConfigHelper.GetPool().getResource();


        jedis.select(3);
        jedis.set("1", "1value");
        System.out.println(jedis.exists("1"));
        System.out.println(jedis.get("1"));


    }

}

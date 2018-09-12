package net.fgq.study.general.jedis.usage;

import com.alibaba.fastjson.JSON;
import net.fgq.study.general.jedis.JedisConfigHelper;
import redis.clients.jedis.Jedis;

import javax.sound.midi.Soundbank;
import java.util.List;
import java.util.Set;

/**
 * @author fenggqc
 * @create 2018-09-12 15:57
 **/


public class One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {
//        LastItem();
        VoteRank();

    }

    /**
     * 显示最新的项目列表
     */
    private static void LastItem() {

        String key = "lastitem";

        Jedis jedis = JedisConfigHelper.GetPool().getResource();

        for (int i = 0; i < 10; i++) {
            jedis.lpush(key, String.valueOf(i));

        }
        List<String> li = jedis.lrange(key, 0, 99);
        System.out.println(JSON.toJSONString(li));

        System.out.println(jedis.ttl(key));
        jedis.expire(key, 1);


    }

    /**
     * 投票，排行榜
     */
    private static void VoteRank() {

        String key = "VoteRank";
        Jedis jedis = JedisConfigHelper.GetPool().getResource();
        for (int i = 0; i < 100; i++) {
            jedis.zadd(key, 1000 - i, String.valueOf(i));
        }
        System.out.println(jedis.zcard(key));
        System.out.println(jedis.zscore(key, "93"));

        Set<String> vr = jedis.zrange(key, 0, 10);//分值从小到大排序返回
        System.out.println(JSON.toJSONString(vr));
        vr=jedis.zrevrange(key,0,10);//分值从大到小排序返回
        System.out.println(JSON.toJSONString(vr));
        System.out.println(vr.toArray()[0].toString());
        System.out.println(jedis.zscore(key, vr.toArray()[0].toString()));
        jedis.expire(key, 1);


    }


}

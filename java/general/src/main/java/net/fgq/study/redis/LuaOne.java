package net.fgq.study.redis;

import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.BitSet;
import java.util.List;

/**
 * Created by fengguoqiang 2020/9/27
 */
public class LuaOne {

    public static void main(String[] args) throws Exception {
        JedisPool jedisPool = new JedisPool("192.168.253.131", 6379);
        Jedis jedis = jedisPool.getResource();
        String luaStr = "return 10";
        String scriptSha = jedis.scriptLoad(luaStr);
        List<String> keys = new ArrayList<>(Arrays.asList("name", "age"));
        List<String> paras = new ArrayList<>(Arrays.asList("fgq", "21"));
        System.out.println(scriptSha);//output:10
        Object result = jedis.evalsha(scriptSha, keys, paras);
        System.out.println(result.toString());//output:10

        System.out.println("1-------------------------------------");
        luaStr = "return {KEYS[1],KEYS[2],ARGV[1],ARGV[2]}";
        scriptSha = jedis.scriptLoad(luaStr);
        keys = new ArrayList<>(Arrays.asList("name", "age"));
        paras = new ArrayList<>(Arrays.asList("fgq", "21"));
        System.out.println(scriptSha);//output:10
        result = jedis.evalsha(scriptSha, keys, paras);
        System.out.println(result.toString());//output:[name, age, fgq, 21]

        //2和3的做法在单实例redis下是不对的。因为redis需要在执行之前分析此脚本执行涉及到的
        //key，所以要求key必须是明确传递到执行语句中。
        System.out.println("2-------------------------------------");
        luaStr = "return redis.call('set','foo','bar')";
        scriptSha = jedis.scriptLoad(luaStr);
        keys = new ArrayList<>(Arrays.asList("name", "age"));
        paras = new ArrayList<>(Arrays.asList("fgq", "21"));
        System.out.println(scriptSha);//output:10
        result = jedis.evalsha(scriptSha, keys, paras);
        System.out.println(result.toString());//output:OK

        System.out.println("3-------------------------------------");
        luaStr = "return redis.call('set',ARGV[1],KEYS[1])";
        scriptSha = jedis.scriptLoad(luaStr);
        keys = new ArrayList<>(Arrays.asList("name", "age"));
        paras = new ArrayList<>(Arrays.asList("fgq", "21"));
        System.out.println(scriptSha);//output:10
        result = jedis.evalsha(scriptSha, keys, paras);
        System.out.println(result.toString());//output:OK

        System.out.println("4-------------------------------------");
        luaStr = "return redis.call('get',KEYS[1])";
        scriptSha = jedis.scriptLoad(luaStr);
        keys = new ArrayList<>(Arrays.asList("name", "age"));
        paras = new ArrayList<>(Arrays.asList("fgq", "21"));
        System.out.println(scriptSha);//output:10
        result = jedis.evalsha(scriptSha, keys, paras);
        System.out.println(result.toString());//output:OK





        jedis.close();

    }

}

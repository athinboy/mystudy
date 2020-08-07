package net.fgq.study.redission;

import net.fgq.study.redis.BinaryObject;
import org.redisson.*;
import org.redisson.api.RLock;
import org.redisson.api.RedissonClient;
import org.redisson.config.Config;

/**
 * Created by fengguoqiang 2020/7/23
 */
public class RedissonOne {

    public static void main(String[] args) throws Exception {

        Config config = new Config();
        config.useClusterServers()
                // use "rediss://" for SSL connection
                .addNodeAddress("redis://127.0.0.1:7181");
        RedissonClient redisson = Redisson.create(config);

        RLock rLock;


    }

}

package net.fgq.study.general.redisson;

import net.fgq.study.general.multithread.A;
import org.redisson.Redisson;
import org.redisson.api.RLock;
import org.redisson.api.RReadWriteLock;
import org.redisson.api.RedissonClient;
import org.redisson.config.Config;
import redis.clients.jedis.Client;

import java.io.File;
import java.io.InputStream;
import java.util.concurrent.TimeUnit;

/**
 * Created by fenggqc on 2018/4/16.
 */
public class Redisson_ReadWriteLock {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {


        InputStream inputStream = Redisson_ReadWriteLock.class.getClassLoader()
                .getResourceAsStream("redisson\\redissonconfig.json");

        Config redissonConfig = Config.fromJSON(inputStream);
        RedissonClient redissonClient = Redisson.create(redissonConfig);

        RReadWriteLock rReadWriteLock = redissonClient.getReadWriteLock("1");
        RLock rLock = rReadWriteLock.readLock();
        rLock.tryLock(10L, 2L, TimeUnit.SECONDS);
        System.out.printf("%s", rLock.isHeldByCurrentThread()).println();

        Thread.sleep(3000);
        System.out.printf("after sleep 3 seconds %s", rLock.isHeldByCurrentThread()).println();;

///
        System.out.println("another lock:");

        rLock = rReadWriteLock.readLock();
        rLock.tryLock(1L, 5L, TimeUnit.SECONDS);
        System.out.printf("try lock: %s", rLock.isHeldByCurrentThread()).println();;
        Thread.sleep(3000);

        System.out.printf("ater sleep 3seconds: %s", rLock.isHeldByCurrentThread()).println();;
        rLock.unlock();
        System.out.printf("ater unlock: %s", rLock.isHeldByCurrentThread()).println();

        ///


        redissonClient.shutdown();


    }

}

package net.fgq.study.general.jedis;

import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPubSub;

public class Jedis_Message {

    //region Getter And Setter
    // endregion


    private static void SenderProcess() {

        JedisPool jedisPool = JedisConfigHelper.GetPool();
        Jedis jedisSender = jedisPool.getResource();

        for (int i = 0; i < 100; i++) {
            jedisSender.publish("23", "f2w3tf23ijgi" + String.valueOf(i));
        }

        jedisPool.destroy();

    }


    private static void ReceiverProcess() {

        JedisPool jedisPool = JedisConfigHelper.GetPool();
        Jedis jedisSender = jedisPool.getResource();
        final JedisPubSub jedisPubSub = new JedisPubSub() {

            private int i = 0;

            @Override
            public void onMessage(String channel, String message) {
                i += 1;

                System.out.println(message + String.valueOf(i));
                if (i == 90) {
                    this.unsubscribe();
                }
            }
        };
        jedisSender.subscribe(jedisPubSub, "23");

        jedisPool.destroy();
    }


    public static void main(String[] args) throws Exception {


        Thread sendthread = new Thread(new Runnable() {
            @Override
            public void run() {
                SenderProcess();
            }
        });
        Thread receivethread = new Thread(new Runnable() {
            @Override
            public void run() {
                ReceiverProcess();
            }
        });


        sendthread.start();
        receivethread.start();


        Thread.sleep(2000);


    }

}

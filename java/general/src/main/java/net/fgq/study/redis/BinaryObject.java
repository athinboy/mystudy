package net.fgq.study.redis;

import com.alibaba.fastjson.JSON;
import org.apache.commons.lang3.time.StopWatch;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;

import java.io.*;

/**
 * @author fenggqc
 * @create 2018-12-26 16:47
 **/


public class BinaryObject extends Thread {

    //region Getter And Setter
    // endregion

    public static class A implements Serializable {
        private Integer age;
        private String name;
        private String fullName;

        public Integer getAge() {
            return age;
        }

        public void setAge(Integer age) {
            this.age = age;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getFullName() {
            return fullName;
        }

        public void setFullName(String fullName) {
            this.fullName = fullName;
        }
    }


    public static void main(String[] args) throws Exception {
        BinaryObject binaryObject = new BinaryObject();
        binaryObject.start();

    }


    @Override
    public void run() {
        Binary();

        //JSON();
    }

    private void JSON() {


        A a = new A();
        a.setAge(11);
        a.setName("A");
        a.setFullName("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

        byte[] bytes = null;
        Jedis jedis = null;
        try {

            JedisPool jedisPool = new JedisPool("192.168.169.107", 6379);
            jedis = jedisPool.getResource();

            StopWatch stopWatch = new StopWatch();
            stopWatch.start();
            for (int i = 0; i < 10000; i++) {


                jedis.set(String.valueOf(i), JSON.toJSONString(a));

            }

            for (int i = 0; i < 10000; i++) {
                a = JSON.parseObject(jedis.get(String.valueOf(i)), A.class);
            }


            stopWatch.stop();
            System.out.println(stopWatch.getTime()); //7706

        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            jedis.close();


        }
    }


    private void Binary() {


        A a = new A();
        a.setAge(11);
        a.setName("A");
        a.setFullName("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        ObjectOutputStream objectOutputStream = null;
        byte[] bytes = null;
        Jedis jedis = null;
        try {

            JedisPool jedisPool = new JedisPool("192.168.169.107", 6379);
            jedis = jedisPool.getResource();

            StopWatch stopWatch = new StopWatch();
            stopWatch.start();
            for (int i = 0; i < 10000; i++) {
                byteArrayOutputStream = new ByteArrayOutputStream();
                objectOutputStream = new ObjectOutputStream(byteArrayOutputStream);

                objectOutputStream.writeObject(a);
                bytes = byteArrayOutputStream.toByteArray();


                if (null == bytes) {
                    return;
                }


                jedis.set(String.valueOf(i).getBytes(), bytes);

            }


            ObjectInputStream objectInputStream;
            ByteArrayInputStream byteArrayInputStream;
            for (int i = 0; i < 10000; i++) {


                bytes = jedis.get(String.valueOf(i).getBytes());
                byteArrayInputStream = new ByteArrayInputStream(bytes);
                objectInputStream = new ObjectInputStream(byteArrayInputStream);
                try {
                    a = (A) objectInputStream.readObject();
                } catch (ClassNotFoundException e) {
                    e.printStackTrace();
                }

            }


            stopWatch.stop();
            System.out.println(stopWatch.getTime());

        } catch (IOException e) {
            System.out.println(e.toString());
        } finally {
            jedis.close();

            if (null != objectOutputStream) {
                try {
                    objectOutputStream.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

    }


}

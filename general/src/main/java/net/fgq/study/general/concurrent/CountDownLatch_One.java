package net.fgq.study.general.concurrent;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CountDownLatch;

/**
 * @author fenggqc
 * @create 2018-12-25 15:51
 **/


public class CountDownLatch_One extends Thread {


    @Override
    public void run() {


        try {
            System.out.println(String.format("      %s等待开始", String.valueOf(this.index)));
            batchstart_CountDownLatch.await();
            Thread.sleep(300);
        } catch (Exception e) {
            e.printStackTrace();
        }
        System.out.println(String.format("      %s完成计算", String.valueOf(this.index)));
        batchend_CountDownLatch.countDown();


    }


    private Integer index;
    private static CountDownLatch batchend_CountDownLatch;

    private static CountDownLatch batchstart_CountDownLatch;




    public CountDownLatch_One(Integer i) {
        this.index = i;
    }


    //等待多个任务完成


    public static void main(String[] args) {
        CountDownLatch_One main = new CountDownLatch_One(0);


        int batchsize = 10;

        batchend_CountDownLatch = new CountDownLatch(batchsize);
        batchstart_CountDownLatch = new CountDownLatch(1);

        List<CountDownLatch_One> countDownLatchOneList = new ArrayList<>();
        for (int i = 0; i < batchsize; i++) {
            countDownLatchOneList.add(new CountDownLatch_One(i));
        }
        for (int i = 0; i < batchsize; i++) {
            countDownLatchOneList.get(i).start();
        }
        try {

            Thread.sleep(2000);

            System.out.println("开始");
            batchstart_CountDownLatch.countDown();
            batchend_CountDownLatch.await();
            System.out.println("完成");

            batchstart_CountDownLatch.countDown();


        } catch (Exception e) {
            e.printStackTrace();
        }


    }

}

package net.fgq.study.general.concurrent;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.CyclicBarrier;

/**
 * @author fenggqc
 * @create 2018-12-25 16:13
 **/


public class CyclicBarrier_One extends Thread {

    //region Getter And Setter
    // endregion


    @Override
    public void run() {
        try {
            System.out.println(String.format("   %s 等待开始", index.toString()));
            startCountDownLatch.await();

            while (needrun) {


                Thread.sleep(10);
                System.out.println(String.format("   %s 完成", index.toString()));

                mainCyclicBarrier.await();
                System.out.println(String.format("   %s wait barrier", index.toString()));
                batchEndCountDownLatch.countDown();
                startCountDownLatch.await();
                if(false==needrun){
                    return;
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private Integer index = 0;

    private static CyclicBarrier mainCyclicBarrier;

    private static volatile boolean needrun = true;

    private static CountDownLatch startCountDownLatch = new CountDownLatch(1);
    private static CountDownLatch batchEndCountDownLatch = new CountDownLatch(1);


    public CyclicBarrier_One(Integer i) {
        this.index = i;

    }


    //多个任务，分批次同步逐个批次执行
    public static void main(String[] args) {


        int batchsize = 5;
        mainCyclicBarrier = new CyclicBarrier(batchsize);

        startCountDownLatch = new CountDownLatch(1);

        List<CyclicBarrier_One> cyclicBarrierOneList = new ArrayList<>();
        for (int i = 0; i < batchsize; i++) {
            CyclicBarrier_One t = new CyclicBarrier_One(i);
            t.start();
            cyclicBarrierOneList.add(t);
        }


        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        for (int i = 0; i < 20; i++) {

            batchEndCountDownLatch = new CountDownLatch(batchsize);
            System.out.println(String.format("%s开始", String.valueOf(i)));
            startCountDownLatch.countDown();
            startCountDownLatch = new CountDownLatch(1);


            try {
                System.out.println(String.format("await endcountdown", String.valueOf(i)));
                batchEndCountDownLatch.await();
                System.out.println(String.format("barrier reset", String.valueOf(i)));
                mainCyclicBarrier.reset();
                System.out.println(String.format("%s完成", String.valueOf(i)));

            } catch (InterruptedException e) {
                e.printStackTrace();
            }


        }


        needrun = false;
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        startCountDownLatch.countDown();


    }


}

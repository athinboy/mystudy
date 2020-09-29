package net.fgq.study.general.concurrent;

import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingDeque;
import java.util.concurrent.TimeUnit;

public class BlockingQueue_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {
        BlockingQueue blockingQueue = new LinkedBlockingDeque<Integer>(500);


        Runnable p = () -> {

            for (int i = 0; i < 200; i++) {
                System.out.println("发送：" + String.valueOf(i));
                blockingQueue.add(String.valueOf(i));
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }


        };
        Runnable c = () -> {
            try {
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            while (1 == 1) {
                try {
                    try {
                        Thread.sleep(250);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                    Object o = blockingQueue.poll(100, TimeUnit.MILLISECONDS);

                    if (o != null) {
                        System.out.println("接到:" + o.toString());
                        if (o.toString().equals("100")) {
                            return;
                        }
                    } else {

                    }


                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        };


        Thread pt = new Thread(p);
        Thread ct = new Thread(c);
        ct.start();
        pt.start();


    }


}

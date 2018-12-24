package net.fgq.study.general.multithread.wait;

import java.util.ArrayList;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-12-21 14:47
 **/


public class ProduceConsumer1 {

    //region Getter And Setter
    // endregion


    private static Object producerlockhelper = new Object();

    private static Object consumerlockhelper = new Object();

    private static Integer produceLimit = 10;
    private static Integer consumerLimit = 20;
    private static Integer maxStorage = 50;

    private static List<Integer> storages = new ArrayList<>();


    private static boolean needrun = true;


    private static class Producer extends Thread {


        private Integer capacity;

        public Producer(Integer c) {
            this.capacity = c;
        }


        @Override
        public void run() {


            while (needrun) {
                try {
                    Thread.sleep(10);

                    synchronized (producerlockhelper) {

                        while (storages.size() + this.capacity > maxStorage) {
                            consumerlockhelper.notifyAll();
                        }


                        for (int i = 0; i < this.capacity - 1; i++) {
                            storages.add(i);
                        }


                        if (storages.size() >= consumerLimit) {
                            consumerlockhelper.notifyAll();
                        }


                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }


        }
    }

    private static class Consumer extends Thread {

        private Integer capacity;

        public Consumer(Integer c) {
            this.capacity = c;
        }

        @Override
        public void run() {

        }


    }


}

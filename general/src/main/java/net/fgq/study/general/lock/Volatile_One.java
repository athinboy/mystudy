package net.fgq.study.general.lock;

import org.omg.CORBA.IRObject;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Volatile_One {

    //region Getter And Setter
    // endregion


    private static volatile int i = 0;
    private static int j = 0;


    private static Runnable initrunnable = new Runnable() {
        @Override
        public void run() {

        }
    };



    private static Runnable irunnable = new Runnable() {
        @Override
        public void run() {
            i+=1;
        }
    };


    private static Runnable jrunnable = new Runnable() {
        @Override
        public void run() {
            j+=1;
        }
    };


    public static void main(String[] args) throws InterruptedException {


        ExecutorService executorService = Executors.newFixedThreadPool(10000);

        for (int k = 0; k < 10000; k++) {
            executorService.execute(initrunnable);
        }
        Thread.sleep(10 * 1000);

        for (int k = 0; k < 10000; k++) {
            executorService.execute(jrunnable);
        }
        Thread.sleep(10 * 1000);
        System.out.println(j); //10000

        for (int k = 0; k < 10000; k++) {
            executorService.execute(irunnable);
        }
        Thread.sleep(10 * 1000);
        System.out.println(i); //10000

        executorService.shutdown();


    }

}

package net.fgq.study.general.multithread;

import sun.misc.Unsafe;

import javax.sound.midi.Soundbank;
import java.util.List;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicInteger;


/**
 * Created by fenggqc on 2018/4/13.
 */
public class MultiThread_A {

    //region Getter And Setter
    // endregion


    private static AtomicInteger atomicInteger = new AtomicInteger(0);

    private static Runnable a = new Runnable() {

        @Override
        public void run() {
            atomicInteger.addAndGet(1);
        }

    };


    public static void main(String[] args) throws Exception {

        ExecutorService FixedExecutor = Executors.newFixedThreadPool(2);
        List<Future<Long>> results = FixedExecutor.invokeAll(java.util.Arrays.asList(
                new Sum(0, 10), new Sum(100, 1_000), new Sum(10_000, 1_000_000)
        ));
        FixedExecutor.shutdown();

        for (Future<Long> result : results) {
            System.out.println(result.get());
        }
//        Thread.currentThread().join();

        FixedExecutor.awaitTermination(3, TimeUnit.SECONDS);


        ExecutorService singleExecutor = Executors.newSingleThreadExecutor();
        results = singleExecutor.invokeAll(java.util.Arrays.asList(
                new Sum(0, 10), new Sum(100, 1_000), new Sum(10_000, 1_000_000)
        ));
        singleExecutor.shutdown();
        for (Future<Long> result : results) {
            System.out.println(result.get());
        }

        ScheduledExecutorService scheduledExecutorService = Executors.newScheduledThreadPool(2);
        scheduledExecutorService.scheduleWithFixedDelay(new Runnable() {
            @Override
            public void run() {
                System.out.println("what is the funk!");
            }
        }, 1000L, 1000L, TimeUnit.MILLISECONDS);

        Thread.sleep(10*1000L);
        scheduledExecutorService.shutdown();


    }


    static class Sum implements Callable<Long> {
        private final long from;
        private final long to;

        Sum(long from, long to) {
            this.from = from;
            this.to = to;
        }

        @Override
        public Long call() throws InterruptedException {

            Thread.sleep(1000L);
            long acc = 0;
            for (long i = from; i <= to; i++) {
                acc = acc + i;
            }
            return acc;
        }
    }

}

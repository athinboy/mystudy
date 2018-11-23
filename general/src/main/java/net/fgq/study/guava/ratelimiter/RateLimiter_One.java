package net.fgq.study.guava.ratelimiter;

import com.google.common.util.concurrent.RateLimiter;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

/**
 * @author fenggqc
 * @create 2018-11-21 17:55
 **/


public class RateLimiter_One {


    static RateLimiter rateLimiter;

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {


        rateLimiter = RateLimiter.create(2D, 1000L, TimeUnit.MILLISECONDS);


        List<Runnable> runnableList = new ArrayList<>();

        for (int i = 0; i < 1000; i++) {
            int finalI = i;
            runnableList.add(new Runnable() {
                @Override
                public void run() {
                    System.out.println(finalI);
                }
            });
        }


        ExecutorService executorService = Executors.newCachedThreadPool();

        for (Runnable task : runnableList) {
            rateLimiter.acquire(); // may wait
            executorService.submit(task);

        }

    }
}

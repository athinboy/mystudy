package net.fgq.study.general.concurrent;

import sun.misc.Unsafe;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.locks.AbstractQueuedSynchronizer;

/**
 * Created by fengguoqiang 2020/7/28
 */
public class CountDownLatch_Two {

    private static Unsafe unsafe = null;
    private static final long stateOffset;
    private volatile int state = 10000;

    static {
        try {
            Field f = Unsafe.class.getDeclaredField("theUnsafe");
            f.setAccessible(true);
            unsafe = (Unsafe) f.get(null);

            stateOffset = unsafe.objectFieldOffset
                    (AbstractQueuedSynchronizer.class.getDeclaredField("state"));

        } catch (Exception ex) {
            throw new Error(ex);
        }
    }

    private int getState() {
        return state;
    }

    protected boolean compareAndSetState(int expect, int update) {
        // See below for intrinsics setup to support this
        return unsafe.compareAndSwapInt(this, stateOffset, expect, update);
    }

    public static void main(String[] args) throws InterruptedException {

        CountDownLatch_Two t = new CountDownLatch_Two();

        List<Thread> threads = new ArrayList<>();

        int s = t.getState();

        for (int i = 0; i < s; i++) {
            Thread newThread = new Thread() {
                @Override
                public void run() {
                    for (; ; ) {
                        int c = t.getState();
                        if (c == 0)
                            return;
                        int nextc = c - 1;
                        if (t.compareAndSetState(c, nextc)) {

                        }

                    }
                }
            };
            threads.add(newThread);
        }
        for (int i = 0; i < s; i++) {
            threads.get(i).start();
        }
        Thread.sleep(10000);
        System.out.println(t.getState());

    }

}

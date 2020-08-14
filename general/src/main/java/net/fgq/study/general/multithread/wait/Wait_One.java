package net.fgq.study.general.multithread.wait;

import sun.misc.Unsafe;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.locks.AbstractQueuedSynchronizer;

/**
 * @author fenggqc
 * @create 2018-12-21 14:12
 **/

public class Wait_One extends Thread {

    private static Unsafe unsafe = null;
    private static final long stateOffset;

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
    //region Getter And Setter
    // endregion

    private volatile static Integer waitCount = 0;
    private AtomicInteger waitCount2 = new AtomicInteger(0);

    public static void main(String[] args) throws Exception {

        List<Wait_One> waitOneList = new ArrayList<>();

        int threadcount = 6;
        for (int i = 0; i < threadcount; i++) {
            waitOneList.add(new Wait_One(i));
        }
        for (int i = 0; i < threadcount; i++) {
            waitOneList.get(i).start();
        }
        Thread.sleep(10000);
        for (int i = 0; i < threadcount; i++) {
            if (waitOneList.get(i).getState() == State.WAITING
                    || waitOneList.get(i).getState() == State.TIMED_WAITING) {
                waitOneList.get(i).interrupt();
            }
        }

    }

    private static Object lockhelper = new Object();

    private Integer index = 0;

    public Wait_One(Integer i) {
        this.index = i;
    }

    @Override
    public void run() {
        try {
            System.out.println(index.toString() + ":enter");

            synchronized (lockhelper) {
                System.out.println(index.toString() + ":enter synchronized");

                if (index % 3 == 2) { //少量线程进行notify
                    System.out.println(index.toString() + ":notify");
                    lockhelper.notify();
                } else {
                    System.out.println(index.toString() + ":wait");
                    waitCount += 1;
                    waitCount2.addAndGet(1);
                    lockhelper.wait();
                    int i = waitCount2.addAndGet(-1);
                    System.out.println(index.toString() + ":" + String.valueOf(i));
                    if (i > 0) {
                        System.out.println(index.toString() + ":notifyAll");
                        lockhelper.notifyAll();
                    }
                }

                System.out.println(index.toString() + ":is running");

                System.out.println(index.toString() + ":out synchronized");
            }

            System.out.println(index.toString() + ":out");
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}

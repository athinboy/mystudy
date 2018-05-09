package net.fgq.study.general.lock.locksupport;

import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.LockSupport;
import java.util.concurrent.locks.ReentrantLock;

public class LockSupport_One {

    //region Getter And Setter
    // endregion

    private static Thread t1 = new Thread(new Runnable() {
        @Override
        public void run() {
            System.out.println("t1 enter");
            LockSupport.park();
            if (t1.isInterrupted()) {
                System.out.println("t1 is interrupted");
            }
            System.out.println("t1 finish");

        }
    });


    public static void main(String[] args) throws InterruptedException {


        t1.start();
        Thread.sleep(1000);
//        t1.interrupt();
        LockSupport.unpark(t1);

    }

}

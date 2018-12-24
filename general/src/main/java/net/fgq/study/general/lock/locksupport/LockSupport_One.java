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
            System.out.println("park t1");
            LockSupport.park();
            if (t1.isInterrupted()) {
                System.out.println("t1 is interrupted");
            }
            System.out.println("t1 finish");


        }
    });



    public static void main(String[] args) throws InterruptedException {

        /*
t1 enter
park t1
unpark t1
t1 finish
        */

        t1.start();
        Thread.sleep(1000);
        System.out.println("unpark t1");
        LockSupport.unpark(t1);

    }






}

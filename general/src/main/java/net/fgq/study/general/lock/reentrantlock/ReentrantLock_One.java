package net.fgq.study.general.lock.reentrantlock;

import java.util.concurrent.locks.Condition;
import java.util.concurrent.locks.ReentrantLock;

public class ReentrantLock_One {

    //region Getter And Setter
    // endregion


    private  static  Runnable runnable=new Runnable() {
        @Override
        public void run() {

            System.out.println(Thread.currentThread().getName()+"enter");
            reentrantLock.lock();
            System.out.println(Thread.currentThread().getName()+"lock");

            try {
                Thread.sleep(500);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.out.println(Thread.currentThread().getName()+"unlock");
            reentrantLock.unlock();


        }
    };


    private  static  ReentrantLock reentrantLock;

    public static void main(String[] args) throws Exception {


        reentrantLock=new ReentrantLock(true);
        Thread t1=new Thread(runnable);
        t1.setName("t1");
        Thread t2=new Thread(runnable);
        t2.setName("t2");
        t1.start();

        Thread.sleep(200);

        t2.start();
        Thread.sleep(1000);

        /*
t1enter
t1lock
t2enter
t1unlock
t2lock
t2unlock
         */


    }

}

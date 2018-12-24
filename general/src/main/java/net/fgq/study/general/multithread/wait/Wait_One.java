package net.fgq.study.general.multithread.wait;

import java.util.ArrayList;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-12-21 14:12
 **/


public class Wait_One extends Thread {


    //region Getter And Setter
    // endregion

    public static void main(String[] args) throws Exception {


        List<Wait_One> waitOneList = new ArrayList<>();

        int threadcount=20;
        for (int i = 0; i < threadcount; i++) {
            waitOneList.add(new Wait_One(i));
        }
        for (int i = 0; i < threadcount; i++) {
            waitOneList.get(i).start();
        }
        Thread.sleep(2000);
//        System.out.println("notifyall");
        //lockhelper.notifyAll();


    }


    private static Object lockhelper = new Object();


    private Integer index = 0;

    public Wait_One(Integer i) {
        this.index = i;
    }


    /**
     * If this thread was constructed using a separate
     * <code>Runnable</code> run object, then that
     * <code>Runnable</code> object's <code>run</code> method is called;
     * otherwise, this method does nothing and returns.
     * <p>
     * Subclasses of <code>Thread</code> should override this method.
     *
     * @see #start()
     * @see #stop()
     * @see #Thread(ThreadGroup, Runnable, String)
     */
    @Override
    public void run() {
        try {
            System.out.println(index.toString()+"enter");

            synchronized (lockhelper) {
                System.out.println(index.toString()+"enter synchronized");

                if(index<10){
                    if(index %  3==0){ //少量线程进行notify
                        lockhelper.notify();
                    }else{
                        lockhelper.wait();
                    }

                }



                System.out.println(index.toString()+" is running");

                System.out.println(index.toString()+"out synchronized");
            }


            System.out.println(index.toString()+"out");
        } catch ( Exception e) {
            e.printStackTrace();
        }

    }
}

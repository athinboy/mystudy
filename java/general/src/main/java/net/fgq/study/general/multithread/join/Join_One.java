package net.fgq.study.general.multithread.join;

import java.util.ArrayList;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-12-21 11:23
 **/


public class Join_One {

    //region Getter And Setter
    // endregion


    static List<myThread> threadList;

    public static void main(String[] args) throws Exception {



        /*
0enter
1enter
2enter
3enter
4enter
4out
3out
2out
1out
0out
        * */

        threadList = new ArrayList<>();
        myThread thread;
        for (int i = 0; i < 5; i++) {
            thread =  new myThread(i);
            threadList.add(thread);
        }

        for (int i = 0; i < 5; i++) {
            threadList.get(i).start();
        }


    }

    protected static class myThread extends Thread {


        private Integer s = null;




        public void Do() {
            try {

                System.out.println(s.toString() + "enter");



                Thread.sleep(100L);


                if (s.compareTo(threadList.size() - 1) == 0) {

                } else {
                    threadList.get(s + 1).join();
                }
                System.out.println(s.toString() + "out");

            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }


        public myThread(Integer arg) {
            this.s = arg;

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
            this.Do();
        }
    }


}

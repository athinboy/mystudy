package net.fgq.study.general.memleak;

import sun.misc.GC;

import java.io.Console;
import java.util.Vector;

/**
 * Created by fenggqc on 2018/4/17.
 */
public class MemLeak_A {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {
        System.out.println(System.in.read());

        Vector v = new Vector(10);

        for (int i = 1; i < 10000000; i++) {
            Object o = new Object();
            v.add(o);
            o = null;
        }
        System.out.println(System.in.read());

        v=null;
        System.gc();
        System.out.println(System.in.read());
    }
}

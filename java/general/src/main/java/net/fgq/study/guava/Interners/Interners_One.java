package net.fgq.study.guava.Interners;

import com.google.common.collect.Interner;
import com.google.common.collect.Interners;

/**
 * Created by fengguoqiang 2020/8/26
 */
public class Interners_One {

    public static void main(String[] args) {

        Interners.InternerBuilder internerBuilder = Interners.newBuilder();
        internerBuilder.build();

        String aa = "aa";
        aa.intern();

        Integer i = new Integer(2);

        Interner<String> ids = Interners.<String>newWeakInterner();
        ids.intern("fwer");

    }
}

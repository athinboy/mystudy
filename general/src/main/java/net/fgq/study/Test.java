package net.fgq.study;

import org.apache.commons.lang3.builder.CompareToBuilder;

import java.util.ArrayList;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-12-06 18:25
 **/


public class Test {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {

        System.out.println(a());
    }

    public static boolean a() {


        try {
            return true;
        } finally {
            return false;
        }

    }


}

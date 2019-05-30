package net.fgq.study;

import org.apache.commons.lang3.builder.CompareToBuilder;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Supplier;

/**
 * @author fenggqc
 * @create 2018-12-06 18:25
 **/


public class Test {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {
//
//        final Car car = Car.create( Car::new );
//        System.out.println(a());

        Boolean s=null;

        if(Boolean.FALSE.equals(s)){

        }


        if (false == s) {

        }

//        System.out.println(s!=false);
//        System.out.println(false!=null);
//        System.out.println();
//       System.out.println( s==false);
//        System.out.println(false== s);


    }

    public static boolean a() {


        try {
            return true;
        } finally {
            return false;
        }

    }




    public static class Car {
        public static Car create( final Supplier< Car > supplier )
        {
            return supplier.get();
        }

        public static void collide( final Car car ) {
            System.out.println( "Collided " + car.toString() );
        }

        public void follow( final Car another ) {
            System.out.println( "Following the " + another.toString() );
        }

        public void repair() {
            System.out.println( "Repaired " + this.toString() );
        }
    }


}

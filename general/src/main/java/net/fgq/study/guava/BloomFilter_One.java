package net.fgq.study.guava;

import com.google.common.hash.BloomFilter;
import com.google.common.hash.Funnels;

public class BloomFilter_One {


    //region Getter And Setter
    // endregion

    public static void main(String[] args) throws Exception{
        BloomFilter<Integer> integerBloomFilter=  BloomFilter.create(Funnels.integerFunnel(),2000000);

        for (int i = 0; i < 100000; i++) {
            integerBloomFilter.put(i);
            
        }
        for (int i = 0; i < 200000; i++) {
            System.out.println(i);
            System.out.println(integerBloomFilter.mightContain(i));
        }
        

    }



}

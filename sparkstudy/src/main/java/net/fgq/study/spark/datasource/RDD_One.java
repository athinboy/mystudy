package net.fgq.study.spark.datasource;

import org.apache.spark.SparkConf;
import org.apache.spark.api.java.JavaRDD;
import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.api.java.function.Function;
import org.apache.spark.sql.SparkSession;
import org.apache.spark.util.LongAccumulator;

import java.util.Arrays;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-09-25 14:25
 **/


public class RDD_One {

    //region Getter And Setter
    // endregion

    //spark-submit --class  net.fgq.study.spark.datasource.RDD_One  --master spark://192.168.169.110:7077 --jars  F:\fenggq\study\github\studyjava\sparkstudy\src\main\resources\mysqldrive\mysql-connector-java-5.0.8-bin.jar   F:\fenggq\study\github\studyjava\sparkstudy\target\sparkstudy-1.0-SNAPSHOT.jar
    public static void main(String[] args) {

        SparkConf conf = new SparkConf().setAppName(MysqlSource.class.getName());

        JavaSparkContext sc = new JavaSparkContext(conf);


        List<Integer> data = Arrays.asList(1, 2, 3, 4, 5);
        JavaRDD<Integer> distData = sc.parallelize(data);

        distData.map((x) -> x + 2);

        LongAccumulator accum = sc.sc().longAccumulator();

        distData.foreach(x -> accum.add(x));

        System.out.println("fwefw");
        System.out.println(accum.value());


    }


}

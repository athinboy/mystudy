package net.fgq.study.spark.streaming;

import net.fgq.study.spark.datasource.MysqlSource;
import org.apache.spark.SparkConf;
import org.apache.spark.api.java.JavaRDD;
import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.streaming.Durations;
import org.apache.spark.streaming.api.java.JavaDStream;
import org.apache.spark.streaming.api.java.JavaReceiverInputDStream;
import org.apache.spark.streaming.api.java.JavaStreamingContext;
import org.apache.spark.util.LongAccumulator;

import java.util.Arrays;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-09-28 17:32
 **/


public class SocketTextStream_One {

    //region Getter And Setter
    // endregion


    //spark-submit --class  net.fgq.study.spark.streaming.SocketTextStream_One      --master local --jars  F:\fenggq\study\github\studyjava\sparkstudy\src\main\resources\mysqldrive\mysql-connector-java-5.0.8-bin.jar   F:\fenggq\study\github\studyjava\sparkstudy\target\sparkstudy-1.0-SNAPSHOT.jar

    public static void main(String[] args) throws InterruptedException {

        SparkConf conf = new SparkConf().setAppName(MysqlSource.class.getName());

        JavaStreamingContext jssc = new JavaStreamingContext(conf, Durations.seconds(1));

        JavaReceiverInputDStream<String> lines = jssc.socketTextStream("localhost", 9999);

        JavaDStream<String> words = lines.flatMap(x -> Arrays.asList(x.split(" ")).iterator());

        words.print(1000);

        jssc.start();              // Start the computation
        jssc.awaitTermination();


    }


}

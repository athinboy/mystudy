package net.fgq.study.spark.datasource;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.util.*;

import org.apache.spark.SparkConf;
import org.apache.spark.api.java.JavaPairRDD;
import org.apache.spark.api.java.JavaRDD;
import org.apache.spark.api.java.JavaSparkContext;
import org.apache.spark.api.java.function.Function;
import org.apache.spark.api.java.function.PairFunction;
import org.apache.spark.api.java.function.VoidFunction;
import org.apache.spark.sql.*;
import org.apache.spark.sql.types.DataTypes;
import org.apache.spark.sql.types.StructField;
import org.apache.spark.sql.types.StructType;

/**
 * @author fenggqc
 * @create 2018-07-20 17:23
 **/


public class MysqlSource {

    //region Getter And Setter
    // endregion


    //spark-submit --class  net.fgq.study.spark.datasource.MysqlSource  --master local[8]   --jars  F:\fenggq\study\github\studyjava\sparkstudy\src\main\resources\mysqldrive\mysql-connector-java-5.0.8-bin.jar   F:\fenggq\study\github\studyjava\sparkstudy\target\sparkstudy-1.0-SNAPSHOT.jar

    public static void main(String[] args) throws Exception {

        SparkConf conf = new SparkConf().setAppName(MysqlSource.class.getName());



        SparkSession sparkSession = SparkSession.builder().appName(MysqlSource.class.getName()).config(conf)
                .getOrCreate();

        DataFrameReader dataFrameReader = sparkSession.read().format("jdbc")
                .option("url", "jdbc:mysql://127.0.0.1:3306/test")
                .option("dbtable", "ba_area")
                .option("driver", "com.mysql.jdbc.Driver")
                .option("user", "root")
                .option("password", "123");

        if (null == dataFrameReader) {
            throw new Exception("初始化DataFrameReader失败");
        }

        Dataset<Row> rowDataset = dataFrameReader.load();

        System.out.println("load finish!!!!!!!!!!!!");

        rowDataset.show();

        rowDataset = sparkSession.sql("select * from ba_area ");
        rowDataset.show();



    }


}

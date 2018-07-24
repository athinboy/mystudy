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
                .option("url", "jdbc:mysql://10.10.14.215:6603/kingkoo_wms")
                .option("dbtable", "ba_area")
                .option("driver", "com.mysql.jdbc.Driver")
                .option("user", "kingkoo")
                .option("password", "Kingkoo!!!123");

        if (null == dataFrameReader) {
            throw new Exception("wefewf");
        }

        Dataset<Row> jdbcDF = dataFrameReader.load();


//        Properties connectionProperties = new Properties();
//        connectionProperties.put("user", "username");
//        connectionProperties.put("password", "password");
//        Dataset<Row> jdbcDF2 = sparkSession.read()
//                .jdbc("jdbc:mysql:10.10.14.215:6603/kingkoo_wms", "ba_area", connectionProperties);


        jdbcDF.show();

    }


}

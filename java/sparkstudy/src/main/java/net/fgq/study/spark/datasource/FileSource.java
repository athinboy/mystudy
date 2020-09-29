package net.fgq.study.spark.datasource;

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

//spark-submit --class  net.fgq.study.spark.datasource.FileSource  --master local[8] F:\fenggq\study\github\studyjava\sparkstudy\target\sparkstudy-1.0-SNAPSHOT.jar

/**
 * @author fenggqc
 * @create 2018-07-23 16:36
 **/


public class FileSource {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {
        SparkSession sparkSession = SparkSession.builder().appName(FileSource.class.getName())
                .getOrCreate();
        String path = "c:\\1.txt";
        Dataset<String> stringDataset = sparkSession.read().textFile(path);
        stringDataset.show();

    }


}

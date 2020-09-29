package net.fgq.study.spark.datasource;

import org.apache.spark.launcher.SparkAppHandle;
import org.apache.spark.launcher.SparkLauncher;

import java.io.IOException;
import java.util.HashMap;
import java.util.concurrent.CountDownLatch;

import org.apache.spark.launcher.SparkAppHandle;
import org.apache.spark.launcher.SparkLauncher;

/**
 * @author fenggqc
 * @create 2018-09-28 14:52
 **/


public class SparkLauncher_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) throws Exception {


        HashMap env = new HashMap();

        //这两个属性必须设置
//        env.put("HADOOP_CONF_DIR", "/usr/local/hadoop/etc/overriterHaoopConf");
        env.put("JAVA_HOME", "C:\\Program Files\\Java\\jdk1.8.0_161");

        //可以不设置
        //env.put("YARN_CONF_DIR","");

        CountDownLatch countDownLatch = new CountDownLatch(1);

        SparkAppHandle handle;

        SparkLauncher sparkLauncher = new SparkLauncher(env)
                .setSparkHome("D:\\spark\\spark-2.3.1-bin-hadoop2.7")
                .setAppResource("F:\\fenggq\\study\\github\\studyjava\\sparkstudy\\target\\sparkstudy-1.0-SNAPSHOT.jar")
                .setMainClass("net.fgq.study.spark.datasource.RDD_One")
                .setMaster("local[8]")
                .setDeployMode("client")
                .setVerbose(true);

        int s = 1;
        if (s == 1) {

            handle = sparkLauncher.startApplication(new SparkAppHandle.Listener() {
                //这里监听任务状态，当任务结束时（不管是什么原因结束）,isFinal（）方法会返回true,否则返回false
                @Override
                public void stateChanged(SparkAppHandle sparkAppHandle) {
                    if (sparkAppHandle.getState().isFinal()) {
                        countDownLatch.countDown();
                    }
                    System.out.println("state:" + sparkAppHandle.getState().toString());
                }


                @Override
                public void infoChanged(SparkAppHandle sparkAppHandle) {
                    System.out.println("Info:" + sparkAppHandle.getState().toString());
                }
            });

            System.out.println("The task is executing, please wait ....");


            countDownLatch.await();
            System.out.println("The task is finished!");


        } else {


            sparkLauncher.redirectOutput(ProcessBuilder.Redirect.INHERIT);
            Process process = sparkLauncher.launch();
//                    InputStreamReaderRunnable inputStreamReaderRunnable = new InputStreamReaderRunnable(process.getInputStream(), "input");
//                    Thread inputThread = new Thread(inputStreamReaderRunnable, "LogStreamReader input");
//                    inputThread.start();
//
//                    InputStreamReaderRunnable errorStreamReaderRunnable = new InputStreamReaderRunnable(process.getErrorStream(), "error");
//                    Thread errorThread = new Thread(errorStreamReaderRunnable, "LogStreamReader error");
//                    errorThread.start();

            System.out.println("Waiting for finish...");
            int exitCode = process.waitFor();
            System.out.println("Finished! Exit code:" + exitCode);

        }
    }

}


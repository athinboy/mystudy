package net.fgq.study.elasticsearch;

import org.apache.http.HttpHost;
import org.elasticsearch.action.get.GetRequest;
import org.elasticsearch.action.get.GetResponse;
import org.elasticsearch.client.RequestOptions;
import org.elasticsearch.client.RestClient;
import org.elasticsearch.client.RestHighLevelClient;

import java.io.IOException;
import java.sql.SQLException;
import java.util.Properties;

/**
 * @author fenggqc
 * @create 2019-01-03 16:32
 **/


public class RestHighLevelClient_Get_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {


        Properties properties = new Properties();
        RestHighLevelClient client = null;

        try {


            client = new RestHighLevelClient(
                    RestClient.builder(
                            new HttpHost("192.168.169.107", 9200, "http")));


            GetRequest getRequest = new GetRequest(
                    "tydmat",
                    "mat",
                    "170000000002");

           GetResponse getResponse= client.get(getRequest, RequestOptions.DEFAULT);
            System.out.println(getResponse.getSourceAsString());



        } catch (Exception e) {
            System.out.println(e.toString());
            e.printStackTrace();
        } finally {

            try {
                client.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

        }


    }


}

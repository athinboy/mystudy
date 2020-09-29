package net.fgq.study.elasticsearch;

import org.apache.http.HttpEntity;
import org.apache.http.HttpHost;
import org.apache.http.StatusLine;
import org.apache.http.entity.ContentType;
import org.apache.http.entity.StringEntity;
import org.apache.http.nio.entity.NStringEntity;
import org.apache.http.util.EntityUtils;
import org.elasticsearch.client.Response;
import org.elasticsearch.client.RestClient;


import java.io.IOException;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * @author fenggqc
 * @create 2018-12-29 17:44
 **/


public class RestClient_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {


        RestClient restClient = null;
        String responseBody;
        Response response;
        StatusLine statusLine;
        try {


            restClient = RestClient.builder(
                    new HttpHost("192.168.169.107", 9200, "http")).build();


            StringEntity stringEntity = new StringEntity("{\n" +
                    "  \"mappings\": {\n" +
                    "    \"doc\": { \n" +
                    "      \"properties\": { \n" +
                    "        \"title\":    { \"type\": \"text\"  }, \n" +
                    "        \"name\":     { \"type\": \"text\"  }, \n" +
                    "        \"age\":      { \"type\": \"integer\" },  \n" +
                    "        \"created\":  {\n" +
                    "          \"type\":   \"date\", \n" +
                    "          \"format\": \"strict_date_optional_time||epoch_millis\"\n" +
                    "        }\n" +
                    "      }\n" +
                    "    }\n" +
                    "  }\n" +
                    "}", ContentType.APPLICATION_JSON);

            //创建索引
            Map<String, String> para= Collections.emptyMap();
            response = restClient.performRequest("PUT", "/people", para, stringEntity);
            statusLine = response.getStatusLine();
            System.out.println(String.valueOf(statusLine.getStatusCode()) + ":" + statusLine.getReasonPhrase());//404 Not Found
            responseBody = EntityUtils.toString(response.getEntity());
            System.out.println(responseBody);


            if (1 == 1) return;

            //创建索引
            response = restClient.performRequest("PUT", "/testindex");
            responseBody = EntityUtils.toString(response.getEntity());
            System.out.println(responseBody);

            //查询索引
            response = restClient.performRequest("GET", "/testindex");
            responseBody = EntityUtils.toString(response.getEntity());
            statusLine = response.getStatusLine();
            System.out.println(String.valueOf(statusLine.getStatusCode()) + ":" + statusLine.getReasonPhrase());//404 Not Found
            System.out.println(responseBody);


            //查询是否存在索引  A 404 means it does not exist, and 200 means it does.
            response = restClient.performRequest("HEAD", "/testindex");
            statusLine = response.getStatusLine();
            System.out.println(String.valueOf(statusLine.getStatusCode()) + ":" + statusLine.getReasonPhrase()); //200:OK


            //删除索引
            response = restClient.performRequest("DELETE", "/testindex");
            responseBody = EntityUtils.toString(response.getEntity());
            statusLine = response.getStatusLine();
            System.out.println(String.valueOf(statusLine.getStatusCode()) + ":" + statusLine.getReasonPhrase());
            System.out.println(responseBody);//{"acknowledged":true}


        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            try {
                restClient.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }


    }


}

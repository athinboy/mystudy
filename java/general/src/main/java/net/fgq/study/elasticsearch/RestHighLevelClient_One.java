package net.fgq.study.elasticsearch;

import org.apache.http.HttpHost;
import org.elasticsearch.action.DocWriteResponse;
import org.elasticsearch.action.index.IndexRequest;
import org.elasticsearch.action.index.IndexResponse;
import org.elasticsearch.action.support.replication.ReplicationResponse;
import org.elasticsearch.client.RequestOptions;
import org.elasticsearch.client.RestClient;
import org.elasticsearch.client.RestHighLevelClient;
import org.elasticsearch.common.xcontent.XContentType;

import java.io.IOException;

/**
 * @author fenggqc
 * @create 2019-01-03 10:44
 **/


public class RestHighLevelClient_One {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) {


        RestHighLevelClient client = null;


        try {


            client = new RestHighLevelClient(
                    RestClient.builder(
                            new HttpHost("192.168.169.107", 9200, "http")));



            IndexRequest request = new IndexRequest(
                    "tyd",
                    "mydoc",
                    "1");
            String jsonString = "{" +
                    "\"user\":\"kimchy\"," +
                    "\"postDate\":\"2013-01-30\"," +
                    "\"message\":\"trying out Elasticsearch\"" +
                    "}";

            request.routing("fwe");

            request.source(jsonString, XContentType.JSON);
            IndexResponse indexResponse = client.index(request, RequestOptions.DEFAULT);
            String index = indexResponse.getIndex();
            String type = indexResponse.getType();
            String id = indexResponse.getId();
            long version = indexResponse.getVersion();
            if (indexResponse.getResult() == DocWriteResponse.Result.CREATED) {

            } else if (indexResponse.getResult() == DocWriteResponse.Result.UPDATED) {

            }
            ReplicationResponse.ShardInfo shardInfo = indexResponse.getShardInfo();
            if (shardInfo.getTotal() != shardInfo.getSuccessful()) {

            }
            if (shardInfo.getFailed() > 0) {
                for (ReplicationResponse.ShardInfo.Failure failure :
                        shardInfo.getFailures()) {
                    String reason = failure.reason();
                }
            }



        } catch (Exception ex) {
            System.out.println(ex.toString());
        } finally {


            try {
                client.close();


            } catch (IOException e) {
                e.printStackTrace();
            }
        }


    }


}

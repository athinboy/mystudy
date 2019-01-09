package net.fgq.study.elasticsearch;

import org.apache.commons.lang3.ArrayUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.http.HttpHost;
import org.apache.lucene.search.PrefixQuery;
import org.elasticsearch.action.get.GetRequest;
import org.elasticsearch.action.get.GetResponse;
import org.elasticsearch.action.search.*;
import org.elasticsearch.client.RequestOptions;
import org.elasticsearch.client.RestClient;
import org.elasticsearch.client.RestHighLevelClient;
import org.elasticsearch.common.unit.TimeValue;
import org.elasticsearch.search.Scroll;
import org.elasticsearch.search.SearchHit;
import org.elasticsearch.search.SearchHits;
import org.elasticsearch.search.builder.SearchSourceBuilder;

import java.io.IOException;
import java.util.Arrays;
import java.util.Properties;

import static org.elasticsearch.index.query.QueryBuilders.matchQuery;
import static org.elasticsearch.index.query.QueryBuilders.prefixQuery;

/**
 * @author fenggqc
 * @create 2019-01-09 9:27
 **/


public class RestHighLevelClient_SearchScroll_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {


        Properties properties = new Properties();
        RestHighLevelClient client = null;

        try {


            client = new RestHighLevelClient(
                    RestClient.builder(
                            new HttpHost("192.168.169.107", 9200, "http")));


//            GetRequest getRequest = new GetRequest(
//                    "tydmat",
//                    "mat",
//                    "170000000002");
            final Scroll scroll = new Scroll(TimeValue.timeValueMinutes(1L));
            SearchRequest searchRequest = new SearchRequest("tydmat");
            SearchSourceBuilder searchSourceBuilder = new SearchSourceBuilder();
            //searchSourceBuilder.query(matchQuery("title", "Elasticsearch"));



            searchSourceBuilder.query(prefixQuery("material_id","17000000"));
            searchSourceBuilder.fetchSource(new String[]{"*color"},new String[]{});
            searchSourceBuilder.size(1);
            searchRequest.source(searchSourceBuilder);
            searchRequest.scroll(TimeValue.timeValueMinutes(1L));
            SearchResponse searchResponse = client.search(searchRequest, RequestOptions.DEFAULT);





            String scrollId = searchResponse.getScrollId();
            SearchHits hits = searchResponse.getHits();
            SearchHit[] searchHits = hits.getHits();
            for(SearchHit hit:hits){

                System.out.println(hit.getSourceAsString());
            }



            while (searchHits != null && searchHits.length > 0) {
                SearchScrollRequest scrollRequest = new SearchScrollRequest(scrollId);
                scrollRequest.scroll(scroll);
                searchResponse = client.scroll(scrollRequest, RequestOptions.DEFAULT);
                scrollId = searchResponse.getScrollId();
                hits = searchResponse.getHits();
                searchHits = hits.getHits();
                for(SearchHit hit:hits){
                    System.out.println(hit.getSourceAsString());
                }
            }


            ClearScrollRequest clearScrollRequest = new ClearScrollRequest();
            clearScrollRequest.addScrollId(scrollId);
            ClearScrollResponse clearScrollResponse = client.clearScroll(clearScrollRequest, RequestOptions.DEFAULT);
            boolean succeeded = clearScrollResponse.isSucceeded();




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

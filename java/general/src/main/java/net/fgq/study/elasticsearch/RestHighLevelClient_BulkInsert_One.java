package net.fgq.study.elasticsearch;

import com.alibaba.fastjson.JSONObject;
import com.mysql.jdbc.JDBC4Connection;
import org.apache.commons.dbcp2.BasicDataSource;
import org.apache.commons.dbcp2.ConnectionFactory;
import org.apache.commons.dbcp2.DataSourceConnectionFactory;
import org.apache.http.HttpHost;
import org.elasticsearch.action.DocWriteRequest;
import org.elasticsearch.action.DocWriteResponse;
import org.elasticsearch.action.bulk.BulkItemResponse;
import org.elasticsearch.action.bulk.BulkRequest;
import org.elasticsearch.action.bulk.BulkResponse;
import org.elasticsearch.action.delete.DeleteResponse;
import org.elasticsearch.action.index.IndexRequest;
import org.elasticsearch.action.index.IndexResponse;
import org.elasticsearch.action.update.UpdateResponse;
import org.elasticsearch.client.RequestOptions;
import org.elasticsearch.client.RestClient;
import org.elasticsearch.client.RestHighLevelClient;
import org.elasticsearch.common.xcontent.XContentType;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.sql.DataSource;
import java.io.IOException;
import java.sql.*;
import java.util.Properties;

/**
 * @author fenggqc
 * @create 2019-01-03 11:21
 **/


public class RestHighLevelClient_BulkInsert_One {

    //region Getter And Setter
    // endregion


    static Logger logger = LoggerFactory.getLogger(RestHighLevelClient_BulkInsert_One.class);


    public static void main(String[] args) {


        BasicDataSource dataSource;
        ConnectionFactory connectionFactory;
        Connection connection = null;


        Properties properties = new Properties();
        RestHighLevelClient client = null;

        try {


            client = new RestHighLevelClient(
                    RestClient.builder(
                            new HttpHost("192.168.169.107", 9200, "http")));


            dataSource = new BasicDataSource();
            connectionFactory = new DataSourceConnectionFactory(dataSource);
            connection = null;

            dataSource.setDriverClassName("com.mysql.jdbc.Driver");
            dataSource.setUrl("jdbc:mysql://192.168.169.107:3306/study");
            dataSource.setUsername("root");
            dataSource.setPassword("123");
            connection = connectionFactory.createConnection();

            PreparedStatement statement = connection.prepareStatement("select * from ba_material limit 100000 ");

            ResultSet resultSet = statement.executeQuery();
            ResultSetMetaData resultSetMetaData = resultSet.getMetaData();
            int c = resultSetMetaData.getColumnCount();


            JSONObject jsonObject;
            String cellstr;

            Object o;


            BulkRequest request = new BulkRequest();
            String materialId;
            String matid = "";
            while (resultSet.next()) {

                jsonObject = new JSONObject();
                for (int i = 1; i <= c; i++) {
                    o = resultSet.getObject(i);
                    cellstr = (o == null ? "" : o).toString();
                    jsonObject.put(resultSetMetaData.getColumnName(i), cellstr);
                    if ("material_id".equals(resultSetMetaData.getColumnName(i))) {
                        matid = cellstr;
                    }

                }
                System.out.println(jsonObject.toJSONString());

                request.add(new IndexRequest("tydmat", "mat", matid).source(jsonObject.toJSONString(), XContentType.JSON));
            }


            BulkResponse bulkResponse = client.bulk(request, RequestOptions.DEFAULT);


            for (BulkItemResponse bulkItemResponse : bulkResponse) {

                if (true == bulkItemResponse.isFailed()) {

                    System.out.println(bulkItemResponse.getFailureMessage());
                    continue;
                }

                DocWriteResponse itemResponse = bulkItemResponse.getResponse();


                if (bulkItemResponse.getOpType() == DocWriteRequest.OpType.INDEX
                        || bulkItemResponse.getOpType() == DocWriteRequest.OpType.CREATE) {
                    IndexResponse indexResponse = (IndexResponse) itemResponse;

                } else if (bulkItemResponse.getOpType() == DocWriteRequest.OpType.UPDATE) {
                    UpdateResponse updateResponse = (UpdateResponse) itemResponse;

                } else if (bulkItemResponse.getOpType() == DocWriteRequest.OpType.DELETE) {
                    DeleteResponse deleteResponse = (DeleteResponse) itemResponse;
                }


            }


        } catch (Exception e) {
            logger.error("we5", e);
            e.printStackTrace();
        } finally {
            try {
                connection.close();
            } catch (SQLException e) {
                e.printStackTrace();
            }
            try {
                client.close();
            } catch (IOException e) {
                e.printStackTrace();
            }

        }


    }


}

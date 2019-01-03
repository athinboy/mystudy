package net.fgq.study.elasticsearch;

import org.elasticsearch.action.get.GetRequestBuilder;
import org.elasticsearch.action.index.IndexRequestBuilder;
import org.elasticsearch.client.transport.TransportClient;
import org.elasticsearch.common.settings.Settings;
import org.elasticsearch.common.transport.TransportAddress;
import org.elasticsearch.transport.client.PreBuiltTransportClient;

import java.net.InetAddress;
import java.net.UnknownHostException;

/**
 * @author fenggqc
 * @create 2019-01-02 15:19
 **/


public class TransportClient_One {

    //region Getter And Setter
    // endregion


    public static void main(String[] args) {


        TransportClient client = null;
        try {
            // on startup
            client = new PreBuiltTransportClient(Settings.EMPTY)
                    .addTransportAddress(new TransportAddress(InetAddress.getByName("192.168.169.107"), 9200));

            IndexRequestBuilder indexRequestBuilder= client.prepareIndex();
            indexRequestBuilder.setId("9");
            indexRequestBuilder.setType("test");



        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            // on shutdown
            client.close();
        }


    }


}

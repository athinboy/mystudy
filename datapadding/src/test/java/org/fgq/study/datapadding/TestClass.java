package org.fgq.study.datapadding;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.serializer.SerializerFeature;
import org.apache.commons.logging.impl.Log4JLogger;
import org.fgq.study.datapadding.exception.DataPaddingException;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.impl.Log4jLoggerFactory;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * @author fenggqc
 * @create 2018-10-30 14:18
 **/

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration("classpath:applicationContext.xml")
public class TestClass {

    //region Getter And Setter
    // endregion

    Logger logger = LoggerFactory.getLogger(TestClass.class);


    @Test
    public void T() {



        PaddingClient paddingClient = new PaddingClient();

        List<PaddingClient> paddingClientList = new ArrayList<PaddingClient>();

        for (int i = 0; i < 10; i++) {
            paddingClient = new PaddingClient();
            paddingClient.setIndex(String.valueOf(i / 3));
            paddingClientList.add(paddingClient);
        }


        try {

            DataPadding.PadInfo(PaddingClient.class, paddingClientList);

            System.out.println(JSON.toJSONString(paddingClientList,new SerializerFeature[]{SerializerFeature.PrettyFormat}));

        } catch (Exception e) {
            System.out.println(e.toString());
            logger.error("", e);
        }


    }


}

package org.fgq.study.controller;


import com.alibaba.fastjson.JSON;
import com.rabbitmq.tools.json.JSONUtil;
import feign.Feign;
import feign.codec.StringDecoder;
import feign.gson.GsonDecoder;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.fgq.study.service.feign.FeighResult;
import org.fgq.study.service.feign.OneService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpRequest;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.Map;

@Controller()
@RequestMapping("/mvc/feigh")
public class FeignController implements OneService {


    //region Getter And Setter
    // endregion

    @Autowired
    HttpServletRequest httpRequest;
    @Autowired
    HttpServletRequest httpResponse;


    @ResponseBody
    @RequestMapping("/hello/{name}")
    public String HelloName(@PathVariable String name) {

        return "Hello " + name + "!";

    }

    @ResponseBody
    @RequestMapping("/testHello")
    public void TestHello() throws IOException {


        OneService oneService = Feign.builder()
//                .decoder(new GsonDecoder())
                .decoder(new StringDecoder())
                .target(OneService.class, "http://localhost:8100/mv/");
        System.out.println(oneService.HelloName("fgq"));


    }

    @Override
    @ResponseBody
    @RequestMapping("/all/{name}")
    public FeighResult All(@PathVariable String name, Map headers, Map querymap) throws IOException {

        System.out.println(httpRequest.getHeader("myname"));
        System.out.println(httpRequest.getQueryString());


        FeighResult result = new FeighResult();
        result.setAge(123);
        result.setName(name);
        return result;
    }

    @ResponseBody
    @RequestMapping("/testAll")
    public void TestAll() throws IOException {

        OneService oneService = Feign.builder()
                .decoder(new GsonDecoder())
//                .decoder(new StringDecoder())
                .target(OneService.class, "http://localhost:8100/mv/");
        Map<String, String> headmap = new HashMap<String, String>();
        headmap.put("myname", "fgq");
        Map<String, String> querymap = new HashMap<String, String>();
        querymap.put("myask", "hahaha");
        String str = JSON.toJSONString(oneService.All("fgq", headmap, querymap));
        System.out.println(str);


    }


}

package org.fgq.study.controller;


import feign.Feign;
import feign.codec.StringDecoder;
import feign.gson.GsonDecoder;
import org.fgq.study.service.feign.OneService;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller()
@RequestMapping("/mvc/feigh")
public class FeignController implements OneService {


    //region Getter And Setter
    // endregion

    @ResponseBody
    @RequestMapping("/hello/{name}")
    public String HelloName(@PathVariable String name) {

        return "Hello " + name + "!";

    }

    @ResponseBody
    @RequestMapping("/testHello")
    public void TestHello() {

        OneService oneService = Feign.builder()
//                .decoder(new GsonDecoder())
                .decoder(new StringDecoder())
                .target(OneService.class, "http://localhost:8100/mv/");
        System.out.println(oneService.HelloName("fgq"));


    }


}

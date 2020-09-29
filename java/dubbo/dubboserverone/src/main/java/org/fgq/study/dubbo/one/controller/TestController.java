package org.fgq.study.dubbo.one.controller;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.Date;

/**
 * @author fenggqc
 * @create 2018-10-31 11:29
 **/


@Controller
@RequestMapping("/test")
public class TestController {

    Logger logger= LoggerFactory.getLogger(TestController.class);
    //region Getter And Setter
    // endregion


    @ResponseBody
    @RequestMapping("/getstring")
    public Object getString() {

        logger.error("fweeeeeeettttttttttttttttttttttttt");

        return new Date();
    }


}

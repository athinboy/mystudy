package org.fgq.study.controller;


import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.ArrayList;
import java.util.List;

/**
 * @author fenggqc
 * @create 2018-10-24 15:35
 **/

@Controller()
@RequestMapping("/dp")
public class DataPaddingController {

    //region Getter And Setter
    // endregio

    @ResponseBody
    @RequestMapping("/test")
    public String HelloName() {



        return "";


    }


}

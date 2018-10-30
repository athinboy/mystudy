package org.fgq.study.controller;

import com.alibaba.fastjson.JSON;

import org.fgq.study.datapadding.DataPadding;
import org.fgq.study.datapadding.exception.DataPaddingException;
import org.fgq.study.datapadding.test.PaddingClient;
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
    // endregion

    @ResponseBody
    @RequestMapping("/test")
    public String HelloName() {



        return "";


    }


}

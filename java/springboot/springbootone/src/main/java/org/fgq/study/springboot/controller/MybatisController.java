package org.fgq.study.springboot.controller;

import org.fgq.study.springboot.service.BaRoomService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author fenggqc
 * @create 2018-12-29 9:51
 **/

@RestController()
@RequestMapping("/mybatis")
public class MybatisController {

    @Autowired
    BaRoomService baRoomService;


    @RequestMapping("/doone")
    public String doOne() {


        this.baRoomService.countAll();
        this.baRoomService.GetById(0L);

        return "hello mybatis!";
    }


    //region Getter And Setter
    // endregion
}

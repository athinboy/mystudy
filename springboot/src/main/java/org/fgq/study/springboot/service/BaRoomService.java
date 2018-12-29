package org.fgq.study.springboot.service;

import org.fgq.study.mbgmapper.domain.ba.BaRoom;

/**
 * @author fenggqc
 * @create 2018-12-29 9:43
 **/


public interface BaRoomService {


    Integer countAll();

    BaRoom GetById(Long id);



}

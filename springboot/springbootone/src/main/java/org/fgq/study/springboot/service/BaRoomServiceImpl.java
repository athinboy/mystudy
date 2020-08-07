package org.fgq.study.springboot.service;

import org.fgq.study.mbgmapper.domain.ba.BaRoom;
import org.fgq.study.mbgmapper.mapper.ba.BaRoomMapper;
import org.fgq.study.springboot.dao.BaRoomDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * @author fenggqc
 * @create 2018-12-29 9:44
 **/


@Service
public class BaRoomServiceImpl implements BaRoomService {

    //region Getter And Setter
    // endregion

    @Autowired
    BaRoomDao baRoomDao;

    @Autowired
    BaRoomMapper baRoomMapper;

    @Override
    public Integer countAll() {
        return this.baRoomDao.count();
    }

    @Override
    public BaRoom GetById(Long id) {
        return this.baRoomMapper.selectByPrimaryKey(id);
    }
}

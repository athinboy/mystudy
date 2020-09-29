package org.fgq.study.springboot.dao;

import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;

/**
 * @author fenggqc
 * @create 2018-12-29 9:42
 **/


public interface BaRoomDao {

    @Select("select count(*) from ba_room ")
    Integer count();


}

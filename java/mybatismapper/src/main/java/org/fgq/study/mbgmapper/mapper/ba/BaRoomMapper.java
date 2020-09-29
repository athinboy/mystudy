package org.fgq.study.mbgmapper.mapper.ba;

import java.util.List;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.session.RowBounds;
import org.fgq.study.mbgmapper.domain.ba.BaRoom;
import org.fgq.study.mbgmapper.domain.ba.BaRoomExample;

public interface BaRoomMapper {
    long countByExample(BaRoomExample example);

    int deleteByExample(BaRoomExample example);

    int deleteByPrimaryKey(Long id);

    int insert(BaRoom record);

    int insertSelective(BaRoom record);

    List<BaRoom> selectByExampleWithRowbounds(BaRoomExample example, RowBounds rowBounds);

    List<BaRoom> selectByExample(BaRoomExample example);

    BaRoom selectByPrimaryKey(Long id);

    int updateByExampleSelective(@Param("record") BaRoom record, @Param("example") BaRoomExample example);

    int updateByExample(@Param("record") BaRoom record, @Param("example") BaRoomExample example);

    int updateByPrimaryKeySelective(BaRoom record);

    int updateByPrimaryKey(BaRoom record);
}
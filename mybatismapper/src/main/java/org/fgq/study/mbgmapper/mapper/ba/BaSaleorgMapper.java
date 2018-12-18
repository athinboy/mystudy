package org.fgq.study.mbgmapper.mapper.ba;

import java.util.List;
import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.session.RowBounds;
import org.fgq.study.mbgmapper.domain.ba.BaSaleorg;
import org.fgq.study.mbgmapper.domain.ba.BaSaleorgExample;

public interface BaSaleorgMapper {
    long countByExample(BaSaleorgExample example);

    int deleteByExample(BaSaleorgExample example);

    int deleteByPrimaryKey(String saleorgId);

    int insert(BaSaleorg record);

    int insertSelective(BaSaleorg record);

    List<BaSaleorg> selectByExampleWithRowbounds(BaSaleorgExample example, RowBounds rowBounds);

    List<BaSaleorg> selectByExample(BaSaleorgExample example);

    BaSaleorg selectByPrimaryKey(String saleorgId);

    int updateByExampleSelective(@Param("record") BaSaleorg record, @Param("example") BaSaleorgExample example);

    int updateByExample(@Param("record") BaSaleorg record, @Param("example") BaSaleorgExample example);

    int updateByPrimaryKeySelective(BaSaleorg record);

    int updateByPrimaryKey(BaSaleorg record);
}
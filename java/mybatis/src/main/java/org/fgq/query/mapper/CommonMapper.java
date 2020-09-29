package org.fgq.query.mapper;

import org.apache.ibatis.annotations.Param;
import org.apache.ibatis.annotations.SelectProvider;
import org.fgq.query.sqlprovider.SelectProdiver;


import java.util.List;
import java.util.Map;

/**
 * Created by fenggqc on 2016/12/16.
 */

public interface CommonMapper<T> {



    @SelectProvider( type = SelectProdiver.class,method ="BuildSelect" )
    <T> List<Map<String, Object>> SelectByPrimaryKey(@Param("dto")T t);







}

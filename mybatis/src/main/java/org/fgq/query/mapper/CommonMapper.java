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


    @SelectProvider(type = SelectProdiver.class, method = "BuildSelect")
    <T> List<Map<String, Object>> SelectByPrimaryKey(@Param("dto") T t);

    <T> List<List<Map<String, Object>>> Select(@Param("dto") T t);

    <T> Long Count(@Param("dto") T t);

    <T> void UpdateByPrimary(@Param("dto") T t);

    <T> void Update(@Param("dto") T t);

    <T> void DeleteByPrimary(@Param("dto") T t);

    <T> void Delete(@Param("dto") T t);

    <T> void Insert(@Param("dto") T t);


}

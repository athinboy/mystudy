package org.fgq.query.sqlprovider.select;

/**
 * Created by fenggqc on 2016/12/23.
 */
public interface IBuildSelectSql {

    <T> String BuildSelect(T t);

}

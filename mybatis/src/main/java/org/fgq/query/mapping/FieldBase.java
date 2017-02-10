package org.fgq.query.mapping;

/**
 *
 * Created by fenggqc on 2017/1/20.
 */
public abstract class FieldBase {


    /**
     * jdbc type;
     */
    private org.apache.ibatis.type.JdbcType jdbcType;

    /**
     * the column name.
     */
    private String colName;




    //region Getter And Setter
    // endregion

}

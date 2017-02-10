package org.fgq.query.sqlprovider;

import org.fgq.query.annotation.MTDto;
import org.fgq.query.annotation.STDto;
import org.fgq.query.sqlprovider.select.IBuildSelectSql;
import org.fgq.query.sqlprovider.select.JoinSelectSqlBuilder;
import org.fgq.query.sqlprovider.select.SimplySelectSQLBuilder;

import java.lang.annotation.Annotation;

/**
 * Created by fenggqc on 2016/12/23.
 */
public class SelectProdiver {

    //region Getter And Setter
    // endregion




    public <T> String BuildSelect(T t) {
        Annotation[] annotations = t.getClass().getAnnotations();

        boolean simpletable=true;

        IBuildSelectSql iBuildSelectSql;
        if (true==simpletable){
            iBuildSelectSql=new SimplySelectSQLBuilder();
        }else
        {

            throw new Error("multi table join is not support yet!");
            //iBuildSelectSql=new JoinSelectSqlBuilder();
        }

        return  iBuildSelectSql.BuildSelect(t);
    }





}

package org.fgq.query.sqlprovider.select;

import org.fgq.query.mapping.DtoMetaReflect;

import java.lang.annotation.Annotation;

/**
 * Created by fenggqc on 2016/12/16.
 */
public class SimplySelectSQLBuilder implements IBuildSelectSql {


    public <T> String BuildSelect(T t) {
        Annotation[] annotations = t.getClass().getAnnotations();

       // DtoMetaReflect.Reflect(t.getClass());


        return "select  e.page_id as 'button_id',e.page_name as 'text_value' from test_db.ui_page e  limit 1";




    }
    ;



    //region Getter And Setter
    // endregion

}



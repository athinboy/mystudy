package fgq.mybatis_1;

import org.apache.ibatis.annotations.Options;
import org.apache.ibatis.annotations.Select;

/**
 * Created by fenggqc on 2016/7/1.
 */
public interface UI2Mapper {



    @Select(" select e.page_id as 'button_id',e.page_name as 'text_value'\n" +
            "        from test_db.ui_page e\n" +
            "        limit 1")
    @Options( useCache = false)
    UI2 SelectOne(String id);



}

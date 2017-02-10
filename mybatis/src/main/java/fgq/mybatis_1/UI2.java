package fgq.mybatis_1;

import org.fgq.query.annotation.*;


import java.lang.annotation.Retention;

/**
 * Created by fenggqc on 2016/7/1.
 */


@STDto(TableName ="ui_page")
public class UI2 {


    public String getButton_id() {
        return button_id;
    }

    public void setButton_id(String button_id) {
        this.button_id = button_id;
    }


    public String getText_value() {
        return text_value;
    }

    public void setText_value(String text_value) {
        this.text_value = text_value;
    }


    @FieldTableName(value = "text_value")
    private String text_value;

    @FieldTableName(value = "button_id")
    private String button_id;

}

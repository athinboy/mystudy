package net.fgq.study.pdf.annoation;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Document {

    private List<Content> contents = new ArrayList<>();

    private List<Table> tables = new ArrayList<>();

    public List<Content> getContents() {
        return contents;
    }

    public void setContents(List<Content> contents) {
        this.contents = contents;
    }

    public List<Table> getTables() {
        return tables;
    }

    public void setTables(List<Table> tables) {
        this.tables = tables;
    }
}

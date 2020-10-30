package net.fgq.study.pdf.annoation;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Document {

    private List<Content> contents = new ArrayList<>();

    private List<Table> tables = new ArrayList<>();

    protected String pageIndexSign = null;

    public String getPageIndexSign() {
        return pageIndexSign;
    }

    public void setPageIndexSign(String pageIndexSign) {
        this.pageIndexSign = pageIndexSign;
    }

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

    public void changePageIndex(int pageIndex) {
        for (Content content : this.contents) {
            content.setPageIndex(pageIndex);
        }
        for (Table table : this.tables) {
            table.setPageIndex(pageIndex);
        }
    }
}

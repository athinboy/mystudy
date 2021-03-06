package net.fgq.study.pdf.annoation;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Document {

    private List<Content> contents = new ArrayList<>();

    private List<TableGroup> tableGroups = new ArrayList<>();

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

    public List<TableGroup> getTableGroups() {
        return tableGroups;
    }

    public void setTableGroups(List<TableGroup> tableGroups) {
        this.tableGroups = tableGroups;
    }

    protected void changePageIndex(int startPageIndex, int endPageIndex) {

        for (Content content : this.contents) {
            content.setStartPageIndex(startPageIndex);
            content.setEndPageIndex(endPageIndex);
        }
        for (TableGroup tableGroup : this.tableGroups) {
            for (Table table : tableGroup.getTables()) {
                table.setPageIndex(startPageIndex);
            }

        }
    }

    public TableGroup addTableGroup(TableGroup tableGroup) {
        tableGroups.add(tableGroup);
        return tableGroup;
    }

    public TableGroup addTable(Table table) {
        if (tableGroups.size() == 0) {
            tableGroups.add(new TableGroup());
        }
        tableGroups.get(0).getTables().add(table);
        return tableGroups.get(0);
    }
}

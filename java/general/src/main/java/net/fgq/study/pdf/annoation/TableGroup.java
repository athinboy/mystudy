package net.fgq.study.pdf.annoation;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/30
 */
public class TableGroup {

    private List<Table> tables = new ArrayList<>();

    public List<Table> getTables() {
        return tables;
    }

    public void setTables(List<Table> tables) {
        this.tables = tables;
    }
}

package org.fgq.query.mapping;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * Created by fenggqc on 2016/12/27.
 */
public class DtoTypeInfo {

    private List<Table> tables=new ArrayList<Table>();





    /**
     * is one table mapper type ?
     */
    private  Boolean isSimpleTable=true;

    //region Getter And Setter

    public Boolean getIsSimpleTable() {
        return isSimpleTable;
    }

    public void setIsSimpleTable(Boolean isSimpleTable) {
        this.isSimpleTable = isSimpleTable;
    }

    public List<Table> getTables() {
        return tables;
    }

    public void setTables(List<Table> tables) {
        this.tables = tables;
    }


    // endregion

}

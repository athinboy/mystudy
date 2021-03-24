package net.fgq.study.pdf.annoation;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class InsOrderDocument extends Document {

    private int pageIndex;

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public InsOrderDocument(int pageIndex) {
        this.pageIndex = pageIndex;
    }
}

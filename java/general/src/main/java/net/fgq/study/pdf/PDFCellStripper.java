package net.fgq.study.pdf;

import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;

import java.util.List;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class PDFCellStripper {

    private PDFCustomerRender render;

    private PageLineStripper pageLineStripper;

    public PDFCellStripper(PDDocument document) {
        render = new PDFCustomerRender(document);


    }

    public List<Cell>  stripCell(int pageindex) throws Exception {
        render.renderImage(pageindex);
        pageLineStripper = render.getPageLineStripper();
        List<Line> lines = pageLineStripper.getLines();
        List<Cell> cells = CellStripper.stripper(lines);
        return cells;

    }

    public PageLineStripper getPageLineStripper() {
        return pageLineStripper;
    }

    public void setPageLineStripper(PageLineStripper pageLineStripper) {
        this.pageLineStripper = pageLineStripper;
    }
}

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

//        pdDocument = new PDDocument();
//        pdDocument.addPage(new PDPage());
//        pageLineStripper.pageContentStream = new PDPageContentStream(
//                pdDocument,
//                pdDocument.getPages().get(0),
//                PDPageContentStream.AppendMode.APPEND,
//                false);

    }

    public List<Cell>  stripCell(int pageindex) throws Exception {
        render.renderImage(pageindex);
        pageLineStripper = render.getPageLineStripper();
        List<Line> lines = pageLineStripper.getLines();
        List<Cell> cells = CellStripper.stripper(lines);
        return cells;

    }

}

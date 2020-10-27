package net.fgq.study.pdf;

import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.rendering.PDFRenderer;
import org.apache.pdfbox.rendering.PageDrawer;
import org.apache.pdfbox.rendering.PageDrawerParameters;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class PDFCustomerRender extends PDFRenderer {

    /**
     * Creates a new PDFRenderer.
     *
     * @param document the document to render
     */
    public PDFCustomerRender(PDDocument document) {
        super(document);
        rectangle = document.getPages().get(0).getCropBox();

    }

    @Override
    public BufferedImage renderImage(int pageIndex) throws IOException {
        if (pageLineStripper != null) {
            pageLineStripper.startPage();
        }
        return renderImage(pageIndex, 1);
    }

    @Override
    protected PageDrawer createPageDrawer(PageDrawerParameters parameters) throws IOException {

        pageLineStripper = new PageLineStripper(parameters);

        pdDocument = new PDDocument();
        pdDocument.addPage(new PDPage());
        pdDocument.getPages().get(0).setCropBox(rectangle);
        pageLineStripper.pageContentStream = new PDPageContentStream(
                pdDocument,
                pdDocument.getPages().get(0),
                PDPageContentStream.AppendMode.APPEND,
                false);
        return pageLineStripper;
    }

    //todo need to del
    private PDRectangle rectangle;

    private PageLineStripper pageLineStripper;

    public PageLineStripper getPageLineStripper() {
        return pageLineStripper;
    }

    public void setPageLineStripper(PageLineStripper pageLineStripper) {
        this.pageLineStripper = pageLineStripper;
    }

    //todo need to del
    private PDDocument pdDocument;

    //todo need to del
    public void save() throws IOException {

        pageLineStripper.getLines();
        pageLineStripper.pageContentStream.closeAndStroke();
        pageLineStripper.pageContentStream.close();
        pdDocument.save(new File("D:\\fgq\\temp\\ccc.pdf"));
        pdDocument.close();

    }
}

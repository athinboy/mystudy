package net.fgq.study.pdf;

import net.fgq.study.pdf.annoation.Document;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class PdfResult {

    private Document compulsoryDocument;

    private Document commercialDocument;





    public Document getCompulsoryDocument() {
        return compulsoryDocument;
    }

    public void setCompulsoryDocument(Document compulsoryDocument) {
        this.compulsoryDocument = compulsoryDocument;
    }

    public Document getCommercialDocument() {
        return commercialDocument;
    }

    public void setCommercialDocument(Document commercialDocument) {
        this.commercialDocument = commercialDocument;
    }
}

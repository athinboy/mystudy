package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;

import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class CompluseDocument extends InsOrderDocument {

    public CompluseDocument(int pageIndex) {
        super(pageIndex);
    }

    @Override
    public void parseContent(final List<PdfTextPosition> textPositions) {
        super.parseContent(textPositions);
    }
}

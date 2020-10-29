package net.fgq.study.pdf;

import org.apache.pdfbox.contentstream.operator.Operator;
import org.apache.pdfbox.cos.COSBase;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.text.PDFTextStripper;
import org.apache.pdfbox.text.TextPosition;

import java.io.IOException;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/24
 */
public class PDFTextPositionStripper extends PDFTextStripper {

    /**
     * 字符间距
     */
    private int charGapSpace = 1;

    public boolean ShouwSystemOut = false;

    /**
     * Instantiate a new PDFTextStripper object.
     *
     * @throws IOException If there is an error loading the properties.
     */
    public PDFTextPositionStripper() throws IOException {
        super();
    }

    public int getCharGapSpace() {
        return charGapSpace;
    }

    public void setCharGapSpace(int charGapSpace) {
        this.charGapSpace = charGapSpace;
    }

    private List<PdfTextPosition> textPositions = null;

    private int currentPageIndex;

    public List<PdfTextPosition> stripPosition(PDDocument document) throws IOException {

        textPositions = new ArrayList<>();
        setStartPage(getCurrentPageNo());
        setEndPage(getCurrentPageNo());

        for (int i = 0; i < document.getPages().getCount(); i++) {
            currentPageIndex = i;
            PDPage pdPage = document.getPages().get(i);
            if (pdPage.hasContents()) {

                lastStr = "";
                startX = 0;
                startY = 0;
                width = 0;
                height = 0;

                processPage(pdPage);
                if (lastStr.length() > 0) {
                    savePosition();
                }
            }

        }

        return textPositions;

    }

    private String lastStr = "";
    private float startX = 0;
    private float startY = 0;
    private float width = 0;
    private float height = 0;

    @Override
    protected void writePage() throws IOException {

        output = new StringWriter();
        super.writePage();

    }

    protected void processOperator(Operator operator, List<COSBase> operands) throws IOException {
        super.processOperator(operator, operands);

        if (1 == 0
                && (operator.getName().equals("l")
                || operator.getName().equals("m"))) {
            System.out.println(operator.getClass().getName() + ":" + operator.getName());
            for (int i = 0; i < operands.size(); i++) {
                System.out.println(operands.get(i).getCOSObject().getClass().getTypeName() + ":" + operands.get(i).toString());
            }
        }

    }

    /**
     * {@inheritDoc}
     */
    @Override
    protected void processTextPosition(TextPosition text) {

        super.processTextPosition(text);

        if (text.getY() == startY
                && text.getX() <= startX + width + this.charGapSpace
                && text.getX() + text.getWidth() > startX + width + this.charGapSpace) {
            lastStr = lastStr + text;

            width = text.getX() + text.getWidth() - startX;
            height = Math.max(height, getHeight(text));

        } else {
            if (lastStr.length() > 0) {
                savePosition();
            }
            lastStr = text.getUnicode();
            startX = text.getX();
            startY = text.getY();
            width = text.getWidth();
            height = getHeight(text);
        }

    }

    private float getHeight(TextPosition text) {
        if (text.getFontSize() > text.getWidth() * 1.5) {
            return (float) (text.getWidth() * 1.2);
        }
        return text.getFontSize();//text.getHeight()=text.getFontSize()/2;
    }

    private void savePosition() {

        PdfTextPosition position = new PdfTextPosition(currentPageIndex, lastStr,
                (new Double(Math.ceil(startX))).intValue(),
                (new Double(Math.ceil(startY))).intValue(),
                (new Double(Math.floor(width))).intValue(),
                (new Double(Math.floor(height))).intValue());
        this.textPositions.add(position);
        if (ShouwSystemOut) {
            System.out.println(position.toString());
        }
    }

    private String getPosition(TextPosition textPosition) {
        return "x:" + String.valueOf(textPosition.getX()) +
                "y:" + String.valueOf(textPosition.getY()) +
                "width:" + String.valueOf(textPosition.getWidth()) +
                "height:" + String.valueOf(textPosition.getHeight());
    }

}

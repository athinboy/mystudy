package net.fgq.study.pdf;

import org.apache.commons.lang3.StringUtils;
import org.apache.pdfbox.contentstream.operator.Operator;
import org.apache.pdfbox.contentstream.operator.OperatorName;
import org.apache.pdfbox.cos.COSArray;
import org.apache.pdfbox.cos.COSBase;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.font.PDFont;
import org.apache.pdfbox.pdmodel.font.PDType1Font;
import org.apache.pdfbox.pdmodel.graphics.state.PDGraphicsState;
import org.apache.pdfbox.pdmodel.graphics.state.PDTextState;
import org.apache.pdfbox.text.PDFTextStripper;
import org.apache.pdfbox.text.TextPosition;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringWriter;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/24
 */
public class PDFTextPositionStripper extends PDFTextStripper {

    /**
     * 字符间距
     */
    private float charGapSpace = 1;

    public boolean ShowSystemOut = false;

    Logger logger = LoggerFactory.getLogger(PDFTextPositionStripper.class);

    /**
     * Instantiate a new PDFTextStripper object.
     *
     * @throws IOException If there is an error loading the properties.
     */
    public PDFTextPositionStripper() throws IOException {
        super();
    }

    private List<PdfTextPosition> pdfTextPositions = null;

    private int currentPageIndex;

    public List<PdfTextPosition> stripPosition(PDDocument document) throws IOException {

        pdfTextPositions = new ArrayList<>();
        setStartPage(getCurrentPageNo());
        setEndPage(getCurrentPageNo());

        for (int i = 0; i < document.getPages().getCount(); i++) {
            currentPageIndex = i;
            PDPage pdPage = document.getPages().get(i);
            if (pdPage.hasContents()) {

                lastStr = "";
                textPositions = new ArrayList<>();
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

        return pdfTextPositions;

    }

    private String lastStr = "";
    private List<TextPositionEx> textPositions = new ArrayList<>();
    private float startX = 0;
    private float startY = 0;
    private float width = 0;
    private float height = 0;

    @Override
    protected void writePage() throws IOException {

        output = new StringWriter();
        super.writePage();

    }

    @Override
    public void showTextStrings(COSArray array) throws IOException {
        super.showTextStrings(array);
    }

    private String showTextContent = "";

    @Override
    public void showTextString(byte[] string) throws IOException {
        super.showTextString(string);
    }

    @Override
    protected void showText(byte[] string) throws IOException {

        showTextContent = "";
        PDGraphicsState state = getGraphicsState();
        PDTextState textState = state.getTextState();
        // get the current font
        PDFont font = textState.getFont();
        if (font == null) {
            System.out.println("No current font, will use default");
            font = PDType1Font.HELVETICA;
        }
        // read the stream until it is empty
        InputStream in = new ByteArrayInputStream(string);
        while (in.available() > 0) {

            // decode a character
            int before = in.available();
            int code = font.readCode(in);
            int codeLength = before - in.available();

            showTextContent += font.toUnicode(code);
        }
        if (showTextContent.equals("13.64")) {
            logger.debug("13.64");
        }
        super.showText(string);
        savePosition();

    }

    protected void processOperator(Operator operator, List<COSBase> operands) throws IOException {
        super.processOperator(operator, operands);

        if (1 == 0
                //org.apache.pdfbox.contentstream.operator.text.ShowText
                && operator.getName().equals(OperatorName.SHOW_TEXT)) {
            for (int i = 0; i < operands.size(); i++) {
                System.out.println(operands.get(i).getCOSObject().getClass().getTypeName()
                        + ":" + operands.get(i).toString());
            }
        }

    }

    protected void writeString(String text, List<TextPosition> textPositions) throws IOException {
        super.writeString(text, textPositions);
        //System.out.println("ffffffffff:" + text);
        if (ShowSystemOut) {
            System.out.println(text);
            for (TextPosition textPosition : textPositions) {
                if ("国".equals(textPosition.getUnicode()) || "国".equals(textPosition.getUnicode())) {
                    System.out.println(textPosition.getUnicode());
                }
            }
        }
    }

    @Override
    protected void writeLineSeparator() throws IOException {
        super.writeLineSeparator();
    }

    private float floatGap = 0.5F;//修正由于浮点变为整数造成的偏差

    /**
     * {@inheritDoc}
     */
    @Override
    protected void processTextPosition(TextPosition text) {
        super.processTextPosition(text);

        if (showTextContent.contains(text.getUnicode()) == false) {
            throw PdfException.getInstance("");
        }
        if (text.getUnicode().equals("2") || text.getUnicode().equals("浮")) {
            logger.debug(String.valueOf(text.getX()));
        }
        TextPositionEx tex = new TextPositionEx(currentPageIndex, text);

//        if (this.mergeTextPosition(tex)) {
//            return;
//        }
        if (textPositions.size() == 0 && StringUtils.isBlank(text.getUnicode())) {
            return;
        }

        boolean b = false;
        if (StringUtils.isBlank(text.getUnicode())
                && text.getX() - floatGap <= startX + width + this.charGapSpace
                && text.getX() + floatGap >= startX + width
                && text.getY() >= startY - height / 2
                && text.getY() < startY + height / 2) {
            b = true;
        }
        if (b || (text.getY() == startY
                && tex.getRectangle().getMiddleY() < startY + height
                && text.getX() - floatGap <= startX + width + this.charGapSpace
                && text.getX() + floatGap >= startX + width //不明白为啥存在这个条件，字母文字存在误判，所以注释掉 + this.charGapSpace
        )) {
            lastStr = lastStr + text.getUnicode();
            textPositions.add(tex);

            width = text.getX() + text.getWidth() - startX;
            height = Math.max(height, TextPositionExHelper.getHeight(text));

        } else {
            if (lastStr.length() > 0) {
                savePosition();
            }
            lastStr = text.getUnicode();
            textPositions = new ArrayList<>();
            textPositions.add(new TextPositionEx(currentPageIndex, text));
            startX = text.getX();
            startY = text.getY();
            width = text.getWidth();
            height = TextPositionExHelper.getHeight(text);
            this.charGapSpace = (Double.valueOf(text.getWidthOfSpace())).intValue();
        }

    }

    /**
     * 将TextPosition合并到现有的信息中。
     *
     * @param text
     * @return
     */
    private boolean mergeTextPosition(TextPositionEx text) {

        for (PdfTextPosition pdfTextPosition : pdfTextPositions) {
            if (pdfTextPosition.mergeHoriz(text)) {
                return true;
            }
        }
        return false;
    }

    private void savePosition() {
        if (textPositions.size() == 0) {
            return;
        }
        PdfTextPosition position = new PdfTextPosition(currentPageIndex, lastStr,
                (new Double(Math.ceil(startX))).intValue(),
                (new Double(Math.ceil(startY))).intValue(),
                (new Double(Math.floor(width))).intValue(),
                (new Double(Math.floor(height))).intValue());
        position.setTextPositions(textPositions);

        this.pdfTextPositions.add(position);
        textPositions = new ArrayList<>();
        lastStr = "";
        startX = 0;
        startY = 0;
        if (ShowSystemOut) {
            logger.debug(position.toString());
        }
    }

    private String getPosition(TextPosition textPosition) {
        return "x:" + String.valueOf(textPosition.getX()) +
                "y:" + String.valueOf(textPosition.getY()) +
                "width:" + String.valueOf(textPosition.getWidth()) +
                "height:" + String.valueOf(textPosition.getHeight());
    }

    /**
     * 获取按照位置排列的文字
     *
     * @param document
     * @return
     */
    public String getRangedText(PDDocument document) throws IOException {
        List<PdfTextPosition> pdfTextPositions = this.stripPosition(document);

        pdfTextPositions.sort(new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                int xc = new Integer(o1.getRectangle().x).compareTo(new Integer(o2.getRectangle().x));
                int yc = new Integer(o1.getRectangle().y).compareTo(new Integer(o2.getRectangle().y));
                if (yc == 0) {
                    if (xc == 0) {
                        return o1.getText().compareTo(o2.getText());
                    } else {
                        return xc;
                    }
                } else {
                    return yc;
                }
            }
        });
        StringBuilder resultText = new StringBuilder();
        for (int i = 0; i < pdfTextPositions.size(); i++) {
            resultText.append(pdfTextPositions.get(i).getText());
            if (i < pdfTextPositions.size() - 1) {
                if (false == TableParse.sameRow(2, pdfTextPositions.get(i), pdfTextPositions.get(i + 1))) {
                    resultText.append(System.lineSeparator());
                }
            }
        }

        return resultText.toString();
    }
}

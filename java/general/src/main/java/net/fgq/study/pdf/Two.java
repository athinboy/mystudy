package net.fgq.study.pdf;

import org.apache.commons.lang3.time.DateFormatUtils;
import org.apache.pdfbox.pdmodel.font.PDType0Font;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDFont;
import org.apache.pdfbox.text.PDFTextStripperByArea;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.File;
import java.awt.Rectangle;
import java.util.Date;
import java.util.List;

/**
 * Created by fengguoqiang 2020/8/28
 */
public class Two {

    public static void main(String[] args) throws Exception {
//        T0();
        //  saveImage();
        //showTextPosition();
        StripText();
    }

    private static void StripText() throws Exception {
        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));

        for (int i = 2; i < document.getPages().getCount() - 1; i++) {
            PDPage pdPage = document.getPages().get(i);
            Rectangle textRrect = new Rectangle(474, 126, 120, 20);
            String REGION_NAME = "text1";
            PDFTextStripperByArea textStripper = new PDFTextStripperByArea();
            textStripper.setSortByPosition(true);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            String textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

        }

    }

    private static void T0() throws Exception {
        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));

        PDFCellStripper pdfCellStripper = new PDFCellStripper(document);
        List<Cell> cells = pdfCellStripper.stripCell(0);

        //-------------------
        PDDocument newdoc = new PDDocument();
        newdoc.getPages().add(new PDPage());
        PDPageContentStream contentStream = new PDPageContentStream(newdoc, newdoc.getPage(0),
                PDPageContentStream.AppendMode.APPEND, false, true);

        for (Cell cell : cells) {
            Rectangle rectangle = cell.getRect();
            contentStream.addRect((float) rectangle.getX(),
                    (float) rectangle.getY(),
                    (float) rectangle.getWidth(),
                    (float) rectangle.getHeight());

        }
        contentStream.closeAndStroke();

        contentStream.close();
        String filename2 = "D:\\fgq\\temp\\" + DateFormatUtils.format(new Date(), "yyyyMMddhhmmss") + ".pdf";
        newdoc.save(filename2);
        //-------------------
        System.out.println("55555555555555555");
        if (cells.size() > 0) {
            return;
        }

        //-------------------

        for (Cell cell : cells) {

            PDPage pdPage = document.getPages().get(0);

            Rectangle textRrect = cell.getRect();
            String REGION_NAME = "text1";
            PDFTextStripperByArea textStripper = new PDFTextStripperByArea();
            textStripper.setSortByPosition(true);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            String textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(cell.toString() + ":" + textContent);

        }
        //-------------------
        System.out.println("55555555555555555");
        if (cells.size() > 0) {
            //return;
        }

        for (int i = 0; i < document.getPages().getCount(); i++) {
            PDPage pdPage = document.getPages().get(i);
            Rectangle textRrect = new Rectangle(80, 190, 50, 20);
            String REGION_NAME = "text1";
            PDFTextStripperByArea textStripper = new PDFTextStripperByArea();
            textStripper.setSortByPosition(true);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            String textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

            //--------------------------------------
            REGION_NAME = "text1";
            textRrect = new Rectangle(40, 190, 40, 20);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

            //--------------------------------------
            REGION_NAME = "text3";
            textRrect = new Rectangle(91, 650, 90, 16);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

        }

    }

    private static void saveImage() throws Exception {
        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));

        PDFCustomerRender renderer = new PDFCustomerRender(document);

        BufferedImage bufferedImage = renderer.renderImage(0);
        renderer.save();
        String filename2 = "D:\\fgq\\temp\\" + DateFormatUtils.format(new Date(), "yyyyMMddhhmmss") + ".jpg";
        File outputfile = new File(filename2);
        ImageIO.write(bufferedImage, "jpg", outputfile);

    }

    private static void T1() throws Exception {
        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));
        for (int i = 0; i < document.getPages().getCount(); i++) {
            PDPage pdPage = document.getPages().get(i);
            Rectangle textRrect = new Rectangle(80, 190, 50, 20);
            String REGION_NAME = "text1";
            PDFTextStripperByArea textStripper = new PDFTextStripperByArea();
            textStripper.setSortByPosition(true);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            String textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

            //--------------------------------------
            REGION_NAME = "text1";
            textRrect = new Rectangle(40, 190, 40, 20);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);

            //--------------------------------------
            REGION_NAME = "text3";
            textRrect = new Rectangle(91, 650, 90, 16);
            textStripper.addRegion(REGION_NAME, textRrect);
            textStripper.extractRegions(pdPage);
            textContent = textStripper.getTextForRegion(REGION_NAME);
            System.out.println(textContent);
        }

        PDFCustomerRender renderer = new PDFCustomerRender(document);
        BufferedImage bufferedImage = renderer.renderImage(0);
        renderer.save();
        File outputfile = new File("D:\\fgq\\temp\\000.jpg");
        ImageIO.write(bufferedImage, "jpg", outputfile);

    }

    private static void showTextPosition() throws Exception {
        //String filename = "D:\\fgq\\temp\\999.pdf";
        String filename = "D:\\fgq\\temp\\222.pdf";

        PDDocument document = PDDocument.load(new File(filename));

        PDFTextPositionStripper textPositionStripper = new PDFTextPositionStripper();
        textPositionStripper.setSortByPosition(true);
        textPositionStripper.setSortByPosition(true);
        textPositionStripper.stripPosition(document);
    }

    private static void T3() throws Exception {

        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));

        PDPage pdPage = document.getPages().get(0);
        document.setAllSecurityToBeRemoved(true);

        PDPageContentStream contentStream = new PDPageContentStream(document, pdPage,
                PDPageContentStream.AppendMode.APPEND, false, true);

        contentStream.setStrokingColor(66, 177, 230);

        contentStream.drawLine(5, 5, 10, 10);
//        contentStream.drawLine(100, 100, 200, 100);
        contentStream.drawLine(20, 20, 80, 80);

//
//        moveTo:x334.1  y:604.459
//        lineTo:x334.1  y:589.126

        contentStream.moveTo(55, 30);
        contentStream.beginText();
        PDFont font = PDType0Font.load(document, new File("D:\\fgq\\temp\\simkai.ttf"));
        contentStream.setFont(font, 12);
        contentStream.showText("test");
        contentStream.endText();
        contentStream.addRect(100, 100, 50, 20);
        contentStream.closeAndStroke();

        contentStream.close();
        String filename2 = "D:\\fgq\\temp\\999.pdf";
        document.save(filename2);

//        PDFLineRenderer renderer=new PDFLineRenderer(document);
//        renderer.renderImage(0);

    }

}

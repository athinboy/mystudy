package net.fgq.study.pdf.test;

import com.alibaba.fastjson.JSON;
import net.fgq.study.pdf.ContentParse;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfResult;
import net.fgq.study.pdf.PdfToJson;
import org.apache.pdfbox.pdmodel.PDDocument;

import java.io.File;
import java.util.Arrays;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Seven {

    public static void main(String[] args) throws Exception {

        File fileDirectory = new File("D:\\fgq\\temp\\新测试保单-3\\");
        File[] files = fileDirectory.listFiles();

        for (int i = 0; i < files.length; i++) {
            try {

                System.out.println(files[i].getName());
                PDDocument document = PDDocument.load(files[i]);

                PDFTextPositionStripper textPositionStripper = new PDFTextPositionStripper();
                textPositionStripper.setSortByPosition(true);
                textPositionStripper.setSortByPosition(true);
                textPositionStripper.ShowSystemOut = true;
                String positionText = textPositionStripper.getRangedText(document);

                System.out.println(positionText);

                PdfToJson pdfToJson = new PdfToJson();
                ContentParse.errsign = "";
                PdfResult pdfResult = pdfToJson.parse(document);
                System.out.println(JSON.toJSONString(pdfResult));
            } catch (Exception var4) {
                System.out.println(files[i].getAbsolutePath());
                var4.printStackTrace();

                PDDocument document = PDDocument.load(files[i]);

                PDFTextPositionStripper textPositionStripper = new PDFTextPositionStripper();
                textPositionStripper.setSortByPosition(true);
                textPositionStripper.setSortByPosition(true);
                textPositionStripper.ShowSystemOut = true;
                String positionText = textPositionStripper.getRangedText(document);

                System.out.println(positionText);

                PdfToJson pdfToJson = new PdfToJson();
                PdfResult pdfResult = pdfToJson.parse(document);
                System.out.println(JSON.toJSONString(pdfResult));

                return;

            }
        }
    }

}

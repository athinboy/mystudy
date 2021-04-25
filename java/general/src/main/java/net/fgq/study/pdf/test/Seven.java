package net.fgq.study.pdf.test;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.serializer.SerializerFeature;
import net.fgq.study.pdf.ContentParse;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfResult;
import net.fgq.study.pdf.PdfToJson;
import org.apache.pdfbox.pdmodel.PDDocument;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Seven {

    private static class R {

        public R(String fileName, PdfResult pdfResult) {
            this.fileName = fileName;
            this.pdfResult = pdfResult;
        }

        private String fileName;
        private PdfResult pdfResult;

        public String getFileName() {
            return fileName;
        }

        public void setFileName(String fileName) {
            this.fileName = fileName;
        }

        public PdfResult getPdfResult() {
            return pdfResult;
        }

        public void setPdfResult(PdfResult pdfResult) {
            this.pdfResult = pdfResult;
        }
    }

    public static void main(String[] args) throws Exception {
        File fileDirectory;
        fileDirectory = new File("D:\\fgq\\temp\\新测试保单-3\\");
        fileDirectory = new File("D:\\fgq\\temp\\新保单");
        File[] files = fileDirectory.listFiles();
        List<R> rs = new ArrayList<>();
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

                R r = new R(files[i].getAbsolutePath(), pdfResult);
                rs.add(r);

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
                try {
                    PdfResult pdfResult = pdfToJson.parse(document);
                    System.out.println(JSON.toJSONString(pdfResult));
                } catch (Exception ex) {
                    System.out.println(files[i].getAbsolutePath());
                }

                return;

            }

        }
        String content = JSON.toJSONString(rs, SerializerFeature.PrettyFormat);
        FileOutputStream fileOutputStream = new FileOutputStream(new File("c:\\1\\1.txt"));
        fileOutputStream.write(content.getBytes());
        fileOutputStream.close();

    }
}

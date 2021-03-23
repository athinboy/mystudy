package net.fgq.study.pdf.test;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfToJson;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.Document;
import org.apache.pdfbox.pdmodel.PDDocument;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.Arrays;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Five {

    public static void main(String[] args) throws Exception {

        String pdfUrl = "https://wintop-obs-001.obs.cn-north-1.myhuaweicloud.com/file%2Fdefaults%2Fapplication%2Foctet-stream%2F16160494846ed3ebaf1e2740c7bc0f99d32acf4cd04165.pdf";
        try {

            InputStream inputStream = null;
            URL url = new URL(pdfUrl);
            URLConnection con = url.openConnection();
            con.setConnectTimeout(3000);
            inputStream = con.getInputStream();
            PDDocument pdfDocument = PDDocument.load(inputStream);

            PDFTextPositionStripper textPositionStripper = new PDFTextPositionStripper();
            textPositionStripper.setSortByPosition(true);
            textPositionStripper.setSortByPosition(true);
            textPositionStripper.ShowSystemOut = true;
            String positionText = textPositionStripper.getRangedText(pdfDocument);

            System.out.println(positionText);

            Document parseDoc = new Document();
            parseDoc.getContents().add(new Content(0, "agentDate", "签单日期([:]|[：]){0,1}"));
            parseDoc.getContents().add(new Content(0, "insuredName", "被保险人").setRightSigns(Arrays.asList("行驶证车主")));
            parseDoc.getContents().add(new Content(0, "insuredContactAddress", "地址").setRightSigns(Arrays.asList("联系电话")));
            PdfToJson pdfToJson = new PdfToJson();
            JSONObject jsonObject = pdfToJson.parse(pdfDocument, parseDoc);

        } catch (IOException var4) {
            var4.printStackTrace();

        }

    }

}

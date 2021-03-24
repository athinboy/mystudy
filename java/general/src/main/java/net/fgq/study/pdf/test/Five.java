package net.fgq.study.pdf.test;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfToJson;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import net.fgq.study.pdf.annoation.Document;

import org.apache.pdfbox.pdmodel.PDDocument;
import net.fgq.study.pdf.annoation.special.content.*;

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
            Content content = new DateContent(0, "agentDate", "签单日期([:]|[：]){0,1}");
//            content.getValueRegstr().add(ContentValueTypeEnum.Date.getRegexStr());
//            parseDoc.getContents().add(content);
//
//            parseDoc.getContents().add(new EffectiveDateContent(1,"effectiveDate"));
//            parseDoc.getContents().add(new ExpireDateContent(1,"expireDate"));

            content = new MoneyContent(0, "insuranceFee", "保险费合计");
            parseDoc.getContents().add(content);

//            content = new Content(0, "insuredName", "被保险人").setRightSigns(Arrays.asList("行驶证车主"));
//            parseDoc.getContents().add(content);
//            content = new Content(0, "insuredContactAddress", "地址").setRightSigns(Arrays.asList("联系电话"));
//            parseDoc.getContents().add(content);
            PdfToJson pdfToJson = new PdfToJson();
            JSONObject jsonObject = pdfToJson.parse(pdfDocument, parseDoc);
            System.out.println(JSON.toJSONString(jsonObject));
        } catch (IOException var4) {
            var4.printStackTrace();

        }

    }

}

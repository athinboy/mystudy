package net.fgq.study.pdf.test;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.ContentParse;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfResult;
import net.fgq.study.pdf.PdfToJson;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import net.fgq.study.pdf.annoation.Document;

import net.fgq.study.pdf.annoation.InsOrderDocument;
import org.apache.pdfbox.pdmodel.PDDocument;
import net.fgq.study.pdf.annoation.special.content.*;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.Arrays;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Six {

    public static void main(String[] args) throws Exception {

        //String filepath = "C:\\Users\\fengguoqiang\\Desktop\\temp\\识别失败保单\\运通汇未识别保单\\新建文件夹\\LSYKDAAA5HK056512付裕.pdf";

//        String filepath = "D:\\fgq\\temp\\新测试保单-3\\太平洋交强+商业险-1.pdf";
       String filepath = "D:\\fgq\\temp\\新保单\\LSGXE8353MD153951 .1.pdf";

        //  String filepath = "D:\\fgq\\temp\\新测试保单-3\\于克兰2.pdf";
        try {

            PDDocument pdfDocument = PDDocument.load(new File(filepath));

            PDFTextPositionStripper textPositionStripper = new PDFTextPositionStripper();
            textPositionStripper.setSortByPosition(true);
            textPositionStripper.setSortByPosition(true);
            textPositionStripper.ShowSystemOut = true;
            String positionText = textPositionStripper.getRangedText(pdfDocument);

            System.out.println(positionText);

            PdfToJson pdfToJson = new PdfToJson();

            ContentParse.errsign="";
            InsOrderDocument.errorSign="";

            PdfResult pdfResult = pdfToJson.parse(pdfDocument);
            System.out.println(JSON.toJSONString(pdfResult));
        } catch (Exception var4) {
            var4.printStackTrace();

        }

    }

}

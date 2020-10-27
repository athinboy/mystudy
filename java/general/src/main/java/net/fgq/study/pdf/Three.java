package net.fgq.study.pdf;

import com.alibaba.fastjson.JSONObject;
import javafx.scene.text.TextAlignment;
import net.fgq.study.pdf.annoation.Column;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.Document;
import net.fgq.study.pdf.annoation.Table;
import org.apache.pdfbox.pdmodel.PDDocument;

import java.util.ArrayList;
import java.util.List;

import java.awt.*;
import java.io.File;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class Three {

    public static void main(String[] args) throws Exception {

        //String filename = "D:\\fgq\\temp\\999.pdf";
        String filename = "D:\\fgq\\temp\\222.pdf";
        PDDocument document = PDDocument.load(new File(filename));

        PdfToJson pdfToJson = new PdfToJson();

        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 412, 175, 87, 8));

        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 208));
        columnList.add(new Column("绝对免赔率", "绝对免赔率", 40));
        columnList.add(new Column("费率浮动", "费率浮动", 60));
        columnList.add(new Column("保险金额/责任限额", "责任限额", 68, TextAlignment.RIGHT));
        columnList.add(new Column("保险费", "保险费", 80, TextAlignment.RIGHT));

        Table table = new Table(0, new Rectangle(40, 294, 530, 8), "除法律法规另有约定外", columnList, "明细");

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(jsonObject.toJSONString());

    }
}

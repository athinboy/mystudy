package net.fgq.study.pdf;

import com.alibaba.fastjson.JSONObject;
import javafx.scene.text.TextAlignment;
import net.fgq.study.pdf.annoation.*;
import net.fgq.study.pdf.annoation.special.PingAnNewTable;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.text.PDFTextStripper;

import java.io.IOException;
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

        File fileDirectory = new File("D:\\fgq\\temp\\3\\");

        File[] files = fileDirectory.listFiles();
        for (int i = 0; i < files.length; i++) {
//            String filename = "D:\\fgq\\temp\\222.pdf";
            System.out.println(files[i].getName());
            PDDocument document = PDDocument.load(files[i]);

            String content;

            PDFTextStripper pts = new PDFTextStripper();
            pts.setSortByPosition(true);
            content = pts.getText(document);
            if (content.contains("中国平安") && content.contains("机动车商业保险保险单")) {
//                 parsePingAnNew(files[i], document);
            } else if (content.contains("中国平安") && content.contains("机动车综合商业保险保险单")) {
//                parsePingAnOld(files[i], document);
            } else if (content.contains("人寿") && content.contains("机动车辆商业保险单")) {
                //parseRenShouOld(files[i], document);
            } else if (content.contains("人寿") && content.contains("机动车商业保险保险单")) {
                //parseRenShouNew(files[i], document);
            } else if (content.contains("太平财产保险") && content.contains("机动车商业保")) {
                //parseTaiPing(files[i], document);
            } else if (content.contains("PICC") && content.contains("机动车商业保险保险单")) {
                //parseRenBao(files[i], document);
            } else if (content.contains("CPIC") && content.contains("神行车保机动车保险单")) {
                parseTaiPingYang(files[i], document);
            } else {
                System.out.println(content);
                throw new Exception("33333333333333");
            }

        }

    }

    /**
     * 太平洋
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseTaiPingYang(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(2, "保险单号", 474, 127, 120, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险别", "承保险别", 120));
        columnList.add(new Column("保险金额", "保险金额", 70));
        columnList.add(new Column("保险费", "保险费", 60));

        PingAnNewTable table = new PingAnNewTable(2, new Rectangle(38, 311, 310, 30), "保险期间：自", columnList, "明细");
        purseDoc.getTables().add(table);

        table = new PingAnNewTable(2, new Rectangle(344, 311, 310, 25), "保险期间：自", columnList, "明细");
        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 人保
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseRenBao(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 412, 175, 100, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 257 - 38));
        columnList.add(new Column("不计免赔", "不计免赔", 32));
        columnList.add(new Column("费率浮动", "费率浮动", 60, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("保险金额", "保险金额", 80, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("保险费", "保险费", 60, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));

        PingAnNewTable table = new PingAnNewTable(0, new Rectangle(38, 280, 537 + 30 - 38, 10), "除法律法规另有约定外", columnList, "明细");
        table.setCellLineSpace(0.5F);

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 太平
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseTaiPing(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 413, 205, 100, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 120));
        columnList.add(new Column("保险金额", "保险金额", 56, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("每次事故绝对免赔额", "每次事故绝对免赔额", 84, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("不计免赔率", "不计免赔率", 40, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("保险费", "保险费", 40, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));

        PingAnNewTable table = new PingAnNewTable(0, new Rectangle(88, 360, 521 + 30 - 88, 10), "保 险 费 合 计", columnList, "明细");
        table.setCellLineSpace(0.5F);

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 人寿新
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseRenShouNew(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 413, 133, 160, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 325 - 33));
        columnList.add(new Column("费率浮动", "费率浮动", 56));
        columnList.add(new Column("责任限额", "责任限额", 84, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("绝对免赔率", "绝对免赔率", 40));
        columnList.add(new Column("保险费", "保险费", 40, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));

        Table table = new Table(0, new Rectangle(33, 252, 535 + 30 - 33, 10), "除法律法规另有约定外，投保人拥有保险合同解除权", columnList, "明细");

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 人寿旧
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseRenShouOld(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 453, 155, 150, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 155));
        columnList.add(new Column("不计免赔率", "不计免赔率", 48));
        columnList.add(new Column("每次事故绝对免赔", "每次事故绝对免赔", 84));
        columnList.add(new Column("费率浮动", "费率浮动", 45));
        columnList.add(new Column("保险金额", "保险金额", 82, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        columnList.add(new Column("保险费", "保险费", 50, TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));

        Table table = new Table(0, new Rectangle(33, 329, 530, 10), "保险费合计(人民币大", columnList, "明细");

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 平安旧
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parsePingAnOld(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 450, 137, 150, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("承保险种", "承保险种", 155));
        columnList.add(new Column("保险金额", "保险金额", 66));
        columnList.add(new Column("保险费$", "保险费", 40));
        columnList.add(new Column("是否投保", "是否投保不计免赔", 45));
        columnList.add(new Column("保险费小计", "保险费小计", 80));

        Table table = new Table(0, new Rectangle(46, 278, 512, 20), "车损险每次事故绝对免赔", columnList, "明细");

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 平安新
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parsePingAnNew(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        Document purseDoc = new Document();
        purseDoc.getContents().add(new Content(0, "保险单号", 450, 137, 150, 8));
        List<Column> columnList = new ArrayList<>();
        columnList.add(new Column("投保险别", "投保险别", 206 - 48));
        columnList.add(new Column("保险金额", "保险金额", 348 - 206));
        columnList.add(new Column("保费小计", "保费小计", 430 - 348));
        columnList.add(new Column("绝对免赔率", "绝对免赔率", 45));
        columnList.add(new Column("保费合计", "保费合计", 490 - 430));

        PingAnNewTable table = new PingAnNewTable(0, new Rectangle(48, 278, 520, 20), "车损险每次事故绝对免赔额", columnList, "明细");

        purseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, purseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

}

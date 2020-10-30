package net.fgq.study.pdf;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.*;
import net.fgq.study.pdf.annoation.special.*;
import org.apache.commons.lang3.exception.ExceptionUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.text.PDFTextStripper;

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

        //        File fileDirectory = new File("D:\\fgq\\temp\\3\\");
   File fileDirectory = new File("D:\\fgq\\temp\\4\\");
        File[] files = fileDirectory.listFiles();
        for (int i = 0; i < files.length; i++) {

            String content = "";
            try {

//            String filename = "D:\\fgq\\temp\\222.pdf";
                System.out.println(files[i].getName());
                PDDocument document = PDDocument.load(files[i]);

                PDFTextStripper pts = new PDFTextStripper();
                pts.setSortByPosition(true);
                content = pts.getText(document);
                //System.out.println(content);
                if (content.contains("中国平安") && content.contains("机动车商业保险保险单")) {
                    parsePingAnNew(files[i], document);
                } else if (content.contains("中国平安") && content.contains("机动车综合商业保险保险单")) {
                    parsePingAnOld(files[i], document);
                } else if (content.contains("人寿") && content.contains("机动车辆商业保险单")) {
                    parseRenShouOld(files[i], document);
                } else if (content.contains("人寿") && content.contains("机动车商业保险保险单")) {
                    parseRenShouNew(files[i], document);
                } else if (content.contains("太平财产保险") && content.contains("机动车商业保")) {
                    parseTaiPing(files[i], document);
                } else if (content.contains("PICC") && content.contains("机动车商业保险保险单（电子保单）")) {
                    parseRenBaoOld(files[i], document);//人保旧
                } else if (content.contains("PICC") && content.contains("机动车商业保险保险单") && false == content.contains("机动车商业保险保险单（电子保单）")) {
                    parseRenBaoNew(files[i], document);//人保新
                } else if (content.contains("CPIC") && content.contains("神行车保机动车保险单") && false == content.contains("费率浮动")) {
                    parseTaiPingYangOld(files[i], document);
                } else if (content.contains("CPIC") && content.contains("费率浮动") && content.contains("神行车保机动车保险单")) {
                    parseTaiPingYangNew(files[i], document);
                } else {
                    //System.out.println(content);
                    //throw new Exception("33333333333333");
                }

            } catch (Exception ex) {

                System.out.println(files[i].getName());
                System.out.println(content);
                System.out.println(files[i].getName());
                System.out.println(ExceptionUtils.getStackTrace(ex));
                return;
            }
        }
    }

    private static void parseTaiPingYangNew(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        pdfToJson.setShowSystemOut(true);
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(2, "保险单号", 474, 127, 120, 8));
        parseDoc.setPageIndexSign("神行车保机动车保险单");

        TaiPingYangNewTable table = new TaiPingYangNewTable(2, new Rectangle(89, 260, 327 + 30 - 89, 30), "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额")).addSign("责任限额");
        table.addColumn(new Column("绝对", "免赔率")).addSign("免赔率");
        table.addColumn(new NumberColumn("保险费", "保险费", TextHorizontalAlignEnum.RIGHT));

        table = new TaiPingYangNewTable(2, new Rectangle(325 + 30, 260, 327 + 30 - 89, 30), "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种1", false));
        table.addColumn(new Column("保险金额", "保险金额1")).addSign("责任限额");
        table.addColumn(new Column("绝对", "免赔率1")).addSign("免赔率");
        table.addColumn(new NumberColumn("保险费", "保险费1", TextHorizontalAlignEnum.RIGHT));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");
    }

    /**
     * 太平洋-old
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseTaiPingYangOld(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        pdfToJson.setShowSystemOut(false);
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(2, "保险单号", 474, 127, 120, 8));
        parseDoc.setPageIndexSign("神行车保机动车保险单");

        TaiPingYangTable table = new TaiPingYangTable(2, new Rectangle(38, 311, 305, 30), "明细");
        parseDoc.getTables().add(table);

        table.addColumn(new Column("承保险别", "承保险别", false));
        table.addColumn(new Column("保险金额", "保险金额"));
        table.addColumn(new NumberColumn("保险费", "保险费", TextHorizontalAlignEnum.LEFT));

        table = new TaiPingYangTable(2, new Rectangle(343, 311, 305, 25), "明细");
        parseDoc.getTables().add(table);

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 人保新
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseRenBaoNew(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();

        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 412, 175, 87, 8));

        RenBaoNewTable table = new RenBaoNewTable(0, new Rectangle(39, 294, 530, 8), "除法律法规另有约定外", "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new Column("费率浮动", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("保险金额/责任限额", "责任限额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

    /**
     * 人保旧
     *
     * @param file
     * @param document
     * @throws Exception
     */
    private static void parseRenBaoOld(File file, PDDocument document) throws Exception {

        PdfToJson pdfToJson = new PdfToJson();
        pdfToJson.setShowSystemOut(false);
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 412, 175, 100, 8));

        RenBaoTable table = new RenBaoTable(0, new Rectangle(38, 280, 537 + 30 - 38, 10), "明细");
        table.setCellLineSpace(1);
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("不计免赔", "不计免赔"));
        table.addColumn(new Column("费率浮动", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
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
        pdfToJson.setShowSystemOut(true);
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 413, 205, 100, 8));

        TaiPingTable table = new TaiPingTable(0, new Rectangle(47, 345, 521 + 30 - 47, 10), "明细");
        parseDoc.getTables().add(table);
        //太平太平商业险.pdf
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("每次事故绝对免赔额", "绝对免赔额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("不计免赔率", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
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
        Document parseDoc = new Document();

        parseDoc.getContents().add(new Content(0, "保险单号", 413, 133, 160, 8));

        Table table = new Table(0, new Rectangle(33, 252, 535 + 30 - 33, 10), "除法律法规另有约定外，投保人拥有保险合同解除权", "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("费率浮动", "费率浮动"));
        table.addColumn(new Column("责任限额", "责任限额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new NumberColumn("保险费", "保险费"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
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
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 453, 155, 150, 8));

        Table table = new Table(0, new Rectangle(33, 329, 530, 10), "保险费合计(人民币大", "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("不计免赔率", "不计免赔率"));
        table.addColumn(new Column("每次事故绝对免赔", "每次事故绝对免赔"));
        table.addColumn(new Column("费率浮动", "费率浮动"));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
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
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 450, 137, 150, 8));

        Table table = new Table(0, new Rectangle(46, 278, 512, 20), "车损险每次事故绝对免赔", "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额"));
        table.addColumn(new Column("保险费$", "保险费"));
        table.addColumn(new Column("是否投保", "是否投保不计免赔"));
        table.addColumn(new NumberColumn("保险费小计", "保险费小计"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
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
        Document parseDoc = new Document();
        parseDoc.getContents().add(new Content(0, "保险单号", 450, 137, 150, 8));

        PingAnNewTable table = new PingAnNewTable(0, new Rectangle(48, 278, 520, 20), "明细");
        parseDoc.getTables().add(table);
        table.addColumn(new Column("投保险别", "投保险别", false));
        table.addColumn(new Column("保险金额", "保险金额"));
        table.addColumn(new Column("保费小计", "保费小计"));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new NumberColumn("保费合计", "保费合计"));

        JSONObject jsonObject = pdfToJson.parse(document, parseDoc);
        System.out.println("识别结果：");
        System.out.println(file.getName());
        System.out.println(jsonObject.toJSONString());

        System.out.println("");
        System.out.println("");
        System.out.println("");

    }

}

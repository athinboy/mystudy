package net.fgq.study.pdf.annoation;

import com.alibaba.fastjson.JSONObject;
import com.spire.pdf.PdfDocument;
import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PDFTextPositionStripper;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfToJson;
import net.fgq.study.pdf.annoation.special.table.*;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.text.PDFTextStripper;

import java.awt.*;
import java.io.File;
import java.io.IOException;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class CommecialDocument extends InsOrderDocument {

    public CommecialDocument(int pageIndex) {
        super(pageIndex);
        init();
    }

    private void init() {

        /**
         * 车损险每次事故绝对免赔额
         */
        this.orderItemInfos.add(new OrderItemInfo("deductible", false, "(车损险每次事故)?绝对免赔额[:：]?"));//

        /**
         * 保险费合计
         */
        this.orderItemInfos.add(new OrderItemInfo("insuranceFee", ContentValueTypeEnum.Money, "保险{0,1}费合计"));//BigDecimal

    }

    @Override
    protected void specialOrder(PDDocument pdfDocument) throws Exception {
        super.specialOrder(pdfDocument);
        switch (this.insCompanyType) {

            case taiping:
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(new String[]{"保费确认时间"});
                break;
            case pingan:
                this.getOrderItemInfo("insuredName").setKeySigns(ArrayUtils.addAll(
                        this.getOrderItemInfo("insuredName").getKeySigns(), "正式名称"));
                this.getOrderItemInfo("insuredName").setValueMultiLine(true);
                break;
            case tpyang:
                this.getOrderItemInfo("platNum").setRequire(false);

                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(ArrayUtils.addAll(
                        this.getOrderItemInfo("insuranceConfirmationTime").getKeySigns(), "[收保]费确认时间"));

                //this.getOrderItemInfo("insuredContactAddress").setKeySigns(new String[]{"被保险人地址"});

                break;
            case renshou:

                this.getCombineLabelSign().add("姓名/名称");

                OrderItemInfo o = this.getOrderItemInfo("platNum");
                o.setRequire(false);
                this.getOrderItemInfo("insuredName").setKeySigns(new String[]{"姓名/名称"});
                this.getOrderItemInfo("engineNumber").setValueMultiLine(true);
                this.getOrderItemInfo("vin").setRequire(false);

                //不可使用，人寿的 被保险人 只占用一行文字，无法提取右侧的三行文本
//                this.constructItemArea(this.addInfoArea("BBXR", "被保险人")
//                        , "insuredName"
//                        , "insuredPhone"
//                        , "insuredIDNumer"
//                        , "insuredSex"
//                        , "insuredBirthday"
//                        , "insuredEMail"
//                        , "insuredContactAddress");

                break;
            case renbao:
                this.getOrderItemInfo("insuredIDNumer").setRequire(false);
                this.getOrderItemInfo("insuredContactAddress").setRequire(false);
                this.getOrderItemInfo("insuredPhone").setRequire(false);
                this.getOrderItemInfo("insuranceConfirmationTime").setKeySigns(new String[]{"收费确认时间"});
                break;
        }
        specialItem(pdfDocument);
    }

    protected void specialItem(PDDocument document) throws Exception {

        String content = "";
        PDFTextStripper pts = new PDFTextStripper();
        pts.setSortByPosition(true);
        content = pts.getText(document);
        if (content.contains("中国平安") && content.contains("机动车商业保险保险单")) {
            parsePingAnNew(document);
        } else if (content.contains("中国平安") && content.contains("机动车综合商业保险保险单")) {
            parsePingAnOld(document);
        } else if (content.contains("人寿") && content.contains("机动车辆商业保险")) {
            parseRenShouOld(document);
        } else if (content.contains("人寿") && content.contains("机动车商业保险保险单")) {
            parseRenShouNew(document);
        } else if (content.contains("太平财产保险") && content.contains("机动车商业保")) {
            parseTaiPing(document);
        } else if (content.contains("PICC") && content.contains("机动车商业保险保险单（电子保单）")) {
            parseRenBaoOld(document);//人保旧
        } else if (content.contains("PICC") && content.contains("机动车商业保险保险单") && false == content.contains("机动车商业保险保险单（电子保单）")) {
            parseRenBaoNew(document);//人保新
        } else if (content.contains("CPIC") && content.contains("神行车保机动车保险单")) {
            parseTaiPingYang(document);
        } else {

            throw PdfException.getInstance("异常的保单商保明细推断");
        }

    }

    private void parseTaiPingYang(PDDocument document) throws Exception {

        TaiPingYangNewTable table = new TaiPingYangNewTable(2, null);
        addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额")).addSign("责任限额");
        table.addColumn(new Column("绝对", "免赔率")).addSign("免赔率");
        table.addColumn(new NumberColumn("保险费", "保险费", TextHorizontalAlignEnum.RIGHT));
        table.addColumn(new Column("承保险种", "承保险种1", false));
        table.addColumn(new Column("保险金额", "保险金额1")).addSign("责任限额");
        table.addColumn(new Column("绝对", "免赔率1")).addSign("免赔率");
        table.addColumn(new NumberColumn("保险费", "保险费1", TextHorizontalAlignEnum.RIGHT));

        ////////////////////////////////////////

        TableGroup tableGroup = this.addTableGroup(new TableGroup());
        TaiPingYangTable table2 = new TaiPingYangTable(2, null);
        tableGroup.getTables().add(table2);
        table2.addColumn(new Column("承保险别", "承保险别", false));
        table2.addColumn(new Column("保险金额", "保险金额").addSign("赔偿限额"));
        table2.addColumn(new NumberColumn("保险费", "保险费", TextHorizontalAlignEnum.LEFT));
        table2.addColumn(new Column("承保险别", "承保险别1", false));
        table2.addColumn(new Column("保险金额", "保险金额1").addSign("赔偿限额"));
        table2.addColumn(new NumberColumn("保险费", "保险费1", TextHorizontalAlignEnum.LEFT));

    }

    /**
     * 人保新
     *
     * @param document
     * @throws Exception
     */
    private void parseRenBaoNew(PDDocument document) throws Exception {

        RenBaoNewTable table = new RenBaoNewTable(0, new Rectangle(39, 294, 530, 8), "除法律法规另有约定外");
        this.addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new Column("费率浮动", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("保险金额/责任限额", "责任限额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

    }

    /**
     * 人保旧
     *
     * @param document
     * @throws Exception
     */
    private void parseRenBaoOld(PDDocument document) throws Exception {

        RenBaoTable table = new RenBaoTable(0, new Rectangle(38, 280, 537 + 30 - 38, 10));
        table.setCellLineSpace(1);
        this.addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("不计免赔", "不计免赔"));
        table.addColumn(new Column("费率浮动", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

    }

    /**
     * 太平
     *
     * @param document
     * @throws Exception
     */
    private void parseTaiPing(PDDocument document) throws Exception {

        TaiPingTable table = new TaiPingTable(0, null);
        this.addTableGroup(new TableGroup()).getTables().add(table);
        //太平太平商业险.pdf
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("每次事故绝对免赔额", "绝对免赔额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("不计免赔率", "不计免赔率", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));
        table.getFootSigns().add("除法律法规另有约定外，涉及本保险");
        table.getFootSigns().add("保 险 费 合 计");
        table.setLeftReferenceText("被保险人证件号码");
        table.setTopReferenceText("协商实际价值");

        TaiPingTable table2 = new TaiPingTable(0, null);
        this.addTableGroup(new TableGroup()).getTables().add(table2);
        //太平胡泊 sy.pdf
        table2.addColumn(new Column("承保险种", "承保险种", false));
        table2.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table2.addColumn(new Column("绝对免赔额", "绝对免赔额/率", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table2.addColumn(new Column("费率浮动", "费率浮动", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table2.addColumn(new NumberColumn("保险费", "保险费"));

        table2.getFootSigns().add("除法律法规另有约定外，涉及本保险");
        table.getFootSigns().add("保 险 费 合 计");
        table2.setLeftReferenceText("被保险人证件号码");
        table2.setTopReferenceText("核定载质量");

    }

    /**
     * 人寿新
     *
     * @param document
     * @throws Exception
     */
    private void parseRenShouNew(PDDocument document) throws Exception {

        Table table = new Table(0, new Rectangle(33, 252, 535 + 30 - 33, 10), "除法律法规另有约定外，投保人拥有保险合同解除权");
        addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("费率浮动", "费率浮动"));
        table.addColumn(new Column("责任限额", "责任限额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new NumberColumn("保险费", "保险费"));

    }

    /**
     * 人寿旧
     *
     * @param document
     * @throws Exception
     */
    private void parseRenShouOld(PDDocument document) throws Exception {

        Table table = new Table(0, new Rectangle(33, 329, 530, 10), "保险费合计\\S{0,}人民币大");
        addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("不计免赔率", "不计免赔率"));
        table.addColumn(new Column("每次事故绝对免赔", "每次事故绝对免赔"));
        table.addColumn(new Column("费率浮动", "费率浮动"));
        table.addColumn(new Column("保险金额", "保险金额", TextHorizontalAlignEnum.RIGHT, TextVerticalAlignEnum.TOP));
        table.addColumn(new NumberColumn("保险费", "保险费"));

    }

    /**
     * 平安旧
     *
     * @param document
     * @throws Exception
     */
    private void parsePingAnOld(PDDocument document) throws Exception {

        Table table = new Table(0, new Rectangle(46, 278, 512, 20), "车损险每次事故绝对免赔");
        this.addTable(table);
        table.addColumn(new Column("承保险种", "承保险种", false));
        table.addColumn(new Column("保险金额", "保险金额"));
        table.addColumn(new Column("保险费$", "保险费"));
        table.addColumn(new Column("是否投保", "是否投保不计免赔"));
        table.addColumn(new NumberColumn("保险费小计", "保险费小计"));

    }

    /**
     * 平安新
     *
     * @param document
     * @throws Exception
     */
    private void parsePingAnNew(PDDocument document) throws Exception {

        PingAnNewTable table = new PingAnNewTable(0, new Rectangle(48, 278, 520, 20));
        this.addTable(table);
        table.addColumn(new Column("投保险别", "投保险别", false));
        table.addColumn(new Column("保险金额", "保险金额"));
        table.addColumn(new Column("保费小计", "保费小计"));
        table.addColumn(new Column("绝对免赔率", "绝对免赔率"));
        table.addColumn(new NumberColumn("保费合计", "保费合计"));

    }

}

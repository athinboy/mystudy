package net.fgq.study.pdf.annoation;

import com.alibaba.fastjson.JSONObject;
import com.spire.pdf.PdfDocument;
import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.LexicHelper;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.special.content.*;
import org.apache.commons.lang3.NotImplementedException;
import org.apache.commons.lang3.StringUtils;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class InsOrderDocument extends Document {

    protected InsCompanyType insCompanyType;

    Logger logger = LoggerFactory.getLogger(InsOrderDocument.class);

    private int startPageIndex;
    private int endPageIndex;

    protected List<OrderItemInfo> orderItemInfos = new ArrayList<>();

    private List<InfoArea> infoAreas = new ArrayList<>();

    private List<InfoGroup> infoGroups = new ArrayList<>();

    public int getStartPageIndex() {
        return startPageIndex;
    }

    public void setStartPageIndex(int startPageIndex) {
        this.startPageIndex = startPageIndex;
    }

    public int getEndPageIndex() {
        return endPageIndex;
    }

    public void setEndPageIndex(int endPageIndex) {
        this.endPageIndex = endPageIndex;
    }

    public InsOrderDocument(int startPageIndex, int endPageIndex) {
        this.startPageIndex = startPageIndex;
        this.endPageIndex = endPageIndex;
        init();
    }

    public InsOrderDocument(int pageIndex) {
        this(pageIndex, pageIndex);
    }

    @Override
    protected void changePageIndex(int startPageIndex, int endPageIndex) {
        super.changePageIndex(startPageIndex, endPageIndex);
        this.setStartPageIndex(startPageIndex);
        this.setEndPageIndex(endPageIndex);
    }

    private void init() {
        OrderItemInfo newItem;
        this.orderItemInfos.add(newItem = new OrderItemInfo("policyNumber", "保险单号"));
        this.orderItemInfos.add(newItem = new OrderItemInfo("effectiveDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date
        this.orderItemInfos.add(newItem = new OrderItemInfo("expireDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date

        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredName", "^被保险人"));
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredPhone", "联系(电话|方式)"));
        //证件号
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredIDNumer",
                "(被保险人)?((身份证?)|(证件))号码((（组织机构代码）|(（团体客户代码）)))?"));
        newItem.getValueRegstr().add("\\d+");

        //性别
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredSex", false, "性别"));
        //出生日期
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredBirthday", false, "出生日期"));//string
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredEMail", false, "[Mm]ail"));
        //通讯地址
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuredContactAddress",
                "[^公司]?(通讯|被保险人){0,1}地址"));
        this.orderItemInfos.add(newItem = new OrderItemInfo("platNum", "号牌号码"));
        this.orderItemInfos.add(newItem = new OrderItemInfo("vin", "vin", "VIN", "车架号"));
        //发动机号
        this.orderItemInfos.add(newItem = new OrderItemInfo("engineNumber", "发动机号(码)?"));
        //初登日期
        this.orderItemInfos.add(newItem = new OrderItemInfo("initialRegistration", "初登日期", "(初次){0,1}登记日期"));//String
        //厂牌型号
        this.orderItemInfos.add(newItem = new OrderItemInfo("factoryPlateModel", "厂牌型号"));
        newItem.setValueMultiLine(true);

        //核定载质量
        this.orderItemInfos.add(newItem = new OrderItemInfo("approvedLoad", false, "(核定载质量)|(核定载客/载质量)"));
        //核定载客人数
        this.orderItemInfos.add(newItem = new OrderItemInfo("approvedPassengersCapacity", false, "核定载客"));//
        //使用性质
        this.orderItemInfos.add(newItem = new OrderItemInfo("useCharacter", "使用性质"));//
        //机动车种类
        this.orderItemInfos.add(newItem = new OrderItemInfo("vehicleType", "机动车种类"));//

//        //排量
//        this.orderItemInfos.add(newItem=new OrderItemInfo("displacement", "排量"));//
//        //功率
//        this.orderItemInfos.add(newItem=new OrderItemInfo("capacityFactor", "功率"));//

        /**
         * 银行流水号
         */
        this.orderItemInfos.add(newItem = new OrderItemInfo("bankSerialNumber", false, "(银行){0,1}流水号"));//

        /**
         * 收费确认时间
         */
        this.orderItemInfos.add(newItem = new OrderItemInfo("chargeConfirmationTime",
                ContentValueTypeEnum.DateTime, "[收保]费确认时间", "收付确认时间"));//Date
        newItem.setMuiltValue(true);

        /**
         * 投保确认时间
         */
        this.orderItemInfos.add(newItem = new OrderItemInfo("insuranceConfirmationTime", ContentValueTypeEnum.DateTime,
                "生成(有效)?保单时间", "(有效)?保单生成时间"));//Date
        newItem.setMuiltValue(true);

        /**
         * 经办人
         */
        this.orderItemInfos.add(newItem = new OrderItemInfo("agentName", "经办(人{0,1})"));//String

        /**
         * 出单日期
         */
        this.orderItemInfos.add(newItem = new OrderItemInfo("agentDate", ContentValueTypeEnum.Date,
                "[出签]单日期", "订立合同日期"));//Date
        newItem.setBackupItem("insuranceConfirmationTime");

        this.constructItemGroup(this.addInfoGroup("BBXJDC")
                , "useCharacter"
                , "vin"
                , "engineNumber"
                , "vehicleType"
                , "platNum"
        );

        this.constructItemGroup(this.addInfoGroup("insuaredPeople"),
                "insuredName"
                , "insuredPhone"
                , "insuredIDNumer"
                , "insuredContactAddress");
    }

    public List<OrderItemInfo> getOrderItemInfos() {
        return orderItemInfos;
    }

    public void setOrderItemInfos(List<OrderItemInfo> orderItemInfos) {
        this.orderItemInfos = orderItemInfos;
    }

    private void identityCompany(final List<PdfTextPosition> textPositions) {
        for (PdfTextPosition textPosition : textPositions) {
            if (textPosition.getTrimedText().contains("中国平安")) {
                this.insCompanyType = InsCompanyType.pingan;
                return;
            }
            if (textPosition.getTrimedText().contains("太平洋")) {
                this.insCompanyType = InsCompanyType.tpyang;
                return;
            }
            if (textPosition.getTrimedText().contains("中国人寿")) {
                this.insCompanyType = InsCompanyType.renshou;
                return;
            }
            if (textPosition.getTrimedText().contains("人保")) {
                this.insCompanyType = InsCompanyType.renbao;
                return;
            }
            if (textPosition.getTrimedText().contains("太平财产保险有限")) {
                this.insCompanyType = InsCompanyType.taiping;
                return;
            }

        }
        throw PdfException.getInstance("无法识别的保险公司类型");
    }

    public void parseContent(PDDocument pdfDocument, final List<PdfTextPosition> pdfTextPositions) {

        List<PdfTextPosition> textPositions = new ArrayList<>();
        identityCompany(pdfTextPositions);
        specialOrder();

        if (StringUtils.isNotBlank(this.getPageIndexSign())) {
            for (PdfTextPosition textPosition : textPositions) {
                if (textPosition.getText().contains(this.getPageIndexSign())) {
                    if (this instanceof CompluseDocument) {
                        this.changePageIndex(textPosition.getPageIndex(), textPosition.getPageIndex());
                    } else {
                        this.changePageIndex(textPosition.getPageIndex(), pdfDocument.getPages().getCount() - 1);
                    }

                    break;
                }
            }

        } else {
            if (this instanceof CommecialDocument) {
                this.changePageIndex(this.getStartPageIndex(), pdfDocument.getPages().getCount() - 1);
            }
        }

        for (PdfTextPosition pdfTextPosition : pdfTextPositions) {
            if (pdfTextPosition.getPageIndex() >= this.startPageIndex && pdfTextPosition.getPageIndex() <= this.endPageIndex) {
                textPositions.add(pdfTextPosition);
            }
        }

        preStructText(textPositions);
        List<PdfTextPosition> allCandidateTexts = new ArrayList<>();

        boolean succ = false;

        int priority = 0;
        while (priority <= 3) {
            priority++;
            for (OrderItemInfo orderItemInfo : orderItemInfos) {
                if (priority != orderItemInfo.getPriority()) continue;
                if (orderItemInfo.getJsonKey().equals("chargeConfirmationTime")) {
                    int i = 0;
                }
                orderItemInfo.getCandidateKeyTexts().clear();
                succ = false;

                if (orderItemInfo.getInfoArea() != null) {
                    List<PdfTextPosition> tempTexts = orderItemInfo.getInfoArea().getTextPosition().getGroupItems();
                    for (PdfTextPosition textPosition : tempTexts) {
                        Predicate<String> predicate = orderItemInfo.getSignPredicate();
                        if (predicate.test(textPosition.getTrimedText())) {

                            orderItemInfo.getCandidateKeyTexts().add(textPosition);
                            succ = true;
                            if (false == allCandidateTexts.contains(textPosition)) {
                                allCandidateTexts.add(textPosition);
                            }
                        }
                    }

                }
                if (succ == false) {
                    for (PdfTextPosition textPosition : textPositions) {
                        Predicate<String> predicate = orderItemInfo.getSignPredicate();
                        if (predicate.test(textPosition.getTrimedText())
                                && LexicHelper.checkLabel(textPosition)) {
                            orderItemInfo.getCandidateKeyTexts().add(textPosition);
                            if (false == allCandidateTexts.contains(textPosition)) {
                                allCandidateTexts.add(textPosition);
                            }
                        }
                    }
                }
                if (orderItemInfo.getCandidateKeyTexts().size() == 0 && orderItemInfo.isRequire()) {
                    throw PdfException.getInstance("查询信息失败：" + orderItemInfo.toString());
                }

            }
            for (PdfTextPosition allCandidateText : allCandidateTexts) {

                for (PdfTextPosition candidateText2 : allCandidateTexts) {
                    if (allCandidateText == candidateText2) {
                        continue;
                    }
                    if (allCandidateText.checkSameLine(candidateText2) || allCandidateText.checkSameLeft(candidateText2)) {
                        allCandidateText.setKeyPercent(allCandidateText.getKeyPercent() + 1);
                        candidateText2.setKeyPercent(candidateText2.getKeyPercent() + 1);
                    }
                }
            }

            for (OrderItemInfo orderItemInfo : orderItemInfos) {
                if (priority != orderItemInfo.getPriority()) continue;
                if (orderItemInfo.getJsonKey().equals("effectiveDate")) {
                    int i = 0;
                }
                List<PdfTextPosition> temps = orderItemInfo.getCandidateKeyTexts();
                if (temps.size() > 1 && temps.stream().anyMatch(x -> {
                    return x.getKeyPercent() > 0;
                })) {
                    for (int i = 0; i < temps.size(); i++) {
                        if (temps.get(i).getKeyPercent() == 0) {
                            logger.info("信息{}:不再作为{}:的候选标签信息", temps.get(i).toString(), orderItemInfo.toString());
                            temps.remove(i--);

                        }
                    }
                    if (temps.size() > 1) {
                        logger.info(" {}具有多个候选标签信息{}", orderItemInfo.toString(), temps.toString());
                    } else if (temps.size() == 0) {
                        throw PdfException.getInstance("删除候选项后，查询信息失败：" + orderItemInfo.toString());
                    }
                }
            }
            for (OrderItemInfo itemInfo1 : orderItemInfos) {
                if (priority != itemInfo1.getPriority()) continue;
                if (itemInfo1.getJsonKey().equals("effectiveDate")) {
                    int i = 0;
                }
                for (OrderItemInfo itemInfo2 : orderItemInfos) {
                    if (itemInfo2.getJsonKey().equals("effectiveDate")) {
                        int i = 0;
                    }
                    if (itemInfo1 == itemInfo2) {
                        continue;
                    }
                    if (itemInfo1.getCandidateKeyTexts().size() == 0 || itemInfo2.getCandidateKeyTexts().size() == 0) {
                        continue;
                    }

                    //

                    if ((false == itemInfo1.getMuiltValue())
                            && (false == itemInfo2.getMuiltValue())) {

                        if (itemInfo1.getCandidateKeyTexts().size() == 1
                                && itemInfo2.getCandidateKeyTexts().size() == 1
                                && itemInfo1.getCandidateKeyTexts().get(0) == itemInfo2.getCandidateKeyTexts().get(0)) {
                            if (itemInfo1.getPriority() > 3) {
                                throw PdfException.getInstance(String.format("相同的候选项：\r\n%s\r\n:%s\r\n:%s\r\n",
                                        itemInfo1.toString(),
                                        itemInfo2.toString(),
                                        itemInfo1.getCandidateKeyTexts().get(0)));
                            }
                        }

                    }
                }
                if (itemInfo1.getCandidateKeyTexts().size() == 1) {

                    PdfTextPosition pdfTextPosition = itemInfo1.getCandidateKeyTexts().get(0);

                    if (itemInfo1.getMuiltValue() == false) {
                        pdfTextPosition.getCandidateOrderItems().clear();   //我方一一对应
                    }
                    addContent(itemInfo1, itemInfo1.getCandidateKeyTexts());
                } else {
                    for (int i = 0; i < itemInfo1.getCandidateKeyTexts().size(); i++) {
                        PdfTextPosition pdfTextPosition = itemInfo1.getCandidateKeyTexts().get(i);
                        if (itemInfo1.getMuiltValue() == false
                                && pdfTextPosition.getCandidateOrderItems().size() == 1) {
                            //对方一一对应，我方解除候选
                            itemInfo1.getCandidateKeyTexts().remove(i--);
                            break;
                        }
                    }
                    if (itemInfo1.isRequire() && itemInfo1.getCandidateKeyTexts().size() != 1) {

                        if (itemInfo1.getPriority() > 3) {
                            //不再抛出异常，留给后续流程根据值进行判断处理
//                            throw PdfException.getInstance("必须项目但是未找到唯一："
//                                    + itemInfo1.toString()
//                                    + itemInfo1.getCandidateKeyTexts().toString());
                        } else {
                            itemInfo1.setPriority(itemInfo1.getPriority() + 1);
                        }
                    }
                    addContent(itemInfo1, itemInfo1.getCandidateKeyTexts());
                }
            }
        }

    }

    protected void specialOrder() {

    }

    /**
     * 预规整数据。
     *
     * @param textPositions
     */
    private void preStructText(List<PdfTextPosition> textPositions) {
        InsOrderStructor.struct(this, textPositions, this.insCompanyType);
    }

    private void addContent(OrderItemInfo orderItemInfo, List<PdfTextPosition> pdfTextPositions) {

        pdfTextPositions.forEach(x -> x.getCandidateOrderItems().add(orderItemInfo));

        Content content = null;
        switch (orderItemInfo.getJsonKey()) {
            case "effectiveDate":
                this.addContent(orderItemInfo, content = new EffectiveDateContent(this.startPageIndex, this.endPageIndex, "effectiveDate", orderItemInfo.getKeySigns()));
                break;
            case "expireDate":
                this.addContent(orderItemInfo, content = new ExpireDateContent(this.startPageIndex, this.endPageIndex, "expireDate", orderItemInfo.getKeySigns()));
                break;
            default:
                switch (orderItemInfo.getValueType()) {
                    case Date:
                        this.addContent(orderItemInfo, content = new DateContent(this.startPageIndex, this.endPageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                        break;
                    case Money:
                        this.addContent(orderItemInfo, content = new MoneyContent(this.startPageIndex, this.endPageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                        break;
                    case DateTime:
                        this.addContent(orderItemInfo, content = new DateTimeContent(this.startPageIndex, this.endPageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                        break;
                    case Text:
                        this.addContent(orderItemInfo, content = new Content(this.startPageIndex, this.endPageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                        break;
                }
        }
        if (content != null) {
            content.setValueMultiLine(orderItemInfo.getValueMultiLine());
            return;
        }

        throw new NotImplementedException("");
    }

    private Content addContent(OrderItemInfo orderItemInfo, Content content) {
        content.setOrderItem(orderItemInfo);
        this.getContents().add(content);
        return content;
    }

    public void validate(JSONObject jsonObject) {
        for (OrderItemInfo orderItemInfo : this.orderItemInfos) {
            orderItemInfo.validate(jsonObject);
        }
    }

    public List<InfoArea> getInfoAreas() {
        return infoAreas;
    }

    public void setInfoAreas(List<InfoArea> infoAreas) {
        this.infoAreas = infoAreas;
    }

    protected InfoArea addInfoArea(String key, String... sign) {
        InfoArea infoArea = new InfoArea(key);
        infoArea.getSigns().addAll(Arrays.asList(sign));
        infoAreas.add(infoArea);
        return infoArea;
    }

    protected InfoGroup addInfoGroup(String key) {
        InfoGroup infoGroup = new InfoGroup(key);
        infoGroups.add(infoGroup);
        return infoGroup;
    }

    protected void constructItemArea(InfoArea area, String... itemKeys) {
        for (OrderItemInfo orderItemInfo : this.getOrderItemInfos()) {
            for (int i = 0; i < itemKeys.length; i++) {
                if (itemKeys[i].equals(orderItemInfo.getJsonKey())) {
                    orderItemInfo.setInfoArea(area);
                }
            }
        }
    }

    protected void constructItemGroup(InfoGroup group, String... itemKeys) {
        for (OrderItemInfo orderItemInfo : this.getOrderItemInfos()) {
            for (int i = 0; i < itemKeys.length; i++) {
                if (itemKeys[i].equals(orderItemInfo.getJsonKey())) {
                    orderItemInfo.setInfoGroup(group);
                }
            }
        }
    }

    protected OrderItemInfo getOrderItemInfo(String jsonkey) {
        for (OrderItemInfo orderItemInfo : this.getOrderItemInfos()) {
            if (orderItemInfo.getJsonKey().equals(jsonkey)) {
                return orderItemInfo;
            }
        }
        return null;
    }

    public boolean checkPage(int pageIndex) {
        return this.startPageIndex <= pageIndex && this.endPageIndex >= pageIndex;
    }
}

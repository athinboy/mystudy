package net.fgq.study.pdf.annoation;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.special.content.*;
import org.apache.commons.lang3.NotImplementedException;
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
    private int pageIndex;

    protected List<OrderItemInfo> orderItemInfos = new ArrayList<>();
    /**
     * 信息组的标记，比如：车辆信息
     * -----------------
     * |车牌号码
     * 车辆信息   |核定载客
     * |使用性质
     * -------------------------
     */
    private List<InfoGroup> infoGroups = new ArrayList<>();

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public InsOrderDocument(int pageIndex) {
        this.pageIndex = pageIndex;
        init();
    }

    private void init() {

        this.orderItemInfos.add(new OrderItemInfo("policyNumber", "保险单号"));
        this.orderItemInfos.add(new OrderItemInfo("effectiveDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date
        this.orderItemInfos.add(new OrderItemInfo("expireDate", ContentValueTypeEnum.DateTime, true, true, "保险期间"));//Date

        this.orderItemInfos.add(new OrderItemInfo("insuredName", "^被保险人$"));
        this.orderItemInfos.add(new OrderItemInfo("insuredPhone", "联系(电话|方式)"));
        //证件号
        this.orderItemInfos.add(new OrderItemInfo("insuredIDNumer", "被保险人((身份证)|(证件))号码"));
        //性别
        this.orderItemInfos.add(new OrderItemInfo("insuredSex", false, "性别"));
        //出生日期
        this.orderItemInfos.add(new OrderItemInfo("insuredBirthday", false, "出生日期"));//string
        this.orderItemInfos.add(new OrderItemInfo("insuredEMail", false, "[Mm]ail"));
        //通讯地址
        this.orderItemInfos.add(new OrderItemInfo("insuredContactAddress", "(通讯|被保险人){0,1}地址"));
        this.orderItemInfos.add(new OrderItemInfo("platNum", "号牌号码"));
        this.orderItemInfos.add(new OrderItemInfo("vin", "vin", "VIN", "车架号"));
        //发动机号
        this.orderItemInfos.add(new OrderItemInfo("engineNumber", "发动机号"));
        //初登日期
        this.orderItemInfos.add(new OrderItemInfo("initialRegistration", "初登日期", "(初次){0,1}登记日期"));//String
        //厂牌型号
        this.orderItemInfos.add(new OrderItemInfo("factoryPlateModel", "厂牌型号"));
//        //核定载质量
//        this.orderItemInfos.add(new OrderItemInfo("approvedLoad",   "(核定载质量)|(核定载客/载质量)"));
//        //核定载客人数
//        this.orderItemInfos.add(new OrderItemInfo("approvedPassengersCapacity", "核定载客"));//
        //使用性质
        this.orderItemInfos.add(new OrderItemInfo("useCharacter", "使用性质"));//
        //机动车种类
        this.orderItemInfos.add(new OrderItemInfo("vehicleType", "机动车种类"));//

//        //排量
//        this.orderItemInfos.add(new OrderItemInfo("displacement", "排量"));//
//        //功率
//        this.orderItemInfos.add(new OrderItemInfo("capacityFactor", "功率"));//

        /**
         * 银行流水号
         */
        this.orderItemInfos.add(new OrderItemInfo("bankSerialNumber", false, "(银行){0,1}流水号"));//

        /**
         * 收费确认时间
         */
        this.orderItemInfos.add(new OrderItemInfo("chargeConfirmationTime", ContentValueTypeEnum.DateTime, "[收保]费确认时间"));//Date

        /**
         * 投保确认时间
         */
        this.orderItemInfos.add(new OrderItemInfo("insuranceConfirmationTime", ContentValueTypeEnum.DateTime, "生成(有效){0,1}保单时间", "有效保单生成时间"));//Date

        /**
         * 经办人
         */
        this.orderItemInfos.add(new OrderItemInfo("agentName", "经办(人{0,1})"));//String

        /**
         * 出单日期
         */
        this.orderItemInfos.add(new OrderItemInfo("agentDate", ContentValueTypeEnum.Date, "[出签]单日期"));//Date

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

        }
        throw PdfException.getInstance("无法识别的保险公司类型");
    }

    public void parseContent(final List<PdfTextPosition> pdfTextPositions) {

        List<PdfTextPosition> textPositions = new ArrayList<>();
        identityCompany(pdfTextPositions);
        for (PdfTextPosition pdfTextPosition : pdfTextPositions) {
            if (pdfTextPosition.getPageIndex() == this.pageIndex) {
                textPositions.add(pdfTextPosition);
            }
        }

        preStructText(textPositions);
        List<PdfTextPosition> allCandidateTexts = new ArrayList<>();

        boolean succ = false;
        for (OrderItemInfo orderItemInfo : orderItemInfos) {
            if (orderItemInfo.getJsonKey().equals("effectiveDate")) {
                int i = 0;
            }
            succ = false;

            if (orderItemInfo.getInfoGroup() != null) {
                List<PdfTextPosition> tempTexts = orderItemInfo.getInfoGroup().getTextPosition().getGroupItems();
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
                    if (predicate.test(textPosition.getTrimedText())) {
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
            List<PdfTextPosition> temps = orderItemInfo.getCandidateKeyTexts();
            if (temps.size() > 1) {
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
        for (OrderItemInfo orderItemInfo : orderItemInfos) {

            for (OrderItemInfo itemInfo : orderItemInfos) {
                if (orderItemInfo == itemInfo) {
                    continue;
                }
                if (orderItemInfo.getCandidateKeyTexts().size() == 0 || itemInfo.getCandidateKeyTexts().size() == 0) {
                    continue;
                }

                //
                if ((false == orderItemInfo.getMuiltValue())
                        && (false == itemInfo.getMuiltValue())
                        && orderItemInfo.getCandidateKeyTexts().get(0) == itemInfo.getCandidateKeyTexts().get(0)) {
                    throw PdfException.getInstance(String.format("相同的候选项：\r\n%s\r\n:%s\r\n:%s\r\n",
                            orderItemInfo.toString(),
                            itemInfo.toString(),
                            orderItemInfo.getCandidateKeyTexts().get(0)));
                }
            }

            if (orderItemInfo.getJsonKey().equals("insuredName")) {
                int i = 0;
            }
            if (orderItemInfo.getCandidateKeyTexts().size() == 1) {

                PdfTextPosition pdfTextPosition = orderItemInfo.getCandidateKeyTexts().get(0);

                if (orderItemInfo.getMuiltValue() == false) {
                    pdfTextPosition.getCandidateOrderItems().clear();   //我方一一对应
                }
                addContent(orderItemInfo, orderItemInfo.getCandidateKeyTexts());
            } else {
                for (int i = 0; i < orderItemInfo.getCandidateKeyTexts().size(); i++) {
                    PdfTextPosition pdfTextPosition = orderItemInfo.getCandidateKeyTexts().get(i);
                    if (pdfTextPosition.getCandidateOrderItems().size() == 1) {
                        //对方一一对应，我方解除候选
                        orderItemInfo.getCandidateKeyTexts().remove(i--);
                        break;
                    }
                }
                addContent(orderItemInfo, orderItemInfo.getCandidateKeyTexts());
            }
        }

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

        switch (orderItemInfo.getJsonKey()) {
            case "effectiveDate":
                this.addContent(orderItemInfo, new EffectiveDateContent(this.pageIndex, "effectiveDate", orderItemInfo.getKeySigns()));
                return;
            case "expireDate":
                this.addContent(orderItemInfo, new ExpireDateContent(this.pageIndex, "expireDate", orderItemInfo.getKeySigns()));
                return;
        }

        switch (orderItemInfo.getValueType()) {
            case Date:
                this.addContent(orderItemInfo, new DateContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case Money:
                this.addContent(orderItemInfo, new MoneyContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case DateTime:
                this.addContent(orderItemInfo, new DateTimeContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case Text:
                this.addContent(orderItemInfo, new Content(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
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

    public List<InfoGroup> getInfoGroups() {
        return infoGroups;
    }

    public void setInfoGroups(List<InfoGroup> infoGroups) {
        this.infoGroups = infoGroups;
    }

    protected InfoGroup addInfoGroup(String key, String... sign) {
        InfoGroup infoGroup = new InfoGroup(key);
        infoGroup.getSigns().addAll(Arrays.asList(sign));
        infoGroups.add(infoGroup);
        return infoGroup;
    }

    protected void setItemGroup(InfoGroup group, String... itemKeys) {
        for (OrderItemInfo orderItemInfo : this.getOrderItemInfos()) {
            for (int i = 0; i < itemKeys.length; i++) {
                if (itemKeys[i].equals(orderItemInfo.getJsonKey())) {
                    orderItemInfo.setInfoGroup(group);
                }
            }
        }
    }
}

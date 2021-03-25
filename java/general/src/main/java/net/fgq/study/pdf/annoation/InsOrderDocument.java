package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.Item.OrderItemInfo;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.special.content.*;
import org.apache.commons.lang3.NotImplementedException;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Predicate;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class InsOrderDocument extends Document {

    Logger logger = LoggerFactory.getLogger(InsOrderDocument.class);
    private int pageIndex;

    protected List<OrderItemInfo> orderItemInfos = new ArrayList<>();

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public InsOrderDocument(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public List<OrderItemInfo> getOrderItemInfos() {
        return orderItemInfos;
    }

    public void setOrderItemInfos(List<OrderItemInfo> orderItemInfos) {
        this.orderItemInfos = orderItemInfos;
    }

    public void parseContent(final List<PdfTextPosition> textPositions) {

        List<PdfTextPosition> allCandidateTexts = new ArrayList<>();

        for (OrderItemInfo orderItemInfo : orderItemInfos) {
            for (PdfTextPosition textPosition : textPositions) {
                if (textPosition.getPageIndex() != this.pageIndex) {
                    continue;
                }
                Predicate<String> predicate = orderItemInfo.getSignPredicate();
                if (predicate.test(textPosition.getTrimedText())) {
                    orderItemInfo.getCandidateKeyTexts().add(textPosition);
                    if (false == allCandidateTexts.contains(textPosition)) {
                        allCandidateTexts.add(textPosition);
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
                    throw PdfException.getInstance(String.format("相同的候选项：%s:%s:%s",
                            orderItemInfo.toString(),
                            itemInfo.toString(),
                            orderItemInfo.getCandidateKeyTexts().get(0)));
                }
            }
            if(orderItemInfo.getCandidateKeyTexts().size()>0) {
                addContent(orderItemInfo, orderItemInfo.getCandidateKeyTexts().get(0));
            }
        }

    }

    private void addContent(OrderItemInfo orderItemInfo, PdfTextPosition pdfTextPosition) {

        switch (orderItemInfo.getJsonKey()) {
            case "effectiveDate":
                this.getContents().add(new EffectiveDateContent(this.pageIndex, "effectiveDate", orderItemInfo.getKeySigns()));
                return;
            case "expireDate":
                this.getContents().add(new ExpireDateContent(this.pageIndex, "expireDate", orderItemInfo.getKeySigns()));
                return;
        }

        switch (orderItemInfo.getValueType()) {
            case Date:
                this.getContents().add(new DateContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case Money:
                this.getContents().add(new MoneyContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case DateTime:
                this.getContents().add(new DateTimeContent(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
            case Text:
                this.getContents().add(new Content(this.pageIndex, orderItemInfo.getJsonKey(), orderItemInfo.getKeySigns()));
                return;
        }

        throw new NotImplementedException("");
    }

}

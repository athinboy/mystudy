package net.fgq.study.pdf;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.Document;
import net.fgq.study.pdf.bean.CommercialInsurance;
import net.fgq.study.pdf.bean.CompulsoryInsurance;
import org.apache.commons.lang3.StringUtils;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class PdfResult {

    private JSONObject compulsoryDocument;

    private JSONObject commercialDocument;

    private CommercialInsurance commercialInsurance;

    private CompulsoryInsurance compulsoryInsurance;

    public JSONObject getCompulsoryDocument() {
        return compulsoryDocument;
    }

    public void setCompulsoryDocument(JSONObject compulsoryDocument) {
        this.compulsoryDocument = compulsoryDocument;
        this.compulsoryInsurance = JSON.toJavaObject(compulsoryDocument, CompulsoryInsurance.class);
    }

    public JSONObject getCommercialDocument() {
        return commercialDocument;
    }

    public void setCommercialDocument(JSONObject commercialDocument) {
        this.commercialDocument = commercialDocument;
        this.commercialInsurance = JSON.toJavaObject(commercialDocument, CommercialInsurance.class);
    }

    public void validate() {

        if (commercialDocument != null && compulsoryDocument != null) {

            if (false == StringUtils.equals(compulsoryDocument.getString("insuredName"), commercialDocument.getString("insuredName"))) {
                throw PdfException.getInstance("insuredName");
            }
            if (false == StringUtils.equals(compulsoryDocument.getString("platNum"), commercialDocument.getString("platNum"))) {
                throw PdfException.getInstance("platNum");
            }
            if (false == StringUtils.equals(compulsoryDocument.getString("vin"), commercialDocument.getString("vin"))) {
                throw PdfException.getInstance("vin");
            }

        }

    }
}

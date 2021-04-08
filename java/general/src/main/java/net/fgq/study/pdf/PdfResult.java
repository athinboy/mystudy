package net.fgq.study.pdf;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.Document;

/**
 * Created by fengguoqiang 2021/3/24
 */
public class PdfResult {

    private JSONObject compulsoryDocument;

    private JSONObject commercialDocument;

    public JSONObject getCompulsoryDocument() {
        return compulsoryDocument;
    }

    public void setCompulsoryDocument(JSONObject compulsoryDocument) {
        this.compulsoryDocument = compulsoryDocument;
    }

    public JSONObject getCommercialDocument() {
        return commercialDocument;
    }

    public void setCommercialDocument(JSONObject commercialDocument) {
        this.commercialDocument = commercialDocument;
    }
}

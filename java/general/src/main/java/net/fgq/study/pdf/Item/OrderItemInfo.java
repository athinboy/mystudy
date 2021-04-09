package net.fgq.study.pdf.Item;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import net.fgq.study.pdf.annoation.InfoGroup;
import org.apache.commons.lang3.StringUtils;

import java.nio.channels.MulticastChannel;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.function.Predicate;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/19
 */
public class OrderItemInfo {

    private String jsonKey;
    private ContentValueTypeEnum valueType;
    private String[] keySigns;
    private boolean require;
    private InfoGroup infoGroup;
    /**
     * 多个值包含在同一个文本中比如保险期间。
     */
    private boolean muiltValue = true;

    private List<PdfTextPosition> candidateKeyTexts = new ArrayList<>();

    public OrderItemInfo(String jsonKey, ContentValueTypeEnum valueType, boolean muiltValue, boolean require, String... keySigns) {
        if (StringUtils.isBlank(jsonKey) || keySigns == null || keySigns.length == 0) {
            throw PdfException.getInstance("参数错误");
        }
        for (int i = 0; i < keySigns.length; i++) {
            if (StringUtils.isBlank(keySigns[i])) {
                throw PdfException.getInstance("参数错误");
            }
        }
        this.jsonKey = jsonKey;
        this.keySigns = keySigns;
        this.require = require;
        this.valueType = valueType;
        this.muiltValue = muiltValue;
    }

    public OrderItemInfo(String jsonKey, ContentValueTypeEnum valueType, boolean require, String... keySigns) {
        this(jsonKey, valueType, true, require, keySigns);
    }

    public OrderItemInfo(String jsonKey, boolean muiltValue, boolean require, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, require, keySigns);
    }

    public OrderItemInfo(String jsonKey, boolean require, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, require, keySigns);
    }

    public OrderItemInfo(String jsonKey, ContentValueTypeEnum valueType, String... keySigns) {
        this(jsonKey, valueType, true, keySigns);
    }

    public OrderItemInfo(String jsonKey, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, true, keySigns);
    }

    private Predicate<String> signPredicate = null;

    public Predicate<String> getSignPredicate() {
        if (signPredicate == null) {
            String singstr = "(" + String.join(")|(", this.keySigns) + ")";
            signPredicate = Pattern.compile(singstr).asPredicate();
        }
        return signPredicate;

    }

    public String getJsonKey() {
        return jsonKey;
    }

    public void setJsonKey(String jsonKey) {
        this.jsonKey = jsonKey;
    }

    public ContentValueTypeEnum getValueType() {
        return valueType;
    }

    public void setValueType(ContentValueTypeEnum valueType) {
        this.valueType = valueType;
    }

    public String[] getKeySigns() {
        return keySigns;
    }

    public void setKeySigns(String[] keySigns) {
        this.keySigns = keySigns;
    }

    public boolean isRequire() {
        return require;
    }

    public void setRequire(boolean require) {
        this.require = require;
    }

    public List<PdfTextPosition> getCandidateKeyTexts() {
        return candidateKeyTexts;
    }

    public void setCandidateKeyTexts(List<PdfTextPosition> candidateKeyTexts) {
        this.candidateKeyTexts = candidateKeyTexts;
    }

    @Override
    public String toString() {
        return "OrderItemInfo{" +
                "jsonKey='" + jsonKey + '\'' +
                ", keySigns=" + Arrays.toString(keySigns) +
                '}';
    }

    public boolean getMuiltValue() {
        return muiltValue;
    }

    public void setMuiltValue(boolean muiltValue) {
        this.muiltValue = muiltValue;
    }

    public void validate(JSONObject jsonObject) {
        if (this.isRequire()) {
            Object o = jsonObject.get(this.jsonKey);
            if (null == o || StringUtils.isBlank(o.toString())) {
                throw PdfException.getInstance("未提取：" + this.jsonKey);
            }
        }

        return;
    }

    public InfoGroup getInfoGroup() {
        return infoGroup;
    }

    public void setInfoGroup(InfoGroup infoGroup) {
        this.infoGroup = infoGroup;
    }

    public boolean isMuiltValue() {
        return muiltValue;
    }
}

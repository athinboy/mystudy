package net.fgq.study.pdf.Item;

import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.PdfException;
import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.annoation.ContentValueTypeEnum;
import net.fgq.study.pdf.annoation.InfoArea;
import net.fgq.study.pdf.annoation.InfoGroup;
import org.apache.commons.lang3.StringUtils;

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
    private InfoArea infoArea;
    private InfoGroup infoGroup;
    /**
     * 垂直顺序
     */
    private int verticalSort = -1;
    /**
     * 值正则模式
     */
    private List<String> valueRegstr = new ArrayList<>();
    /**
     * 后补字段，比如签单日期，如果无法解析，则可以从其他字段取值。
     */
    private String backupItem;
    /**
     * 多个值包含在同一个文本中比如保险期间。
     */
    private boolean muiltValue = false;

    private List<PdfTextPosition> candidateKeyTexts = new ArrayList<>();
    private boolean valueMultiLine;
    private int priority = 1;

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
        this(jsonKey, valueType, false, require, keySigns);
    }

    public OrderItemInfo(String jsonKey, boolean muiltValue, boolean require, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, require, keySigns);
    }

    public OrderItemInfo(String jsonKey, boolean require, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, require, keySigns);
    }

    public OrderItemInfo(int verticalSort, String jsonKey, boolean require, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, require, keySigns);
        this.verticalSort = verticalSort;
    }

    public OrderItemInfo(String jsonKey, ContentValueTypeEnum valueType, String... keySigns) {
        this(jsonKey, valueType, true, keySigns);
    }

    public OrderItemInfo(String jsonKey, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, true, keySigns);
    }

    public OrderItemInfo(int verticalSort, String jsonKey, String... keySigns) {
        this(jsonKey, ContentValueTypeEnum.Text, true, keySigns);
        this.verticalSort = verticalSort;
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

    public InfoArea getInfoArea() {
        return infoArea;
    }

    public void setInfoArea(InfoArea infoArea) {
        this.infoArea = infoArea;
    }

    public boolean isMuiltValue() {
        return muiltValue;
    }

    public InfoGroup getInfoGroup() {
        return infoGroup;
    }

    public void setInfoGroup(InfoGroup infoGroup) {
        this.infoGroup = infoGroup;
    }

    public String getBackupItem() {
        return backupItem;
    }

    public void setBackupItem(String backupItem) {
        this.backupItem = backupItem;
    }

    public List<String> getValueRegstr() {
        return valueRegstr;
    }

    public void setValueRegstr(List<String> valueRegstr) {
        this.valueRegstr = valueRegstr;
    }

    public void setSignPredicate(Predicate<String> signPredicate) {
        this.signPredicate = signPredicate;
    }

    public void setValueMultiLine(boolean valueMultiLine) {
        this.valueMultiLine = valueMultiLine;
    }

    public boolean getValueMultiLine() {
        return valueMultiLine;
    }

    public int getPriority() {
        return priority;
    }

    public void setPriority(int priority) {
        this.priority = priority;
    }

    public int getVerticalSort() {
        return verticalSort;
    }

    public void setVerticalSort(int verticalSort) {
        this.verticalSort = verticalSort;
    }

    public boolean isValueMultiLine() {
        return valueMultiLine;
    }
}

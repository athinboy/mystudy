package net.fgq.study.pdf.annoation;

public enum ContentValueTypeEnum {

    Text("文本", "[\\s\\S]{0}"),
    Money("金额", "((RMB)|￥){0,1}[0-9]{1,}(\\.[0-9]{1,2}){0,1}元{0,1}"),
    Date("日期", "(\\d{4}-\\d{1,2}-\\d{1,2})|(\\d{4}年\\d{2}月\\d{2}日)");

    private String typeName;

    private String RegexStr;

    ContentValueTypeEnum(String typeName, String regexStr) {
        this.typeName = typeName;
        RegexStr = regexStr;
    }

    public String getTypeName() {
        return typeName;
    }

    public void setTypeName(String typeName) {
        this.typeName = typeName;
    }

    public String getRegexStr() {
        return RegexStr;
    }

    public void setRegexStr(String regexStr) {
        RegexStr = regexStr;
    }
}

package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;

import java.util.ArrayList;
import java.util.List;


/**
 * 信息区域的标记，比如：车辆信息
 * -----------------
 *           |车牌号码
 * 车辆信息    |核定载客
 *           |使用性质
 * -------------------------
 */
public class InfoArea {

    private String key;

    private List<String> signs = new ArrayList<>();

    private PdfTextPosition textPosition;

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public List<String> getSigns() {
        return signs;
    }

    public void setSigns(List<String> signs) {
        this.signs = signs;
    }

    public InfoArea(String key) {
        this.key = key;
    }

    public PdfTextPosition getTextPosition() {
        return textPosition;
    }

    public void setTextPosition(PdfTextPosition textPosition) {
        this.textPosition = textPosition;
    }
}

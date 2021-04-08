package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2021/4/8
 */
public class InfoGroup {

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

    public InfoGroup(String key) {
        this.key = key;
    }

    public PdfTextPosition getTextPosition() {
        return textPosition;
    }

    public void setTextPosition(PdfTextPosition textPosition) {
        this.textPosition = textPosition;
    }
}

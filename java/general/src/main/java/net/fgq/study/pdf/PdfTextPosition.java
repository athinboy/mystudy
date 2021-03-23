package net.fgq.study.pdf;

import java.awt.*;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfTextPosition {

    private String text;

    /**
     * 去除空格的内容。
     */
    private String trimedText;

    private int lineNumber = 1;

    private PdfRectangle rectangle = null;

    private int pageIndex;

    public PdfTextPosition(int pageIndex, String text, PdfRectangle rectangle) {
        this.text = text;
        this.rectangle = rectangle;
        this.pageIndex = pageIndex;
    }

    public PdfTextPosition(int pageIndex, String text, int x, int y, int width, int height) {
        this(pageIndex, text, new PdfRectangle(x, y, width, height));
    }

    /**
     * 从上到下,再从左到右排序。
     *
     * @return
     */
    public static Comparator<? super PdfTextPosition> getYXSortCompare() {
        return new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                if (o1.getRectangle().y < o2.getRectangle().y) {
                    return -1;
                } else if (o1.getRectangle().y == o2.getRectangle().y) {

                    if (o1.getRectangle().x < o2.getRectangle().x) {
                        return -1;
                    } else if (o1.getRectangle().x == o2.getRectangle().x) {
                        return 0;
                    } else {
                        return 1;
                    }

                } else {
                    return 1;
                }

            }
        };
    }

    /**
     * 从左到右,再从上到下排序。
     *
     * @return
     */
    public static Comparator<? super PdfTextPosition> getXYSortCompare() {
        return new Comparator<PdfTextPosition>() {
            @Override
            public int compare(PdfTextPosition o1, PdfTextPosition o2) {
                if (o1.getRectangle().x < o2.getRectangle().x) {
                    return -1;
                } else if (o1.getRectangle().x == o2.getRectangle().x) {

                    if (o1.getRectangle().y < o2.getRectangle().y) {
                        return -1;
                    } else if (o1.getRectangle().y == o2.getRectangle().y) {
                        return 0;
                    } else {
                        return 1;
                    }

                } else {
                    return 1;
                }

            }
        };
    }

    /**
     * 合并多个信息。
     *
     * @param candidateTexts
     * @return
     */
    public static PdfTextPosition merge(List<PdfTextPosition> candidateTexts) {
        if (candidateTexts.size() == 0) {
            return null;
        }

        int pageIndex = candidateTexts.get(0).getPageIndex();
        String str = "";
        PdfRectangle pdfRectangle = candidateTexts.get(0).getRectangle();

        for (PdfTextPosition candidateText : candidateTexts) {
            str += candidateText.getText();
            pdfRectangle = new PdfRectangle(pdfRectangle.union(candidateText.getRectangle()));
        }
        PdfTextPosition newPosition = new PdfTextPosition(pageIndex, str, pdfRectangle);

        List<List<PdfTextPosition>> textRows = new ArrayList<>();
        List<PdfTextPosition> textRow;
        List<PdfTextPosition> temps = new ArrayList<>();
        temps.addAll(candidateTexts);
        temps.sort(PdfTextPosition.getYXSortCompare());
        while (temps.size() > 0) {
            PdfTextPosition candidateText = temps.get(0);
            temps.remove(0);
            textRow = new ArrayList<>();
            textRow.add(candidateText);
            textRows.add(textRow);
            for (int i = 0; i < temps.size(); i++) {
                if (candidateText.checkSameLine(temps.get(i))) {
                    textRow.add(temps.get(i));
                    temps.remove(i--);
                }
            }

        }
        newPosition.setLineNumber(textRows.size());
        return newPosition;

    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getTrimedText() {
        if (trimedText == null) {
            trimedText = this.getText();
            trimedText = trimedText.replaceAll("\\s", "");
        }
        return trimedText;
    }

    public void setTrimedText(String trimedText) {
        this.trimedText = trimedText;
    }

    public PdfRectangle getRectangle() {
        return rectangle;
    }

    public void setRectangle(PdfRectangle rectangle) {
        this.rectangle = rectangle;
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public int getLineNumber() {
        return lineNumber;
    }

    public void setLineNumber(int lineNumber) {
        this.lineNumber = lineNumber;
    }

    @Override
    public String toString() {
        return "PdfTextPosition{" +
                "text='" + text + '\'' +
                "trimedText='" + trimedText + '\'' +
                ", rectangle=" + rectangle +
                ", pageIndex=" + pageIndex +
                '}';
    }

    public int lineHeight() {
        return this.getRectangle().height / this.lineNumber;
    }

    public boolean checkSameLine(PdfTextPosition textPosition) {
        int lineheight = (this.lineHeight() + textPosition.lineHeight()) / 2;
        return this.getRectangle().checkSameLine(textPosition.getRectangle(), lineheight);
    }
}

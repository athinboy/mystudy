package net.fgq.study.pdf;

import org.apache.commons.lang3.StringUtils;
import org.apache.pdfbox.pdmodel.common.PDRectangle;
import org.apache.pdfbox.text.TextPosition;

import java.awt.*;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

/**
 * Created by fengguoqiang 2021/4/13
 */
public class TextPositionExHelper {

    public static float getHeight(TextPosition text) {
        if (text.getFontSize() > text.getWidth() * 1.5) {
            return (float) (text.getWidth() * 1.2);
        }
        //return text.getFontSize();//text.getHeight()=text.getFontSize()/2;
        return text.getFont().getFontDescriptor().getCapHeight() / 1000 * text.getFontSize();
    }

    /**
     * 从上到下,再从左到右排序。
     * todo :不可用是否同一行进行判断，可能A、B是同一行，B、C是同一行。但是A、C差距较大不是同一行
     *
     * @return
     */
    public static Comparator<? super TextPositionEx> getYXSortCompare() {
        return new Comparator<TextPositionEx>() {
            @Override
            public int compare(TextPositionEx o1, TextPositionEx o2) {

                if (o1.checkSameLine(o2)) {

                    if (o1.getRectangle().x < o2.getRectangle().x) {
                        return -1;
                    } else if (o1.getRectangle().x == o2.getRectangle().x) {
                        return 0;
                    } else {
                        return 1;
                    }

                } else if (o1.getRectangle().y < o2.getRectangle().y) {
                    return -1;
                } else {
                    return 1;
                }

            }
        };
    }

    private static PdfTextPosition merge(List<TextPositionEx> allTexts) {
        if (allTexts == null || allTexts.size() == 0) {
            return null;
        }

        for (int i = 0; i < allTexts.size(); i++) {
            if (StringUtils.isBlank(allTexts.get(i).getTextPosition().getUnicode())) {
                allTexts.remove(i--);
            }
        }
        try {
            allTexts.sort(TextPositionExHelper.getYXSortCompare());
        } catch (IllegalArgumentException ilex) {
            System.out.println(ilex.getMessage());
            throw ilex;
        }

        List<List<TextPositionEx>> textRows = new ArrayList<>();
        String str = "";
        PdfRectangle rectangle = allTexts.get(0).getRectangle();
        for (TextPositionEx allText : allTexts) {
            str += allText.getTextPosition().getUnicode();
            rectangle = new PdfRectangle(rectangle.union(allText.getRectangle()));
        }
        List<TextPositionEx> textRow;

        while (allTexts.size() > 0) {
            TextPositionEx candidateText = allTexts.get(0);
            allTexts.remove(0);
            textRow = new ArrayList<>();
            textRow.add(candidateText);
            textRows.add(textRow);
            for (int i = 0; i < allTexts.size(); i++) {
                if (candidateText.checkSameLine(allTexts.get(i))) {
                    textRow.add(allTexts.get(i));
                    allTexts.remove(i--);
                }
            }

        }

        PdfTextPosition result = new PdfTextPosition(0, str, rectangle);
        result.setLineNumber(textRows.size());
        return result;

    }

    public static PdfTextPosition mergeBlock(List<TextPositionEx> allTexts) {

        if (allTexts == null || allTexts.size() <= 1) {
            return merge(allTexts);
        }
        allTexts.sort(new Comparator<TextPositionEx>() {
            @Override
            public int compare(TextPositionEx o1, TextPositionEx o2) {

                if (o1.getRectangle().x == o2.getRectangle().x) {
                    if (o1.getRectangle().y < o2.getRectangle().y) {
                        return -1;
                    } else if (o1.getRectangle().y > o2.getRectangle().y) {
                        return 1;
                    }
                    return 0;
                } else if (o1.getRectangle().x > o2.getRectangle().x) {
                    return 1;
                } else {
                    return -1;
                }
            }
        });

        boolean singleOne = true;
        for (int i = 1; i < allTexts.size(); i++) {
            if (StringUtils.isBlank(allTexts.get(i).getTextPosition().getUnicode())) {
                continue;
            }
            //有漏洞,比如
            //SSSSSSSS大
            //         y
            //y的x比大的x大，但是y在第二行
            if (allTexts.get(i).getRectangle().x < allTexts.get(i - 1).getRectangle().getMiddleX()) {
                singleOne = false;
            }
        }
        if (singleOne) {
            return mergeSingleRow(allTexts);
        }
        List<TextPositionEx> singleRow = new ArrayList<>();
        List<TextPositionEx> multiRow = new ArrayList<>();
        return merge(allTexts);

    }

    private static PdfTextPosition mergeSingleRow(List<TextPositionEx> allTexts) {
        String str = "";
        PdfRectangle rectangle = allTexts.get(0).getRectangle();
        for (TextPositionEx allText : allTexts) {
            str += allText.getTextPosition().getUnicode();
            rectangle = new PdfRectangle(rectangle.union(allText.getRectangle()));
        }
        PdfTextPosition result = new PdfTextPosition(0, str, rectangle);
        result.setLineNumber(1);
        return result;
    }

    /**
     * 检查是否水平紧靠。
     *
     * @return
     */
    public static boolean checkXBeside(TextPositionEx o1, TextPositionEx o2) {

        PdfRectangle o1Rec = new PdfRectangle(o1.getRectangle());
        PdfRectangle o2Rec = new PdfRectangle(o2.getRectangle());
        if (o1Rec.x > o2Rec.x) {
            o1Rec.x = o1Rec.x - o1Rec.width;
        } else {
            o2Rec.x = o2Rec.x - o2Rec.width;
        }
        if (o1Rec.intersects(o2Rec)) {
            Rectangle intersectR = o1Rec.intersection(o2Rec);
            int area = intersectR.width * intersectR.height;
            if (area >= o1Rec.area() * 0.8 && area >= o2Rec.area() * 0.8) {
                return true;
            }
        }

        return false;
    }

    /**
     * 检查是否垂直紧靠。
     * 注意：对于下列情况无效：第二行文字正好处于第一行两个文字中间。
     * 车牌
     *  A
     * @return
     */
    public static boolean checkYBeside(TextPositionEx o1, TextPositionEx o2) {

        PdfRectangle o1Rec = new PdfRectangle(o1.getRectangle());
        PdfRectangle o2Rec = new PdfRectangle(o2.getRectangle());
        if (o1Rec.y > o2Rec.y) {
            o1Rec.y = o1Rec.y - o1Rec.height;
        } else {
            o2Rec.y = o2Rec.y - o2Rec.height;
        }
        if (o1Rec.intersects(o2Rec)) {
            Rectangle intersectR = o1Rec.intersection(o2Rec);
            int area = intersectR.width * intersectR.height;
            if (area * 2 >= (o1Rec.area() + o2Rec.area()) * 0.5) {
                return true;
            }
        }

        return false;
    }

}

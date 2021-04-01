package net.fgq.study.pdf;

import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/29
 */
public class PdfTextPositionHelper {

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
    public static PdfTextPosition merge(final List<PdfTextPosition> candidateTexts) {
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
        temps.sort(PdfTextPositionHelper.getYXSortCompare());
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

    /**
     * 获取右侧所有内容
     *
     * @param candidateTexts
     * @param textPosition
     * @return
     */
    public static List<PdfTextPosition> getRightAll(final List<PdfTextPosition> candidateTexts, PdfTextPosition textPosition) {

        List<PdfTextPosition> temp = new ArrayList<>();
        for (PdfTextPosition candidateText : candidateTexts) {
            if (textPosition.checkSameLine(candidateText) && textPosition.getRectangle().checkRightSide(candidateText.getRectangle())) {
                temp.add(candidateText);
            }
        }
        temp.sort(getXYSortCompare());
        return temp;

    }

    /**
     * 获取右侧邻居
     *
     * @param candidateTexts
     * @param textPosition
     * @return
     */
    public static PdfTextPosition getRightNeighbor(final List<PdfTextPosition> candidateTexts, PdfTextPosition textPosition) {

        List<PdfTextPosition> temp = getRightAll(candidateTexts, textPosition);
        temp.sort(getXYSortCompare());
        return temp.size() > 0 ? temp.get(0) : null;

    }

    /**
     * 获取右侧邻居
     *
     * @param candidateTexts
     * @param textPosition
     * @param regstr         正则校验
     * @return
     */
    public static PdfTextPosition getRightNeighbor(final List<PdfTextPosition> candidateTexts, String regstr, PdfTextPosition textPosition) {
        if (StringUtils.isBlank(regstr)) {
            throw PdfException.getInstance("regstr不可为空");
        }
        PdfTextPosition result = getRightNeighbor(candidateTexts, textPosition);
        if (result == null) return result;
        Pattern pattern = Pattern.compile(regstr);
        if (pattern.asPredicate().test(result.getTrimedText())) {
            return result;
        } else {
            return null;
        }

    }

}

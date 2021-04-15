package net.fgq.study.pdf;

import org.apache.commons.lang3.StringUtils;
import org.apache.pdfbox.text.TextPosition;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.function.ToIntFunction;
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
        }

                ;
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
    public static PdfTextPosition merge(PdfTextPosition... candidateTexts) {

        return merge(Arrays.asList(candidateTexts));
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
        if (1 != candidateTexts.stream().mapToInt(new ToIntFunction<PdfTextPosition>() {
            @Override
            public int applyAsInt(PdfTextPosition value) {
                return value.getPageIndex();
            }
        }).distinct().count()) {
            throw PdfException.getInstance("非同一页的信息");
        }

        int pageIndex = candidateTexts.get(0).getPageIndex();
        List<TextPositionEx> allTexts = new ArrayList<>();
        for (PdfTextPosition candidateText : candidateTexts) {
            allTexts.addAll(candidateText.getTextPositions());
        }
        PdfTextPosition pdfTextPosition = TextPositionExHelper.mergeBlock(allTexts);
        if (pdfTextPosition != null) {
            pdfTextPosition.setPageIndex(pageIndex);
            return pdfTextPosition;
        }

        String str = "";
        PdfRectangle pdfRectangle = candidateTexts.get(0).getRectangle();

        candidateTexts.sort(PdfTextPositionHelper.getYXSortCompare());
        for (PdfTextPosition candidateText : candidateTexts) {
            str += candidateText.getText();
            pdfRectangle = new PdfRectangle(pdfRectangle.getPageIndex(), pdfRectangle.union(candidateText.getRectangle()));
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
     * @param needSameLine   是否要求同一行
     * @return
     */
    public static List<PdfTextPosition> getRightAll(final List<PdfTextPosition> candidateTexts, PdfTextPosition textPosition, boolean needSameLine) {

        List<PdfTextPosition> temp = new ArrayList<>();
        for (PdfTextPosition candidateText : candidateTexts) {
            if (candidateText == textPosition
                    || candidateText.getPageIndex() != textPosition.getPageIndex()) continue;
            if (textPosition.getRectangle().checkRightSide(candidateText.getRectangle())) {
                if (needSameLine) {
                    if (textPosition.checkSameLine(candidateText)) {
                        temp.add(candidateText);
                    }
                } else {
                    if (candidateText.getRectangle().maxY() > textPosition.getRectangle().y
                            && candidateText.getRectangle().y < textPosition.getRectangle().maxY()) {
                        temp.add(candidateText);
                    }
                }
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

        List<PdfTextPosition> temp = getRightAll(candidateTexts, textPosition, true);
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

    /**
     * 是否邻居
     *
     * @param o1
     * @param o2
     * @return
     */
    public static boolean checkNeighbor(PdfTextPosition o1, PdfTextPosition o2, List<PdfTextPosition> allTexts) {
        if (o1 == o2) {
            throw PdfException.getInstance("同一个对象:" + o1.toString());
        }
        if (o1.getPageIndex() != o2.getPageIndex()) return false;

        if (true == o1.checkSameLeft(o2)) {
            for (PdfTextPosition text : allTexts) {
                if (text == o1 || text == o2 || o1.checkSameLeft(text) == false) continue;
                if (text.getRectangle().y > Math.min(o1.getRectangle().y, o2.getRectangle().y)
                        && text.getRectangle().y < Math.max(o1.getRectangle().y, o2.getRectangle().y)
                ) {
                    return false;
                }

            }
            return true;
        }
        if (false == o1.checkSameLine(o2)) {
            for (PdfTextPosition text : allTexts) {
                if (text == o1 || text == o2 || o1.checkSameLine(text) == false) continue;
                if (text.getRectangle().x > Math.min(o1.getRectangle().x, o2.getRectangle().x)
                        && text.getRectangle().x < Math.max(o1.getRectangle().x, o2.getRectangle().x)
                ) {
                    return false;
                }

            }

            return true;
        }
        if (o1.getRectangle().y > o2.getRectangle().y) {
            PdfTextPosition t = o2;
            o2 = o1;
            o1 = t;
        }
        if (o2.getRectangle().x >= o1.getRectangle().x && o2.getRectangle().x < o1.getRectangle().getMaxX()) {
            if (checkBollowNeighbor(o1, o2, allTexts)) {
                return true;
            }

        }

        return false;

    }

    /**
     * o2 是o1 的下方邻居
     *
     * @param o1
     * @param o2
     * @param allTexts
     * @return
     */
    public static boolean checkBollowNeighbor(PdfTextPosition o1, PdfTextPosition o2, List<PdfTextPosition> allTexts) {
        if (o1.getPageIndex() != o2.getPageIndex()) return false;
        if (o2.getRectangle().x > o1.getRectangle().getMaxX() || o2.getRectangle().getMaxX() < o1.getRectangle().x) {
            return false;
        }

        for (PdfTextPosition text : allTexts) {
            if (text == o1 || text == o2 || text.getPageIndex() != o1.getPageIndex()) continue;
            if (text.getRectangle().y > Math.min(o1.getRectangle().y, o2.getRectangle().y)
                    && text.getRectangle().y < Math.max(o1.getRectangle().y, o2.getRectangle().y)
            ) {
                return false;
            }

        }
        return true;

    }
}

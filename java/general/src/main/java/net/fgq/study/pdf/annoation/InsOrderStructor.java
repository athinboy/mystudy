package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.PdfTextPositionHelper;
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Predicate;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/29
 */
public class InsOrderStructor {

    private static Pattern p1 = Pattern.compile("日\\d{1,2}(:)\\d{1,2}(时)");

    public static void struct(InsOrderDocument insOrderDocument, final List<PdfTextPosition> textPositions, InsCompanyType insCompanyType) {

        List<InfoGroup> infoGroups = insOrderDocument.getInfoGroups();
        for (InfoGroup infoGroup : infoGroups) {
            infoGroup.setTextPosition(null);
            for (String sign : infoGroup.getSigns()) {
                for (PdfTextPosition textPosition : textPositions) {
                    if (insOrderDocument.getPageIndex() != textPosition.getPageIndex()) {
                        continue;
                    }
                    if (sign.indexOf(textPosition.getTrimedText()) == 0) {
                        PdfTextPosition result = groupTextPosition(sign, textPosition, new ArrayList<>(textPositions));
                        if (result != null) {
                            infoGroup.setTextPosition(result);
                            break;
                        }
                    }
                }
                if (infoGroup.getTextPosition() != null) {
                    break;
                }
            }
        }

        textPositions.sort(PdfTextPositionHelper.getXYSortCompare());
        for (PdfTextPosition textPosition : textPositions) {
            String str;
            if (null != (str = standaredize(textPosition.getTrimedText()))) {
                textPosition.setOriginalStr(textPosition.getText());
                textPosition.setText(str);
                textPosition.setTrimedText(null);
                textPosition.setStandaredized(true);
            }
        }

        switch (insCompanyType) {
            case tpyang:
                structTPY(textPositions);
                return;
        }
    }

    private static PdfTextPosition groupTextPosition(String infoGroupSign, PdfTextPosition textPosition, List<PdfTextPosition> textPositions) {

        String sign = infoGroupSign.substring(textPosition.getTrimedText().length());
        PdfTextPosition nextText;
        PdfTextPosition resultText = textPosition;
        List<PdfTextPosition> mergedTexts = new ArrayList<>();
        mergedTexts.add(textPosition);
        textPositions.remove(textPosition);

        textPositions.sort(PdfTextPositionHelper.getYXSortCompare());

        for (int i = 0; i < textPositions.size(); i++) {
            nextText = textPositions.get(i);
            if (StringUtils.isBlank(nextText.getTrimedText())) {
                continue;
            }
            if (sign.indexOf(nextText.getTrimedText()) == 0) {
                if (resultText.getRectangle().contains(nextText.getRectangle())
                        || PdfTextPositionHelper.checkNeighbor(nextText, resultText, textPositions)) {
                    sign = sign.substring(nextText.getTrimedText().length());
                    resultText = PdfTextPositionHelper.merge(resultText, nextText);
                    mergedTexts.add(nextText);
                    textPositions.remove(i--);
                    if (sign.length() == 0) {
                        break;
                    }
                }

            }
        }
        if (sign.length() > 0) {
            textPositions.addAll(mergedTexts);
            return null;//寻找失败
        }
        resultText.getOrigTexts().addAll(mergedTexts);
        textPositions.removeAll(mergedTexts);
        List<PdfTextPosition> groupItems = PdfTextPositionHelper.getRightAll(textPositions, resultText, false);
        resultText.setGroupItems(groupItems);
        if (groupItems.size() > 0) {
            resultText.setIsGroupInfo(true);
        }
        textPositions.add(resultText);
        return resultText;

    }

    /**
     * 太平洋
     *
     * @param textPositions
     */
    private static void structTPY(List<PdfTextPosition> textPositions) {

        for (int i = 0; i < textPositions.size(); i++) {
//收费确认时间：2020/08/16 16:55:14 有效保单生成时间：2020/08/16 16:55:18 电子保单生成时间：2020/08/16 16:56:20

        }

    }

    public static String standaredize(String value) {
        if (StringUtils.isBlank(value)) return null;
        if (p1.asPredicate().test(value)) {
            String str = value;
            while (p1.asPredicate().test(str)) {
                Matcher matcher = p1.matcher(str);
                if (matcher.find()) {
                    str = str.replaceFirst("(?<=日\\d{1,2}):(?=\\d{1,2}时)", "时");
                    str = str.replaceFirst("(?<=日\\d{1,2}时\\d{1,2})时", "分");
                    return str;
                }
            }
        }
        return null;
    }

}

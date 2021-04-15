package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.PdfTextPositionHelper;
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/29
 */
public class InsOrderStructor {

    public static void struct(InsOrderDocument insOrderDocument, final List<PdfTextPosition> textPositions, InsCompanyType insCompanyType) {

        List<InfoArea> infoAreas = insOrderDocument.getInfoAreas();
        for (InfoArea infoArea : infoAreas) {
            infoArea.setTextPosition(null);
            for (String sign : infoArea.getSigns()) {
                for (PdfTextPosition textPosition : textPositions) {
                    if (false == insOrderDocument.checkPage(textPosition.getPageIndex())) {
                        continue;
                    }
                    if (sign.indexOf(textPosition.getTrimedText()) == 0) {
                        PdfTextPosition result = findTxtArea(sign, textPosition, new ArrayList<>(textPositions));
                        if (result != null) {
                            infoArea.setTextPosition(result);
                            break;
                        }
                    }
                }
                if (infoArea.getTextPosition() != null) {
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

    private static PdfTextPosition findTxtArea(String infoAreaSign, PdfTextPosition textPosition, List<PdfTextPosition> textPositions) {

        String sign = infoAreaSign.substring(textPosition.getTrimedText().length());
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
        //resultText.addOrigTexts(mergedTexts);
        resultText = PdfTextPositionHelper.merge(mergedTexts);
        textPositions.removeAll(mergedTexts);

        List<PdfTextPosition> areaItems = PdfTextPositionHelper.getRightAll(textPositions, resultText, false);
        resultText.setGroupItems(areaItems);
        if (areaItems.size() > 0) {
            resultText.setAreaInfo(true);
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

    private static Pattern p1 = Pattern.compile("日\\d{1,2}(:)\\d{1,2}(时)");
    private static Pattern p2 = Pattern.compile("\\d{1,2}日二十四时");

    /**
     * 未做任何修改时，切记返回null
     *
     * @param value
     * @return
     */
    public static String standaredize(final String value) {
        if (StringUtils.isBlank(value)) return null;
        String str = value;
        boolean dealed = false;
        if (p1.asPredicate().test(str)) {

            while (p1.asPredicate().test(str)) {
                Matcher matcher = p1.matcher(str);
                if (matcher.find()) {
                    str = str.replaceFirst("(?<=日\\d{1,2}):(?=\\d{1,2}时)", "时");
                    str = str.replaceFirst("(?<=日\\d{1,2}时\\d{1,2})时", "分");

                }
            }
            return str;
        }
        if (p2.asPredicate().test(str)) {

            while (p2.asPredicate().test(str)) {
                Matcher matcher = p2.matcher(str);
                if (matcher.find()) {
                    str = str.replaceFirst("(?<=\\d{1,2}日)二十四(?=时)", "24");
                }
            }
            return str;
        }

        if (dealed == false) {
            return null;
        } else {
            return str;
        }
    }

}

package net.fgq.study.pdf;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.Document;
import org.apache.commons.lang3.NotImplementedException;
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/22
 */
public class ContentParse {

    public static void parseContent(Document document, JSONObject jsonObject, final List<PdfTextPosition> textPositions) {
        String candidateValueStr;
        List<PdfRectangle> candidateRects = new ArrayList<>();
        for (Content content : document.getContents()) {
            if(content.getLableSigns().get(0).equals("保险期间")){
                int i=0;
            }

            if (content.getRectangle() != null) {
                parseContentByPosition(content, jsonObject, textPositions);
                continue;
            }

            List<PdfTextPosition> candidateLableTexts = new ArrayList<>();
            List<PdfTextPosition> candidateValueTexts = new ArrayList<>();
            List<PdfTextPosition> candidateRightLables = new ArrayList<>();
            for (PdfTextPosition textPosition : textPositions) {
                if (content.getLableSignsPattern().asPredicate().test(textPosition.getTrimedText())) {
                    candidateLableTexts.add(textPosition);
                }
            }
            if (candidateLableTexts.size() == 0) {
                throw new PdfException("定位内容失败：" + content.toString());
            }
            if (candidateLableTexts.size() == 1 && content.getLableSigns().size() == 1) {

                if ((candidateValueStr = parseValue(content, candidateLableTexts.get(0))) != null) {
                    formatValue(jsonObject, content, candidateValueStr);
                    continue;
                }
            }
            candidateRects.clear();

            if (content.getRightSigns().size() > 0) {
                for (PdfTextPosition textPosition : textPositions) {
                    if (content.getRightSignsPattern().asPredicate().test(textPosition.getTrimedText())) {
                        candidateRightLables.add(textPosition);
                    }
                }
                for (PdfTextPosition candidateText : candidateLableTexts) {
                    for (PdfTextPosition candidateRightLable : candidateRightLables) {

                        if (candidateText.checkSameLine(candidateRightLable)) {
                            int x = candidateText.getRectangle().x + candidateText.getRectangle().width;
                            int y = candidateText.getRectangle().y;
                            int width = candidateRightLable.getRectangle().x - x;
                            int height = Math.max(candidateText.getRectangle().height, candidateRightLable.getRectangle().height);
                            if (width <= 0 || height <= 0) {
                                throw new PdfException("推断值区域异常："
                                        + "r1:" + candidateText.getRectangle().toString()
                                        + "r2:" + candidateRightLable.getRectangle().toString());
                            }
                            candidateRects.add(new PdfRectangle(x, y, width, height));
                        }
                    }
                }

            } else {

                for (PdfTextPosition candidateText : candidateLableTexts) {
                    candidateValueTexts.clear();

                    for (PdfTextPosition textPosition : textPositions) {
                        if (candidateText.checkSameLine(textPosition)) {
                            candidateValueTexts.add(textPosition);
                        }
                    }



                }
                PdfTextPosition newTextPosition = PdfTextPositionHelper.merge(candidateValueTexts);
                if (null != (candidateValueStr = parseValue(content, newTextPosition))) {
                    formatValue(jsonObject, content, candidateValueStr);
                    continue;
                } else {
                    throw new PdfException("提取值失败：" + content.toString() + "\r\n" + JSON.toJSONString(newTextPosition.toString()));
                }
//                throw new NotImplementedException("未配置右侧标签的情况");
            }

            List<String> candidateValues = new ArrayList<>();

            for (PdfRectangle candidateRect : candidateRects) {
                candidateValueTexts.clear();
                for (PdfTextPosition textPosition : textPositions) {
                    if (candidateRect.intersects(textPosition.getRectangle())) {
                        candidateValueTexts.add(textPosition);

                    }
                }

                PdfTextPosition newText = PdfTextPositionHelper.merge(candidateValueTexts);
                newText = findExtendBlock(textPositions, newText);
                if ((candidateValueStr = parseValue(content, newText)) != null) {
                    candidateValues.add(candidateValueStr);
                }

            }
            if (candidateValues.size() == 1) {

                formatValue(jsonObject, content, candidateValues.get(0));
                continue;
            } else {
                throw new PdfException("提取值识别：" + JSON.toJSONString(candidateValues.toString()));
            }

        }
    }

    /**
     * 通过扩展查询对象所属的文本块。
     *
     * @param textPositions
     * @param textPosition
     * @return
     */
    private static PdfTextPosition findExtendBlock(List<PdfTextPosition> textPositions, PdfTextPosition textPosition) {

        List<PdfTextPosition> candidates = new ArrayList<>();

        List<PdfTextPosition> temp = new ArrayList<>();
        temp.addAll(textPositions);
        temp.sort(PdfTextPositionHelper.getYXSortCompare());
        for (PdfTextPosition position : temp) {
            //左边距排除
            if (Math.abs(position.getRectangle().x - textPosition.getRectangle().x) > position.lineHeight() / 2) {
                continue;
            }
            //上边距排除
            if (position.getRectangle().y >= textPosition.getRectangle().y && position.getRectangle().y <= textPosition.getRectangle().getMaxY()) {
                continue;
            }
            candidates.add(position);
        }
        temp.clear();
        int minY = textPosition.getRectangle().y;
        int maxY = textPosition.getRectangle().y + textPosition.getRectangle().height;
        //从上往下找相邻
        for (int i = 0; i < candidates.size(); i++) {
            if (Math.abs(candidates.get(i).getRectangle().y - maxY) < candidates.get(i).lineHeight() / 2) {
                maxY = candidates.get(i).getRectangle().maxY();
                temp.add(candidates.get(i));
            }
        }
        //从下往上找相邻
        for (int i = candidates.size() - 1; i >= 0; i--) {
            if (Math.abs(minY - candidates.get(i).getRectangle().maxY()) < candidates.get(i).lineHeight() / 2) {
                minY = candidates.get(i).getRectangle().y;
                temp.add(candidates.get(i));
            }
        }

        temp.add(textPosition);
        return PdfTextPositionHelper.merge(temp);

    }

    private static void formatValue(JSONObject jsonObject, Content content, String valuestr) {
        jsonObject.put(content.getJsonKey(), content.formatValue(valuestr));
    }

    /**
     * 根据区域提取值
     *
     * @param content
     * @param jsonObject
     * @param textPositions
     * @return
     */
    public static boolean parseContentByPosition(Content content, JSONObject jsonObject, final List<PdfTextPosition> textPositions) {
        for (PdfTextPosition textPosition : textPositions) {

            if (content.getPageIndex() == textPosition.getPageIndex()
                    && content.getRectangle().contains(textPosition.getRectangle())) {
                jsonObject.put(content.getJsonKey(), textPosition.getText());
                return true;

            }
        }
        return false;
    }

    /**
     * 提取内容。
     *
     * @param content
     * @param candidateText
     * @return null：提取失败
     */
    private static String parseValue(Content content, final PdfTextPosition candidateText) {

        String valueCandidateStr = candidateText.getTrimedText();

        Matcher matcher = content.getLableSignsPattern().matcher(valueCandidateStr);
        if (matcher.find()) {
            valueCandidateStr = valueCandidateStr.substring(matcher.end());

        }
        if (StringUtils.isBlank(valueCandidateStr)) {
            return null;
        }

        if (content.getValueRegstr().size() > 0) {
            Pattern valuePattern = content.getValuePattern();

            if (valuePattern.asPredicate().test(valueCandidateStr)) {
                matcher = valuePattern.matcher(valueCandidateStr);
                if (matcher.find()) {
                    valueCandidateStr = valueCandidateStr.substring(matcher.start(), matcher.end());
                    return valueCandidateStr;
                } else {
                    return null;
                }
            }
        } else {
            return valueCandidateStr;
        }

        return null;
    }

}

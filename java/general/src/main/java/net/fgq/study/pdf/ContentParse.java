package net.fgq.study.pdf;

import com.alibaba.fastjson.JSON;
import com.alibaba.fastjson.JSONObject;
import net.fgq.study.pdf.annoation.Content;
import net.fgq.study.pdf.annoation.Document;
import net.fgq.study.pdf.annoation.InsOrderStructor;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by fengguoqiang 2021/3/22
 */
public class ContentParse {

    static Logger logger = LoggerFactory.getLogger(ContentParse.class);

    //todo :need to del
    public static String errsign = "";

    public static void parseContent(Document document, JSONObject jsonObject, final List<PdfTextPosition> pdfTextPositions) {

        String candidateValueStr;
        List<PdfRectangle> candidateRects = new ArrayList<>();

        document.getContents().sort(new Comparator<Content>() {
            @Override
            public int compare(Content o1, Content o2) {
                if (o1.getOrderItem().getCandidateKeyTexts().size() != o2.getOrderItem().getCandidateKeyTexts().size()) {
                    return Integer.compare(o1.getOrderItem().getCandidateKeyTexts().size(), o2.getOrderItem().getCandidateKeyTexts().size());
                }
                if (o1.getVerticalSort() != o2.getVerticalSort()) {
                    return -1 * Integer.compare(o1.getVerticalSort(), o2.getVerticalSort());
                }
                return o1.getOrderItem().getJsonKey().compareTo(o2.getOrderItem().getJsonKey());
            }
        });

        //每一个垂直顺序的上边距
        //
        int[] verticalUpperLimit = new int[]{
                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };

        int priority = 0;
        while (priority <= 3) {
            priority += 1;
            for (Content content : document.getContents()) {
                if (content.getPriority() != priority) {
                    continue;
                }
                if (content.getOrderItem().getJsonKey().equals(errsign)) {
                    int i = 0;
                }

                List<PdfTextPosition> textPositions = new ArrayList<>();
                if (content.getOrderItem().getInfoArea() != null
                        && content.getOrderItem().getInfoArea().getTextPosition() != null
                        && CollectionUtils.isNotEmpty(content.getOrderItem().getInfoArea().getTextPosition().getGroupItems())) {
                    textPositions = content.getOrderItem().getInfoArea().getTextPosition().getGroupItems();
                } else {
                    for (PdfTextPosition textPosition : pdfTextPositions) {
                        if (content.getVerticalSort() != -1
                                && verticalUpperLimit[content.getVerticalSort() + 1] != -1
                                && verticalUpperLimit[content.getVerticalSort() + 1] < (textPosition.getRectangle().getPageIndex() * 10000 + textPosition.getRectangle().y)
                        ) {
                            continue;
                        }

                        if (content.checkPage(textPosition.getPageIndex())) {
                            textPositions.add(textPosition);
                        }
                    }
                }

                if (content.getRectangle() != null) {
                    parseContentByPosition(content, jsonObject, textPositions);
                    continue;
                }
                textPositions.sort(PdfTextPositionHelper.getXYSortCompare());

                List<PdfTextPosition> candidateLabelTexts = new ArrayList<>();

                List<PdfTextPosition> candidateRightLabels = new ArrayList<>();
                if (content.getOrderItem().getCandidateKeyTexts().size() == 1) {
                    candidateLabelTexts.add(content.getOrderItem().getCandidateKeyTexts().get(0));
                } else {
                    for (PdfTextPosition textPosition : textPositions) {
                        if (content.getOrderItem().getMuiltValue() == false) {
                            if (textPosition.getCandidateOrderItems().size() == 1
                                    && textPosition.getCandidateOrderItems().get(0) != content.getOrderItem()) {
                                continue;
                            }
                        }

                        if (content.getLabelSignsPredicate().test(textPosition.getTrimedText())) {

                            if (textPosition.getCandidateOrderItems().size() > 0 && content.getOrderItem() != null) {
                                if (textPosition.getCandidateOrderItems().contains(content.getOrderItem())) {
                                    candidateLabelTexts.add(textPosition);
                                }
                            } else {
                                candidateLabelTexts.add(textPosition);
                            }

                        }
                    }
                }

                if (candidateLabelTexts.size() == 0) {
                    if (content.getOrderItem().isRequire()) {
                        throw new PdfException("定位内容失败：" + content.toString());
                    } else {
                        continue;
                    }
                }
                //对于类似下列形式无效
                // 保险费合计（人民币大写）：                           （￥：          元）
                // 100 捌佰伍拾伍圆整

//                if (candidateLabelTexts.size() == 1) {
//                    if ((candidateValueStr = parseValue(content, candidateLabelTexts.get(0))) != null) {
//                        formatValue(jsonObject, content, candidateValueStr);
//                        continue;
//                    }
//                }
                candidateRects.clear();

                if (content.getRightSigns().size() > 0) {
                    for (PdfTextPosition textPosition : textPositions) {
                        if (content.getRightSignsPredicate().test(textPosition.getTrimedText())) {
                            candidateRightLabels.add(textPosition);
                        }
                    }
                    for (PdfTextPosition candidateText : candidateLabelTexts) {
                        for (PdfTextPosition candidateRightLabel : candidateRightLabels) {
                            if (candidateText.checkRightSameLine(candidateRightLabel)) {
                                int x = candidateText.getRectangle().x;
                                int y = candidateText.getRectangle().y;
                                int width = candidateRightLabel.getRectangle().x + candidateRightLabel.getRectangle().width - x;
                                int height = Math.max(candidateText.getRectangle().height, candidateRightLabel.getRectangle().height);
                                if (width <= 0 || height <= 0) {
                                    throw new PdfException("推断值区域异常："
                                            + "r1:" + candidateText.getRectangle().toString()
                                            + "r2:" + candidateRightLabel.getRectangle().toString());
                                }
                                candidateRects.add(new PdfRectangle(candidateText.getPageIndex(), x, y, width, height));
                            }
                        }
                    }

                } else {

                    PdfRectangle rectangle;

                    for (PdfTextPosition candidateText : candidateLabelTexts) {
                        rectangle = null;
                        int maxX = Integer.MAX_VALUE;

                        for (PdfTextPosition textPosition : textPositions) {

                            if (candidateText != textPosition
                                    && (false == candidateLabelTexts.contains(textPosition))
                                    && candidateText.checkRightSameLine(textPosition)) {
                                if (textPosition.getCandidateOrderItems().size() >= 1) {
                                    maxX = Math.min(textPosition.getRectangle().x, maxX);
                                    continue;
                                }
                                if (textPosition.getRectangle().getX() > maxX) {
                                    continue;
                                }
                                rectangle = rectangle == null ? textPosition.getRectangle()
                                        : new PdfRectangle(candidateText.getPageIndex(), rectangle.union(textPosition.getRectangle()));
                            }
                        }

                        if (rectangle != null && rectangle.getX() < maxX) {
                            rectangle = new PdfRectangle(candidateText.getPageIndex(), candidateText.getRectangle().union(rectangle));

                        } else {
                            rectangle = new PdfRectangle(
                                    candidateText.getPageIndex()
                                    , candidateText.getRectangle().x//必须从X开始。比如保险期间自  年 月  日 时 分起至  年  月  日  时  分止
                                    , candidateText.getRectangle().y
                                    , maxX - candidateText.getRectangle().x//未找到合适的右侧信息那就直到右侧边缘。
                                    , candidateText.getRectangle().height);
                        }
                        //值项目可能是多行，或者打印位置偏高，造成无法获取值，所以高度扩展0.5倍。
                        rectangle.y = rectangle.y - rectangle.height / 4;
                        rectangle.height = Double.valueOf(rectangle.height * 1.5).intValue();

                        candidateRects.add(rectangle);
                    }

                }

                List<String> candidateValues = new ArrayList<>();

                if (content.getOrderItem().getInfoGroup() != null) {
                    List<PdfRectangle> rectangles = content.getOrderItem().getInfoGroup().mergeNear(candidateRects);
                    if (rectangles.size() == 1) {
                        candidateRects = rectangles;
                    } else {
                        content.setPriority(content.getPriority() + 1);
                        if (content.getPriority() <= 3) {
                            continue;
                        }
                    }

                }
                List<PdfTextPosition> candidateValueTexts = new ArrayList<>();
                PdfTextPosition newText = null;
                for (PdfRectangle candidateRect : candidateRects) {
                    candidateValueTexts.clear();
                    for (PdfTextPosition textPosition : textPositions) {
                        if (candidateRect.intersects(textPosition.getRectangle())) {
                            candidateValueTexts.add(textPosition);

                        }
                    }
                    if (content.getOrderItem().getJsonKey().equals(errsign)) {
                        int i = 0;
                    }
                    if (candidateValueTexts.size() > 0) {

                        newText = PdfTextPositionHelper.merge(candidateValueTexts);
                        if (content.getValueMultiLine()) {
                            newText = findExtendBlock(textPositions, newText, 1);
                        }
                        if ((candidateValueStr = parseValue(content, newText)) != null) {
                            candidateValues.add(candidateValueStr);
                        }
                    } else {
                        System.out.println(34);
                    }
                }
                if (candidateValues.size() == 1) {
                    setUpperLimit(content, verticalUpperLimit, newText);
                    formatValue(jsonObject, content, candidateValues.get(0));
                    continue;
                } else {

                    if (StringUtils.isNotBlank(content.getOrderItem().getBackupItem())) {
                        Object o;
                        content.setPriority(content.getPriority() + 1);
                        if (content.getPriority() <= 3) {
                            continue;
                        }
                        if (null != (o = jsonObject.get(content.getOrderItem().getBackupItem()))) {
                            jsonObject.put(content.getJsonKey(), o);
                            continue;
                        }
                    }

                    if (content.getOrderItem().isRequire() == false) {
                        continue;
                    }
                    errsign = content.getOrderItem().getJsonKey();
                    throw new PdfException("提取值失败：" + content.toString() + "\r\n" + JSON.toJSONString(candidateValues.toString()));
                }

            }

        }

    }

    private static void setUpperLimit(Content content, int[] verticalUpperLimit, PdfTextPosition newText) {
        if (content.getVerticalSort() == -1) return;

        verticalUpperLimit[content.getVerticalSort()] =
                verticalUpperLimit[content.getVerticalSort()] == -1
                        ? newText.getRectangle().getPageIndex() * 10000 + newText.getRectangle().y
                        : Math.min(newText.getRectangle().getPageIndex() * 10000 + newText.getRectangle().y, verticalUpperLimit[content.getVerticalSort()]);
    }

    /**
     * 通过扩展查询对象所属的文本块。
     *
     * @param textPositions
     * @param middleTexts
     * @param linegap       行距
     * @return
     */
    private static PdfTextPosition findExtendBlock(List<PdfTextPosition> textPositions, PdfTextPosition middleTexts, int linegap) {

        List<PdfTextPosition> candidates = new ArrayList<>();

        List<PdfTextPosition> temp = new ArrayList<>();
        temp.addAll(textPositions);
        temp.sort(PdfTextPositionHelper.getYXSortCompare());
        for (PdfTextPosition position : temp) {
            if (position.getPageIndex() != middleTexts.getPageIndex()) {
                continue;
            }
            //左边距排除
            if (Math.abs(position.getRectangle().x - middleTexts.getRectangle().x) > position.lineHeight() / 2) {
                continue;
            }
            //上边距排除
            if (position.getRectangle().y >= middleTexts.getRectangle().y && position.getRectangle().y <= middleTexts.getRectangle().getMaxY()) {
                continue;
            }
            candidates.add(position);
        }
        temp.clear();
        int minY = middleTexts.getRectangle().y;
        int maxY = middleTexts.getRectangle().y + middleTexts.getRectangle().height;

        //从上往下找相邻
        for (int i = 0; i < candidates.size(); i++) {
            if (Math.abs(candidates.get(i).getRectangle().y - maxY) < linegap) {
                maxY = candidates.get(i).getRectangle().maxY();
                temp.add(candidates.get(i));
            }
        }
        //从下往上找相邻
        for (int i = candidates.size() - 1; i >= 0; i--) {
            if (Math.abs(minY - candidates.get(i).getRectangle().maxY()) < linegap) {
                minY = candidates.get(i).getRectangle().y;
                temp.add(candidates.get(i));
            }
        }

        temp.add(middleTexts);
        return PdfTextPositionHelper.merge(temp);

    }

    private static void formatValue(JSONObject jsonObject, Content content, String valuestr) {

        try {
            if (StringUtils.isBlank(valuestr)) {
                return;
            }
            jsonObject.put(content.getJsonKey(), content.formatValue(valuestr));
        } catch (Exception ex) {
            String str = jsonObject.toJSONString() + "\r\n" + content.toString() + "\r\n" + valuestr;
            logger.error(str, ex);
            throw ex;
        }

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

            if (content.checkPage(textPosition.getPageIndex())
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

//        if (candidateText.getText().contains("日0时")) {//021年03月13日0时起至2022年03月12日24时止
//            candidateText.setText(candidateText.getText().replace("日0时", "日00时"));
//            candidateText.setTrimedText(null);
//        }

        String valueCandidateStr = candidateText.getTrimedText();
        if (false == candidateText.getStandaredized()) {
            String str;
            valueCandidateStr = (str = InsOrderStructor.standaredize(valueCandidateStr)) == null ? valueCandidateStr : str;
        }

        Matcher matcher = content.getLabelSignsPattern().matcher(valueCandidateStr);
        if (matcher.find()) {
            int endIndex = matcher.end();
            while (matcher.find()) {
                endIndex = matcher.end();
            }
            valueCandidateStr = valueCandidateStr.substring(endIndex);

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

package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;
import net.fgq.study.pdf.PdfTextPositionHelper;
import net.fgq.study.pdf.TextPositionEx;

import java.util.List;

/**
 * 太平洋辅助类
 * Created by fengguoqiang 2021/4/19
 */
public class TPYHelper {

    public static void adjust(List<PdfTextPosition> textPositions) {
        PdfTextPosition text;
        for (int i = 0; i < textPositions.size(); i++) {
            text = textPositions.get(i);
            if (text.getTrimedText().startsWith("保险单号")) {

                List<PdfTextPosition> rights = PdfTextPositionHelper.getRightAll(textPositions, text, true);
                if (rights.size() == 0) {

                    for (int j = 0; j < textPositions.size(); j++) {
                        if (PdfTextPositionHelper.checkBollowNeighbor(text, textPositions.get(j), textPositions)) {
                            int x = text.getRectangle().maxX();
                            int y = text.getRectangle().y;
                            text = textPositions.get(j);

                            for (TextPositionEx textPosition : text.getTextPositions()) {
                                textPosition.getRectangle().x += ((x - text.getRectangle().x));
                                textPosition.getRectangle().y += ((y - text.getRectangle().y));
                            }

                            text.getRectangle().x = x;
                            text.getRectangle().y = y;
                            return;
                        }
                    }

                }

            }

        }
    }

}



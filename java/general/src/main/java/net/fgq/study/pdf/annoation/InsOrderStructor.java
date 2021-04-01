package net.fgq.study.pdf.annoation;

import net.fgq.study.pdf.PdfTextPosition;

import java.util.List;

/**
 * Created by fengguoqiang 2021/3/29
 */
public class InsOrderStructor {

    public static void struct(List<PdfTextPosition> textPositions, InsCompanyType insCompanyType) {
        switch (insCompanyType) {
            case tpyang:
                structTPY(textPositions);
                return;
        }
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
}

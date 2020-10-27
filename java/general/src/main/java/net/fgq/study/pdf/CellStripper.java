package net.fgq.study.pdf;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class CellStripper {

    public static List<Cell> stripper(List<Line> lines) throws Exception {

        List<Cell> cells = new ArrayList<>();

        removeDumplicateLine(lines);

        List<Line> crosslines = lines.stream().filter(x -> {
            return x.getDirectEnum() == Line.DirectEnum.crosswise;
        }).collect(Collectors.toList());
        List<Line> verticallines = lines.stream().filter(x -> {
            return x.getDirectEnum() == Line.DirectEnum.vertical;
        }).collect(Collectors.toList());

        Collections.sort(crosslines);
        Collections.sort(verticallines);

        Line lineC1;//上方水平线
        Line lineV1;//左侧垂直线
        Line lineC2;//下方水平线
        Line lineV2;//右侧垂直线

        for (int c = 0; c < crosslines.size(); c++) {
            lineC1 = crosslines.get(c);
            for (int v = 0; v < verticallines.size(); v++) {
                lineV1 = verticallines.get(v);
                if (false == lineC1.checkCross(lineV1)) {
                    continue;
                }
                lineV2 = null;
                for (int v2 = v + 1; v2 < verticallines.size(); v2++) {
                    lineV2 = verticallines.get(v2);
                    if (false == lineC1.checkCross(lineV2)) {
                        continue;
                    }
                    lineC2 = null;
                    for (int c2 = c + 1; c2 < crosslines.size(); c2++) {
                        lineC2 = crosslines.get(c2);
                        if (false == lineV1.checkCross(lineC2) && false == lineV2.checkCross(lineC2)) {
                            continue;
                        }
                        if (lineC1 != null && lineC2 != null && lineV1 != null && lineV2 != null) {

                            cells.add(new Cell(lineC1, lineV1, lineC2, lineV2));
                        }
                    }

                }

            }
        }
        removeSimilarityCell(cells);
        return cells;
    }

    private static void removeSimilarityCell(List<Cell> cells) {
        for (int i = 0; i < cells.size(); i++) {

            for (int j = i + 1; j < cells.size(); j++) {
                if (cells.get(i).checkSimilarity(cells.get(j))) {
                    cells.remove(j);
                    j -= 1;
                    continue;
                }
            }
        }
    }

    private static void removeDumplicateLine(List<Line> lines) {
        for (int i = 0; i < lines.size(); i++) {

            for (int j = i + 1; j < lines.size(); j++) {
                int r = lines.get(i).checkDumplicated(lines.get(j));
                if (r == 0 || r == 1) {
                    lines.remove(j);
                    j -= 1;
                    continue;
                }
                if (r == 2) {
                    lines.remove(i);
                    i -= 1;
                    break;
                }

            }
        }
    }
}


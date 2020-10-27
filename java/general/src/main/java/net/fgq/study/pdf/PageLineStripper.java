package net.fgq.study.pdf;

import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.rendering.PageDrawer;
import org.apache.pdfbox.rendering.PageDrawerParameters;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class PageLineStripper extends PageDrawer {

    //todo need to del
    public PDPageContentStream pageContentStream;

    private List<Line> lines = new ArrayList<>();

    public List<Line> getLines() {
        return lines;
    }

    public void setLines(List<Line> lines) {
        this.lines = lines;
    }

    public void startPage() {
        lines.clear();
    }

    /**
     * Constructor.
     *
     * @param parameters Parameters for page drawing.
     * @throws IOException If there is an error loading properties from the file.
     */
    public PageLineStripper(PageDrawerParameters parameters) throws IOException {
        super(parameters);
    }

    private Float lastx = null;
    private Float lasty = null;

    @Override
    public void moveTo(float x, float y) {
        super.moveTo(x, y);
        lastx = x;
        lasty = y;
        try {
            pageContentStream.moveTo(x, y);
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println("moveTo:x" + String.valueOf(x) + "  y:" + String.valueOf(y));

    }

    @Override
    public void lineTo(float x, float y) {
        super.lineTo(x, y);
        if (lastx != null && lasty != null) {
            lines.add(new Line(
                    Float.min(x, lastx),
                    Float.min(y, lasty),
                    Float.max(x, lastx),
                    Float.max(y, lasty)));
        }
        lastx = x;
        lasty = y;
        try {
            pageContentStream.lineTo(x, y);
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println("lineTo:x" + String.valueOf(x) + "  y:" + String.valueOf(y));

    }
}

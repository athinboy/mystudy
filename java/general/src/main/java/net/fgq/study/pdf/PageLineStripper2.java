package net.fgq.study.pdf;

import org.apache.pdfbox.contentstream.PDFGraphicsStreamEngine;
import org.apache.pdfbox.cos.COSName;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.graphics.image.PDImage;
import org.apache.pdfbox.rendering.PageDrawer;
import org.apache.pdfbox.rendering.PageDrawerParameters;

import java.awt.geom.Point2D;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by fengguoqiang 2020/10/26
 */
public class PageLineStripper2 extends PDFGraphicsStreamEngine {

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

    public PageLineStripper2(PDPage page) {
        super(page);
    }

    private Float lastx = null;
    private Float lasty = null;

    @Override
    public void moveTo(float x, float y) {

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

    @Override
    public void appendRectangle(Point2D p0, Point2D p1, Point2D p2, Point2D p3) throws IOException {

    }

    @Override
    public void drawImage(PDImage pdImage) throws IOException {

    }

    @Override
    public void clip(int windingRule) throws IOException {

    }

    @Override
    public void curveTo(float x1, float y1, float x2, float y2, float x3, float y3) throws IOException {

    }

    @Override
    public Point2D getCurrentPoint() throws IOException {
        return null;
    }

    @Override
    public void closePath() throws IOException {

    }

    @Override
    public void endPath() throws IOException {

    }

    @Override
    public void strokePath() throws IOException {

    }

    @Override
    public void fillPath(int windingRule) throws IOException {

    }

    @Override
    public void fillAndStrokePath(int windingRule) throws IOException {

    }

    @Override
    public void shadingFill(COSName shadingName) throws IOException {

    }
}

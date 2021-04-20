package net.fgq.study.pdf;

/**
 * Created by fengguoqiang 2021/4/13
 */
public class TextBlock extends PdfTextPosition {

    public TextBlock(int pageIndex, String text, PdfRectangle rectangle) {
        super(pageIndex, text, rectangle);
    }

    public TextBlock(int pageIndex, String text, int x, int y, int width, int height) {
        super(pageIndex, text, x, y, width, height);
    }

    public TextBlock(TextPositionEx textPositionEx) {
        super(textPositionEx);
    }

    @Override
    protected void sortTextPosition() {
        this.getTextPositions().sort(TextPositionExHelper.getYXSortCompare());
    }

    /**
     * 按照文本顺序附加合并
     * <p>
     * 支持：-为空白
     * 1、
     * 姓名
     * 2、
     * 车牌
     * 号码
     * 3、
     * -车牌号
     * --码
     * 不支持：
     * 1、
     * AAAAA
     * --B
     * -CCC
     * --C
     *
     * @param ox
     * @return
     */
    public boolean appendMerge(TextPositionEx ox) {
        //todo 未完全实现功能。
        if (this.getLineNumber() == 1) {
            if (super.appendHoriz(ox)) {
                return true;
            }
            if (this.getTextPositions().get(0).checkSameLeft(ox)) {
                this.getTextPositions().add(ox);
                this.reGenerate();
                this.setLineNumber(this.getLineNumber() + 1);
            } else {
                return false;
            }
        } else {
            if (this.getTextPositions().get(this.getTextPositions().size() - 1).checkSameLine(ox)) {

                if (ox.getRectangle().x >= this.getRectangle().maxX()) {
                    return false;
                }
                if (ox.getRectangle().x < this.getRectangle().x) {
                    return false;
                }
                this.getTextPositions().add(ox);
                this.reGenerate();
                return true;

            } else {

                if (this.getTextPositions().get(0).checkSameLeft(ox)) {
                    this.getTextPositions().add(ox);
                    this.reGenerate();
                    this.setLineNumber(this.getLineNumber() + 1);
                    return true;
                } else {
                    return false;
                }

            }
        }
        return false;

    }
}

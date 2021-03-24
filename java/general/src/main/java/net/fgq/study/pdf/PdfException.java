package net.fgq.study.pdf;

/**
 * Created by fengguoqiang 2020/10/27
 */
public class PdfException extends RuntimeException {
    public PdfException(String message) {
        super(message);
    }

    public static PdfException getInstance(String message) {
        return new PdfException(message);
    }
}

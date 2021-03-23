package net.fgq.study.pdf.test;

import com.spire.pdf.PdfDocument;
import com.spire.pdf.PdfPageBase;
import com.spire.pdf.widget.PdfPageCollection;

import java.io.*;

/**
 * Created by fengguoqiang 2020/8/28
 */
public class One {

    public static void main(String[] args) {

        PdfDocument doc = new PdfDocument();
        doc.loadFromFile("D:\\fgq\\temp\\222.pdf");
        PdfPageCollection pageCollection = doc.getPages();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < pageCollection.getCount(); i++) {
            sb.append(pageCollection.get(i).extractText());
        }
        System.out.println(sb.toString());

    }

}

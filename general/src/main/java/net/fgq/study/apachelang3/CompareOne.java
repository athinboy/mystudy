package net.fgq.study.apachelang3;

import org.apache.commons.lang3.builder.CompareToBuilder;

public class CompareOne {

    //region Getter And Setter
    // endregion

    public static void main(String[] args) {
        org.apache.commons.lang3.builder.CompareToBuilder compareToBuilder = new CompareToBuilder();
        compareToBuilder.append(23,4).toComparison();

    }


}

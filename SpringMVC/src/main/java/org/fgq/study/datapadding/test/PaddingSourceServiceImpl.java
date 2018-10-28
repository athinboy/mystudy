package org.fgq.study.datapadding.test;

/**
 * @author fenggqc
 * @create 2018-10-24 17:38
 **/


public class PaddingSourceServiceImpl implements PaddingSourceService {

    //region Getter And Setter
    // endregion


    @Override
    public String getServiceA() {
        return "ServiceA";
    }

    @Override
    public String getServiceParaA(String a) {
        return "getServiceParaA:" + (a == null ? "" : a);
    }
}

package org.fgq.study.datapadding;

import org.springframework.stereotype.Component;

/**
 * @author fenggqc
 * @create 2018-10-24 17:38
 **/


@Component
public class PaddingSourceServiceImpl implements PaddingSourceService {

    //region Getter And Setter
    // endregion


    @Override
    public String getServiceA() {
        return "ServiceAValue";
    }

    @Override
    public String getServiceParaA(String a) {
        return "ServiceParaAValue:" + (a == null ? "" : a);
    }
}

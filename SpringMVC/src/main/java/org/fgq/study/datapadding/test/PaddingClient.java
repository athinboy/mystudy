package org.fgq.study.datapadding.test;

import org.fgq.study.datapadding.annotation.NeedPad;

/**
 * @author fenggqc
 * @create 2018-10-24 15:06
 **/


public class PaddingClient {


    @NeedPad(SourceClass = PaddingSource.class,
            SourceMethod = "PaddingSource", PadSort = 2)
    private String staticA;

    @NeedPad(SourceClass = PaddingSourceService.class,
            SourceMethod = "getServiceA", ParaField = {})
    private String serviceA;

    @NeedPad(SourceClass = PaddingSourceService.class,
            SourceMethod = "getServiceParaA", ParaField = {"staticA"})
    private String serviceParaA;


    private String otherfield;


    //region Getter And Setter


    public String getServiceA() {
        return serviceA;
    }

    public void setServiceA(String serviceA) {
        this.serviceA = serviceA;
    }

    public String getOtherfield() {
        return otherfield;
    }

    public void setOtherfield(String otherfield) {
        this.otherfield = otherfield;
    }

    public String getStaticA() {
        return staticA;
    }

    public void setStaticA(String staticA) {
        this.staticA = staticA;
    }


    // endregion

}

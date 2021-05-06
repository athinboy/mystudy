package net.fgq.study.pdf.bean;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;

/**
 * 商业险明细
 * ins_commercial_insurance_detail
 *
 * @author: FGQ 2020-09-02
 */
@Data
public class CommercialInsuranceDetail implements Serializable {

    /**
     * 商业险保单Id
     */
    private Long id;

    /**
     *
     */
    private Long commercialInsuranceId;

    /**
     * 承保险种
     */
    private String insuranceType;

    /**
     * 保险金额/责任限额
     */
    private String liability;

    /**
     * 保险费（元）
     */
    private BigDecimal fee;

    /**
     * 是否投保不计免赔
     */
    private String noDeductible;

    /**
     * 保险费小计（元）
     */
    private BigDecimal sumFee;

    /**
     * 绝对免赔额
     */
    private String noDeductibleFee;


    /**
     * 不计免赔率
     */
    private String noDeductiblePercent;

    private static final long serialVersionUID = 1L;
}

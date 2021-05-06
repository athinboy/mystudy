package net.fgq.study.pdf.bean;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

/**
 * 商业险保单
 * ins_commercial_insurance
 *
 * @author: FGQ 2020-09-04
 */
@Data
public class CommercialInsurance implements Serializable {

    /**
     *
     */
    private Long id;

    /**
     * 保单号
     */
    private String policyNumber;

    /**
     * 保险公司Id
     */
    private Long insuranceCompanyId;

    /**
     * 保险公司CODE
     */
    private String insuranceCompanyCode;
    /**
     * 生效日期
     */
    private Date effectiveDate;

    /**
     * 失效日期
     */
    private Date expireDate;

    /**
     * 输入方式: 0:输入、1:识别
     */
    private String inputType;

    /**
     *
     */
    private String fileId;

    /**
     * 文件名称
     */
    private String fileName;

    /**
     * 被保险人姓名
     */
    private String insuredName;

    /**
     * 手机号
     */
    private String insuredPhone;

    /**
     * 证件号
     */
    private String insuredIDNumer;

    /**
     * 性别
     */
    private String insuredSex;

    /**
     * 出生日期
     */
    private String insuredBirthday;

    /**
     * E-Mail
     */
    private String insuredEMail;

    /**
     * 通讯地址
     */
    private String insuredContactAddress;

    /**
     * 车牌号
     */
    private String platNum;

    /**
     * 车架号
     */
    private String vin;

    /**
     * 发动机号
     */
    private String engineNumber;

    /**
     * 初登日期
     */
    private String initialRegistration;

    /**
     * 厂牌型号
     */
    private String factoryPlateModel;

    /**
     * 核定载质量
     */
    private String approvedLoad;

    /**
     * 核定载客人数
     */
    private String approvedPassengersCapacity;

    /**
     * 使用性质
     */
    private String useCharacter;

    /**
     * 机动车种类
     */
    private String vehicleType;

    /**
     * 排量
     */
    private String displacement;

    /**
     * 功率
     */
    private String capacityFactor;

    /**
     * 车损险每次事故绝对免赔额
     */
    private String deductible;

    /**
     * 商业险保险费合计
     */
    private BigDecimal insuranceFee;

    /**
     * 银行流水号
     */
    private String bankSerialNumber;

    /**
     * 收费确认时间
     */
    private Date chargeConfirmationTime;

    /**
     * 投保确认时间
     */
    private Date insuranceConfirmationTime;

    /**
     *
     */
    private Long createPerson;

    /**
     *
     */
    private String createPersonName;

    /**
     *
     */
    private Date createTime;

    /**
     * 经办人
     */
    private String agentName;

    /**
     * 出单日期
     */
    private Date agentDate;

    private List<CommercialInsuranceDetail> details;

    private static final long serialVersionUID = 1L;
}

package net.fgq.study.pdf.bean;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

/**
 * 交强险保单
 * ins_compulsory_insurance
 *
 * @author: FGQ 2020-09-04
 */
@Data
public class CompulsoryInsurance implements Serializable {

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
     * 死亡伤残赔偿限额
     */
    private String deathCompensation;

    /**
     * 无责任死亡伤残赔偿限额
     */
    private String noLiabilityDeathCompensation;

    /**
     * 医疗费用赔偿限额
     */
    private String medicalCompensation;

    /**
     * 医疗费用赔偿限额
     */
    private String noLiabilityMedicalCompensation;

    /**
     * 财产损失赔偿限额
     */
    private String propertyCompensation;

    /**
     * 无责任财产损失赔偿限额
     */
    private String noLiabilityPropertyCompensation;

    /**
     * 与道路交通安全违法行为和道路交通事故相联系的浮动比率
     */
    private String floatingRate;

    /**
     * 交强险保费合计
     */
    private String totalCompulsoryFee;

    /**
     * 车船税费用合计
     */
    private BigDecimal vehicleTaxFee;

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
     * 代收车船税-整备质量
     */
    private String vtCurbWeight;

    /**
     * 代收车船税-纳税人识别号
     */
    private String vtTaxpayerIdentification;

    /**
     * 代收车船税-当年应缴
     */
    private String vtCurrentPayable;

    /**
     * 代收车船税-往年应缴
     */
    private String vtPastPayable;

    /**
     * 代收车船税-滞纳金
     */
    private String vtLateFee;

    /**
     * 代收车船税-完税凭证号
     */
    private String vtPaymentNo;

    /**
     * 经办人
     */
    private String agentName;

    /**
     * 出单日期
     */
    private Date agentDate;

    private static final long serialVersionUID = 1L;
}

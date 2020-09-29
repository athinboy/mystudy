package org.fgq.study.mbgmapper.domain.ba;

import java.io.Serializable;
import java.util.Date;

public class BaSaleorg implements Serializable {
    private String saleorgId;

    private String partnerId;

    private String saleorgName;

    private String saleorgType;

    private String saleorgSname;

    private String saleorgEngname;

    private String saleorgAddress;

    private String saleorgPostid;

    private String saleorgLinkman;

    private String saleorgTelphone;

    private String saleorgEmail;

    private String saleorgUrl;

    private Boolean delflag;

    private String creator;

    private Date createTime;

    private String modifier;

    private Date modifyTime;

    private String ipAddress;

    private static final long serialVersionUID = 1L;

    public String getSaleorgId() {
        return saleorgId;
    }

    public void setSaleorgId(String saleorgId) {
        this.saleorgId = saleorgId;
    }

    public String getPartnerId() {
        return partnerId;
    }

    public void setPartnerId(String partnerId) {
        this.partnerId = partnerId;
    }

    public String getSaleorgName() {
        return saleorgName;
    }

    public void setSaleorgName(String saleorgName) {
        this.saleorgName = saleorgName;
    }

    public String getSaleorgType() {
        return saleorgType;
    }

    public void setSaleorgType(String saleorgType) {
        this.saleorgType = saleorgType;
    }

    public String getSaleorgSname() {
        return saleorgSname;
    }

    public void setSaleorgSname(String saleorgSname) {
        this.saleorgSname = saleorgSname;
    }

    public String getSaleorgEngname() {
        return saleorgEngname;
    }

    public void setSaleorgEngname(String saleorgEngname) {
        this.saleorgEngname = saleorgEngname;
    }

    public String getSaleorgAddress() {
        return saleorgAddress;
    }

    public void setSaleorgAddress(String saleorgAddress) {
        this.saleorgAddress = saleorgAddress;
    }

    public String getSaleorgPostid() {
        return saleorgPostid;
    }

    public void setSaleorgPostid(String saleorgPostid) {
        this.saleorgPostid = saleorgPostid;
    }

    public String getSaleorgLinkman() {
        return saleorgLinkman;
    }

    public void setSaleorgLinkman(String saleorgLinkman) {
        this.saleorgLinkman = saleorgLinkman;
    }

    public String getSaleorgTelphone() {
        return saleorgTelphone;
    }

    public void setSaleorgTelphone(String saleorgTelphone) {
        this.saleorgTelphone = saleorgTelphone;
    }

    public String getSaleorgEmail() {
        return saleorgEmail;
    }

    public void setSaleorgEmail(String saleorgEmail) {
        this.saleorgEmail = saleorgEmail;
    }

    public String getSaleorgUrl() {
        return saleorgUrl;
    }

    public void setSaleorgUrl(String saleorgUrl) {
        this.saleorgUrl = saleorgUrl;
    }

    public Boolean getDelflag() {
        return delflag;
    }

    public void setDelflag(Boolean delflag) {
        this.delflag = delflag;
    }

    public String getCreator() {
        return creator;
    }

    public void setCreator(String creator) {
        this.creator = creator;
    }

    public Date getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Date createTime) {
        this.createTime = createTime;
    }

    public String getModifier() {
        return modifier;
    }

    public void setModifier(String modifier) {
        this.modifier = modifier;
    }

    public Date getModifyTime() {
        return modifyTime;
    }

    public void setModifyTime(Date modifyTime) {
        this.modifyTime = modifyTime;
    }

    public String getIpAddress() {
        return ipAddress;
    }

    public void setIpAddress(String ipAddress) {
        this.ipAddress = ipAddress;
    }
}
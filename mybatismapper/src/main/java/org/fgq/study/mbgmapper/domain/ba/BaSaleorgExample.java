package org.fgq.study.mbgmapper.domain.ba;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class BaSaleorgExample {
    protected String orderByClause;

    protected boolean distinct;

    protected List<Criteria> oredCriteria;

    public BaSaleorgExample() {
        oredCriteria = new ArrayList<Criteria>();
    }

    public void setOrderByClause(String orderByClause) {
        this.orderByClause = orderByClause;
    }

    public String getOrderByClause() {
        return orderByClause;
    }

    public void setDistinct(boolean distinct) {
        this.distinct = distinct;
    }

    public boolean isDistinct() {
        return distinct;
    }

    public List<Criteria> getOredCriteria() {
        return oredCriteria;
    }

    public void or(Criteria criteria) {
        oredCriteria.add(criteria);
    }

    public Criteria or() {
        Criteria criteria = createCriteriaInternal();
        oredCriteria.add(criteria);
        return criteria;
    }

    public Criteria createCriteria() {
        Criteria criteria = createCriteriaInternal();
        if (oredCriteria.size() == 0) {
            oredCriteria.add(criteria);
        }
        return criteria;
    }

    protected Criteria createCriteriaInternal() {
        Criteria criteria = new Criteria();
        return criteria;
    }

    public void clear() {
        oredCriteria.clear();
        orderByClause = null;
        distinct = false;
    }

    protected abstract static class GeneratedCriteria {
        protected List<Criterion> criteria;

        protected GeneratedCriteria() {
            super();
            criteria = new ArrayList<Criterion>();
        }

        public boolean isValid() {
            return criteria.size() > 0;
        }

        public List<Criterion> getAllCriteria() {
            return criteria;
        }

        public List<Criterion> getCriteria() {
            return criteria;
        }

        protected void addCriterion(String condition) {
            if (condition == null) {
                throw new RuntimeException("Value for condition cannot be null");
            }
            criteria.add(new Criterion(condition));
        }

        protected void addCriterion(String condition, Object value, String property) {
            if (value == null) {
                throw new RuntimeException("Value for " + property + " cannot be null");
            }
            criteria.add(new Criterion(condition, value));
        }

        protected void addCriterion(String condition, Object value1, Object value2, String property) {
            if (value1 == null || value2 == null) {
                throw new RuntimeException("Between values for " + property + " cannot be null");
            }
            criteria.add(new Criterion(condition, value1, value2));
        }

        public Criteria andSaleorgIdIsNull() {
            addCriterion("saleorg_id is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdIsNotNull() {
            addCriterion("saleorg_id is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdEqualTo(String value) {
            addCriterion("saleorg_id =", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdNotEqualTo(String value) {
            addCriterion("saleorg_id <>", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdGreaterThan(String value) {
            addCriterion("saleorg_id >", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_id >=", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdLessThan(String value) {
            addCriterion("saleorg_id <", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdLessThanOrEqualTo(String value) {
            addCriterion("saleorg_id <=", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdLike(String value) {
            addCriterion("saleorg_id like", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdNotLike(String value) {
            addCriterion("saleorg_id not like", value, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdIn(List<String> values) {
            addCriterion("saleorg_id in", values, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdNotIn(List<String> values) {
            addCriterion("saleorg_id not in", values, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdBetween(String value1, String value2) {
            addCriterion("saleorg_id between", value1, value2, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdNotBetween(String value1, String value2) {
            addCriterion("saleorg_id not between", value1, value2, "saleorgId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdIsNull() {
            addCriterion("partner_id is null");
            return (Criteria) this;
        }

        public Criteria andPartnerIdIsNotNull() {
            addCriterion("partner_id is not null");
            return (Criteria) this;
        }

        public Criteria andPartnerIdEqualTo(String value) {
            addCriterion("partner_id =", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdNotEqualTo(String value) {
            addCriterion("partner_id <>", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdGreaterThan(String value) {
            addCriterion("partner_id >", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdGreaterThanOrEqualTo(String value) {
            addCriterion("partner_id >=", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdLessThan(String value) {
            addCriterion("partner_id <", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdLessThanOrEqualTo(String value) {
            addCriterion("partner_id <=", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdLike(String value) {
            addCriterion("partner_id like", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdNotLike(String value) {
            addCriterion("partner_id not like", value, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdIn(List<String> values) {
            addCriterion("partner_id in", values, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdNotIn(List<String> values) {
            addCriterion("partner_id not in", values, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdBetween(String value1, String value2) {
            addCriterion("partner_id between", value1, value2, "partnerId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdNotBetween(String value1, String value2) {
            addCriterion("partner_id not between", value1, value2, "partnerId");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameIsNull() {
            addCriterion("saleorg_name is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameIsNotNull() {
            addCriterion("saleorg_name is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameEqualTo(String value) {
            addCriterion("saleorg_name =", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameNotEqualTo(String value) {
            addCriterion("saleorg_name <>", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameGreaterThan(String value) {
            addCriterion("saleorg_name >", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_name >=", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameLessThan(String value) {
            addCriterion("saleorg_name <", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameLessThanOrEqualTo(String value) {
            addCriterion("saleorg_name <=", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameLike(String value) {
            addCriterion("saleorg_name like", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameNotLike(String value) {
            addCriterion("saleorg_name not like", value, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameIn(List<String> values) {
            addCriterion("saleorg_name in", values, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameNotIn(List<String> values) {
            addCriterion("saleorg_name not in", values, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameBetween(String value1, String value2) {
            addCriterion("saleorg_name between", value1, value2, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameNotBetween(String value1, String value2) {
            addCriterion("saleorg_name not between", value1, value2, "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeIsNull() {
            addCriterion("saleorg_type is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeIsNotNull() {
            addCriterion("saleorg_type is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeEqualTo(String value) {
            addCriterion("saleorg_type =", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeNotEqualTo(String value) {
            addCriterion("saleorg_type <>", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeGreaterThan(String value) {
            addCriterion("saleorg_type >", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_type >=", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeLessThan(String value) {
            addCriterion("saleorg_type <", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeLessThanOrEqualTo(String value) {
            addCriterion("saleorg_type <=", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeLike(String value) {
            addCriterion("saleorg_type like", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeNotLike(String value) {
            addCriterion("saleorg_type not like", value, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeIn(List<String> values) {
            addCriterion("saleorg_type in", values, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeNotIn(List<String> values) {
            addCriterion("saleorg_type not in", values, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeBetween(String value1, String value2) {
            addCriterion("saleorg_type between", value1, value2, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeNotBetween(String value1, String value2) {
            addCriterion("saleorg_type not between", value1, value2, "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameIsNull() {
            addCriterion("saleorg_sname is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameIsNotNull() {
            addCriterion("saleorg_sname is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameEqualTo(String value) {
            addCriterion("saleorg_sname =", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameNotEqualTo(String value) {
            addCriterion("saleorg_sname <>", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameGreaterThan(String value) {
            addCriterion("saleorg_sname >", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_sname >=", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameLessThan(String value) {
            addCriterion("saleorg_sname <", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameLessThanOrEqualTo(String value) {
            addCriterion("saleorg_sname <=", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameLike(String value) {
            addCriterion("saleorg_sname like", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameNotLike(String value) {
            addCriterion("saleorg_sname not like", value, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameIn(List<String> values) {
            addCriterion("saleorg_sname in", values, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameNotIn(List<String> values) {
            addCriterion("saleorg_sname not in", values, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameBetween(String value1, String value2) {
            addCriterion("saleorg_sname between", value1, value2, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameNotBetween(String value1, String value2) {
            addCriterion("saleorg_sname not between", value1, value2, "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameIsNull() {
            addCriterion("saleorg_engname is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameIsNotNull() {
            addCriterion("saleorg_engname is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameEqualTo(String value) {
            addCriterion("saleorg_engname =", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameNotEqualTo(String value) {
            addCriterion("saleorg_engname <>", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameGreaterThan(String value) {
            addCriterion("saleorg_engname >", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_engname >=", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameLessThan(String value) {
            addCriterion("saleorg_engname <", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameLessThanOrEqualTo(String value) {
            addCriterion("saleorg_engname <=", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameLike(String value) {
            addCriterion("saleorg_engname like", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameNotLike(String value) {
            addCriterion("saleorg_engname not like", value, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameIn(List<String> values) {
            addCriterion("saleorg_engname in", values, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameNotIn(List<String> values) {
            addCriterion("saleorg_engname not in", values, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameBetween(String value1, String value2) {
            addCriterion("saleorg_engname between", value1, value2, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameNotBetween(String value1, String value2) {
            addCriterion("saleorg_engname not between", value1, value2, "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressIsNull() {
            addCriterion("saleorg_address is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressIsNotNull() {
            addCriterion("saleorg_address is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressEqualTo(String value) {
            addCriterion("saleorg_address =", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressNotEqualTo(String value) {
            addCriterion("saleorg_address <>", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressGreaterThan(String value) {
            addCriterion("saleorg_address >", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_address >=", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressLessThan(String value) {
            addCriterion("saleorg_address <", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressLessThanOrEqualTo(String value) {
            addCriterion("saleorg_address <=", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressLike(String value) {
            addCriterion("saleorg_address like", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressNotLike(String value) {
            addCriterion("saleorg_address not like", value, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressIn(List<String> values) {
            addCriterion("saleorg_address in", values, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressNotIn(List<String> values) {
            addCriterion("saleorg_address not in", values, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressBetween(String value1, String value2) {
            addCriterion("saleorg_address between", value1, value2, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressNotBetween(String value1, String value2) {
            addCriterion("saleorg_address not between", value1, value2, "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidIsNull() {
            addCriterion("saleorg_postid is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidIsNotNull() {
            addCriterion("saleorg_postid is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidEqualTo(String value) {
            addCriterion("saleorg_postid =", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidNotEqualTo(String value) {
            addCriterion("saleorg_postid <>", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidGreaterThan(String value) {
            addCriterion("saleorg_postid >", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_postid >=", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidLessThan(String value) {
            addCriterion("saleorg_postid <", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidLessThanOrEqualTo(String value) {
            addCriterion("saleorg_postid <=", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidLike(String value) {
            addCriterion("saleorg_postid like", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidNotLike(String value) {
            addCriterion("saleorg_postid not like", value, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidIn(List<String> values) {
            addCriterion("saleorg_postid in", values, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidNotIn(List<String> values) {
            addCriterion("saleorg_postid not in", values, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidBetween(String value1, String value2) {
            addCriterion("saleorg_postid between", value1, value2, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidNotBetween(String value1, String value2) {
            addCriterion("saleorg_postid not between", value1, value2, "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanIsNull() {
            addCriterion("saleorg_linkman is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanIsNotNull() {
            addCriterion("saleorg_linkman is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanEqualTo(String value) {
            addCriterion("saleorg_linkman =", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanNotEqualTo(String value) {
            addCriterion("saleorg_linkman <>", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanGreaterThan(String value) {
            addCriterion("saleorg_linkman >", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_linkman >=", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanLessThan(String value) {
            addCriterion("saleorg_linkman <", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanLessThanOrEqualTo(String value) {
            addCriterion("saleorg_linkman <=", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanLike(String value) {
            addCriterion("saleorg_linkman like", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanNotLike(String value) {
            addCriterion("saleorg_linkman not like", value, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanIn(List<String> values) {
            addCriterion("saleorg_linkman in", values, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanNotIn(List<String> values) {
            addCriterion("saleorg_linkman not in", values, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanBetween(String value1, String value2) {
            addCriterion("saleorg_linkman between", value1, value2, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanNotBetween(String value1, String value2) {
            addCriterion("saleorg_linkman not between", value1, value2, "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneIsNull() {
            addCriterion("saleorg_telphone is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneIsNotNull() {
            addCriterion("saleorg_telphone is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneEqualTo(String value) {
            addCriterion("saleorg_telphone =", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneNotEqualTo(String value) {
            addCriterion("saleorg_telphone <>", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneGreaterThan(String value) {
            addCriterion("saleorg_telphone >", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_telphone >=", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneLessThan(String value) {
            addCriterion("saleorg_telphone <", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneLessThanOrEqualTo(String value) {
            addCriterion("saleorg_telphone <=", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneLike(String value) {
            addCriterion("saleorg_telphone like", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneNotLike(String value) {
            addCriterion("saleorg_telphone not like", value, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneIn(List<String> values) {
            addCriterion("saleorg_telphone in", values, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneNotIn(List<String> values) {
            addCriterion("saleorg_telphone not in", values, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneBetween(String value1, String value2) {
            addCriterion("saleorg_telphone between", value1, value2, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneNotBetween(String value1, String value2) {
            addCriterion("saleorg_telphone not between", value1, value2, "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailIsNull() {
            addCriterion("saleorg_email is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailIsNotNull() {
            addCriterion("saleorg_email is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailEqualTo(String value) {
            addCriterion("saleorg_email =", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailNotEqualTo(String value) {
            addCriterion("saleorg_email <>", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailGreaterThan(String value) {
            addCriterion("saleorg_email >", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_email >=", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailLessThan(String value) {
            addCriterion("saleorg_email <", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailLessThanOrEqualTo(String value) {
            addCriterion("saleorg_email <=", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailLike(String value) {
            addCriterion("saleorg_email like", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailNotLike(String value) {
            addCriterion("saleorg_email not like", value, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailIn(List<String> values) {
            addCriterion("saleorg_email in", values, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailNotIn(List<String> values) {
            addCriterion("saleorg_email not in", values, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailBetween(String value1, String value2) {
            addCriterion("saleorg_email between", value1, value2, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailNotBetween(String value1, String value2) {
            addCriterion("saleorg_email not between", value1, value2, "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlIsNull() {
            addCriterion("saleorg_url is null");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlIsNotNull() {
            addCriterion("saleorg_url is not null");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlEqualTo(String value) {
            addCriterion("saleorg_url =", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlNotEqualTo(String value) {
            addCriterion("saleorg_url <>", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlGreaterThan(String value) {
            addCriterion("saleorg_url >", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlGreaterThanOrEqualTo(String value) {
            addCriterion("saleorg_url >=", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlLessThan(String value) {
            addCriterion("saleorg_url <", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlLessThanOrEqualTo(String value) {
            addCriterion("saleorg_url <=", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlLike(String value) {
            addCriterion("saleorg_url like", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlNotLike(String value) {
            addCriterion("saleorg_url not like", value, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlIn(List<String> values) {
            addCriterion("saleorg_url in", values, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlNotIn(List<String> values) {
            addCriterion("saleorg_url not in", values, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlBetween(String value1, String value2) {
            addCriterion("saleorg_url between", value1, value2, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlNotBetween(String value1, String value2) {
            addCriterion("saleorg_url not between", value1, value2, "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andDelflagIsNull() {
            addCriterion("delflag is null");
            return (Criteria) this;
        }

        public Criteria andDelflagIsNotNull() {
            addCriterion("delflag is not null");
            return (Criteria) this;
        }

        public Criteria andDelflagEqualTo(Boolean value) {
            addCriterion("delflag =", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagNotEqualTo(Boolean value) {
            addCriterion("delflag <>", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagGreaterThan(Boolean value) {
            addCriterion("delflag >", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagGreaterThanOrEqualTo(Boolean value) {
            addCriterion("delflag >=", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagLessThan(Boolean value) {
            addCriterion("delflag <", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagLessThanOrEqualTo(Boolean value) {
            addCriterion("delflag <=", value, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagIn(List<Boolean> values) {
            addCriterion("delflag in", values, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagNotIn(List<Boolean> values) {
            addCriterion("delflag not in", values, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagBetween(Boolean value1, Boolean value2) {
            addCriterion("delflag between", value1, value2, "delflag");
            return (Criteria) this;
        }

        public Criteria andDelflagNotBetween(Boolean value1, Boolean value2) {
            addCriterion("delflag not between", value1, value2, "delflag");
            return (Criteria) this;
        }

        public Criteria andCreatorIsNull() {
            addCriterion("creator is null");
            return (Criteria) this;
        }

        public Criteria andCreatorIsNotNull() {
            addCriterion("creator is not null");
            return (Criteria) this;
        }

        public Criteria andCreatorEqualTo(String value) {
            addCriterion("creator =", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorNotEqualTo(String value) {
            addCriterion("creator <>", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorGreaterThan(String value) {
            addCriterion("creator >", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorGreaterThanOrEqualTo(String value) {
            addCriterion("creator >=", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorLessThan(String value) {
            addCriterion("creator <", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorLessThanOrEqualTo(String value) {
            addCriterion("creator <=", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorLike(String value) {
            addCriterion("creator like", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorNotLike(String value) {
            addCriterion("creator not like", value, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorIn(List<String> values) {
            addCriterion("creator in", values, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorNotIn(List<String> values) {
            addCriterion("creator not in", values, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorBetween(String value1, String value2) {
            addCriterion("creator between", value1, value2, "creator");
            return (Criteria) this;
        }

        public Criteria andCreatorNotBetween(String value1, String value2) {
            addCriterion("creator not between", value1, value2, "creator");
            return (Criteria) this;
        }

        public Criteria andCreateTimeIsNull() {
            addCriterion("create_time is null");
            return (Criteria) this;
        }

        public Criteria andCreateTimeIsNotNull() {
            addCriterion("create_time is not null");
            return (Criteria) this;
        }

        public Criteria andCreateTimeEqualTo(Date value) {
            addCriterion("create_time =", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeNotEqualTo(Date value) {
            addCriterion("create_time <>", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeGreaterThan(Date value) {
            addCriterion("create_time >", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeGreaterThanOrEqualTo(Date value) {
            addCriterion("create_time >=", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeLessThan(Date value) {
            addCriterion("create_time <", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeLessThanOrEqualTo(Date value) {
            addCriterion("create_time <=", value, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeIn(List<Date> values) {
            addCriterion("create_time in", values, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeNotIn(List<Date> values) {
            addCriterion("create_time not in", values, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeBetween(Date value1, Date value2) {
            addCriterion("create_time between", value1, value2, "createTime");
            return (Criteria) this;
        }

        public Criteria andCreateTimeNotBetween(Date value1, Date value2) {
            addCriterion("create_time not between", value1, value2, "createTime");
            return (Criteria) this;
        }

        public Criteria andModifierIsNull() {
            addCriterion("modifier is null");
            return (Criteria) this;
        }

        public Criteria andModifierIsNotNull() {
            addCriterion("modifier is not null");
            return (Criteria) this;
        }

        public Criteria andModifierEqualTo(String value) {
            addCriterion("modifier =", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierNotEqualTo(String value) {
            addCriterion("modifier <>", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierGreaterThan(String value) {
            addCriterion("modifier >", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierGreaterThanOrEqualTo(String value) {
            addCriterion("modifier >=", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierLessThan(String value) {
            addCriterion("modifier <", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierLessThanOrEqualTo(String value) {
            addCriterion("modifier <=", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierLike(String value) {
            addCriterion("modifier like", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierNotLike(String value) {
            addCriterion("modifier not like", value, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierIn(List<String> values) {
            addCriterion("modifier in", values, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierNotIn(List<String> values) {
            addCriterion("modifier not in", values, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierBetween(String value1, String value2) {
            addCriterion("modifier between", value1, value2, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifierNotBetween(String value1, String value2) {
            addCriterion("modifier not between", value1, value2, "modifier");
            return (Criteria) this;
        }

        public Criteria andModifyTimeIsNull() {
            addCriterion("modify_time is null");
            return (Criteria) this;
        }

        public Criteria andModifyTimeIsNotNull() {
            addCriterion("modify_time is not null");
            return (Criteria) this;
        }

        public Criteria andModifyTimeEqualTo(Date value) {
            addCriterion("modify_time =", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeNotEqualTo(Date value) {
            addCriterion("modify_time <>", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeGreaterThan(Date value) {
            addCriterion("modify_time >", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeGreaterThanOrEqualTo(Date value) {
            addCriterion("modify_time >=", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeLessThan(Date value) {
            addCriterion("modify_time <", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeLessThanOrEqualTo(Date value) {
            addCriterion("modify_time <=", value, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeIn(List<Date> values) {
            addCriterion("modify_time in", values, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeNotIn(List<Date> values) {
            addCriterion("modify_time not in", values, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeBetween(Date value1, Date value2) {
            addCriterion("modify_time between", value1, value2, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andModifyTimeNotBetween(Date value1, Date value2) {
            addCriterion("modify_time not between", value1, value2, "modifyTime");
            return (Criteria) this;
        }

        public Criteria andIpAddressIsNull() {
            addCriterion("ip_address is null");
            return (Criteria) this;
        }

        public Criteria andIpAddressIsNotNull() {
            addCriterion("ip_address is not null");
            return (Criteria) this;
        }

        public Criteria andIpAddressEqualTo(String value) {
            addCriterion("ip_address =", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressNotEqualTo(String value) {
            addCriterion("ip_address <>", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressGreaterThan(String value) {
            addCriterion("ip_address >", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressGreaterThanOrEqualTo(String value) {
            addCriterion("ip_address >=", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressLessThan(String value) {
            addCriterion("ip_address <", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressLessThanOrEqualTo(String value) {
            addCriterion("ip_address <=", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressLike(String value) {
            addCriterion("ip_address like", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressNotLike(String value) {
            addCriterion("ip_address not like", value, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressIn(List<String> values) {
            addCriterion("ip_address in", values, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressNotIn(List<String> values) {
            addCriterion("ip_address not in", values, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressBetween(String value1, String value2) {
            addCriterion("ip_address between", value1, value2, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andIpAddressNotBetween(String value1, String value2) {
            addCriterion("ip_address not between", value1, value2, "ipAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgIdLikeInsensitive(String value) {
            addCriterion("upper(saleorg_id) like", value.toUpperCase(), "saleorgId");
            return (Criteria) this;
        }

        public Criteria andPartnerIdLikeInsensitive(String value) {
            addCriterion("upper(partner_id) like", value.toUpperCase(), "partnerId");
            return (Criteria) this;
        }

        public Criteria andSaleorgNameLikeInsensitive(String value) {
            addCriterion("upper(saleorg_name) like", value.toUpperCase(), "saleorgName");
            return (Criteria) this;
        }

        public Criteria andSaleorgTypeLikeInsensitive(String value) {
            addCriterion("upper(saleorg_type) like", value.toUpperCase(), "saleorgType");
            return (Criteria) this;
        }

        public Criteria andSaleorgSnameLikeInsensitive(String value) {
            addCriterion("upper(saleorg_sname) like", value.toUpperCase(), "saleorgSname");
            return (Criteria) this;
        }

        public Criteria andSaleorgEngnameLikeInsensitive(String value) {
            addCriterion("upper(saleorg_engname) like", value.toUpperCase(), "saleorgEngname");
            return (Criteria) this;
        }

        public Criteria andSaleorgAddressLikeInsensitive(String value) {
            addCriterion("upper(saleorg_address) like", value.toUpperCase(), "saleorgAddress");
            return (Criteria) this;
        }

        public Criteria andSaleorgPostidLikeInsensitive(String value) {
            addCriterion("upper(saleorg_postid) like", value.toUpperCase(), "saleorgPostid");
            return (Criteria) this;
        }

        public Criteria andSaleorgLinkmanLikeInsensitive(String value) {
            addCriterion("upper(saleorg_linkman) like", value.toUpperCase(), "saleorgLinkman");
            return (Criteria) this;
        }

        public Criteria andSaleorgTelphoneLikeInsensitive(String value) {
            addCriterion("upper(saleorg_telphone) like", value.toUpperCase(), "saleorgTelphone");
            return (Criteria) this;
        }

        public Criteria andSaleorgEmailLikeInsensitive(String value) {
            addCriterion("upper(saleorg_email) like", value.toUpperCase(), "saleorgEmail");
            return (Criteria) this;
        }

        public Criteria andSaleorgUrlLikeInsensitive(String value) {
            addCriterion("upper(saleorg_url) like", value.toUpperCase(), "saleorgUrl");
            return (Criteria) this;
        }

        public Criteria andCreatorLikeInsensitive(String value) {
            addCriterion("upper(creator) like", value.toUpperCase(), "creator");
            return (Criteria) this;
        }

        public Criteria andModifierLikeInsensitive(String value) {
            addCriterion("upper(modifier) like", value.toUpperCase(), "modifier");
            return (Criteria) this;
        }

        public Criteria andIpAddressLikeInsensitive(String value) {
            addCriterion("upper(ip_address) like", value.toUpperCase(), "ipAddress");
            return (Criteria) this;
        }
    }

    public static class Criteria extends GeneratedCriteria {

        protected Criteria() {
            super();
        }
    }

    public static class Criterion {
        private String condition;

        private Object value;

        private Object secondValue;

        private boolean noValue;

        private boolean singleValue;

        private boolean betweenValue;

        private boolean listValue;

        private String typeHandler;

        public String getCondition() {
            return condition;
        }

        public Object getValue() {
            return value;
        }

        public Object getSecondValue() {
            return secondValue;
        }

        public boolean isNoValue() {
            return noValue;
        }

        public boolean isSingleValue() {
            return singleValue;
        }

        public boolean isBetweenValue() {
            return betweenValue;
        }

        public boolean isListValue() {
            return listValue;
        }

        public String getTypeHandler() {
            return typeHandler;
        }

        protected Criterion(String condition) {
            super();
            this.condition = condition;
            this.typeHandler = null;
            this.noValue = true;
        }

        protected Criterion(String condition, Object value, String typeHandler) {
            super();
            this.condition = condition;
            this.value = value;
            this.typeHandler = typeHandler;
            if (value instanceof List<?>) {
                this.listValue = true;
            } else {
                this.singleValue = true;
            }
        }

        protected Criterion(String condition, Object value) {
            this(condition, value, null);
        }

        protected Criterion(String condition, Object value, Object secondValue, String typeHandler) {
            super();
            this.condition = condition;
            this.value = value;
            this.secondValue = secondValue;
            this.typeHandler = typeHandler;
            this.betweenValue = true;
        }

        protected Criterion(String condition, Object value, Object secondValue) {
            this(condition, value, secondValue, null);
        }
    }
}
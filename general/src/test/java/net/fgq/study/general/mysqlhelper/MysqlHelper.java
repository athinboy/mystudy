package net.fgq.study.general.mysqlhelper;

/**
 * Created by fengguoqiang 2020/4/23
 */
public class MysqlHelper {

    public static void main(String[] args) {

        String orginalSql = "select * from ( select distinct wcc.member_id as 'memberId','coupon' as 'type',wcc.id as 'addId',wcur.id as 'useId', wcc.cost_amounts as 'costAmounts',wcc.coupon_org_amounts as 'orgAmounts', (ifnull(mac.coupon_org_cost,0)) as 'orgCost',mcr.coupon_org_cost as 'repositoryOrgCost' ,wcc.coupon_amounts as 'interestSum',(case when wcc.coupon_amounts=0 then '1' else '0' end ) as 'presentSign' ,wcur.consume_amount as 'useAmount',mcr.currency_scale as 'currencyScale',wcc.coupon_amounts as 'addAmount',wcur.create_time as 'consumeTime' ,wcc.use_times as 'couponUseTimes',wcc.use_multiple as 'couponUseMultiple',wcc.claim_status as 'interestStatus' ,wcc.use_start_date as 'useBeginDate' ,wcc.use_end_date as 'useEndDate' ,ifnull(wcc.activity_coupon_id,0) as 'interestId' ,ifnull(wcc.print_bill,'') as 'printBill' ,wcc.create_time as 'buyTime' ,ifnull(mac.activity_plan_id,0) as 'servicePlantId' ,ifnull(mac.group_plan_id,0) as 'groupPlantId' ,wcc.service_network_id as 'servicenetworkId',mcr.pricing_way as 'pricingWay' ,wcur.consume_amount as 'useOrgAmounts' ,mcr.sz,mcr.coupon_name as 'interestName' from mb_coupon_claim wcc inner JOIN mb_activity_coupon mac on wcc.activity_coupon_id=mac.id inner join mb_coupon_repository mcr on mac.repository_id=mcr.id and mcr.classify_code not in ('HYCQ','XCQ') left join ( select cur.id,cur.consume_amount,cur.create_time,cur.coupon_claim_id from mb_coupon_use_record cur where cur.use_status='0' and ? >= cur.create_time union ALL select erd.id,erd.detail_amount,eor.create_time,erd.detail_id from mb_equity_oper_record eor inner join mb_equity_refund_detail erd on eor.id=erd.oper_record_id where ? >= eor.create_time and eor.oper_status='1' and erd.detail_type='1' union ALL select etd.id,etd.detail_amount,eor.create_time,etd.detail_id from mb_equity_oper_record eor inner join mb_equity_transfer_detail etd on eor.id=etd.oper_record_id where ? >= eor.create_time and eor.oper_status='1' and etd.detail_type='1' ) wcur on wcur.coupon_claim_id=wcc.id where 'coupon'=? and wcc.recommend_id=0 and wcc.member_id between ? and ? and wcc.claim_status not in ('4') and wcc.use_start_date between ? and ? and wcc.use_end_date between ? and ? and ifnull(wcc.activity_coupon_id,0) between ? and ? and ifnull(wcc.print_bill,'') between ? and ? and wcc.create_time between ? and ? and ifnull(mac.activity_plan_id,0) between ? and ? and ifnull(mac.group_plan_id,0) between ? and ? and ifnull(wcc.service_network_id,0) between ? and ? union all select distinct wmsr.member_id ,'stored',wmsd.id as 'addId',wmsur.id as 'useId', wmsd.current_figures,0 ,0 as 'orgCost',0 as 'repositoryOrgCost' ,wmsd.current_figures, (case when wmsd.stored_type='2' then '1' else '0' end ), wmsur.use_amount ,msr.currency_scale,wmsd.current_figures,wmsur.create_time ,0,'','' ,wmsd.use_start_date as 'useBeginDate' ,wmsd.use_end_date as 'useEndDate' ,ifnull(wmsr.activity_stored_id,0) as 'interestId' ,ifnull(wmsd.print_bill,'') as 'printBill' ,wmsr.create_time as 'buyTime' ,ifnull(mas.activity_plan_id,0) as 'servicePlantId' ,ifnull(mas.group_plan_id,0) as 'groupPlantId' ,wmsr.service_network_id as 'servicenetworkId','' ,0 as 'useOrgAmounts' ,msr.sz,wmsr.template_name as 'template_name' from mb_stored_record wmsr left join mb_activity_stored mas on wmsr.activity_stored_id=mas.id left join mb_stored_repository msr on msr.id=mas.repository_id inner join mb_stored_detail wmsd on wmsd.stored_record_id=wmsr.id and wmsd.figures_status not in ('2','6') left join ( select wmsur.id,wmsur.use_amount,wmsur.create_time,wmsur.stored_detail_id from mb_stored_use_record wmsur where wmsur.use_status !='2' and ? >= wmsur.create_time union ALL select erd.id,erd.detail_amount,eor.create_time,erd.detail_id from mb_equity_oper_record eor inner join mb_equity_refund_detail erd on eor.id=erd.oper_record_id where ? >= eor.create_time and eor.oper_status='1' and erd.detail_type='2' union ALL select etd.id,etd.detail_amount,eor.create_time,etd.detail_id from mb_equity_oper_record eor inner join mb_equity_transfer_detail etd on eor.id=etd.oper_record_id where ? >= eor.create_time and eor.oper_status='1' and etd.detail_type='2' ) wmsur on wmsur.stored_detail_id=wmsd.id where 'stored'=? and wmsr.recommend_id=0 and wmsr.member_id between ? and ? and ifnull(wmsd.print_bill,'') between ? and ? and wmsr.create_time between ? and ? and ifnull(wmsr.activity_stored_id,0) between ? and ? and ifnull(mas.activity_plan_id,0) between ? and ? and ifnull(wmsr.service_network_id,0) between ? and ? and wmsd.use_start_date between ? and ? and wmsd.use_end_date between ? and ? and ifnull(mas.group_plan_id,0) between ? and ? ) w order by memberId, 'type',w.addId,w.useId \n" +
                "==> Parameters: 2020-04-23 11:32:11.345(Timestamp), 2020-04-23 11:32:11.345(Timestamp), 2020-04-23 11:32:11.345(Timestamp), coupon(String), 3479816306141262(Long), 4893793540958209(Long), 2018-01-07(String), 2020-04-22(String), 2020-04-04(String), 2024-08-27(String), 3710524964251648(Long), 4880894136215552(Long), 0(String), 2(String), 2018-01-07 18:02:18.0(Timestamp), 2020-04-22 16:15:16.0(Timestamp), 3704603139008512(Long), 4880894136133632(Long), 0(Long), 4534416720308224(Long), 3152759738607616(Long), 3152759738607616(Long), 2020-04-23 11:32:11.345(Timestamp), 2020-04-23 11:32:11.345(Timestamp), 2020-04-23 11:32:11.345(Timestamp), coupon(String), 3479816306141262(Long), 4893793540958209(Long), 0(String), 2(String), 2018-01-07 18:02:18.0(Timestamp), 2020-04-22 16:15:16.0(Timestamp), 3710524964251648(Long), 4880894136215552(Long), 3704603139008512(Long), 4880894136133632(Long), 3152759738607616(Long), 3152759738607616(Long), 2018-01-07(String), 2020-04-22(String), 2020-04-04(String), 2024-08-27(String), 0(Long), 4534416720308224(Long)";

        String[] splitstrs = orginalSql.split("==> Parameters: ");
        String sqlStr = splitstrs[0];
        String paraStr = splitstrs[1];
        paraStr = paraStr.replaceAll("", "")
                .replaceAll("\\(Timestamp\\)", "")
                .replaceAll("\\(String\\)", "")
                .replaceAll("\\(Integer\\)", "")
                .replaceAll("\\(Long\\)", "");
        String[] paraS = paraStr.split(",");
        int startIndex = 0;
        String resultStr = "";
        for (int i = 0; i < paraS.length; i++) {
            int index = sqlStr.indexOf("?");
            resultStr += sqlStr.substring(startIndex, index);
            resultStr+=("'"+paraS[i].trim()+"'");
            sqlStr=sqlStr.substring(index+1);
        }
        resultStr+=sqlStr;
        System.out.println(resultStr);

    }

}

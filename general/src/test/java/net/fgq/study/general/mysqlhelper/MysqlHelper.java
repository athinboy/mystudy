package net.fgq.study.general.mysqlhelper;

/**
 * Created by fengguoqiang 2020/4/23
 */
public class MysqlHelper {

    public static void main(String[] args) {

        String orginalSql = "select wm.id as 'memberId', (wmsd.current_figures -IFNULL(wmsur.usedamount,0)-IFNULL(metr.transferAmount,0)) as 'balance_figures',wmsd.print_bill,wmsd.stored_type ,(case when IFNULL(wmsur.usedamount,0) >= wmsd.current_figures then '2' when ?> wmsd.use_end_date then '3' else '1' end ) as 'status' from ( select wm.id,wm.department_id from mb_member wm where wm.department_id=? and wm.member_status in ('0','1') and wm.member_type!='8' and wm.id=? and ? > wm.create_time order by wm.id limit ?,? ) wm inner join mb_stored_record wmsr on wmsr.member_id=wm.id and wmsr.recommend_id=0 and wmsr.stored_status='1' and ifnull(wmsr.insurance_detail_id,0)=0 left join mb_purchase_record mpr on mpr.id=wmsr.record_id left join mb_activity_stored mas on mas.id=wmsr.activity_stored_id left join mb_stored_repository msr on msr.id=mas.repository_id and msr.sz=0 inner join mb_stored_detail wmsd on wmsd.stored_record_id=wmsr.id and wmsd.figures_status not in ('2','6','5') left join ( select wmsur.stored_detail_id,sum(wmsur.use_amount) as 'usedamount' from mb_stored_use_record wmsur where wmsur.use_status !='2' and ? >= wmsur.create_time group by wmsur.stored_detail_id ) wmsur on wmsur.stored_detail_id=wmsd.id left join ( select metd.detail_id, sum( metd.detail_amount) as 'transferAmount' from mb_equity_oper_record meor left join mb_equity_transfer_detail metd on meor.id=metd.oper_record_id and metd.detail_type='2' where ? >= meor.create_time and meor.oper_status='1' group by metd.detail_id ) metr on metr.detail_id=wmsd.id where ? >= wmsr.create_time and (mpr.id is null or mpr.purchase_status='0' or mpr.modify_time> ? ) and (wmsd.figures_status!='2' or (wmsd.figures_status='2' and not exists (select * from mb_equity_refund_detail merd inner join mb_equity_oper_record meor on merd.oper_record_id=meor.id where merd.detail_id=wmsd.id and meor.oper_status='1' and merd.detail_type='2' and ? >= meor.create_time ) )) order by wm.id \n" +
                "==> Parameters: 2020-04-28(String), 3238855489218560(Long), 3805196886288384(Long), 2020-04-28 12:23:15.404(Timestamp), 0(Integer), 5000(Integer), 2020-04-28 12:23:15.404(Timestamp), 2020-04-28 12:23:15.404(Timestamp), 2020-04-28 12:23:15.404(Timestamp), 2020-04-28 12:23:15.404(Timestamp), 2020-04-28 12:23:15.404(Timestamp)";

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

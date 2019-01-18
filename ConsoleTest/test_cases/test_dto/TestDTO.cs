﻿using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data;
using WL_OA.Data.dto;
using Xunit;

namespace ConsoleTest.test_cases
{
    public class TestDTO
    {
        [Fact]
        public void Run()
        {
            var str = "{\"OrderInfo\":{\"Flist_id\":\"ratione\",\"Fconsign_man\":\"dicta\",\"Fstart_wharf\":\"qui\",\"Fstart_place\":\"ab\",\"Fto_place\":\"officiis\",\"Fto_wharf\":\"officiis\",\"Fbusiness_date\":\"1955-06-20 00:00:00\",\"Fbusinesser\":\"dicta\",\"Fop_term\":2,\"Ftransit_term\":1,\"Fpay_way\":2,\"Fprotocol_no\":\"1202629592\",\"Fassociate_way\":1,\"Forder_no\":\"1566297681\",\"Fhas_assurance\":18417,\"Fchild_bus_type\":8282,\"Fid\":0,\"Fstate\":1},\"HoldGoodsInfo\":{\"Flist_id\":\"sit\",\"Fgoods_name\":\"笑愚\",\"Fhold_goods_place\":\"a\",\"Fhold_goods_people\":\"nobis\",\"Fhold_goods_people_phone\":\"90407457590\",\"Fhold_goods_mobile\":\"aut\",\"Fhold_goods_memo\":\"deserunt quae nam voluptas\",\"Fsend_goods_company\":\"nihil\",\"Fsend_goods_company_fax\":\"totam\",\"Fget_goods_list_no\":\"2594321632\",\"Fis_pour_jacket\":4181,\"Fpour_jacket_memo\":\"quas vitae perferendis ducimus\",\"Fcar_book_way\":2,\"Fstart_trailer\":\"illo\",\"Fhold_date\":\"1996-11-10 00:00:00\",\"Fhold_priority\":3,\"Fid\":0,\"Fstate\":1},\"LayGoodsInfo\":{\"Flist_id\":\"necessitatibus\",\"Flay_goods_place\":\"accusamus\",\"Flay_goods_people\":\"dolorem\",\"Flay_goods_people_phone\":\"1433-97453931\",\"Flay_goods_mobile\":\"eum\",\"Flay_goods_memo\":\"quia sit non dolorem\",\"Frecv_goods_company\":\"ut\",\"Frecv_goods_company_fax\":\"optio\",\"Fgoods_owner\":\"nihil\",\"Fhold_get_way\":1,\"Fhold_get_memo\":\"culpa ipsum qui optio\",\"Fhold_get_date\":\"1968-03-25 00:00:00\",\"Ftarget_trailer\":\"necessitatibus\",\"Fdispatch_priority\":0,\"Fpredit_send_goods_date\":\"1990-07-23 00:00:00\",\"Fid\":0,\"Fstate\":1},\"ContainsInfoList\":[{\"Flist_id\":\"accusamus\",\"Finterflow_state\":\"aut\",\"Fspec_way\":6843,\"Fcabinet_no\":\"3197562741\",\"Ftitle_no\":\"6433198351\",\"Flist_state\":10,\"Fbook_space_list_no\":\"7124145752\",\"Fbook_date\":\"1966-11-29 19:23:05\",\"Fhold_goods_date\":\"1983-07-24 14:10:39\",\"Fhold_goods_list_no\":\"1153443014\",\"Fencrypt_title_no\":\"1674124719\",\"Fback_date\":\"1953-11-10 05:46:14\",\"Fhold_get_way\":1,\"Fdispatch_goods_date\":\"1979-08-16 07:24:53\",\"Fapproach_record\":\"optio\",\"Fleave_record\":\"a\",\"Fstart_car_no\":\"2495621814\",\"Fstart_driver\":\"fugit\",\"Fstart_driver_phone\":\"51364820767\",\"Fstart_driver_cert\":\"3167352303702\",\"Fdispatch_car_no\":\"2127019157\",\"Fdispatch_driver\":\"odit\",\"Fdispatch_driver_phone\":\"2034-14676831\",\"Fdispatch_driver_cert\":\"6978374260853\",\"Fgoods_name\":\"聪健\",\"Fpacket_way\":26203,\"Fpacket_num\":10783,\"Fpacket_cbm\":2901,\"Fvalue\":25656,\"Fweight\":30590,\"Frough_weight\":3147,\"Ffab_factory\":\"illo\",\"Fcontract_no\":\"2367023000\",\"Fsend_goods_addr\":\"zh_CN\",\"Fget_cabinet_addr\":\"zh_CN\",\"Fget_cabinet_date\":\"1955-01-07 16:45:46\",\"Fgive_cabinet_addr\":\"zh_CN\",\"Fmemo\":\"porro tempora inventore aut\",\"Fassurance_no\":\"2119411996\",\"Fassurance_state\":\"sapiente\",\"Fassurance_apply_no\":\"2632625881\",\"Fid\":0,\"Fstate\":1},{\"Flist_id\":\"a\",\"Finterflow_state\":\"qui\",\"Fspec_way\":19371,\"Fcabinet_no\":\"2910264032\",\"Ftitle_no\":\"7337219982\",\"Flist_state\":0,\"Fbook_space_list_no\":\"3031547401\",\"Fbook_date\":\"1978-04-15 04:31:19\",\"Fhold_goods_date\":\"1959-11-19 14:45:32\",\"Fhold_goods_list_no\":\"4273550954\",\"Fencrypt_title_no\":\"1566185375\",\"Fback_date\":\"1957-09-01 16:35:32\",\"Fhold_get_way\":0,\"Fdispatch_goods_date\":\"1972-04-16 15:46:06\",\"Fapproach_record\":\"nihil\",\"Fleave_record\":\"cupiditate\",\"Fstart_car_no\":\"1772730870\",\"Fstart_driver\":\"cupiditate\",\"Fstart_driver_phone\":\"7533-58868528\",\"Fstart_driver_cert\":\"5081384933745\",\"Fdispatch_car_no\":\"1445012056\",\"Fdispatch_driver\":\"quod\",\"Fdispatch_driver_phone\":\"637-09902352\",\"Fdispatch_driver_cert\":\"0739809350657\",\"Fgoods_name\":\"思聪\",\"Fpacket_way\":9502,\"Fpacket_num\":31659,\"Fpacket_cbm\":14527,\"Fvalue\":9526,\"Fweight\":26324,\"Frough_weight\":23813,\"Ffab_factory\":\"dicta\",\"Fcontract_no\":\"2041030131\",\"Fsend_goods_addr\":\"zh_CN\",\"Fget_cabinet_addr\":\"zh_CN\",\"Fget_cabinet_date\":\"1967-06-16 08:44:53\",\"Fgive_cabinet_addr\":\"zh_CN\",\"Fmemo\":\"et iste quisquam maxime\",\"Fassurance_no\":\"2593284573\",\"Fassurance_state\":\"dignissimos\",\"Fassurance_apply_no\":\"2691984941\",\"Fid\":0,\"Fstate\":1},{\"Flist_id\":\"est\",\"Finterflow_state\":\"beatae\",\"Fspec_way\":4950,\"Fcabinet_no\":\"2761812939\",\"Ftitle_no\":\"2444329627\",\"Flist_state\":36,\"Fbook_space_list_no\":\"1247923296\",\"Fbook_date\":\"1990-02-01 19:22:58\",\"Fhold_goods_date\":\"1956-05-27 07:30:59\",\"Fhold_goods_list_no\":\"3192942512\",\"Fencrypt_title_no\":\"2156749220\",\"Fback_date\":\"1990-07-23 13:53:05\",\"Fhold_get_way\":1,\"Fdispatch_goods_date\":\"1988-08-29 10:51:25\",\"Fapproach_record\":\"dignissimos\",\"Fleave_record\":\"cupiditate\",\"Fstart_car_no\":\"1240416507\",\"Fstart_driver\":\"voluptatum\",\"Fstart_driver_phone\":\"926-53873679\",\"Fstart_driver_cert\":\"1652759587876\",\"Fdispatch_car_no\":\"1832347003\",\"Fdispatch_driver\":\"vel\",\"Fdispatch_driver_phone\":\"3744-67336830\",\"Fdispatch_driver_cert\":\"3448845993106\",\"Fgoods_name\":\"弘文\",\"Fpacket_way\":1608,\"Fpacket_num\":1326,\"Fpacket_cbm\":1235,\"Fvalue\":8098,\"Fweight\":25140,\"Frough_weight\":13869,\"Ffab_factory\":\"accusamus\",\"Fcontract_no\":\"1381930183\",\"Fsend_goods_addr\":\"zh_CN\",\"Fget_cabinet_addr\":\"zh_CN\",\"Fget_cabinet_date\":\"1961-03-26 16:43:37\",\"Fgive_cabinet_addr\":\"zh_CN\",\"Fmemo\":\"eveniet autem odit velit\",\"Fassurance_no\":\"1850797647\",\"Fassurance_state\":\"necessitatibus\",\"Fassurance_apply_no\":\"2622982113\",\"Fid\":0,\"Fstate\":1},{\"Flist_id\":\"ducimus\",\"Finterflow_state\":\"sit\",\"Fspec_way\":15131,\"Fcabinet_no\":\"1556513208\",\"Ftitle_no\":\"2259041752\",\"Flist_state\":4,\"Fbook_space_list_no\":\"1683063377\",\"Fbook_date\":\"1963-08-03 11:01:12\",\"Fhold_goods_date\":\"1963-08-03 11:01:12\",\"Fhold_goods_list_no\":\"2742838621\",\"Fencrypt_title_no\":\"1048271661\",\"Fback_date\":\"1962-09-12 17:58:47\",\"Fhold_get_way\":1,\"Fdispatch_goods_date\":\"1988-08-29 10:51:25\",\"Fapproach_record\":\"nihil\",\"Fleave_record\":\"nihil\",\"Fstart_car_no\":\"7487137013\",\"Fstart_driver\":\"laborum\",\"Fstart_driver_phone\":\"2034-14676831\",\"Fstart_driver_cert\":\"5073835302910\",\"Fdispatch_car_no\":\"2939828738\",\"Fdispatch_driver\":\"omnis\",\"Fdispatch_driver_phone\":\"7533-58868528\",\"Fdispatch_driver_cert\":\"3667136133629\",\"Fgoods_name\":\"嘉懿\",\"Fpacket_way\":8335,\"Fpacket_num\":17481,\"Fpacket_cbm\":21955,\"Fvalue\":3045,\"Fweight\":7806,\"Frough_weight\":21216,\"Ffab_factory\":\"cupiditate\",\"Fcontract_no\":\"1095816887\",\"Fsend_goods_addr\":\"zh_CN\",\"Fget_cabinet_addr\":\"zh_CN\",\"Fget_cabinet_date\":\"1973-09-26 15:58:36\",\"Fgive_cabinet_addr\":\"zh_CN\",\"Fmemo\":\"mollitia suscipit ratione aut\",\"Fassurance_no\":\"1213913182\",\"Fassurance_state\":\"voluptas\",\"Fassurance_apply_no\":\"2144630332\",\"Fid\":0,\"Fstate\":1},{\"Flist_id\":\"dignissimos\",\"Finterflow_state\":\"ad\",\"Fspec_way\":29909,\"Fcabinet_no\":\"2348266511\",\"Ftitle_no\":\"3275727276\",\"Flist_state\":24,\"Fbook_space_list_no\":\"2037625024\",\"Fbook_date\":\"1950-02-07 04:19:54\",\"Fhold_goods_date\":\"1985-07-25 00:11:48\",\"Fhold_goods_list_no\":\"3185980571\",\"Fencrypt_title_no\":\"2970132272\",\"Fback_date\":\"1997-11-28 21:58:16\",\"Fhold_get_way\":0,\"Fdispatch_goods_date\":\"1991-04-28 09:10:00\",\"Fapproach_record\":\"sit\",\"Fleave_record\":\"ad\",\"Fstart_car_no\":\"1435924863\",\"Fstart_driver\":\"similique\",\"Fstart_driver_phone\":\"6359-39535548\",\"Fstart_driver_cert\":\"5081384933745\",\"Fdispatch_car_no\":\"1801232496\",\"Fdispatch_driver\":\"commodi\",\"Fdispatch_driver_phone\":\"93766353503\",\"Fdispatch_driver_cert\":\"9274528347232\",\"Fgoods_name\":\"思淼\",\"Fpacket_way\":10330,\"Fpacket_num\":16113,\"Fpacket_cbm\":4833,\"Fvalue\":15291,\"Fweight\":23543,\"Frough_weight\":4718,\"Ffab_factory\":\"aut\",\"Fcontract_no\":\"1222047211\",\"Fsend_goods_addr\":\"zh_CN\",\"Fget_cabinet_addr\":\"zh_CN\",\"Fget_cabinet_date\":\"1975-08-20 05:11:20\",\"Fgive_cabinet_addr\":\"zh_CN\",\"Fmemo\":\"aperiam porro voluptate officiis\",\"Fassurance_no\":\"1791334531\",\"Fassurance_state\":\"velit\",\"Fassurance_apply_no\":\"3241924704\",\"Fid\":0,\"Fstate\":1}],\"SeaTransportInfo\":{\"Flist_id\":\"cupiditate\",\"Fbook_cabint_proxy\":\"dolorem\",\"Fship_company\":\"fugiat\",\"Fmain_line_ship_name\":\"越彬\",\"Fmain_line_no\":\"2794819138\",\"Fship_no\":\"2560171841\",\"Fship_go_date\":\"1950-02-07 04:19:54\",\"Fship_reach_date\":\"1983-07-24 14:10:39\",\"Fship_report_date\":\"1995-12-17 08:15:48\",\"Fpredit_reach_date\":\"1988-08-27 08:51:46\",\"Fbook_order_man\":\"voluptas\",\"Fbook_recv_man\":\"cupiditate\",\"Fcarft_ship_company\":\"unde\",\"Fbranch_ship_name\":\"懿轩\",\"Fbranch_ship_no\":\"2017061132\",\"Ftransfer_ship_reach_date\":\"1975-11-20 01:17:53\",\"Ftransfer_ship_go_date\":\"1991-04-28 09:10:00\",\"Ftriple_pass_way\":\"natus\",\"Ftriple_pass_ship_no\":\"1949151981\",\"Ftransfer_ship_go_date2\":\"1989-05-03 14:41:09\",\"Fis_transfer_ship\":14738,\"Fline_chn_name\":\"瑾瑜\",\"Fis_main_line_car\":2087,\"Ftransfer_ship_reach_date2\":\"1960-01-10 00:58:29\",\"Ftransfer_ship_wharf\":\"officiis\",\"Ftransfer_ship_wharf2\":\"officia\",\"Fcarft_ship_info_way\":3,\"Ffirst_ship_get_date\":\"1975-11-20 01:17:53\",\"Fid\":0,\"Fstate\":1},\"AssuranceInfo\":{\"Flist_id\":\"officiis\",\"Fassurance_state\":17330,\"Fassurance_no\":\"2392421439\",\"Fassurance_fee\":16766,\"Fassurance_company\":\"voluptatum\",\"Fgoods_val\":26499,\"Fassurance_type\":1,\"Fassurance_info\":\"commodi\",\"Fassurance_rate\":12586,\"Fid\":0,\"Fstate\":1},\"MatterInfo\":{\"Flist_id\":\"est\",\"Frough_weight\":16627,\"Ffinance_matter\":\"odio\",\"Fspecial_things\":\"dolorem\",\"Fmatter_state\":10290,\"Fgather_list_no\":\"2229730593\",\"Fback_cross_date\":\"1973-11-02 11:29:50\",\"Freclaim_info\":\"voluptas\",\"Fid\":0,\"Fstate\":1},\"OpInfo\":{\"Flist_id\":\"cupiditate\",\"Fbusiness_type\":1,\"Fassist_people\":\"est\",\"Fdetent_people\":\"ut\",\"Foperator\":\"autem\",\"Foperator_company\":\"sapiente\",\"Finputor\":\"possimus\",\"Fsplit_list_no\":\"2441426152\",\"Fsplit_source\":\"quia\",\"Fchild_work_list_no\":\"3756217241\",\"Fid\":0,\"Fstate\":1},\"OtherInfo\":{\"Flist_id\":\"possimus\",\"Fid\":0,\"Fstate\":1}}";

            var result = JsonHelper.DeserializeTo<FreBussinessOpCenterDTO>(str);

        }
    }
}
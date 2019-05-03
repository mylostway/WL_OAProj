using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_contains_info")]
    public class FreBusinessContainsInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 物流动态 - 未知填什么值'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Finterflow_state { get; set; } = "";

        /// <summary>
        /// 规格，默认20GP'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fspec_way { get; set; } = "";

        /// <summary>
        /// 柜号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcabinet_no { get; set; } = "";

        /// <summary>
        /// 封号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftitle_no { get; set; } = "";

        /// <summary>
        /// 货柜状态，按位取值,从低到高为：订舱 - 装货（办单）- 装货（派车） - 回场 - 送货 - 维修'
        /// </summary>
        [BitUsageField(6, "货柜状态错误")]
        public virtual int? Flist_state { get; set; } = 0;

        /// <summary>
        /// 订舱单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fbook_space_list_no { get; set; } = "";

        /// <summary>
        /// 订舱日期，如果选择订舱，则默认是当天'
        /// </summary>
        public virtual DateTime? Fbook_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime? Fhold_goods_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 装货单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fhold_goods_list_no { get; set; } = "";

        /// <summary>
        /// 加密封号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fencrypt_title_no { get; set; } = "";

        /// <summary>
        /// 回场日期'
        /// </summary>
        public virtual DateTime? Fback_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 扣放货方式，0 - 无，1 - 扣货（默认）,2 - 放货'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fhold_get_way { get; set; } = "";

        /// <summary>
        /// 送货日期'
        /// </summary>
        public virtual DateTime? Fdispatch_goods_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 进场记录'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fapproach_record { get; set; } = "";

        /// <summary>
        /// 出场记录'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fleave_record { get; set; } = "";

        /// <summary>
        /// 起始车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_car_no { get; set; } = "";

        /// <summary>
        /// 起始司机'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver { get; set; } = "";

        /// <summary>
        /// 起始司机电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver_phone { get; set; } = "";

        /// <summary>
        /// 起始司机证件号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver_cert { get; set; } = "";

        /// <summary>
        /// 送货车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_car_no { get; set; } = "";

        /// <summary>
        /// 送货司机'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver { get; set; } = "";

        /// <summary>
        /// 送货司机电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver_phone { get; set; } = "";

        /// <summary>
        /// 送货司机证件号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver_cert { get; set; } = "";

        /// <summary>
        /// 货名'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fgoods_name { get; set; } = "";

        /// <summary>
        /// 包装形式'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fpacket_way { get; set; } = "";

        /// <summary>
        /// 件数'
        /// </summary>
        public virtual int? Fpacket_num { get; set; } = 0;

        /// <summary>
        /// 体积(CBM)'
        /// </summary>
        public virtual int? Fpacket_cbm { get; set; } = 0;

        /// <summary>
        /// 货值'
        /// </summary>
        public virtual int? Fvalue { get; set; } = 0;

        /// <summary>
        /// 净重(TON)'
        /// </summary>
        public virtual int? Fweight { get; set; } = 0;

        /// <summary>
        /// 毛重(TON)'
        /// </summary>
        public virtual int? Frough_weight { get; set; } = 0;

        /// <summary>
        /// 加工厂'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffab_factory { get; set; } = "";

        /// <summary>
        /// 合同号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcontract_no { get; set; } = "";

        /// <summary>
        /// 送货地址'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fsend_goods_addr { get; set; } = "";

        /// <summary>
        /// 提柜地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fget_cabinet_addr { get; set; } = "";

        /// <summary>
        /// 提柜日期'
        /// </summary>
        public virtual DateTime? Fget_cabinet_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 交柜地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fgive_cabinet_addr { get; set; } = "";

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 保险号,网站上不能编辑'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fassurance_no { get; set; } = "";

        /// <summary>
        /// 保险状态,网站上不能编辑'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fassurance_state { get; set; } = "";

        /// <summary>
        /// 保险申请号,网站上不能编辑
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassurance_apply_no { get; set; } = "";

        public FreBusinessContainsInfoEntity() { }

        public FreBusinessContainsInfoEntity(FreBusinessContainsInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Finterflow_state = rhs.Finterflow_state;
            this.Fspec_way = rhs.Fspec_way;
            this.Fcabinet_no = rhs.Fcabinet_no;
            this.Ftitle_no = rhs.Ftitle_no;
            this.Flist_state = rhs.Flist_state;
            this.Fbook_space_list_no = rhs.Fbook_space_list_no;
            this.Fbook_date = rhs.Fbook_date;
            this.Fhold_goods_date = rhs.Fhold_goods_date;
            this.Fhold_goods_list_no = rhs.Fhold_goods_list_no;
            this.Fencrypt_title_no = rhs.Fencrypt_title_no;
            this.Fback_date = rhs.Fback_date;
            this.Fhold_get_way = rhs.Fhold_get_way;
            this.Fdispatch_goods_date = rhs.Fdispatch_goods_date;
            this.Fapproach_record = rhs.Fapproach_record;
            this.Fleave_record = rhs.Fleave_record;
            this.Fstart_car_no = rhs.Fstart_car_no;
            this.Fstart_driver = rhs.Fstart_driver;
            this.Fstart_driver_phone = rhs.Fstart_driver_phone;
            this.Fstart_driver_cert = rhs.Fstart_driver_cert;
            this.Fdispatch_car_no = rhs.Fdispatch_car_no;
            this.Fdispatch_driver = rhs.Fdispatch_driver;
            this.Fdispatch_driver_phone = rhs.Fdispatch_driver_phone;
            this.Fdispatch_driver_cert = rhs.Fdispatch_driver_cert;
            this.Fgoods_name = rhs.Fgoods_name;
            this.Fpacket_way = rhs.Fpacket_way;
            this.Fpacket_num = rhs.Fpacket_num;
            this.Fpacket_cbm = rhs.Fpacket_cbm;
            this.Fvalue = rhs.Fvalue;
            this.Fweight = rhs.Fweight;
            this.Frough_weight = rhs.Frough_weight;
            this.Ffab_factory = rhs.Ffab_factory;
            this.Fcontract_no = rhs.Fcontract_no;
            this.Fsend_goods_addr = rhs.Fsend_goods_addr;
            this.Fget_cabinet_addr = rhs.Fget_cabinet_addr;
            this.Fget_cabinet_date = rhs.Fget_cabinet_date;
            this.Fgive_cabinet_addr = rhs.Fgive_cabinet_addr;
            this.Fmemo = rhs.Fmemo;
            this.Fassurance_no = rhs.Fassurance_no;
            this.Fassurance_state = rhs.Fassurance_state;
            this.Fassurance_apply_no = rhs.Fassurance_apply_no;
        }

        public static bool operator ==(FreBusinessContainsInfoEntity lhs, FreBusinessContainsInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Finterflow_state == rhs.Finterflow_state &&
               lhs.Fspec_way == rhs.Fspec_way &&
               lhs.Fcabinet_no == rhs.Fcabinet_no &&
               lhs.Ftitle_no == rhs.Ftitle_no &&
               lhs.Flist_state == rhs.Flist_state &&
               lhs.Fbook_space_list_no == rhs.Fbook_space_list_no &&
               lhs.Fbook_date == rhs.Fbook_date &&
               lhs.Fhold_goods_date == rhs.Fhold_goods_date &&
               lhs.Fhold_goods_list_no == rhs.Fhold_goods_list_no &&
               lhs.Fencrypt_title_no == rhs.Fencrypt_title_no &&
               lhs.Fback_date == rhs.Fback_date &&
               lhs.Fhold_get_way == rhs.Fhold_get_way &&
               lhs.Fdispatch_goods_date == rhs.Fdispatch_goods_date &&
               lhs.Fapproach_record == rhs.Fapproach_record &&
               lhs.Fleave_record == rhs.Fleave_record &&
               lhs.Fstart_car_no == rhs.Fstart_car_no &&
               lhs.Fstart_driver == rhs.Fstart_driver &&
               lhs.Fstart_driver_phone == rhs.Fstart_driver_phone &&
               lhs.Fstart_driver_cert == rhs.Fstart_driver_cert &&
               lhs.Fdispatch_car_no == rhs.Fdispatch_car_no &&
               lhs.Fdispatch_driver == rhs.Fdispatch_driver &&
               lhs.Fdispatch_driver_phone == rhs.Fdispatch_driver_phone &&
               lhs.Fdispatch_driver_cert == rhs.Fdispatch_driver_cert &&
               lhs.Fgoods_name == rhs.Fgoods_name &&
               lhs.Fpacket_way == rhs.Fpacket_way &&
               lhs.Fpacket_num == rhs.Fpacket_num &&
               lhs.Fpacket_cbm == rhs.Fpacket_cbm &&
               lhs.Fvalue == rhs.Fvalue &&
               lhs.Fweight == rhs.Fweight &&
               lhs.Frough_weight == rhs.Frough_weight &&
               lhs.Ffab_factory == rhs.Ffab_factory &&
               lhs.Fcontract_no == rhs.Fcontract_no &&
               lhs.Fsend_goods_addr == rhs.Fsend_goods_addr &&
               lhs.Fget_cabinet_addr == rhs.Fget_cabinet_addr &&
               lhs.Fget_cabinet_date == rhs.Fget_cabinet_date &&
               lhs.Fgive_cabinet_addr == rhs.Fgive_cabinet_addr &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Fassurance_no == rhs.Fassurance_no &&
               lhs.Fassurance_state == rhs.Fassurance_state &&
               lhs.Fassurance_apply_no == rhs.Fassurance_apply_no
           );
        }

        public static bool operator !=(FreBusinessContainsInfoEntity lhs, FreBusinessContainsInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }

}

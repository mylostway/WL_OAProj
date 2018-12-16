using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_contains_info")]
    public class FreBusinessContainsInfoEntity : BaseEntity<int>
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected string finterflow_state = "";
        /// <summary>
        /// 物流动态 - 未知填什么值'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Finterflow_state { get { return finterflow_state; } set { finterflow_state = value; } }

        protected int fspec_way = 0;
        /// <summary>
        /// 规格，默认20GP'
        /// </summary>
        public virtual int Fspec_way { get { return fspec_way; } set { fspec_way = value; } }

        protected string fcabinet_no = "";
        /// <summary>
        /// 柜号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcabinet_no { get { return fcabinet_no; } set { fcabinet_no = value; } }

        protected string ftitle_no = "";
        /// <summary>
        /// 封号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftitle_no { get { return ftitle_no; } set { ftitle_no = value; } }

        protected int flist_state = 0;
        /// <summary>
        /// 货柜状态，按位取值,从低到高为：订舱 - 装货（办单）- 装货（派车） - 回场 - 送货 - 维修'
        /// </summary>
        [BitUsageField(6, "货柜状态错误")]
        public virtual int Flist_state { get { return flist_state; } set { flist_state = value; } }

        protected string fbook_space_list_no = "";
        /// <summary>
        /// 订舱单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fbook_space_list_no { get { return fbook_space_list_no; } set { fbook_space_list_no = value; } }

        protected DateTime fbook_date = DateTime.Now;
        /// <summary>
        /// 订舱日期，如果选择订舱，则默认是当天'
        /// </summary>
        public virtual DateTime Fbook_date { get { return fbook_date; } set { fbook_date = value; } }

        protected DateTime fhold_goods_date = DateTime.Now;
        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime Fhold_goods_date { get { return fhold_goods_date; } set { fhold_goods_date = value; } }

        protected string fhold_goods_list_no = "";
        /// <summary>
        /// 装货单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fhold_goods_list_no { get { return fhold_goods_list_no; } set { fhold_goods_list_no = value; } }

        protected string fencrypt_title_no = "";
        /// <summary>
        /// 加密封号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fencrypt_title_no { get { return fencrypt_title_no; } set { fencrypt_title_no = value; } }

        protected DateTime fback_date = DateTime.Now;
        /// <summary>
        /// 回场日期'
        /// </summary>
        public virtual DateTime Fback_date { get { return fback_date; } set { fback_date = value; } }

        protected int fhold_get_way = 0;
        /// <summary>
        /// 扣放货方式，0 - 无，1 - 扣货（默认）,2 - 放货'
        /// </summary>
        
        public virtual int Fhold_get_way { get { return fhold_get_way; } set { fhold_get_way = value; } }

        protected DateTime fdispatch_goods_date = DateTime.Now;
        /// <summary>
        /// 送货日期'
        /// </summary>
        public virtual DateTime Fdispatch_goods_date { get { return fdispatch_goods_date; } set { fdispatch_goods_date = value; } }

        protected string fapproach_record = "";
        /// <summary>
        /// 进场记录'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fapproach_record { get { return fapproach_record; } set { fapproach_record = value; } }

        protected string fleave_record = "";
        /// <summary>
        /// 出场记录'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fleave_record { get { return fleave_record; } set { fleave_record = value; } }

        protected string fstart_car_no = "";
        /// <summary>
        /// 起始车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_car_no { get { return fstart_car_no; } set { fstart_car_no = value; } }

        protected string fstart_driver = "";
        /// <summary>
        /// 起始司机'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver { get { return fstart_driver; } set { fstart_driver = value; } }

        protected string fstart_driver_phone = "";
        /// <summary>
        /// 起始司机电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver_phone { get { return fstart_driver_phone; } set { fstart_driver_phone = value; } }

        protected string fstart_driver_cert = "";
        /// <summary>
        /// 起始司机证件号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_driver_cert { get { return fstart_driver_cert; } set { fstart_driver_cert = value; } }

        protected string fdispatch_car_no = "";
        /// <summary>
        /// 送货车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_car_no { get { return fdispatch_car_no; } set { fdispatch_car_no = value; } }

        protected string fdispatch_driver = "";
        /// <summary>
        /// 送货司机'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver { get { return fdispatch_driver; } set { fdispatch_driver = value; } }

        protected string fdispatch_driver_phone = "";
        /// <summary>
        /// 送货司机电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver_phone { get { return fdispatch_driver_phone; } set { fdispatch_driver_phone = value; } }

        protected string fdispatch_driver_cert = "";
        /// <summary>
        /// 送货司机证件号'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_driver_cert { get { return fdispatch_driver_cert; } set { fdispatch_driver_cert = value; } }

        protected string fgoods_name = "";
        /// <summary>
        /// 货名'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fgoods_name { get { return fgoods_name; } set { fgoods_name = value; } }

        protected int fpacket_way = 0;
        /// <summary>
        /// 包装形式'
        /// </summary>
        public virtual int Fpacket_way { get { return fpacket_way; } set { fpacket_way = value; } }

        protected int fpacket_num = 0;
        /// <summary>
        /// 件数'
        /// </summary>
        public virtual int Fpacket_num { get { return fpacket_num; } set { fpacket_num = value; } }

        protected int fpacket_cbm = 0;
        /// <summary>
        /// 体积(CBM)'
        /// </summary>
        public virtual int Fpacket_cbm { get { return fpacket_cbm; } set { fpacket_cbm = value; } }

        protected int fvalue = 0;
        /// <summary>
        /// 货值'
        /// </summary>
        public virtual int Fvalue { get { return fvalue; } set { fvalue = value; } }

        protected int fweight = 0;
        /// <summary>
        /// 净重(TON)'
        /// </summary>
        public virtual int Fweight { get { return fweight; } set { fweight = value; } }

        protected int frough_weight = 0;
        /// <summary>
        /// 毛重(TON)'
        /// </summary>
        public virtual int Frough_weight { get { return frough_weight; } set { frough_weight = value; } }

        protected string ffab_factory = "";
        /// <summary>
        /// 加工厂'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffab_factory { get { return ffab_factory; } set { ffab_factory = value; } }

        protected string fcontract_no = "";
        /// <summary>
        /// 合同号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcontract_no { get { return fcontract_no; } set { fcontract_no = value; } }

        protected string fsend_goods_addr = "";
        /// <summary>
        /// 送货地址'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fsend_goods_addr { get { return fsend_goods_addr; } set { fsend_goods_addr = value; } }

        protected string fget_cabinet_addr = "";
        /// <summary>
        /// 提柜地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fget_cabinet_addr { get { return fget_cabinet_addr; } set { fget_cabinet_addr = value; } }

        protected DateTime fget_cabinet_date = DateTime.Now;
        /// <summary>
        /// 提柜日期'
        /// </summary>
        public virtual DateTime Fget_cabinet_date { get { return fget_cabinet_date; } set { fget_cabinet_date = value; } }

        protected string fgive_cabinet_addr = "";
        /// <summary>
        /// 交柜地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fgive_cabinet_addr { get { return fgive_cabinet_addr; } set { fgive_cabinet_addr = value; } }

        protected string fmemo = "";
        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        protected string fassurance_no = "";
        /// <summary>
        /// 保险号,网站上不能编辑'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fassurance_no { get { return fassurance_no; } set { fassurance_no = value; } }

        protected string fassurance_state = "";
        /// <summary>
        /// 保险状态,网站上不能编辑'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fassurance_state { get { return fassurance_state; } set { fassurance_state = value; } }

        protected string fassurance_apply_no = "";
        /// <summary>
        /// 保险申请号,网站上不能编辑'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassurance_apply_no { get { return fassurance_apply_no; } set { fassurance_apply_no = value; } }

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
    }
}

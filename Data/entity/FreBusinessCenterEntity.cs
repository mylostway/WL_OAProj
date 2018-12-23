using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_center")]
    public class FreBusinessCenterEntity : BaseEntity<int>
    {
        protected string finterflow_state = "";
        /// <summary>
        /// 物流动态 - 未知填什么值'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Finterflow_state { get { return finterflow_state; } set { finterflow_state = value; } }

        protected string fconsign_man = "";
        /// <summary>
        /// 托运人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fconsign_man { get { return fconsign_man; } set { fconsign_man = value; } }

        protected string fstart_wharf = "";
        /// <summary>
        /// 起运码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fstart_wharf { get { return fstart_wharf; } set { fstart_wharf = value; } }

        protected string fstart_place = "";
        /// <summary>
        /// 起运地'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_place { get { return fstart_place; } set { fstart_place = value; } }

        protected string fto_place = "";
        /// <summary>
        /// 目的地'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fto_place { get { return fto_place; } set { fto_place = value; } }

        protected string fto_wharf = "";
        /// <summary>
        /// 目的码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fto_wharf { get { return fto_wharf; } set { fto_wharf = value; } }

        protected DateTime fbusiness_date = DateTime.Now;
        /// <summary>
        /// 业务日期'
        /// </summary>
        public virtual DateTime Fbusiness_date { get { return fbusiness_date; } set { fbusiness_date = value; } }

        protected string fbusinesser = "";
        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get { return fbusinesser; } set { fbusinesser = value; } }

        protected string fgoods_name = "";
        /// <summary>
        /// 货名'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Fgoods_name { get { return fgoods_name; } set { fgoods_name = value; } }

        protected string fhold_goods_place = "";
        /// <summary>
        /// 装货低点'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Fhold_goods_place { get { return fhold_goods_place; } set { fhold_goods_place = value; } }

        protected string fhold_goods_people_phone = "";
        /// <summary>
        /// 装货联系人'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string Fhold_goods_people_phone { get { return fhold_goods_people_phone; } set { fhold_goods_people_phone = value; } }

        protected string fput_goods_place = "";
        /// <summary>
        /// 卸货低点'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Fput_goods_place { get { return fput_goods_place; } set { fput_goods_place = value; } }

        protected string fput_goods_people_phone = "";
        /// <summary>
        /// 卸货联系人'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string Fput_goods_people_phone { get { return fput_goods_people_phone; } set { fput_goods_people_phone = value; } }

        protected string fop_term = "";
        /// <summary>
        /// 操作条款'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string Fop_term { get { return fop_term; } set { fop_term = value; } }

        protected string ftransit_term = "";
        /// <summary>
        /// 运输条款'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string Ftransit_term { get { return ftransit_term; } set { ftransit_term = value; } }

        protected string fpay_way = "";
        /// <summary>
        /// 付款方式'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string Fpay_way { get { return fpay_way; } set { fpay_way = value; } }

        protected string fwork_order_no = "";
        /// <summary>
        /// 工单号'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string Fwork_order_no { get { return fwork_order_no; } set { fwork_order_no = value; } }

        protected int frecord_state = 0;
        /// <summary>
        /// 
        /// </summary>
        public virtual int Frecord_state { get { return frecord_state; } set { frecord_state = value; } }

        protected string fship_company = "";
        /// <summary>
        /// 船公司'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string Fship_company { get { return fship_company; } set { fship_company = value; } }

        protected string fship_main_ship_name = "";
        /// <summary>
        /// 干线船名'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string Fship_main_ship_name { get { return fship_main_ship_name; } set { fship_main_ship_name = value; } }

        protected string fship_main_line_no = "";
        /// <summary>
        /// 干线航次'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string Fship_main_line_no { get { return fship_main_line_no; } set { fship_main_line_no = value; } }

        protected string fship_trans_no = "";
        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_trans_no { get { return fship_trans_no; } set { fship_trans_no = value; } }

        protected string fstart_trail_car = "";
        /// <summary>
        /// 起始拖车'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fstart_trail_car { get { return fstart_trail_car; } set { fstart_trail_car = value; } }

        protected DateTime fhold_goods_date = DateTime.Now;
        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime Fhold_goods_date { get { return fhold_goods_date; } set { fhold_goods_date = value; } }

        protected string fto_trail_car = "";
        /// <summary>
        /// 目的拖车'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fto_trail_car { get { return fto_trail_car; } set { fto_trail_car = value; } }

        protected string fcabinet_no = "";
        /// <summary>
        /// 柜号/封号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcabinet_no { get { return fcabinet_no; } set { fcabinet_no = value; } }

        protected int f20th = 0;
        /// <summary>
        /// 20'
        /// </summary>
        public virtual int F20th { get { return f20th; } set { f20th = value; } }

        protected int f40th = 0;
        /// <summary>
        /// 40'
        /// </summary>
        public virtual int F40th { get { return f40th; } set { f40th = value; } }

        protected int f40th_hq = 0;
        /// <summary>
        /// 40hq'
        /// </summary>
        public virtual int F40th_hq { get { return f40th_hq; } set { f40th_hq = value; } }

        protected int fhold_state = 0;
        /// <summary>
        /// 装货 - 状态，从低到高分别为： 装货完成(0/1)
        /// </summary>
        public virtual int Fhold_state { get { return fhold_state; } set { fhold_state = value; } }

        public FreBusinessCenterEntity() { }

        public FreBusinessCenterEntity(FreBusinessCenterEntity rhs)
        {
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Finterflow_state = rhs.Finterflow_state;
            this.Fconsign_man = rhs.Fconsign_man;
            this.Fstart_wharf = rhs.Fstart_wharf;
            this.Fstart_place = rhs.Fstart_place;
            this.Fto_place = rhs.Fto_place;
            this.Fto_wharf = rhs.Fto_wharf;
            this.Fbusiness_date = rhs.Fbusiness_date;
            this.Fbusinesser = rhs.Fbusinesser;
            this.Fgoods_name = rhs.Fgoods_name;
            this.Fhold_goods_place = rhs.Fhold_goods_place;
            this.Fhold_goods_people_phone = rhs.Fhold_goods_people_phone;
            this.Fput_goods_place = rhs.Fput_goods_place;
            this.Fput_goods_people_phone = rhs.Fput_goods_people_phone;
            this.Fop_term = rhs.Fop_term;
            this.Ftransit_term = rhs.Ftransit_term;
            this.Fpay_way = rhs.Fpay_way;
            this.Fwork_order_no = rhs.Fwork_order_no;
            this.Frecord_state = rhs.Frecord_state;
            this.Fship_company = rhs.Fship_company;
            this.Fship_main_ship_name = rhs.Fship_main_ship_name;
            this.Fship_main_line_no = rhs.Fship_main_line_no;
            this.Fship_trans_no = rhs.Fship_trans_no;
            this.Fstart_trail_car = rhs.Fstart_trail_car;
            this.Fhold_goods_date = rhs.Fhold_goods_date;
            this.Fto_trail_car = rhs.Fto_trail_car;
            this.Fcabinet_no = rhs.Fcabinet_no;
            this.F20th = rhs.F20th;
            this.F40th = rhs.F40th;
            this.F40th_hq = rhs.F40th_hq;
            this.Fhold_state = rhs.Fhold_state;
        }
    }
}

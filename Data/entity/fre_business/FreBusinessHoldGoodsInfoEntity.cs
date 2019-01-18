using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_hold_goods_info")]
    public class FreBusinessHoldGoodsInfoEntity : BaseEntity<int>
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected string fgoods_name = "";
        /// <summary>
        /// 货名'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fgoods_name { get { return fgoods_name; } set { fgoods_name = value; } }

        protected string fhold_goods_place = "";
        /// <summary>
        /// 装货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fhold_goods_place { get { return fhold_goods_place; } set { fhold_goods_place = value; } }

        protected string fhold_goods_people = "";
        /// <summary>
        /// 装货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_people { get { return fhold_goods_people; } set { fhold_goods_people = value; } }

        protected string fhold_goods_people_phone = "";
        /// <summary>
        /// 装货联系人手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_people_phone { get { return fhold_goods_people_phone; } set { fhold_goods_people_phone = value; } }

        protected string fhold_goods_mobile = "";
        /// <summary>
        /// 装货电话'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_mobile { get { return fhold_goods_mobile; } set { fhold_goods_mobile = value; } }

        protected string fhold_goods_memo = "";
        /// <summary>
        /// 装货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fhold_goods_memo { get { return fhold_goods_memo; } set { fhold_goods_memo = value; } }

        protected string fsend_goods_company = "";
        /// <summary>
        /// 发货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fsend_goods_company { get { return fsend_goods_company; } set { fsend_goods_company = value; } }

        protected string fsend_goods_company_fax = "";
        /// <summary>
        /// 发货方传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fsend_goods_company_fax { get { return fsend_goods_company_fax; } set { fsend_goods_company_fax = value; } }

        protected string fget_goods_list_no = "";
        /// <summary>
        /// 提货单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fget_goods_list_no { get { return fget_goods_list_no; } set { fget_goods_list_no = value; } }

        protected int fis_pour_jacket = 0;
        /// <summary>
        /// 是否套箱,0 - 不是,1 - 是，默认0'
        /// </summary>
        [Range(0,1,ErrorMessage = "非法的是否套箱值")]
        public virtual int Fis_pour_jacket { get { return fis_pour_jacket; } set { fis_pour_jacket = value; } }

        protected string fpour_jacket_memo = "";
        /// <summary>
        /// 套箱说明'
        /// </summary>
        [MaxLength(40)]
        public virtual string Fpour_jacket_memo { get { return fpour_jacket_memo; } set { fpour_jacket_memo = value; } }

        protected int fcar_book_way = 0;
        /// <summary>
        /// 发车预约方式'
        /// </summary>
        [Range((int)FreBusinessReserveCarEnums.None, (int)FreBusinessReserveCarEnums.WaitingNotify, ErrorMessage = "非法的发车预约方式")]
        public virtual int Fcar_book_way { get { return fcar_book_way; } set { fcar_book_way = value; } }

        protected string fstart_trailer = "";
        /// <summary>
        /// 起始拖车'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_trailer { get { return fstart_trailer; } set { fstart_trailer = value; } }

        protected DateTime fhold_date = DateTime.Now;
        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime Fhold_date { get { return fhold_date; } set { fhold_date = value; } }

        protected int fhold_priority = 0;
        /// <summary>
        /// 装货优先级
        /// </summary>
        [Range((int)FreBusinessLoadingLevelEnums.None, (int)FreBusinessLoadingLevelEnums.Urgent, ErrorMessage = "非法的装货优先级")]
        public virtual int Fhold_priority { get { return fhold_priority; } set { fhold_priority = value; } }

        public FreBusinessHoldGoodsInfoEntity() { }

        public FreBusinessHoldGoodsInfoEntity(FreBusinessHoldGoodsInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Fgoods_name = rhs.Fgoods_name;
            this.Fhold_goods_place = rhs.Fhold_goods_place;
            this.Fhold_goods_people = rhs.Fhold_goods_people;
            this.Fhold_goods_people_phone = rhs.Fhold_goods_people_phone;
            this.Fhold_goods_mobile = rhs.Fhold_goods_mobile;
            this.Fhold_goods_memo = rhs.Fhold_goods_memo;
            this.Fsend_goods_company = rhs.Fsend_goods_company;
            this.Fsend_goods_company_fax = rhs.Fsend_goods_company_fax;
            this.Fget_goods_list_no = rhs.Fget_goods_list_no;
            this.Fis_pour_jacket = rhs.Fis_pour_jacket;
            this.Fpour_jacket_memo = rhs.Fpour_jacket_memo;
            this.Fcar_book_way = rhs.Fcar_book_way;
            this.Fstart_trailer = rhs.Fstart_trailer;
            this.Fhold_date = rhs.Fhold_date;
            this.Fhold_priority = rhs.Fhold_priority;
        }
    }
}

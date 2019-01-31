using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_lay_goods_info")]
    public class FreBusinessLayGoodsInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected string flay_goods_place = "";
        /// <summary>
        /// 卸货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Flay_goods_place { get { return flay_goods_place; } set { flay_goods_place = value; } }

        protected string flay_goods_people = "";
        /// <summary>
        /// 卸货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_people { get { return flay_goods_people; } set { flay_goods_people = value; } }

        protected string flay_goods_people_phone = "";
        /// <summary>
        /// 卸货联系人手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_people_phone { get { return flay_goods_people_phone; } set { flay_goods_people_phone = value; } }

        protected string flay_goods_mobile = "";
        /// <summary>
        /// 卸货电话'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_mobile { get { return flay_goods_mobile; } set { flay_goods_mobile = value; } }

        protected string flay_goods_memo = "";
        /// <summary>
        /// 卸货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Flay_goods_memo { get { return flay_goods_memo; } set { flay_goods_memo = value; } }

        protected string frecv_goods_company = "";
        /// <summary>
        /// 收货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Frecv_goods_company { get { return frecv_goods_company; } set { frecv_goods_company = value; } }

        protected string frecv_goods_company_fax = "";
        /// <summary>
        /// 收货方传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Frecv_goods_company_fax { get { return frecv_goods_company_fax; } set { frecv_goods_company_fax = value; } }

        protected string fgoods_owner = "";
        /// <summary>
        /// 货主'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fgoods_owner { get { return fgoods_owner; } set { fgoods_owner = value; } }

        protected int fhold_get_way = 0;
        /// <summary>
        /// 扣放货方式，0 - 无，1 - 扣货（默认）,2 - 放货'
        /// </summary>
        [Range((int)FreBusinessDetainReleaseEnums.None, (int)FreBusinessDetainReleaseEnums.Release, ErrorMessage = "非法的扣放货方式")]
        public virtual int Fhold_get_way { get { return fhold_get_way; } set { fhold_get_way = value; } }

        protected string fhold_get_memo = "";
        /// <summary>
        /// 扣放货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fhold_get_memo { get { return fhold_get_memo; } set { fhold_get_memo = value; } }

        protected DateTime fhold_get_date = DateTime.Now;
        /// <summary>
        /// 扣放货日期'
        /// </summary>
        public virtual DateTime Fhold_get_date { get { return fhold_get_date; } set { fhold_get_date = value; } }

        protected string ftarget_trailer = "";
        /// <summary>
        /// 目的拖车'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ftarget_trailer { get { return ftarget_trailer; } set { ftarget_trailer = value; } }

        protected int fdispatch_priority = 0;
        /// <summary>
        /// 配送优先级'
        /// </summary>
        [Required]
        [Range((int)FreBusinessDeliveryLevelEnums.None, (int)FreBusinessDeliveryLevelEnums.Special, ErrorMessage = "非法的配送优先级")]
        public virtual int Fdispatch_priority { get { return fdispatch_priority; } set { fdispatch_priority = value; } }

        protected DateTime fpredit_send_goods_date = DateTime.Now;
        /// <summary>
        /// 预计送货期'
        /// </summary>
        [Required]
        public virtual DateTime Fpredit_send_goods_date { get { return fpredit_send_goods_date; } set { fpredit_send_goods_date = value; } }

        public FreBusinessLayGoodsInfoEntity() { }

        public FreBusinessLayGoodsInfoEntity(FreBusinessLayGoodsInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Flay_goods_place = rhs.Flay_goods_place;
            this.Flay_goods_people = rhs.Flay_goods_people;
            this.Flay_goods_people_phone = rhs.Flay_goods_people_phone;
            this.Flay_goods_mobile = rhs.Flay_goods_mobile;
            this.Flay_goods_memo = rhs.Flay_goods_memo;
            this.Frecv_goods_company = rhs.Frecv_goods_company;
            this.Frecv_goods_company_fax = rhs.Frecv_goods_company_fax;
            this.Fgoods_owner = rhs.Fgoods_owner;
            this.Fhold_get_way = rhs.Fhold_get_way;
            this.Fhold_get_memo = rhs.Fhold_get_memo;
            this.Fhold_get_date = rhs.Fhold_get_date;
            this.Ftarget_trailer = rhs.Ftarget_trailer;
            this.Fdispatch_priority = rhs.Fdispatch_priority;
            this.Fpredit_send_goods_date = rhs.Fpredit_send_goods_date;
        }
    }
}

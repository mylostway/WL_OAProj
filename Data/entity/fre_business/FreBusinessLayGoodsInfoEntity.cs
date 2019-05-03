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
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 卸货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Flay_goods_place { get; set; } = "";

        /// <summary>
        /// 卸货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_people { get; set; } = "";

        /// <summary>
        /// 卸货联系人手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_people_phone { get; set; } = "";

        /// <summary>
        /// 卸货电话'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_mobile { get; set; } = "";

        /// <summary>
        /// 卸货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Flay_goods_memo { get; set; } = "";

        /// <summary>
        /// 收货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Frecv_goods_company { get; set; } = "";

        /// <summary>
        /// 收货方传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Frecv_goods_company_fax { get; set; } = "";

        /// <summary>
        /// 货主'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fgoods_owner { get; set; } = "";

        /// <summary>
        /// 扣放货方式，0 - 无，1 - 扣货（默认）,2 - 放货'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fhold_get_way { get; set; } = "";

        /// <summary>
        /// 扣放货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fhold_get_memo { get; set; } = "";

        /// <summary>
        /// 扣放货日期'
        /// </summary>
        public virtual DateTime? Fhold_get_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 目的拖车'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ftarget_trailer { get; set; } = "";

        /// <summary>
        /// 配送优先级'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdispatch_priority { get; set; } = "";

        /// <summary>
        /// 预计送货期
        /// </summary>
        public virtual DateTime? Fpredit_send_goods_date { get; set; } = default(DateTime?);

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

        public static bool operator ==(FreBusinessLayGoodsInfoEntity lhs, FreBusinessLayGoodsInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Flay_goods_place == rhs.Flay_goods_place &&
               lhs.Flay_goods_people == rhs.Flay_goods_people &&
               lhs.Flay_goods_people_phone == rhs.Flay_goods_people_phone &&
               lhs.Flay_goods_mobile == rhs.Flay_goods_mobile &&
               lhs.Flay_goods_memo == rhs.Flay_goods_memo &&
               lhs.Frecv_goods_company == rhs.Frecv_goods_company &&
               lhs.Frecv_goods_company_fax == rhs.Frecv_goods_company_fax &&
               lhs.Fgoods_owner == rhs.Fgoods_owner &&
               lhs.Fhold_get_way == rhs.Fhold_get_way &&
               lhs.Fhold_get_memo == rhs.Fhold_get_memo &&
               lhs.Fhold_get_date == rhs.Fhold_get_date &&
               lhs.Ftarget_trailer == rhs.Ftarget_trailer &&
               lhs.Fdispatch_priority == rhs.Fdispatch_priority &&
               lhs.Fpredit_send_goods_date == rhs.Fpredit_send_goods_date
           );
        }

        public static bool operator !=(FreBusinessLayGoodsInfoEntity lhs, FreBusinessLayGoodsInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

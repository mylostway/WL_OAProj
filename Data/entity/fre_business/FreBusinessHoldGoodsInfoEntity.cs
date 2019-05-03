using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_hold_goods_info")]
    public class FreBusinessHoldGoodsInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 货名'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fgoods_name { get; set; } = "";

        /// <summary>
        /// 装货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fhold_goods_place { get; set; } = "";

        /// <summary>
        /// 装货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_people { get; set; } = "";

        /// <summary>
        /// 装货联系人手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_people_phone { get; set; } = "";

        /// <summary>
        /// 装货电话'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_mobile { get; set; } = "";

        /// <summary>
        /// 装货说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fhold_goods_memo { get; set; } = "";

        /// <summary>
        /// 发货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fsend_goods_company { get; set; } = "";

        /// <summary>
        /// 发货方传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fsend_goods_company_fax { get; set; } = "";

        /// <summary>
        /// 提货单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fget_goods_list_no { get; set; } = "";

        /// <summary>
        /// 是否套箱,0 - 不是,1 - 是，默认0'
        /// </summary>
        [Range(0, 1, ErrorMessage = "非法的是否套箱值")]
        public virtual int? Fis_pour_jacket { get; set; } = 0;

        /// <summary>
        /// 套箱说明'
        /// </summary>
        [MaxLength(40)]
        public virtual string Fpour_jacket_memo { get; set; } = "";

        /// <summary>
        /// 发车预约方式'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fcar_book_way { get; set; } = "";

        /// <summary>
        /// 起始拖车'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_trailer { get; set; } = "";

        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime? Fhold_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 装货优先级
        /// </summary>
        [MaxLength(30)]
        public virtual string Fhold_priority { get; set; } = "";

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

        public static bool operator ==(FreBusinessHoldGoodsInfoEntity lhs, FreBusinessHoldGoodsInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Fgoods_name == rhs.Fgoods_name &&
               lhs.Fhold_goods_place == rhs.Fhold_goods_place &&
               lhs.Fhold_goods_people == rhs.Fhold_goods_people &&
               lhs.Fhold_goods_people_phone == rhs.Fhold_goods_people_phone &&
               lhs.Fhold_goods_mobile == rhs.Fhold_goods_mobile &&
               lhs.Fhold_goods_memo == rhs.Fhold_goods_memo &&
               lhs.Fsend_goods_company == rhs.Fsend_goods_company &&
               lhs.Fsend_goods_company_fax == rhs.Fsend_goods_company_fax &&
               lhs.Fget_goods_list_no == rhs.Fget_goods_list_no &&
               lhs.Fis_pour_jacket == rhs.Fis_pour_jacket &&
               lhs.Fpour_jacket_memo == rhs.Fpour_jacket_memo &&
               lhs.Fcar_book_way == rhs.Fcar_book_way &&
               lhs.Fstart_trailer == rhs.Fstart_trailer &&
               lhs.Fhold_date == rhs.Fhold_date &&
               lhs.Fhold_priority == rhs.Fhold_priority
           );
        }

        public static bool operator !=(FreBusinessHoldGoodsInfoEntity lhs, FreBusinessHoldGoodsInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_matter_info")]
    public class FreBusinessMatterInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 毛重'
        /// </summary>
        public virtual int? Frough_weight { get; set; } = 0;

        /// <summary>
        /// 财务事项'
        /// </summary>
        [MaxLength(100)]
        public virtual string Ffinance_matter { get; set; } = "";

        /// <summary>
        /// 特殊事项'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fspecial_things { get; set; } = "";

        /// <summary>
        /// 事项状态，按位取值，从低到高为：超重拆箱 - 回交 - 危险品 - 代收款 - 回收'
        /// </summary>
        [BitUsageField(5, ErrorMsg = "非法的事项状态值")]
        public virtual int? Fmatter_state { get; set; } = 0;

        /// <summary>
        /// 收款单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fgather_list_no { get; set; } = "";

        /// <summary>
        /// 回交日期'
        /// </summary>
        public virtual DateTime? Fback_cross_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 回收信息
        /// </summary>
        [MaxLength(50)]
        public virtual string Freclaim_info { get; set; } = "";

        public FreBusinessMatterInfoEntity() { }

        public FreBusinessMatterInfoEntity(FreBusinessMatterInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Frough_weight = rhs.Frough_weight;
            this.Ffinance_matter = rhs.Ffinance_matter;
            this.Fspecial_things = rhs.Fspecial_things;
            this.Fmatter_state = rhs.Fmatter_state;
            this.Fgather_list_no = rhs.Fgather_list_no;
            this.Fback_cross_date = rhs.Fback_cross_date;
            this.Freclaim_info = rhs.Freclaim_info;
        }


        public static bool operator ==(FreBusinessMatterInfoEntity lhs, FreBusinessMatterInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Frough_weight == rhs.Frough_weight &&
               lhs.Ffinance_matter == rhs.Ffinance_matter &&
               lhs.Fspecial_things == rhs.Fspecial_things &&
               lhs.Fmatter_state == rhs.Fmatter_state &&
               lhs.Fgather_list_no == rhs.Fgather_list_no &&
               lhs.Fback_cross_date == rhs.Fback_cross_date &&
               lhs.Freclaim_info == rhs.Freclaim_info
           );
        }

        public static bool operator !=(FreBusinessMatterInfoEntity lhs, FreBusinessMatterInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }

  
}

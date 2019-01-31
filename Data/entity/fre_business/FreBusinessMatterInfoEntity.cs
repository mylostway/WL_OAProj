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
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected int frough_weight = 0;
        /// <summary>
        /// 毛重'
        /// </summary>
        public virtual int Frough_weight { get { return frough_weight; } set { frough_weight = value; } }

        protected string ffinance_matter = "";
        /// <summary>
        /// 财务事项'
        /// </summary>
        [MaxLength(100)]
        public virtual string Ffinance_matter { get { return ffinance_matter; } set { ffinance_matter = value; } }

        protected string fspecial_things = "";
        /// <summary>
        /// 特殊事项'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fspecial_things { get { return fspecial_things; } set { fspecial_things = value; } }

        protected int fmatter_state = 0;
        /// <summary>
        /// 事项状态，按位取值，从低到高为：超重拆箱 - 回交 - 危险品 - 代收款 - 回收'
        /// </summary>
        public virtual int Fmatter_state { get { return fmatter_state; } set { fmatter_state = value; } }

        protected string fgather_list_no = "";
        /// <summary>
        /// 收款单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fgather_list_no { get { return fgather_list_no; } set { fgather_list_no = value; } }

        protected DateTime? fback_cross_date;
        /// <summary>
        /// 回交日期'
        /// </summary>
        public virtual DateTime? Fback_cross_date { get { return fback_cross_date; } set { fback_cross_date = value; } }

        protected string freclaim_info = "";
        /// <summary>
        /// 回收信息'
        /// </summary>
        [MaxLength(50)]
        public virtual string Freclaim_info { get { return freclaim_info; } set { freclaim_info = value; } }

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
    }
}

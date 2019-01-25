using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_basic_info")]
    public class FreBusinessBasicInfoEntity : BaseEntity<int>
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected DateTime finput_time = DateTime.Now;
        /// <summary>
        /// 录入时间'
        /// </summary>
        [Required]
        public virtual DateTime Finput_time { get { return finput_time; } set { finput_time = value; } }

        protected DateTime fstart_time = DateTime.Now;
        /// <summary>
        /// 起始时间'
        /// </summary>
        public virtual DateTime Fstart_time { get { return fstart_time; } set { fstart_time = value; } }

        protected DateTime? ffinish_time = null;
        /// <summary>
        /// 结束时间'
        /// </summary>
        public virtual DateTime? Ffinish_time { get { return ffinish_time; } set { ffinish_time = value; } }

        protected DateTime flast_modify_time = DateTime.Now;
        /// <summary>
        /// 最近一次修改时间
        /// </summary>
        [Required]
        public virtual DateTime Flast_modify_time { get { return flast_modify_time; } set { flast_modify_time = value; } }

        public FreBusinessBasicInfoEntity() { }

        public FreBusinessBasicInfoEntity(FreBusinessBasicInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Finput_time = rhs.Finput_time;
            this.Fstart_time = rhs.Fstart_time;
            this.Ffinish_time = rhs.Ffinish_time;
            this.Flast_modify_time = rhs.Flast_modify_time;
        }
    }
}

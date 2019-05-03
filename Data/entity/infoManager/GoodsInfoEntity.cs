using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics.Contracts;
using Chloe.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WL_OA.Data.entity
{
    [Table("t_goodsinfo")]
    public class GoodsinfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 货物名称名（中文）'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fchn_Name { get; set; }

        /// <summary>
        /// 货物名称名（英文）'
        /// </summary>
        [MaxLength(30)]
        public virtual string Feng_Name { get; set; }

        /// <summary>
        /// 助记码'
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string Fmark { get; set; }

        /// <summary>
        /// 货物类型'
        /// </summary>
        public virtual int? FgoodsType { get; set; }

        /// <summary>
        /// 所属货类'
        /// </summary>
        public virtual int? FbelongType { get; set; }

        /// <summary>
        /// 标志-需核实重量'
        /// </summary>
        public virtual int? FisCheckWeight { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

        /// <summary>
        /// 标志-可用
        /// </summary>
        public virtual int? Fusable { get; set; }

        public GoodsinfoEntity() { }

        public GoodsinfoEntity(string chnName,string mark)
        {
            this.Fchn_Name = chnName;
            this.Fmark = mark;
        }

        public GoodsinfoEntity(GoodsinfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fchn_Name = rhs.Fchn_Name;
            this.Feng_Name = rhs.Feng_Name;
            this.Fmark = rhs.Fmark;
            this.FgoodsType = rhs.FgoodsType;
            this.FbelongType = rhs.FbelongType;
            this.FisCheckWeight = rhs.FisCheckWeight;
            this.Fmemo = rhs.Fmemo;
            this.Fusable = rhs.Fusable;
        }


        public static bool operator ==(GoodsinfoEntity lhs, GoodsinfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fchn_Name == rhs.Fchn_Name &&
               lhs.Feng_Name == rhs.Feng_Name &&
               lhs.Fmark == rhs.Fmark &&
               lhs.FgoodsType == rhs.FgoodsType &&
               lhs.FbelongType == rhs.FbelongType &&
               lhs.FisCheckWeight == rhs.FisCheckWeight &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Fusable == rhs.Fusable
           );
        }

        public static bool operator !=(GoodsinfoEntity lhs, GoodsinfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

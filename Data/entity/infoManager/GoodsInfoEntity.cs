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
        protected string fchn_Name = "";
        /// <summary>
        /// 货物名称名（中文）'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fchn_Name { get { return fchn_Name; } set { fchn_Name = value; } }

        protected string feng_Name = "";
        /// <summary>
        /// 货物名称名（英文）'
        /// </summary>
        [MaxLength(30)]
        public virtual string Feng_Name { get { return feng_Name; } set { feng_Name = value; } }

        protected string fmark = "";
        /// <summary>
        /// 助记码'
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string Fmark { get { return fmark; } set { fmark = value; } }

        protected int fgoodsType = 0;
        /// <summary>
        /// 货物类型'
        /// </summary>
        [Range(0,5)]
        public virtual int FgoodsType { get { return fgoodsType; } set { fgoodsType = value; } }

        protected int fbelongType = 0;
        /// <summary>
        /// 所属货类'
        /// </summary>
        [Range(0, 3)]
        public virtual int FbelongType { get { return fbelongType; } set { fbelongType = value; } }

        protected int fisCheckWeight = 0;
        /// <summary>
        /// 标志-需核实重量'
        /// </summary>
        public virtual int FisCheckWeight { get { return fisCheckWeight; } set { fisCheckWeight = value; } }


        protected string fmemo = "";
        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        protected int fusable = 0;
        /// <summary>
        /// 标志-可用
        /// </summary>
        public virtual int Fusable { get { return fusable; } set { fusable = value; } }

        public GoodsinfoEntity() { }

        public GoodsinfoEntity(string chnName,string remark)
        {
            this.Fchn_Name = chnName;
            this.Fmark = remark;
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics.Contracts;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class GoodsinfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的GoodsInfoEntity
        /// </summary>
        public GoodsinfoEntity() {  }

        public GoodsinfoEntity(GoodsinfoEntity rhs)
        {
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fchn_Name = rhs.Fchn_Name;
            this.Feng_Name = rhs.Feng_Name;
            this.Fmark = rhs.Fmark;
            this.FisCheckWeight = rhs.FisCheckWeight;
            this.Fusable = rhs.Fusable;
        }

        /// <summary>
        /// 仅仅使用主键ID创建GoodsInfoEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public GoodsinfoEntity(int ID) { this.Fid = ID; }

        /// <summary>
        /// 构建完整信息的GoodsInfoEntity
        /// </summary>
        /// <param name="chnName"></param>
        /// <param name="mark"></param>
        /// <param name="isCheckWeight"></param>
        /// <param name="usable"></param>
        public GoodsinfoEntity(string chnName,string mark,short isCheckWeight = 1,short usable = 1,string engName = "")
        {
            this.Fchn_Name = chnName;
            this.Fmark = mark;
            this.FisCheckWeight = isCheckWeight;
            this.Fusable = usable;
            this.Feng_Name = engName;
        }
        protected string fchn_Name = "";
        /// <summary>
        /// 货物名称名（中文）'
        /// </summary>
        [Required]
        [MaxLength(50)]
        [ColumnInfo("货物名称(中文)")]
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
        [ColumnInfo("助记码")]
        public virtual string Fmark { get { return fmark; } set { fmark = value; } }

        protected int fisCheckWeight = 0;
        /// <summary>
        /// 标志-需核实重量'
        /// </summary>
        public virtual int FisCheckWeight { get { return fisCheckWeight; } set { fisCheckWeight = value; } }

        protected int fusable = 0;
        /// <summary>
        /// 标志-可用
        /// </summary>
        public virtual int Fusable { get { return fusable; } set { fusable = value; } }


        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var entity = obj as GoodsinfoEntity;

            if (entity == null)
            {
                return false;
            }
            else
            {
                return this.Fid.Equals(entity.Fid);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

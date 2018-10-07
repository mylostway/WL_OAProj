using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 航线信息
    /// </summary>
    [Table("t_airway")]
    public class AirwayEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的AirLineEntity
        /// </summary>
        public AirwayEntity() { }

        /// <summary>
        /// 仅仅使用主键ID创建AirLineEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public AirwayEntity(int ID) { this.Fid = ID; }


        /// <summary>
        /// 创建一个AirLineEntity信息
        /// </summary>
        /// <param name="chnName"></param>
        /// <param name="usable"></param>
        /// <param name="engName"></param>
        /// <param name="remark"></param>
        public AirwayEntity(string chnName,short usable = 1,string engName = "",string remark = "")
        {
            Fchn_Name = chnName;
            Feng_Name = engName;
            Fremark = remark;
            Fusable = usable;
            FlastModifyTime = DateTime.Now;
        }


        public AirwayEntity(AirwayEntity rhs)
        {
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fchn_Name = rhs.Fchn_Name;
            this.Feng_Name = rhs.Feng_Name;
            this.Fremark = rhs.Fremark;
            this.Fusable = rhs.Fusable;
            this.FlastModifyTime = rhs.FlastModifyTime;
        }

        protected string fchn_Name = "";
        /// <summary>
        /// 航线名称名（中文）'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fchn_Name { get { return fchn_Name; } set { fchn_Name = value; } }

        protected string feng_Name = "";
        /// <summary>
        /// 航线名称名（英文）'
        /// </summary>
        [MaxLength(30)]
        public virtual string Feng_Name { get { return feng_Name; } set { feng_Name = value; } }

        protected string fremark = "";
        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fremark { get { return fremark; } set { fremark = value; } }

        protected int fusable = 0;
        /// <summary>
        /// 标志-是否可用'
        /// </summary>
        public virtual int Fusable { get { return fusable; } set { fusable = value; } }

        protected DateTime flastModifyTime = DateTime.Now;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Required]
        public virtual DateTime FlastModifyTime { get { return flastModifyTime; } set { flastModifyTime = value; } }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var entity = obj as AirwayEntity;

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

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.entity
{
    /// <summary>
    /// 航线信息
    /// </summary>
    public class AirLineEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的AirLineEntity
        /// </summary>
        public AirLineEntity() { }

        /// <summary>
        /// 仅仅使用主键ID创建AirLineEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public AirLineEntity(int ID) { this.Fid = ID; }


        /// <summary>
        /// 创建一个AirLineEntity信息
        /// </summary>
        /// <param name="chnName"></param>
        /// <param name="usable"></param>
        /// <param name="engName"></param>
        /// <param name="remark"></param>
        public AirLineEntity(string chnName,short usable = 1,string engName = "",string remark = "")
        {
            Fchn_name = chnName;
            Feng_name = engName;
            Fremark = remark;
            Fusable = usable;
            FlastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 航线名称名（中文）
        /// </summary>
        public virtual string Fchn_name { get; set; }

        /// <summary>
        /// 航线名称名（英文）
        /// </summary>
        public virtual string Feng_name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Fremark { get; set; }

        /// <summary>
        /// 标志-是否可用
        /// </summary>
        public virtual short Fusable { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime FlastModifyTime { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            DriverInfoEntity entity = obj as DriverInfoEntity;

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

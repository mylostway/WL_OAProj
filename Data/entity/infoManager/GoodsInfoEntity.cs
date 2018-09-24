using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Data.entity
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class GoodsInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的GoodsInfoEntity
        /// </summary>
        public GoodsInfoEntity() {  }

        /// <summary>
        /// 仅仅使用主键ID创建GoodsInfoEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public GoodsInfoEntity(int ID) { this.Fid = ID; }

        /// <summary>
        /// 构建完整信息的GoodsInfoEntity
        /// </summary>
        /// <param name="chnName"></param>
        /// <param name="mark"></param>
        /// <param name="isCheckWeight"></param>
        /// <param name="usable"></param>
        public GoodsInfoEntity(string chnName,string mark,short isCheckWeight = 1,short usable = 1,string engName = "")
        {
            this.Fchn_name = chnName;
            //this.Fchn_name = Encoding.UTF8.GetString(Encoding.Default.GetBytes(chnName));
            //this.Fchn_name = Encoding.GetEncoding("GBK").GetString(Encoding.Convert(Encoding.Default,Encoding.GetEncoding("GBK"), Encoding.Default.GetBytes(chnName)));
            this.Fmark = mark;
            this.FisCheckWeight = isCheckWeight;
            this.Fusable = usable;
            this.Feng_name = engName;
        }

        /// <summary>
        /// 货物名称名（中文）
        /// </summary>
        [Required]
        [StringLength(2, MinimumLength = 30)]
        public virtual string Fchn_name { get; set; }

        /// <summary>
        /// 货物名称名（英文）
        /// </summary>
        [StringLength(30)]
        public virtual string Feng_name { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        [Required]
        [StringLength(8)]
        public virtual string Fmark { get; set; }

        /// <summary>
        /// 标志-需核实重量
        /// </summary>
        public virtual short FisCheckWeight { get; set; }

        /// <summary>
        /// 标志-可用
        /// </summary>
        public virtual short Fusable { get; set; }

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

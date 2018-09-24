using System;
using System.Collections.Generic;
using System.Text;

namespace Data.entity
{
    /// <summary>
    /// 码头信息
    /// </summary>
    public class WharfInfoEntity : AuditEntity<int>
    {
        /// <summary>
        /// 创建一个空白的WharfInfoEntity
        /// </summary>
        public WharfInfoEntity() { }

        /// <summary>
        /// 仅仅使用主键ID创建WharfInfoEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public WharfInfoEntity(int ID) { this.Fid = ID; }

        /// <summary>
        /// 构建完整信息的WharfInfoEntity
        /// </summary>
        /// <param name="position"></param>
        /// <param name="inputUser"></param>
        /// <param name="alias"></param>
        /// <param name="mark"></param>
        /// <param name="op"></param>
        public WharfInfoEntity(string position, string mark,string inputUser, string alias = "", short op = 0)
        {
            Fposition = position;
            Falias = alias;
            Fmark = mark;
            Fop = op;

            FInputUser = inputUser;
        }

        /// <summary>
        /// 位置，这是一个不定层级列表，目前使用;间隔
        /// </summary>
        public virtual string Fposition { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public virtual string Falias { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        public virtual string Fmark { get; set; }

        /// <summary>
        /// 操作，目前没值
        /// </summary>
        public virtual short Fop { get; set; }


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

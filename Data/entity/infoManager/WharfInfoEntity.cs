using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 码头信息
    /// </summary>
    public class WharfinfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的WharfInfoEntity
        /// </summary>
        public WharfinfoEntity() { }

        /// <summary>
        /// 仅仅使用主键ID创建WharfInfoEntity对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public WharfinfoEntity(int ID) { this.Fid = ID; }

        /// <summary>
        /// 构建完整信息的WharfInfoEntity
        /// </summary>
        /// <param name="position"></param>
        /// <param name="inputUser"></param>
        /// <param name="alias"></param>
        /// <param name="mark"></param>
        /// <param name="op"></param>
        public WharfinfoEntity(string position, string mark,string inputUser, string alias = "", short op = 0)
        {
            FPosition = position;
            Falias = alias;
            Fmark = mark;
            Fop = op;

            finputUser = inputUser;
        }

        public WharfinfoEntity(WharfinfoEntity rhs)
        {
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.FPosition = rhs.FPosition;
            this.Falias = rhs.Falias;
            this.Fmark = rhs.Fmark;
            this.Fop = rhs.Fop;
            this.FinputUser = rhs.FinputUser;
            this.FinputTime = rhs.FinputTime;
            this.FlastModifyUser = rhs.FlastModifyUser;
            this.FlastModifyTime = rhs.FlastModifyTime;
        }

        protected string fPosition = "";
        /// <summary>
        /// 位置，这是一个不定层级列表，目前使用;间隔'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string FPosition { get { return fPosition; } set { fPosition = value; } }

        protected string falias = "";
        /// <summary>
        /// 别名'
        /// </summary>
        [MaxLength(30)]
        public virtual string Falias { get { return falias; } set { falias = value; } }

        protected string fmark = "";
        /// <summary>
        /// 助记码'
        /// </summary>
        [MaxLength(15)]
        public virtual string Fmark { get { return fmark; } set { fmark = value; } }

        protected int fop = 0;
        /// <summary>
        /// 操作，目前没值'
        /// </summary>
        public virtual int Fop { get { return fop; } set { fop = value; } }

        protected string finputUser = "";
        /// <summary>
        /// 录入人'
        /// </summary>
        [MaxLength(30)]
        public virtual string FinputUser { get { return finputUser; } set { finputUser = value; } }

        protected DateTime finputTime = DateTime.Now;
        /// <summary>
        /// 录入时间'
        /// </summary>
        [Required]
        public virtual DateTime FinputTime { get { return finputTime; } set { finputTime = value; } }

        protected string flastModifyUser = "";
        /// <summary>
        /// 最后一次修改人'
        /// </summary>
        [MaxLength(30)]
        public virtual string FlastModifyUser { get { return flastModifyUser; } set { flastModifyUser = value; } }

        protected DateTime flastModifyTime = DateTime.Now;
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public virtual DateTime FlastModifyTime { get { return flastModifyTime; } set { flastModifyTime = value; } }


        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            var entity = obj as WharfinfoEntity;

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Data.entity
{
    public class DriverInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 创建一个空白的DriverInfoEntity
        /// </summary>
        public DriverInfoEntity() { }

        /// <summary>
        /// 仅仅使用主键ID创建DriverInfo对象，目前用于删除
        /// </summary>
        /// <param name="ID"></param>
        public DriverInfoEntity(int ID) { this.Fid = ID; }

        /// <summary>
        /// 构建完整信息的DriverInfoEntity
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="fphone1"></param>
        /// <param name="fphone2"></param>
        /// <param name="fphone3"></param>
        /// <param name="certID"></param>
        /// <param name="driverNo"></param>
        /// <param name="workState"></param>
        public DriverInfoEntity(string fname,string fphone1,
            string certID, string driverNo, 
            string fphone2 = "", string fphone3 = "", short workState = 1)
        {
            this.Fname = fname;
            this.Fphone1 = fphone1;
            this.Fphone2 = fphone2;
            this.Fphone3 = fphone3;
            this.FcertID = certID;
            this.FDriverNo = driverNo;
            this.FworkState = workState;
        }

        public virtual string Fname { get; set; }

        public virtual string Fphone1 { get; set; }

        public virtual string Fphone2 { get; set; }

        public virtual string Fphone3 { get; set; }

        public virtual string FcertID { get; set; }

        public virtual string FDriverNo { get; set; }

        public virtual short FworkState { get; set; }

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

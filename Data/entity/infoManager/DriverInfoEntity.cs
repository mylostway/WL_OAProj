using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_driverinfo")]
    public class DriverinfoEntity : BaseEntity<int>
    {
        public DriverinfoEntity() { }

        public DriverinfoEntity(string name,string phone,string cert,string driverNo)
        {
            fname = name;
            fphone1 = phone;
            fcertID = cert;
            fDriverNo = driverNo;
        }

        public DriverinfoEntity(DriverinfoEntity rhs)
        {
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Fphone1 = rhs.Fphone1;
            this.Fphone2 = rhs.Fphone2;
            this.Fphone3 = rhs.Fphone3;
            this.FcertID = rhs.FcertID;
            this.FDriverNo = rhs.FDriverNo;
            this.FworkState = rhs.FworkState;
        }

        protected string fname = "";
        /// <summary>
        /// 司机姓名'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected string fphone1 = "";
        /// <summary>
        /// 司机手机号码'
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string Fphone1 { get { return fphone1; } set { fphone1 = value; } }

        protected string fphone2 = "";
        /// <summary>
        /// 司机备用手机号码'
        /// </summary>
        [MaxLength(15)]
        public virtual string Fphone2 { get { return fphone2; } set { fphone2 = value; } }

        protected string fphone3 = "";
        /// <summary>
        /// 司机备用手机号码'
        /// </summary>
        [MaxLength(15)]
        public virtual string Fphone3 { get { return fphone3; } set { fphone3 = value; } }

        protected string fcertID = "";
        /// <summary>
        /// 司机证件号码'
        /// </summary>
        [MaxLength(20)]
        public virtual string FcertID { get { return fcertID; } set { fcertID = value; } }

        protected string fDriverNo = "";
        /// <summary>
        /// 驾驶证编号'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FDriverNo { get { return fDriverNo; } set { fDriverNo = value; } }

        protected int fworkState = 0;
        /// <summary>
        /// 是否在职 0 - 否 1 - 是，其他待添加，默认0
        /// </summary>
        public virtual int FworkState { get { return fworkState; } set { fworkState = value; } }
    }
}

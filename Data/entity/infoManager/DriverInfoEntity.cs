using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Chloe.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WL_OA.Data.entity
{
    [Table("t_driverinfo")]
    public class DriverinfoEntity : BaseEntity<int>
    {
        protected string fdriverNo = "";
        /// <summary>
        /// 司机编号'
        /// </summary>
        [MaxLength(20)]
        public virtual string FdriverNo { get { return fdriverNo; } set { fdriverNo = value; } }

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

        protected string fcertID = "";
        /// <summary>
        /// 司机证件号码'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FcertID { get { return fcertID; } set { fcertID = value; } }

        protected string fdriverCardNo = "";
        /// <summary>
        /// 驾驶证编号'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FdriverCardNo { get { return fdriverCardNo; } set { fdriverCardNo = value; } }

        protected string fcarNo = "";
        /// <summary>
        /// 车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string FcarNo { get { return fcarNo; } set { fcarNo = value; } }

        protected string ftrailerNo = "";
        /// <summary>
        /// 挂车号'
        /// </summary>
        [MaxLength(30)]
        public virtual string FtrailerNo { get { return ftrailerNo; } set { ftrailerNo = value; } }

        protected DateTime fbirthday = DateTime.Now;
        /// <summary>
        /// 生日'
        /// </summary>
        public virtual DateTime Fbirthday { get { return fbirthday; } set { fbirthday = value; } }

        protected string fbirthPlace = "";
        /// <summary>
        /// 籍贯'
        /// </summary>
        [MaxLength(50)]
        public virtual string FbirthPlace { get { return fbirthPlace; } set { fbirthPlace = value; } }

        protected string flivePlace = "";
        /// <summary>
        /// 家庭住址'
        /// </summary>
        [MaxLength(50)]
        public virtual string FlivePlace { get { return flivePlace; } set { flivePlace = value; } }

        protected int flowestSalary = 0;
        /// <summary>
        /// 保底工资(分)'
        /// </summary>
        public virtual int FlowestSalary { get { return flowestSalary; } set { flowestSalary = value; } }

        protected string fmemo = "";
        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        protected int fworkState = 0;
        /// <summary>
        /// 是否在职 0 - 否 1 - 是，其他待添加，默认0
        /// </summary>
        [Range(0, 1)]
        public virtual int FworkState { get { return fworkState; } set { fworkState = value; } }

        public DriverinfoEntity() { }

        public DriverinfoEntity(string name,string phone,string certID,string cardNo)
        {
            this.Fname = name;
            this.Fphone1 = phone;
            this.FcertID = certID;
            this.FdriverCardNo = cardNo;            
        }

        public DriverinfoEntity(DriverinfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.FdriverNo = rhs.FdriverNo;
            this.Fname = rhs.Fname;
            this.Fphone1 = rhs.Fphone1;
            this.Fphone2 = rhs.Fphone2;
            this.FcertID = rhs.FcertID;
            this.FdriverCardNo = rhs.FdriverCardNo;
            this.FcarNo = rhs.FcarNo;
            this.FtrailerNo = rhs.FtrailerNo;
            this.Fbirthday = rhs.Fbirthday;
            this.FbirthPlace = rhs.FbirthPlace;
            this.FlivePlace = rhs.FlivePlace;
            this.FlowestSalary = rhs.FlowestSalary;
            this.Fmemo = rhs.Fmemo;
            this.FworkState = rhs.FworkState;
        }
    }
}

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
        /// <summary>
        /// 司机编号'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FdriverNo { get; set; } = "";

        /// <summary>
        /// 司机姓名'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 司机手机号码'
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string Fphone1 { get; set; } = "";

        /// <summary>
        /// 司机备用手机号码'
        /// </summary>
        [MaxLength(15)]
        public virtual string Fphone2 { get; set; } = "";

        /// <summary>
        /// 司机证件号码'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FcertID { get; set; } = "";

        /// <summary>
        /// 驾驶证编号'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FdriverCardNo { get; set; } = "";

        /// <summary>
        /// 车牌号'
        /// </summary>
        [MaxLength(30)]
        public virtual string FcarNo { get; set; } = "";

        /// <summary>
        /// 挂车号'
        /// </summary>
        [MaxLength(30)]
        public virtual string FtrailerNo { get; set; } = "";

        /// <summary>
        /// 生日'
        /// </summary>
        public virtual DateTime? Fbirthday { get; set; } = default(DateTime?);

        /// <summary>
        /// 籍贯'
        /// </summary>
        [MaxLength(50)]

        public virtual string FbirthPlace { get; set; } = "";

        /// <summary>
        /// 家庭住址'
        /// </summary>
        [MaxLength(50)]
        public virtual string FlivePlace { get; set; } = "";

        /// <summary>
        /// 保底工资(分)'
        /// </summary>
        public virtual int? FlowestSalary { get; set; } = 0;

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 是否在职 0 - 否 1 - 是，其他待添加，默认0
        /// </summary>
        [Range(0, 1)]
        public virtual int? FworkState { get; set; } = 0;

        public DriverinfoEntity() { }

        public DriverinfoEntity(string name,string phone,string cert,string cardNo)
        {
            this.Fname = name;
            this.Fphone1 = phone;
            this.FcertID = cert;
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


        public static bool operator ==(DriverinfoEntity lhs, DriverinfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.FdriverNo == rhs.FdriverNo &&
               lhs.Fname == rhs.Fname &&
               lhs.Fphone1 == rhs.Fphone1 &&
               lhs.Fphone2 == rhs.Fphone2 &&
               lhs.FcertID == rhs.FcertID &&
               lhs.FdriverCardNo == rhs.FdriverCardNo &&
               lhs.FcarNo == rhs.FcarNo &&
               lhs.FtrailerNo == rhs.FtrailerNo &&
               lhs.Fbirthday == rhs.Fbirthday &&
               lhs.FbirthPlace == rhs.FbirthPlace &&
               lhs.FlivePlace == rhs.FlivePlace &&
               lhs.FlowestSalary == rhs.FlowestSalary &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.FworkState == rhs.FworkState
           );
        }

        public static bool operator !=(DriverinfoEntity lhs, DriverinfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

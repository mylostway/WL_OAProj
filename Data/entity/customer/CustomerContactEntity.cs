using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_contact")]
    public class CustomerContactEntity : BaseEntity<int>, IComparable<CustomerContactEntity>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 联系人'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 部门'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fdepartment { get; set; } = "";

        /// <summary>
        /// 公司电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 公司传真'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffax { get; set; } = "";

        /// <summary>
        /// 移动电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmobile { get; set; } = "";

        /// <summary>
        /// 身份证号码'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcert { get; set; } = "";

        /// <summary>
        /// 性别 0 -- 未知 1 - 男 2 - 女'
        /// </summary>
        [Range((int)SexEnums.None, (int)SexEnums.Female, ErrorMessage = "非法的性别类型")]
        public virtual int Fsex { get; set; } = 0;

        /// <summary>
        /// 职务'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fjob { get; set; } = "";

        /// <summary>
        /// QQ号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fqq { get; set; } = "";

        /// <summary>
        /// 微信号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fwx { get; set; } = "";

        /// <summary>
        /// 公司电话2'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone2 { get; set; } = "";

        /// <summary>
        /// 公司电话3'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone3 { get; set; } = "";

        /// <summary>
        /// 公司电话4'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone4 { get; set; } = "";

        /// <summary>
        /// 公司电话5'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone5 { get; set; } = "";

        /// <summary>
        /// 记录状态，按位取值，0 - 可用'
        /// </summary>
        [BitUsageField(1)]
        public virtual int Fdata_status { get; set; } = 0;

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 备注2'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo2 { get; set; } = "";

        /// <summary>
        /// 备注3'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo3 { get; set; } = "";

        /// <summary>
        /// 排序号
        /// </summary>
        [MaxLength(200)]
        public virtual string Forder { get; set; } = "";

        public CustomerContactEntity() { }

        public CustomerContactEntity(CustomerContactEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fname = rhs.Fname;
            this.Fdepartment = rhs.Fdepartment;
            this.Fphone = rhs.Fphone;
            this.Ffax = rhs.Ffax;
            this.Fmobile = rhs.Fmobile;
            this.Fcert = rhs.Fcert;
            this.Fsex = rhs.Fsex;
            this.Fjob = rhs.Fjob;
            this.Fqq = rhs.Fqq;
            this.Fwx = rhs.Fwx;
            this.Fphone2 = rhs.Fphone2;
            this.Fphone3 = rhs.Fphone3;
            this.Fphone4 = rhs.Fphone4;
            this.Fphone5 = rhs.Fphone5;
            this.Fdata_status = rhs.Fdata_status;
            this.Fmemo = rhs.Fmemo;
            this.Fmemo2 = rhs.Fmemo2;
            this.Fmemo3 = rhs.Fmemo3;
            this.Forder = rhs.Forder;
        }


        public static bool operator ==(CustomerContactEntity lhs, CustomerContactEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fname == rhs.Fname &&
               lhs.Fdepartment == rhs.Fdepartment &&
               lhs.Fphone == rhs.Fphone &&
               lhs.Ffax == rhs.Ffax &&
               lhs.Fmobile == rhs.Fmobile &&
               lhs.Fcert == rhs.Fcert &&
               lhs.Fsex == rhs.Fsex &&
               lhs.Fjob == rhs.Fjob &&
               lhs.Fqq == rhs.Fqq &&
               lhs.Fwx == rhs.Fwx &&
               lhs.Fphone2 == rhs.Fphone2 &&
               lhs.Fphone3 == rhs.Fphone3 &&
               lhs.Fphone4 == rhs.Fphone4 &&
               lhs.Fphone5 == rhs.Fphone5 &&
               lhs.Fdata_status == rhs.Fdata_status &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Fmemo2 == rhs.Fmemo2 &&
               lhs.Fmemo3 == rhs.Fmemo3 &&
               lhs.Forder == rhs.Forder
           );
        }

        public static bool operator !=(CustomerContactEntity lhs, CustomerContactEntity rhs)
        {
            return !(lhs == rhs);
        }

        public virtual int CompareTo(CustomerContactEntity other)
        {
            if (this == other) return 0;
            return 1;
        }
    }

    /*
    //[Table("t_customer_contact")]
    public class CustomerContactEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 联系人'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 部门'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fdepartment { get; set; } = "";

        /// <summary>
        /// 公司电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 公司传真'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffax { get; set; } = "";

        /// <summary>
        /// 移动电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmobile { get; set; } = "";

        /// <summary>
        /// 身份证号码'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcert { get; set; } = "";

        /// <summary>
        /// 性别 0 -- 未知 1 - 男 2 - 女'
        /// </summary>
        [Range((int)SexEnums.None, (int)SexEnums.Female, ErrorMessage = "非法的性别类型")]
        public virtual int Fsex { get; set; }

        /// <summary>
        /// 职务'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fjob { get; set; } = "";

        /// <summary>
        /// QQ号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fqq { get; set; } = "";

        /// <summary>
        /// 微信号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fwx { get; set; } = "";

        /// <summary>
        /// 公司电话2'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone2 { get; set; } = "";

        /// <summary>
        /// 公司电话3'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone3 { get; set; } = "";

        /// <summary>
        /// 公司电话4'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone4 { get; set; } = "";

        /// <summary>
        /// 公司电话5'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone5 { get; set; } = "";

        /// <summary>
        /// 记录状态，按位取值，0 - 可用'
        /// </summary>
        [BitUsageField(1)]
        public virtual int FdataStatus { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 备注2'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo2 { get; set; } = "";

        /// <summary>
        /// 备注3'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo3 { get; set; } = "";

        /// <summary>
        /// 排序号
        /// </summary>
        [MaxLength(200)]
        public virtual string Forder { get; set; } = "";

    }
    */
}

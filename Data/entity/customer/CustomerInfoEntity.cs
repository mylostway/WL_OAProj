using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_info")]
    public class CustomerInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 客户简称'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fname_for_short { get; set; }

        /// <summary>
        /// 助记码'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fmark { get; set; }

        /// <summary>
        /// 公司全称'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fname { get; set; }

        /// <summary>
        /// 企业类型'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fcompany_type { get; set; }

        /// <summary>
        /// 业务员 - (公司人员)'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; }

        /// <summary>
        /// 默认类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdefault_type { get; set; }

        /// <summary>
        /// 所属行业'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbelong_industry { get; set; }

        /// <summary>
        /// 客户类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fcustomer_type { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

        /// <summary>
        /// 主要货物'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fmain_goods { get; set; }

        /// <summary>
        /// 结算方式'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fsettle_way { get; set; }

        /// <summary>
        /// 付款方式 - 1 - 月结,2 - 票结,3 - 代收款,4 - 代垫'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fpay_way { get; set; }

        /// <summary>
        /// 业务类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_type { get; set; }

        /// <summary>
        /// 公司抬头'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fcompany_title { get; set; }

        /// <summary>
        /// 公司地址'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fcompany_address { get; set; }

        /// <summary>
        /// 公司联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbusiness_contact_people { get; set; }

        /// <summary>
        /// 业务手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fbusiness_mobile { get; set; }

        /// <summary>
        /// 业务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_phone { get; set; }

        /// <summary>
        /// 业务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_fax { get; set; }

        /// <summary>
        /// 财务联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffinance_concat_people { get; set; }

        /// <summary>
        /// 财务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ffinance_phone { get; set; }

        /// <summary>
        /// 财务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ffinance_fax { get; set; }

        /// <summary>
        /// 协议号'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fprotocol_no { get; set; }

        /// <summary>
        /// 目的港电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdest_wharf_phone { get; set; }

        /// <summary>
        /// 记录状态，按位取值，0 - 可用，1 - 已审核，2 - 共享，3 - 完成，4 - 黑名单，5 - 收短信'
        /// </summary>
        [BitUsageField(6)]
        public virtual int? Fdata_status { get; set; }

        /// <summary>
        /// 所属部门(列表选择)'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fdepartment { get; set; }

        public CustomerInfoEntity() { }

        public CustomerInfoEntity(CustomerInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname_for_short = rhs.Fname_for_short;
            this.Fmark = rhs.Fmark;
            this.Fname = rhs.Fname;
            this.Fcompany_type = rhs.Fcompany_type;
            this.Fbusinesser = rhs.Fbusinesser;
            this.Fdefault_type = rhs.Fdefault_type;
            this.Fbelong_industry = rhs.Fbelong_industry;
            this.Fcustomer_type = rhs.Fcustomer_type;
            this.Fmemo = rhs.Fmemo;
            this.Fmain_goods = rhs.Fmain_goods;
            this.Fsettle_way = rhs.Fsettle_way;
            this.Fpay_way = rhs.Fpay_way;
            this.Fbusiness_type = rhs.Fbusiness_type;
            this.Fcompany_title = rhs.Fcompany_title;
            this.Fcompany_address = rhs.Fcompany_address;
            this.Fbusiness_contact_people = rhs.Fbusiness_contact_people;
            this.Fbusiness_mobile = rhs.Fbusiness_mobile;
            this.Fbusiness_phone = rhs.Fbusiness_phone;
            this.Fbusiness_fax = rhs.Fbusiness_fax;
            this.Ffinance_concat_people = rhs.Ffinance_concat_people;
            this.Ffinance_phone = rhs.Ffinance_phone;
            this.Ffinance_fax = rhs.Ffinance_fax;
            this.Fprotocol_no = rhs.Fprotocol_no;
            this.Fdest_wharf_phone = rhs.Fdest_wharf_phone;
            this.Fdata_status = rhs.Fdata_status;
            this.Fdepartment = rhs.Fdepartment;
        }


        public static bool operator ==(CustomerInfoEntity lhs, CustomerInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fname_for_short == rhs.Fname_for_short &&
               lhs.Fmark == rhs.Fmark &&
               lhs.Fname == rhs.Fname &&
               lhs.Fcompany_type == rhs.Fcompany_type &&
               lhs.Fbusinesser == rhs.Fbusinesser &&
               lhs.Fdefault_type == rhs.Fdefault_type &&
               lhs.Fbelong_industry == rhs.Fbelong_industry &&
               lhs.Fcustomer_type == rhs.Fcustomer_type &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Fmain_goods == rhs.Fmain_goods &&
               lhs.Fsettle_way == rhs.Fsettle_way &&
               lhs.Fpay_way == rhs.Fpay_way &&
               lhs.Fbusiness_type == rhs.Fbusiness_type &&
               lhs.Fcompany_title == rhs.Fcompany_title &&
               lhs.Fcompany_address == rhs.Fcompany_address &&
               lhs.Fbusiness_contact_people == rhs.Fbusiness_contact_people &&
               lhs.Fbusiness_mobile == rhs.Fbusiness_mobile &&
               lhs.Fbusiness_phone == rhs.Fbusiness_phone &&
               lhs.Fbusiness_fax == rhs.Fbusiness_fax &&
               lhs.Ffinance_concat_people == rhs.Ffinance_concat_people &&
               lhs.Ffinance_phone == rhs.Ffinance_phone &&
               lhs.Ffinance_fax == rhs.Ffinance_fax &&
               lhs.Fprotocol_no == rhs.Fprotocol_no &&
               lhs.Fdest_wharf_phone == rhs.Fdest_wharf_phone &&
               lhs.Fdata_status == rhs.Fdata_status &&
               lhs.Fdepartment == rhs.Fdepartment
           );
        }

        public static bool operator !=(CustomerInfoEntity lhs, CustomerInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

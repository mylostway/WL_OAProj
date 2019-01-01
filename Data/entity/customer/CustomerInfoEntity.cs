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
        protected string fname_for_short = "";
        /// <summary>
        /// 客户简称'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fname_for_short { get { return fname_for_short; } set { fname_for_short = value; } }

        protected string fmark = "";
        /// <summary>
        /// 助记码'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fmark { get { return fmark; } set { fmark = value; } }

        protected string fname = "";
        /// <summary>
        /// 公司全称'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected string fcompany_type = "";
        /// <summary>
        /// 企业类型'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fcompany_type { get { return fcompany_type; } set { fcompany_type = value; } }

        protected string fbusinesser = "";
        /// <summary>
        /// 业务员 - (公司人员)'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get { return fbusinesser; } set { fbusinesser = value; } }

        protected int fdefault_type = 0;
        /// <summary>
        /// 默认类型'
        /// </summary>
        [Range((int)QueryCustomerInfoTypeEnums.None, (int)QueryCustomerInfoTypeEnums.DstFleet, ErrorMessage = "非法的默认类型")]
        public virtual int Fdefault_type { get { return fdefault_type; } set { fdefault_type = value; } }

        protected string fbelong_industry = "";
        /// <summary>
        /// 所属行业'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbelong_industry { get { return fbelong_industry; } set { fbelong_industry = value; } }

        protected string fcustomer_type = "";
        /// <summary>
        /// 客户类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fcustomer_type { get { return fcustomer_type; } set { fcustomer_type = value; } }

        protected string fmemo = "";
        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        protected int fmain_goods = 0;
        /// <summary>
        /// 主要货物，（引用自商品表）'
        /// </summary>
        public virtual int Fmain_goods { get { return fmain_goods; } set { fmain_goods = value; } }

        protected string fsettle_way = "";
        /// <summary>
        /// 结算方式'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fsettle_way { get { return fsettle_way; } set { fsettle_way = value; } }

        protected int fpay_way = 0;
        /// <summary>
        /// 付款方式 - 1 - 月结,2 - 票结,3 - 代收款,4 - 代垫'
        /// </summary>
        [Range((int)FreBusinessPaymentTypeEnums.None, (int)FreBusinessPaymentTypeEnums.Advance, ErrorMessage = "非法的付款方式")]
        public virtual int Fpay_way { get { return fpay_way; } set { fpay_way = value; } }

        protected string fbusiness_type = "";
        /// <summary>
        /// 业务类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_type { get { return fbusiness_type; } set { fbusiness_type = value; } }

        protected string fcompany_title = "";
        /// <summary>
        /// 公司抬头'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fcompany_title { get { return fcompany_title; } set { fcompany_title = value; } }

        protected string fcompany_address = "";
        /// <summary>
        /// 公司地址'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fcompany_address { get { return fcompany_address; } set { fcompany_address = value; } }

        protected string fbusiness_contact_people = "";
        /// <summary>
        /// 公司联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbusiness_contact_people { get { return fbusiness_contact_people; } set { fbusiness_contact_people = value; } }

        protected string fbusiness_mobile = "";
        /// <summary>
        /// 业务手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fbusiness_mobile { get { return fbusiness_mobile; } set { fbusiness_mobile = value; } }

        protected string fbusiness_phone = "";
        /// <summary>
        /// 业务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_phone { get { return fbusiness_phone; } set { fbusiness_phone = value; } }

        protected string fbusiness_fax = "";
        /// <summary>
        /// 业务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusiness_fax { get { return fbusiness_fax; } set { fbusiness_fax = value; } }

        protected string ffinance_concat_people = "";
        /// <summary>
        /// 财务联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffinance_concat_people { get { return ffinance_concat_people; } set { ffinance_concat_people = value; } }

        protected string ffinance_phone = "";
        /// <summary>
        /// 财务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ffinance_phone { get { return ffinance_phone; } set { ffinance_phone = value; } }

        protected string ffinance_fax = "";
        /// <summary>
        /// 财务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ffinance_fax { get { return ffinance_fax; } set { ffinance_fax = value; } }

        protected string fprotocol_no = "";
        /// <summary>
        /// 协议号'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fprotocol_no { get { return fprotocol_no; } set { fprotocol_no = value; } }

        protected string fdest_wharf_phone = "";
        /// <summary>
        /// 目的港电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdest_wharf_phone { get { return fdest_wharf_phone; } set { fdest_wharf_phone = value; } }

        protected int fdata_status = 0;
        /// <summary>
        /// 记录状态，按位取值，0 - 可用，1 - 已审核，2 - 共享，3 - 完成，4 - 黑名单，5 - 收短信'
        /// </summary>
        [BitUsageField(6, "记录状态取值错误")]
        public virtual int Fdata_status { get { return fdata_status; } set { fdata_status = value; } }

        protected string finputor = "";
        /// <summary>
        /// 录入员'
        /// </summary>
        [MaxLength(50)]
        public virtual string Finputor { get { return finputor; } set { finputor = value; } }

        protected DateTime finput_time = DateTime.Now;
        /// <summary>
        /// 录入时间'
        /// </summary>
        [Required]
        public virtual DateTime Finput_time { get { return finput_time; } set { finput_time = value; } }

        protected string fdepartment = "";
        /// <summary>
        /// 所属部门(列表选择)'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fdepartment { get { return fdepartment; } set { fdepartment = value; } }

        protected string faduitor = "";
        /// <summary>
        /// 审核人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Faduitor { get { return faduitor; } set { faduitor = value; } }

        protected DateTime faduit_time = DateTime.Now;
        /// <summary>
        /// 审核时间
        /// </summary>
        public virtual DateTime Faduit_time { get { return faduit_time; } set { faduit_time = value; } }

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
            this.Finputor = rhs.Finputor;
            this.Finput_time = rhs.Finput_time;
            this.Fdepartment = rhs.Fdepartment;
            this.Faduitor = rhs.Faduitor;
            this.Faduit_time = rhs.Faduit_time;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_customer_info")]
    public class CustomerInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 客户简称'
        /// </summary>
        [MaxLength(30)]
        public virtual string FnameForShort { get; set; }

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
        [Required]
        public virtual int FcompanyType { get; set; }

        /// <summary>
        /// 业务员 - (公司人员)'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; }

        /// <summary>
        /// 默认类型'
        /// </summary>
        [Required]
        public virtual int FdefaultType { get; set; }

        /// <summary>
        /// 所属行业'
        /// </summary>
        [MaxLength(30)]
        public virtual string FbelongIndustry { get; set; }

        /// <summary>
        /// 客户类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string FcustomerType { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

        /// <summary>
        /// 主要货物，（引用自商品表）'
        /// </summary>
        public virtual int FmainGoods { get; set; }

        /// <summary>
        /// 结算方式'
        /// </summary>
        [MaxLength(30)]
        public virtual string FsettleWay { get; set; }

        /// <summary>
        /// 付款方式 - 1 - 月结,2 - 票结,3 - 代收款,4 - 代垫'
        /// </summary>
        public virtual int FpayWay { get; set; }

        /// <summary>
        /// 业务类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string FbusinessType { get; set; }

        /// <summary>
        /// 公司抬头'
        /// </summary>
        [MaxLength(60)]
        public virtual string FcompanyTitle { get; set; }

        /// <summary>
        /// 公司地址'
        /// </summary>
        [MaxLength(200)]
        public virtual string FcompanyAddress { get; set; }

        /// <summary>
        /// 公司联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string FbusinessContactPeople { get; set; }

        /// <summary>
        /// 业务手机'
        /// </summary>
        [MaxLength(20)]
        public virtual string FbusinessMobile { get; set; }

        /// <summary>
        /// 业务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string FbusinessPhone { get; set; }

        /// <summary>
        /// 业务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string FbusinessFax { get; set; }

        /// <summary>
        /// 财务联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string FfinanceConcatPeople { get; set; }

        /// <summary>
        /// 财务电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string FfinancePhone { get; set; }

        /// <summary>
        /// 财务传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string FfinanceFax { get; set; }

        /// <summary>
        /// 协议号'
        /// </summary>
        [MaxLength(60)]
        public virtual string FprotocolNo { get; set; }

        /// <summary>
        /// 目的港电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string FdestWharfPhone { get; set; }

        /// <summary>
        /// 记录状态，按位取值，0 - 可用，1 - 已审核，2 - 共享，3 - 完成，4 - 黑名单，5 - 收短信'
        /// </summary>
        public virtual int FdataStatus { get; set; }

        /// <summary>
        /// 录入员'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Finputor { get; set; }

        /// <summary>
        /// 录入时间'
        /// </summary>
        [Required]
        public virtual DateTime FinputTime { get; set; }

        /// <summary>
        /// 所属部门(列表选择)'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fdepartment { get; set; }

        /// <summary>
        /// 审核人'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Faduitor { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [Required]
        public virtual DateTime FaduitTime { get; set; }

    }
}

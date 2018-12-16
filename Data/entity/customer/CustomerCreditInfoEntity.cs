using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
   // [Table("t_customer_credit_info")]
    public class CustomerCreditInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 资信额度'
        /// </summary>        
        public virtual int FcreditLimit { get; set; }

        /// <summary>
        /// 额度说明'
        /// </summary>        
        [MaxLength(100)]
        public virtual string FlimitMemo { get; set; }

        /// <summary>
        /// 数期'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fexponential { get; set; }

        /// <summary>
        /// 币种'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fcurrency { get; set; }

        /// <summary>
        /// 评估类别'
        /// </summary>
        [MaxLength(30)]
        public virtual string FestimateType { get; set; }

        /// <summary>
        /// 付款评估'
        /// </summary>
        [MaxLength(30)]
        public virtual string FpayEstimate { get; set; }

        /// <summary>
        /// 等级评估'
        /// </summary>
        [MaxLength(30)]
        public virtual string FlevelEstimate { get; set; }

        /// <summary>
        /// 银行名称'
        /// </summary>
        [MaxLength(30)]
        public virtual string FbankName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [MaxLength(30)]
        public virtual string FbankAccount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_customer_bank_account")]
    public class CustomerBankAccountEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 开户行'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string FbankDeposit { get; set; }

        /// <summary>
        /// 账号'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Faccount { get; set; }

        /// <summary>
        /// 开户名'
        /// </summary>
        [MaxLength(100)]
        public virtual string FdepositName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_customer_input_info")]
    public class CustomerInputInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public int FcustomerId { get; set; }

        /// <summary>
        /// 录入员'
        /// </summary>        
        [MaxLength(50)]
        public string Finputor { get; set; }

        /// <summary>
        /// 录入时间'
        /// </summary>        
        public DateTime FinputTime { get; set; }

        /// <summary>
        /// 所属部门(列表选择)'
        /// </summary>        
        [MaxLength(100)]
        public string Fdepartment { get; set; }

        /// <summary>
        /// 审核人'
        /// </summary>        
        [MaxLength(50)]
        public string Faduitor { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>        
        public DateTime FaduitTime { get; set; }

    }
}

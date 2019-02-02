using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_operation_info")]
    public class FreBusinessOperationInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected int fbusiness_type = 0;
        /// <summary>
        /// 业务类型'
        /// </summary>
        [Range((int)FreBusinessBusinessTypeEnums.None, (int)FreBusinessBusinessTypeEnums.Freight, ErrorMessage = "非法的业务类型")]
        public virtual int Fbusiness_type { get { return fbusiness_type; } set { fbusiness_type = value; } }

        protected string fassist_people = "";
        /// <summary>
        /// 协助人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassist_people { get { return fassist_people; } set { fassist_people = value; } }

        protected string fdetent_people = "";
        /// <summary>
        /// 扣货操作人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fdetent_people { get { return fdetent_people; } set { fdetent_people = value; } }

        protected string foperator = "";
        /// <summary>
        /// 操作员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Foperator { get { return foperator; } set { foperator = value; } }

        protected string foperator_company = "";
        /// <summary>
        /// 操作部门'
        /// </summary>
        [MaxLength(30)]
        public virtual string Foperator_company { get { return foperator_company; } set { foperator_company = value; } }

        protected string finputor = "";
        /// <summary>
        /// 录入人员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Finputor { get { return finputor; } set { finputor = value; } }

        protected string fsplit_list_no = "";
        /// <summary>
        /// 拆分单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Fsplit_list_no { get { return fsplit_list_no; } set { fsplit_list_no = value; } }

        protected string fsplit_source = "";
        /// <summary>
        /// 拆分来源'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fsplit_source { get { return fsplit_source; } set { fsplit_source = value; } }

        protected string fchild_work_list_no = "";
        /// <summary>
        /// 子工作单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Fchild_work_list_no { get { return fchild_work_list_no; } set { fchild_work_list_no = value; } }

        public FreBusinessOperationInfoEntity() { }

        public FreBusinessOperationInfoEntity(FreBusinessOperationInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Fbusiness_type = rhs.Fbusiness_type;
            this.Fassist_people = rhs.Fassist_people;
            this.Fdetent_people = rhs.Fdetent_people;
            this.Foperator = rhs.Foperator;
            this.Foperator_company = rhs.Foperator_company;
            this.Finputor = rhs.Finputor;
            this.Fsplit_list_no = rhs.Fsplit_list_no;
            this.Fsplit_source = rhs.Fsplit_source;
            this.Fchild_work_list_no = rhs.Fchild_work_list_no;
        }

        public static bool operator ==(FreBusinessOperationInfoEntity lhs, FreBusinessOperationInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Fbusiness_type == rhs.Fbusiness_type &&
               lhs.Fassist_people == rhs.Fassist_people &&
               lhs.Fdetent_people == rhs.Fdetent_people &&
               lhs.Foperator == rhs.Foperator &&
               lhs.Foperator_company == rhs.Foperator_company &&
               lhs.Finputor == rhs.Finputor &&
               lhs.Fsplit_list_no == rhs.Fsplit_list_no &&
               lhs.Fsplit_source == rhs.Fsplit_source &&
               lhs.Fchild_work_list_no == rhs.Fchild_work_list_no
           );
        }

        public static bool operator !=(FreBusinessOperationInfoEntity lhs, FreBusinessOperationInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    /// <summary>
    /// 客户管理信息DTO
    /// </summary>
    public class AddCustomerInfoDTO : IDataValidator
    {
        public AddCustomerInfoDTO() { }


        /// <summary>
        /// 客户管理信息
        /// </summary>
        [Required]
        public CustomerSummaryInfoDTO CustomerInfo { get; set; }


        /// <summary>
        /// 资信信息
        /// </summary>
        [Required]
        public CustomerCreditInfoEntity CreditInfo { get; set; }



        /// <summary>
        /// 配置信息
        /// </summary>
        [Required]
        public CustomerConfigInfoEntity ConfigInfo { get; set; }


        /// <summary>
        /// 其他信息
        /// </summary>
        [Required]
        public CustomerOtherInfoEntity OtherInfo { get; set; }


        /// <summary>
        /// 录入信息
        /// </summary>
        [Required]
        public CustomerInputInfoEntity InputInfo { get; set; }

        public bool IsValid()
        {
            return CustomerInfo.IsValid()
                && CreditInfo.IsValid()
                && CreditInfo.IsValid()
                && OtherInfo.IsValid();
                //&& InputInfo.IsValid();
        }



        /// <summary>
        /// 将这些信息链接到关联的customerId
        /// </summary>
        /// <param name="linkCustomerID">关联的customerId</param>
        public void Linked(int linkCustomerID)
        {
            /*
            ContactInfo.FcustomerId = linkCustomerID;
            HoldAddrInfo.FcustomerId = linkCustomerID;
            BankAccountInfo.FcustomerId = linkCustomerID;
            BookSpaceReceiverInfo.FcustomerId = linkCustomerID;
            */
            CustomerInfo.Linked(linkCustomerID);
            CreditInfo.Fcustomer_id = linkCustomerID;
            ConfigInfo.Fcustomer_id = linkCustomerID;
            OtherInfo.Fcustomer_id = linkCustomerID;
            InputInfo.Fcustomer_id = linkCustomerID;
        }


    }
}

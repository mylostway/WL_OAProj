using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WL_OA.Data
{
    public class EnumNamesAttribute : Attribute
    {
        public EnumNamesAttribute(string name = "")
        {
            Name = name;
        }
        public string Name { get; set; }
    }


    /// <summary>
    /// 枚举配置查找器
    /// </summary>
    public static class EnumHelper
    {
        static Dictionary<string, Dictionary<string, string>> s_dicEnumsKeyValPair = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// 获取指定名称的枚举配置
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetEnumSettingOnName(string enumName)
        {
            if (string.IsNullOrEmpty(enumName)) return new Dictionary<string, string>();
            if(!s_dicEnumsKeyValPair.ContainsKey(enumName))
            {
                // 遇到没有找到enum配置的情况，直接添加一个空列表以返回
                s_dicEnumsKeyValPair.Add(enumName, new Dictionary<string, string>());                
            }
            return s_dicEnumsKeyValPair[enumName];
        }

        /// <summary>
        /// 将枚举类的名字转换成对应的约定值
        /// </summary>
        /// <param name="e"></param>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static int ConvNameToVal(this Enum e,string enumName)
        {
            var type = e.GetType();
            var typeName = type.Name;
            if (!s_dicEnumsKeyValPair.ContainsKey(typeName)) return -1;
            var dic = s_dicEnumsKeyValPair[typeName];
            if (!dic.ContainsKey(enumName)) return -1;
            return int.Parse(dic[enumName]);
        }


        /// <summary>
        /// 将枚举类的名字转换成对应的约定值
        /// </summary>
        /// <param name="e"></param>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static int ToEnumVal(this string enumName, Type enumType)
        {
            var typeName = enumType.Name;
            if (!s_dicEnumsKeyValPair.ContainsKey(typeName)) return -1;
            var dic = s_dicEnumsKeyValPair[typeName];
            if (!dic.ContainsKey(enumName)) return -1;
            return int.Parse(dic[enumName]);
        }


        static EnumHelper()
        {
            // 这样查找非常方便，不过效率可能低，因为要遍历整个Assembly的数据
            var assembly = Assembly.GetAssembly(typeof(EnumHelper));

            var allTypes = assembly.GetTypes();

            foreach(var eType in allTypes)
            {
                if(eType.IsEnum)
                {
                    var dic = new Dictionary<string, string>();
                    var arrays = eType.GetEnumValues();
                    foreach(var eElem in arrays)
                    {
                        var fieldInfo = eElem.GetType().GetField(eElem.ToString());
                        var attribArray = fieldInfo.GetCustomAttributes(false);
                        if(0 == attribArray.Length)
                        {
                            // 不符合的枚举格式，没有说明属性
                            continue;
                        }
                        var attrib = (EnumNamesAttribute)attribArray[0];
                        if(null == attrib)
                        {
                            // 不符合的枚举格式，没有说明属性
                            continue;
                        }
                        dic.Add(attrib.Name, Convert.ToInt32(eElem).ToString());
                    }
                    s_dicEnumsKeyValPair.Add(eType.Name, dic);
                }
            }
        }
    }

    public enum DateTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("业务日期")]
        BusinessDate,
        [EnumNames("制单日期")]
        MakeListDate,
        [EnumNames("提交商务日期")]
        CommitBusinessDate,
        [EnumNames("预到船期")]
        BookedShipReachDate,
        [EnumNames("中转开船期")]
        TransferShipDate,
        [EnumNames("预开船期")]
        BookedShipStartDate,
        [EnumNames("预计送货期")]
        WantedSendGoodsDate,
        [EnumNames("装货日期")]
        HoldGoodsDate,
        [EnumNames("预计到达期")]
        WantedReachDate,
        [EnumNames("录入时间")]
        InputTime,
        [EnumNames("审核时间")]
        AduitTime,
    }


    /// <summary>
    /// 单号类型枚举
    /// </summary>
    public enum ListIDTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("运单号")]
        ShipNo,
        [EnumNames("柜号")]
        CabinetNo,
        [EnumNames("工作单号")]
        WorkNo,
    }


    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("可用")]
        Usable,

        [EnumNames("未提交商务")]
        NotCommitBusiness,
        [EnumNames("已提交商务")]
        CommitedBusiness,
        [EnumNames("已业务单审核")]
        BusinessAudited,
        [EnumNames("未业务单审核")]
        BusinessNotAudit,
    }



    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum PaywayEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("月结")]
        MonthlyBalance = 1,
        [EnumNames("票结")]
        TicketKnot = 2,
        [EnumNames("代收款")]
        TradeCharges = 3,
        [EnumNames("代垫")]
        Advance = 4,
    }



    /// <summary>
    /// 客户ID类型枚举
    /// </summary>
    public enum QueryCustomerInfoIDTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("助记码")]
        Remark,
        [EnumNames("公司简称,selected")]
        Forshot,
        [EnumNames("公司全称")]
        FullName,
        [EnumNames("企业物流号")]
        CompanyLogisticsID,
        [EnumNames("业务员")]
        BusinessMan,
        [EnumNames("付款方式")]
        Payway,
        [EnumNames("客户类型")]
        CustomType,
        [EnumNames("省份")]
        Province,
        [EnumNames("城市")]
        City,
        [EnumNames("区域")]
        Area,
        [EnumNames("部门")]
        Department,
        [EnumNames("公司地址")]
        CompanyAddr
    }


    /// <summary>
    /// 客户类型枚举
    /// </summary>
    public enum QueryCustomerInfoTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("船东")]
        ShipOwner,
        [EnumNames("托运人")]
        Consignor,
        [EnumNames("发货人")]
        Sender,
        [EnumNames("收货人")]
        Receiver,
        [EnumNames("通知人")]
        Notifier,
        [EnumNames("仓库")]
        Cabinet,
        [EnumNames("港口代理")]
        WharfProxy
    }


    /// <summary>
    /// 客户状态枚举，按位取值，0 - 可用，1 - 已审核，2 - 共享，3 - 完成，4 - 黑名单，5 - 收短信
    /// </summary>
    public enum QueryCustomerInfoStateEnums : int
    {
        [EnumNames("不限")]
        None = -1,
        [EnumNames("不可用")]
        Useless,
        [EnumNames("可用")]
        Usable,
        [EnumNames("未审核")]
        UnAduited,
        [EnumNames("已审核")]
        Aduited,
        [EnumNames("共享")]
        Shared,
        [EnumNames("不共享")]
        UnShared,
        [EnumNames("黑名单")]
        BlackList,
        [EnumNames("非黑名单")]
        NotBlackList,
        [EnumNames("收短信")]
        ReceivedShortmsg,
        [EnumNames("不收短信")]
        NotReceivedShortmsg,
    }
}

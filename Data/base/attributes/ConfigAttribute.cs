using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigAttribute : Attribute
    {
        public ConfigAttribute(string fileRelativePath = "")
        {
            FileRelativePath = fileRelativePath;
        }

        /// <summary>
        /// 配置文件相对路径（不能为绝对路径，不能向上查找！根目录会在配置类中组合）
        /// </summary>
        public string FileRelativePath { get; set; }
    } 
}

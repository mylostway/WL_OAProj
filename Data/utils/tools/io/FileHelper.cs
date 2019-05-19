using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WL_OA.Data.utils.tools
{
    public class FileHelper
    {        
        /// <summary>
        /// 简单读取文件内容·
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encoding">指定编码</param>
        /// <returns></returns>
        public static string ReadFileContent(string path, Encoding encoding = null)
        {
            SAssert.MustTrue(!string.IsNullOrEmpty(path), string.Format("要读取的文件路径不能为空"));

            if (null == encoding) encoding = RunTimeConfig.DEFAULT_CODING;

            PathHelper.MustBeNotUpPath(path);

            SAssert.MustTrue(File.Exists(path), string.Format("文件路径{0}不存在!", path));

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }



        /// <summary>
        /// 保存文件内容到文件，如果保存的路径目录不存在会抛出异常
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="encoding">默认使用运行时默认编码</param>
        public static void SaveToFile(string path,string content, Encoding encoding = null)
        {
            if (null == encoding) encoding = RunTimeConfig.DEFAULT_CODING;

            //PathHelper.MustBeNotUpPath(path);

            // 保存路径的目录不存在，保存失败
            if (!PathHelper.IsPathDirectoryExist(path))
                throw new UserFriendlyException($"文件路径 {path} 目录不存在，保存文件失败");

            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                }
            }
        }
    }
}

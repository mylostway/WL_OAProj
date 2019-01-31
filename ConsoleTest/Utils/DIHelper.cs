using System;
using System.Collections.Generic;
using System.Text;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using WL_OA.Data;

namespace ConsoleTest.Utils
{
    /// <summary>
    /// 注入依赖工具
    /// </summary>
    public class DIHelper
    {
        private DIHelper()
        {
            m_cb.Register<IAssessRight>(c => DefaultAssessRight.Instance).AsSelf().SingleInstance();

            m_asp = new AutofacServiceProvider(m_cb.Build());
        }


        public static DIHelper Instance = new DIHelper();

        ContainerBuilder m_cb = new ContainerBuilder();

        AutofacServiceProvider m_asp = null;

        /// <summary>
        /// 获取IServiceProvider的DI实现
        /// </summary>
        /// <returns></returns>
        public IServiceProvider GetServicesProvider()
        {
            return m_asp;
        }
    }


}

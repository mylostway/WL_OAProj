using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WL_OA.Data;
using WL_OA.Data.dal.Cache;
using WL_OA.Data.utils;
using WL_OAProj.Middlewares;

namespace WL_OAProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<ILog>(LogManager.GetLogger(this.GetType()));
            //services.AddSingleton<ILog>(SLogger.Instance);

            // 使用内存Cache
            //services.AddMemoryCache();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddSingleton<ICacheServices, MemoryCacheServices>();
            // 再启动session
            services.AddSession();

            services.AddSingleton<IAssessRight>(DefaultAssessRight.Instance);            

            services.AddMvc().AddJsonOptions(options =>
            {
                //options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";

                options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            });

            //services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)//增加环境配置文件，新建项目默认有
                .AddEnvironmentVariables();

            var Configuration = builder.Build();   

            // FIXME：这里配置文件路径需要确认
            var cfgPath = $"{env.ContentRootPath}/Configs/log4net.config";
            XmlConfigurator.Configure(new FileInfo(cfgPath));
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMiddleware<ExceptionHandlerMidware>();
            app.UseMiddleware<RequestLogMidware>();

            app.UseStaticFiles();

            app.UseMvc();
            
            SLogger.Info("server start...");            
        }
    }
}

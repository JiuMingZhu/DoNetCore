using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // 添加用户Session服务
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;

            });

            // 指定Session保存方式:分发内存缓存
            services.AddDistributedMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDirectoryBrowser();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();//清除默认的default、index
            defaultFilesOptions.DefaultFileNames.Add("HomeView.cshtml");
            app.UseHttpsRedirection();

            #region 允许访问静态资源，并且将非常见后缀名处理为对应的MIME类型
            // Set up custom content types - associating file extension to MIME type
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Add(".moc", "application/x-msdownload");
            provider.Mappings.Add(".mtn", "application/x-msdownload");
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });
            #endregion

            //启用Session服务
            app.UseSession();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pages",
                    template: "{controller=Blog}/{action=Index}/{param:maxlength(128)}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Blog}/{action=Index}");
                //routes.MapRoute(
                //    name: "article",
                //    template: "{controller=Article}/{action=Index}/{id:int?}");

            });
        }
    }
}

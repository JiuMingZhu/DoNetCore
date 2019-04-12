using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Common.Tools;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            test();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void test()
        {
            #region 数据库连接接测试
            //for (int i = 0; i < 10; i++)
            //{
            //    Models.DBContext ctx = new Models.DBContext();
            //    DateTime dateTime = DateTime.Now;
            //    var testData = System.IO.File.ReadAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "testData.txt"));
            //    Models.BlogModel blog = new Models.BlogModel()
            //    {
            //        Title = "Markdown测试",
            //        SubTitle = "测试",
            //        Author = "小明",
            //        CreateTime = dateTime,
            //        LastEditTime = dateTime,
            //        MainBody = testData
            //    };

            //    ctx.Blogs.Add(blog);
            //    ctx.SaveChanges();
            //}
            #endregion
            #region 日志测试
            //LogHelper.WriteLogDebug("测试");
            //LogHelper.WriteLogException("测试");
            //LogHelper.WriteLogException(new Exception("测试"));
            //LogHelper.WriteLogExceptionUnhandled("测试");
            //LogHelper.WriteLogTrace("测试");
            //LogHelper.WriteLogWeb("测试");
            #endregion
        }
    }
}

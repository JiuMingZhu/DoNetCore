using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //test();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static void test(){
            Models.DBContext ctx = new Models.DBContext();
            DateTime dateTime = DateTime.Now;
            var testData = System.IO.File.ReadAllText(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "testData.txt"));
            Models.BlogModel blog = new Models.BlogModel()
            {
                Title = "Markdown测试",
                SubTitle = "测试",
                Author = "小明",
                CreateTime = dateTime,
                LastEditTime = dateTime,
                MainBody = testData
            };
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
        }
    }
}

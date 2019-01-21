using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Blog.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DbSet<BlogModel> Blogs { get; set; }
        /// <summary>
        /// 数据库配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Common.Tools.AppSettings.GetConfig("ConnectionStrings:Mysql"));//配置连接字符串
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var article = modelBuilder.Entity<Blog>().ToTable("Article");
        //    article.Property(e => e.Id).IsRequired();//不写IsRequired,默认为可空
        //    article.Property(e => e.Title).IsRequired();
        //    article.Property(e => e.SubTitle);
        //}
    }
}

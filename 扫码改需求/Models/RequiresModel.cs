using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 扫码改需求.Models
{
    public class RequiresModelContext : DbContext
    {
        public RequiresModelContext(DbContextOptions<RequiresModelContext> options)
            : base(options)
        { }

        public DbSet<RequireModel> RequireModelItems { get; set; }
    }

    public class RequireModel
    {
        /// <summary>
        /// 需求ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 需求联系人
        /// </summary>
        public string ContactPerson { get; set; }
        /// <summary>
        /// 需求联系人电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 需求标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 需求内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 需求提出日期
        /// </summary>
        public DateTime OriDate { get; set; }
        /// <summary>
        /// 需求变更日期
        /// </summary>
        public DateTime LastestDate { get; set; }
        /// <summary>
        /// 需求优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 需求确认状态
        /// </summary>
        public ConfirmStatus ConfirmStatus { get; set; }
        /// <summary>
        /// 需求完成状态
        /// </summary>
        public WorkingStatus WorkingStatus { get; set; }
    }
    /// <summary>
    /// 需需求确认状态
    /// </summary>
    public enum ConfirmStatus
    {
        /// <summary>
        /// 确认中
        /// </summary>
        Confirming = 0,
        /// <summary>
        /// 已确认
        /// </summary>
        Confirmed = 1
    }
    /// <summary>
    /// 需求完成状态
    /// </summary>
    public enum WorkingStatus
    {
        /// <summary>
        /// 准备中
        /// </summary>
        Preparing = 0,
        /// <summary>
        /// 制作中
        /// </summary>
        Working = 1,
        /// <summary>
        /// 需求变更
        /// </summary>
        ReConfirming = 2,
        /// <summary>
        /// 完成
        /// </summary>
        Completed = 3
    }
    /// <summary>
    /// 需求优先级
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// 可排后
        /// </summary>
        Negative = 0,
        /// <summary>
        /// 一般
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 紧急
        /// </summary>
        Ugency = 2,
        /// <summary>
        /// 需要加班
        /// </summary>
        DeadLine = 3,
    }
}

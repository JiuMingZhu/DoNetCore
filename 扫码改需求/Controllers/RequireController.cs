using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using 扫码改需求.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace 扫码改需求.Controllers
{
    [Route("api/[controller]")]
    public class RequireController : Controller
    {
        private readonly RequiresModelContext requiresModelContext;
        public RequireController(RequiresModelContext requiresModelContext)
        {
            this.requiresModelContext = requiresModelContext;
        }

        /// <summary>
        /// 添加需求
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/AddRequire")]
        public IActionResult AddRequire(RequireModel value)
        {
            try
            {
                var result = requiresModelContext.RequireModelItems.Where(item => item.Id == value.Id).ToList();
                if (result.Count != 0)
                {
                    //已经有该需求了
                    return BadRequest();
                }
                else
                {
                    value.Id = 0;//这里不允许显式插入主键
                    requiresModelContext.Add(value);
                    requiresModelContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                var exString = ex.ToString();
                return BadRequest();
            }
        }

        /// <summary>
        /// 添加需求
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("/AddRequire_FromBody")]
        public IActionResult AddRequire_FromBody([FromBody]RequireModel value)
        {
            try
            {
                var result = requiresModelContext.RequireModelItems.Where(item => item.Id == value.Id).ToList();
                if (result.Count != 0)
                {
                    //已经有该需求了
                    return BadRequest();
                }
                else
                {
                    value.Id = 0;//这里不允许显式插入主键
                    requiresModelContext.Add(value);
                    requiresModelContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                var exString = ex.ToString();
                return BadRequest();
            }
        }

        /// <summary>
        /// 获取全部需求
        /// </summary>
        /// <returns></returns>
        [HttpGet("/GetAll")]
        public IActionResult GetAll()
        {
            var result = requiresModelContext.RequireModelItems.ToList();
            return Ok(result);
        }
    }
}

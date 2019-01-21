using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromQuery]int? count)
        {
            DBContext ctx = new DBContext();
            List<BlogModel> blogs;
            if (count != null && count >= 1)
            {
                blogs=ctx.Blogs.Where(t => t.Id >= 0 && t.Id <= count).ToList();
            }
            else
            {
                blogs=ctx.Blogs.Where(t => t.Id >= 0 && t.Id < 10).ToList();
            }
            return View("~/Views/Home/HomeView.cshtml", blogs);
        }
    }
}
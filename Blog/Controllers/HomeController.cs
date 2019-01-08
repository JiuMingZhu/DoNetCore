using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DBContext ctx = new DBContext();
            return View("~/Views/Home/HomeView.cshtml", ctx.Blogs);
        }
    }
}
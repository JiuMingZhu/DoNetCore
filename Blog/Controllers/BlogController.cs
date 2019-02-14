using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IActionResult Index()
        {
            //return Home(10);
            return View();
        }

        /// <summary>
        /// Home
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IActionResult Home([FromQuery]int? param)
        {
            DBContext ctx = new DBContext();
            List<BlogModel> blogs;
            if (param != null && param >= 1)
            {
                blogs = ctx.Blogs.Where(t => t.Id >= 0 && t.Id <= param).ToList();
            }
            else
            {
                blogs = ctx.Blogs.Where(t => t.Id >= 0 && t.Id < 10).ToList();
            }
            return View("~/Views/Blog/Home.cshtml",blogs);
        }
        /// <summary>
        /// Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Article([FromQuery]int? id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (id == null)
            {
                return NotFound();
            }
            DBContext ctx = new DBContext();
            var blog = ctx.Blogs.First(t => t.Id == id);
            return View(blog);
        }

        /// <summary>
        /// Archives
        /// </summary>
        /// <returns></returns>
        public IActionResult Archives([FromRoute]string archive)
        {
            DBContext ctx = new DBContext();
            var blogs = ctx.Blogs.ToList();
            return View(blogs);
        }

        /// <summary>
        /// Categories
        /// </summary>
        /// <param name="param">CategoryName</param>
        /// <returns></returns>
        public IActionResult Categories([FromRoute]string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                //if param is null,just show all categories
                DBContext ctx = new DBContext();
                var categories = ctx.Blogs.Select(t => t.Category).Distinct().ToList();
                ViewData["action"] = "categories";
                return View("~/Views/Blog/CategoriesOrTags.cshtml",categories);
            }
            else
            {
                //show all articles wicth category equals param
                DBContext ctx = new DBContext();
                var blogs = ctx.Blogs.Where(t => t.Category == param).Distinct().ToList();
                return View("~/Views/Blog/CategoriesOrTags.cshtml", blogs);
            }
        }

        /// <summary>
        /// Tags
        /// </summary>
        /// <param name="param">Tag</param>
        /// <returns></returns>
        public IActionResult Tags([FromRoute]string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                //if param is null,just show all Tags
                DBContext ctx = new DBContext();
                var tags = ctx.Blogs.Select(t => t.Tag).Distinct().ToList();
                ViewData["action"] = "tags";
                return View("~/Views/Blog/CategoriesOrTags.cshtml",tags);
            }
            else
            {
                //show all articles wicth tag equals param
                DBContext ctx = new DBContext();
                var blogs = ctx.Blogs.Where(t => t.Tag == param).Distinct().ToList();
                return View("~/Views/Blog/CategoriesOrTags.cshtml", blogs);
            }
        }

        /// <summary>
        /// About
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return Redirect("/Blog/Login");
            }
            DBContext ctx = new DBContext();
            return View("~/Views/Blog/About.cshtml");
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetInt32("UserId", new System.Random().Next(100000));
            return Redirect("/Blog/About");
            DBContext ctx = new DBContext();
            return View("~/Views/Blog/About.cshtml");
            //return View();
        }
    }
}
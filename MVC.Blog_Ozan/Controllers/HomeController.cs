using MVC.Blog_Ozan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Blog_Ozan.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext conn = new BlogDbContext();
        public ActionResult Index(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                return View(conn.Categories.Where(x => x.CategoryName == category).FirstOrDefault().Posts.Take(2).ToList());
            }
            return View(conn.Posts.Take(2).ToList());
        }

        public ActionResult About()
        {
           // ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            //ViewBag.Categories = conn.Categories.ToList();
            return View(conn.Posts.Find(id));
        }

        [ChildActionOnly]
        public ActionResult Navbar()
        {
            ViewBag.Categories = conn.Categories.ToList();
            return PartialView();
        }

        public ActionResult GetMore(string category, int toSkip)
        {
            List<string> postList = new List<string>();
            if (string.IsNullOrEmpty(category))
            {
                postList = conn.Posts.ToList().Skip(toSkip).Take(2).Select(x=>x.Title).ToList();
            }
            else
            {
                postList = conn.Posts.Where(x=>x.Category.CategoryName==category).ToList().Skip(toSkip).Take(2).Select(x=>x.Title).ToList();
            }

            return Json(postList,JsonRequestBehavior.AllowGet);
        }
    }
}
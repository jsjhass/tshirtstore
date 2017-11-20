using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tshirtstore.Models;

namespace Tshirtstore.Controllers
{
    public class HomeController : Controller
    {
        TshirtContext db = new TshirtContext();
        public ActionResult Index()
        {
            var kid = db.Product.Where(m => m.CategoryID == 1).OrderByDescending(m => m.UploadDate).Take(4);
            var women = db.Product.Where(m => m.CategoryID == 2).OrderByDescending(m => m.UploadDate).Take(4);
            var men = db.Product.Where(m => m.CategoryID == 3).OrderByDescending(m => m.UploadDate).Take(4);
            var baby = db.Product.Where(m => m.CategoryID == 4).OrderByDescending(m => m.UploadDate).Take(4);
            ViewBag.kid = kid;
            ViewBag.women = women;
            ViewBag.men = men;
            ViewBag.baby = baby;
            return View();
        }

        public ActionResult Search()
        {
            string s=Request.Form["txtSearch"];
            var p = (from a in db.Product join b in db.Category on a.CategoryID equals b.CategoryID where a.ProductName.Contains(s) select new SearchViewModel { ProductId=a.ProductId, ProductName = a.ProductName, ImageThumb=a.ImageThumb, Price=a.Price, CategoryName = b.CategoryName }).ToList();
            ViewBag.search = s;
            return View(p);
        }
    }
}
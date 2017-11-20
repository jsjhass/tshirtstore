using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Tshirtstore.Models;

namespace Tshirtstore.Controllers
{
    public class ProductController : Controller
    {
        TshirtContext db = new TshirtContext();
        // GET: Product
        public ActionResult Index(int cat)
        {
            var p = db.Product.Where(m => m.CategoryID == cat);
            var c = db.Category.Where(m => m.CategoryID == cat).Select(m => m.CategoryName).Single();
            ViewBag.cat = c;
            ViewBag.catid = cat;
            return View(p);
        }
        public ActionResult ProductDetail(int id)
        {
            var p = db.Product.Find(id);
            string s = db.Category.Where(m => m.CategoryID == p.CategoryID).Select(m => m.CategoryName).Single();
            ViewBag.cat = s;
            return View(p);
        }
        public PartialViewResult ShowProduct(int cat,string price)
        {
            if (price == "hl")
            {
                var p = db.Product.Where(m => m.CategoryID == cat).OrderByDescending(m => m.Price);
                var c = db.Category.Where(m => m.CategoryID == cat).Select(m => m.CategoryName).Single();
                ViewBag.cat = c;
                return PartialView(p);
            }
            else if(price=="lh")
            {
                var p = db.Product.Where(m => m.CategoryID == cat).OrderBy(m => m.Price);
                var c = db.Category.Where(m => m.CategoryID == cat).Select(m => m.CategoryName).Single();
                ViewBag.cat = c;
                return PartialView(p);
            }
            else
            {
                var p = db.Product.Where(m => m.CategoryID == cat);
                var c = db.Category.Where(m => m.CategoryID == cat).Select(m => m.CategoryName).Single();
                ViewBag.cat = c;
                return PartialView(p);
            }
        }
    }
}
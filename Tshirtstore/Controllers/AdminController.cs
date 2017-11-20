using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Tshirtstore.Models;

namespace Tshirtstore.Controllers
{
    public class AdminController : Controller
    {
        TshirtContext db = new TshirtContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            var s = (from m in db.Admin where m.UserName == ad.UserName && m.Password == ad.Password select m).FirstOrDefault();
            if (s != null)
            {
                Session["admin"] = ad.UserName;
                return RedirectToAction("AdminMain", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name / Password.");
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AdminMain()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            var category = db.Category;
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product pr,HttpPostedFileBase Image,HttpPostedFileBase ImageThumb)
        {
            pr.Image = Path.GetFileName(Image.FileName);
            pr.ImageThumb = Path.GetFileName(ImageThumb.FileName);
            pr.UploadDate = System.DateTime.Now;
            int cat = Convert.ToInt32(pr.CategoryID);
            pr.CategoryID = cat;
            var catnm=db.Category.Where(m=>m.CategoryID==cat).Select(m=>m.CategoryName).Single();
            Image.SaveAs(Server.MapPath("~/Content/images/Tshirt/" + catnm + "/" + pr.Image));
            ImageThumb.SaveAs(Server.MapPath("~/Content/images/Tshirt/" + catnm + "/" + pr.ImageThumb));
            db.Product.Add(pr);
            db.SaveChanges();
            var category = db.Category;
            ViewBag.Category = category;
            ViewBag.Message = "Tshirt Added Successfully.";
            return View();
        }
        public ActionResult RemoveProduct()
        {
            var product = db.Product.OrderBy(m => m.ProductId);
            return View(product);
        }
        public ActionResult Delete(int id,int catid)
        {
            var catnm = db.Category.Where(m => m.CategoryID == catid).Select(m => m.CategoryName).Single();
            var p = db.Product.Find(id);
            ViewBag.catnm = catnm;
            return View(p);
        }
        public ActionResult ViewOrder()
        {
            var od = (from a in db.Order join b in db.Product on a.ProductId equals b.ProductId select new OrderViewModel { ProductId = a.ProductId, ProductName = b.ProductName, Price = b.Price, UserName = a.UserName, ShippingAddress = a.ShippingAddress, OrderDate = a.OrderDate }).OrderByDescending(a=>a.OrderDate);
            return View(od);
        }
    }
}
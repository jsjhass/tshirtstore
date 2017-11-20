using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tshirtstore.Models;

namespace Tshirtstore.Controllers
{
    public class ShopController : Controller
    {
        TshirtContext db = new TshirtContext();
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
        public string AddCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();
                var i = db.Product.Find(id);
                li.Add(i);
                Session["cart"] = li;
                Session["count"] = 1;
                return "Tshirt Added to Cart.";
            }
            else
            {
                List<Product> li = (List<Product>)Session["Cart"];
                bool c = false;
                foreach(var a in li)
                {
                    if(a.ProductId==id)
                    {
                        c = true;
                    }
                }
                if(c==true)
                {
                    return "Tshirt already added to Cart.";
                }
                else
                {
                    var i = db.Product.Find(id);
                    li.Add(i);
                    Session["cart"] = li;
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    return "Tshirt Added to Cart";
                }   
            }
        }
        public ActionResult ViewCart()
        {
            List<Product> li = (List<Product>)Session["cart"];
            if(Session["cart"]!=null)
            { 
            ViewBag.total = li.Sum(m => m.Price);
            }
            return View(li);
        }
        public ActionResult RemoveCart(int id)
        {
            List<Product> li = (List<Product>)Session["cart"];
            li.RemoveAll(m => m.ProductId == id);
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            if(Convert.ToInt32(Session["count"])==0)
            {
                Session["cart"] = null;
            }
            return RedirectToAction("ViewCart");
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(string payment)
        {
            if(payment=="cod")
            {
                return RedirectToAction("Cod");
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult Cod()
        {
            List<Product> li = (List<Product>)Session["cart"];
            if (Session["cart"] != null)
            {
                ViewBag.total = li.Sum(m => m.Price);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Cod(Order od)
        {
            List<Product> li = (List<Product>)Session["cart"];
            int c = Convert.ToInt32(Session["count"]);
            for (int i = 0; i < c; i++)
            {
                od.ProductId = li[i].ProductId;
                od.UserName = Session["user"].ToString();
                od.Price = li[i].Price;
                od.OrderDate = System.DateTime.Now;
                db.Order.Add(od);
                db.SaveChanges();
            }
            Session["cart"] = null;
            Session["count"] = null;
            TempData["dd"] = System.DateTime.Now.AddDays(7).ToString("d");
            return RedirectToAction("OrderSuccess");
        }
        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}
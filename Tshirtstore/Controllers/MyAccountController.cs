using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tshirtstore.Models;

namespace Tshirtstore.Controllers
{
    public class MyAccountController : Controller
    {
        TshirtContext db = new TshirtContext();
        // GET: MyAccount
        public ActionResult Index()
        {
            if (Session["user"] == null)
              {
                return RedirectToAction("Login", "MyAccount");
              }
            else
              {
                return RedirectToAction("AccountDetail", "MyAccount");
              }
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Client cl)
        {
            db.Client.Add(cl);
            db.SaveChanges();
            return View("RegisterSuccess");
        }
        public ActionResult AccountDetail()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Client cl)
        {
            var s = (from m in db.Client where m.UserName == cl.UserName && m.Password == cl.Password select m).FirstOrDefault();
            if (s != null)
            {
                Session["user"] = cl.UserName;
                return RedirectToAction("AccountDetail", "MyAccount");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name / Password.");
                return View();
            }
        }
    }
}
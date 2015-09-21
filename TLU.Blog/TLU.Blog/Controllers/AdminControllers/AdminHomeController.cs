using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.AdminControllers
{
    public class AdminHomeController : AdminBaseController
    {
        private const int ACCOUNT_ID = 15;
        // GET: AdminHome
        public ActionResult Home()
        {

            ViewBag.Profile = new AccountModel().GetProfileById(ACCOUNT_ID);
            return View();
        }
        public ActionResult LogOut()
        {
            const string ACCOUNT_ADMIN = "AccountAdmin";
            HttpContext.Session.Remove(ACCOUNT_ADMIN);
            return RedirectToAction("LogIn", "AdminLogIn");
        }
    }
}
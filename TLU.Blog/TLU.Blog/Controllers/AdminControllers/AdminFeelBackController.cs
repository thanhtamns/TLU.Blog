using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.AdminControllers
{
    public class AdminFeelBackController : Controller
    {
        //
        // GET: /AdminFeelBack/
        public ActionResult Index(int Page = 1,int PageSize=10)
        {
            return View(new FeelBackModel().GetPageListFeelBack(Page,PageSize));
        }
        public ActionResult Details(int id)
        {
            new FeelBackModel().Checked(id);
            return View(new FeelBackModel().GetFeelBackById(id));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new FeelBackModel().GetFeelBackById(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                new FeelBackModel().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
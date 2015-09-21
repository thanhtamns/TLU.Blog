using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminHistoryController : Controller
    {
        // GET: AdminHistory
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new HistoryModel().GetPageListHistoryIsActive(Page,PageSize));
        }

        // GET: AdminHistory/Details/5
        public ActionResult Details(int id)
        {
            return View(new HistoryModel().GetHistoryById(id));
        }
        [HttpGet]
        public ActionResult Hide(int id)
        {
            return View(new HistoryModel().GetHistoryById(id));
        }
        [HttpPost]
        public ActionResult Hide(int id, FormCollection collection)
        {
            try
            {
                new HistoryModel().Hide(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }


    }
}

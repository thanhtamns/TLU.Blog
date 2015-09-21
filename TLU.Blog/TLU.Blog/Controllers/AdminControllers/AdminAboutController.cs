using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.AdminControllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new AboutModel().GetPageListAbout(Page,PageSize));
        }

        // GET: AdminAbout/Details/5
        public ActionResult Details(int id)
        {
            return View(new AboutModel().GetAboutById(id));
        }

        // GET: AdminAbout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAbout/Create
        [HttpPost]
        public ActionResult Create(About pNewAbout)
        {
            try
            {
                HttpPostedFileBase file = HttpContext.Request.Files["pImage"];
                string a = "/Image/" + file.FileName;
                string b = Server.MapPath(a);
                file.SaveAs(b);
                var Image = new Image();
                Image.Image1 = a;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminAbout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminAbout/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminAbout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminAbout/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminImageController : Controller
    {
        // GET: AdminImage
        public ActionResult Index(int Page=1,int PageSize=10)
        {

            return View(new ImageModel().GetPageListImage(Page,PageSize));
        }

        // GET: AdminImage/Details/5
        public ActionResult Details(int id)
        {
            return View(new ImageModel().GetImageById(id));
        }

        // GET: AdminImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminImage/Create
        [HttpPost]
        public ActionResult Create(Image pNewImage)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminImage/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new ImageModel().GetImageById(id));
        }

        // POST: AdminImage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Image pNewImage)
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

        // GET: AdminImage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminImage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Image pNewImage)
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

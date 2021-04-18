using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanjis.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Index()
        {
            return View();
        }

        // GET: Action/Details/5
        public ActionResult Details(string id)
        {
            return Json(new { 
            id = id
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Action/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Action/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Action/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Action/Edit/5
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

        // GET: Action/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Action/Delete/5
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

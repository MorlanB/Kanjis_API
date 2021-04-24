using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanjis.Controllers
{
    public class TarjetasController : Controller
    {
        [HttpGet]
        public ActionResult getTarjetas()
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetAllTarjetas(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTarjetaByMeaning(string meaning/* = ""*/)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaByMeaning(meaning), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTarjetaByWriting(string writing)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaByWriting(writing), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTarjetaByKanji(string kanji)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaByKanji(kanji), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTarjetaById(int id)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaById(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTarjetaByAny(string any)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaByAny(any), JsonRequestBehavior.AllowGet);
        }


        // GET: Tarjetas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tarjetas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tarjetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarjetas/Create
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

        // GET: Tarjetas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tarjetas/Edit/5
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

        // GET: Tarjetas/Delete/5
        public ActionResult Delete(int id)
        {
            //??
            return View();
        }

        // POST: Tarjetas/Delete/5
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

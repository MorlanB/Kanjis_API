using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kanjis.Models;

namespace Kanjis.Controllers
{
    public class TarjetasController : Controller
    {
        [HttpGet]
        public ActionResult getTarjetas()
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.getAllTarjetas(), JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult getTarjetaByMeaning(string meaning)
        //{
        //    TarjetaBLL BLL = new TarjetaBLL();
        //    return Json(BLL.GetTarjetaByMeaning(meaning.ToLower()), JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult getTarjetaByWriting(string writing)
        //{
        //    TarjetaBLL BLL = new TarjetaBLL();
        //    return Json(BLL.GetTarjetaByWriting(writing.ToLower()), JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult getTarjetaByKanji(string kanji)
        //{
        //    TarjetaBLL BLL = new TarjetaBLL();
        //    return Json(BLL.GetTarjetaByKanji(kanji.ToLower()), JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult getTarjetaById(int id)
        //{
        //    TarjetaBLL BLL = new TarjetaBLL();
        //    return Json(BLL.GetTarjetaById(id), JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult getTarjetaByAny(string any)
        {
            TarjetaBLL BLL = new TarjetaBLL();
            return Json(BLL.GetTarjetaByAny(any.ToLower()), JsonRequestBehavior.AllowGet);
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

        // GET: Tarjetas/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Tarjetas/Create
        [HttpPost]
        public ActionResult Create(TarjetaForm tar)
        {
                TarjetaBLL BLL = new TarjetaBLL();
            if (BLL.insertTarjeta(tar.kanji, tar.lectura, tar.significado, tar.notas, tar.diccionario))
                ViewBag.Message = "Se ha guardado la tarjeta exitosamente.";
            else
                ViewBag.Message = "Error al guardar datos.";
                
            return RedirectToAction("Index");
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

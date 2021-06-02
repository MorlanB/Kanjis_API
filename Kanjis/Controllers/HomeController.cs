using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kanjis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
        [Route("kanji")]
        public ActionResult GetKanji()
        {
            TarjetaBLL Cl = new TarjetaBLL();
            return Json(new
            {
                name = "Kanji1",
                array = new string[] { "僕" }
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getMenu()
        {
            MenuBLL BLL = new MenuBLL();
            //TarjetaBLL Cl = new TarjetaBLL();
            //Cl.sqlQuery();
            //return Json(BLL.getMenuJson(), JsonRequestBehavior.AllowGet);
            return Json(BLL.getMenu(), JsonRequestBehavior.AllowGet);
        }

    }
}

using LazyPlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyPlay.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private Data DataService;
        public HomeController()
        {
            DataService = new Data();
        }
        public ActionResult Index()
        {
            IEnumerable<Nation> nations = DataService.GetNations();
            return View(nations);
        }
        [ActionName("Lindex")]
        public ActionResult LazyIndex()
        {
            IEnumerable<Nation> nations = DataService.Nations;
            return View(nations);
        }

        //[ActionName("get--colors")]
        //public ActionResult GetColors()
        //{
        //    IEnumerable<string> colors = DataService.GetColors();
        //    return View(colors);
        //}

        //[ActionName("let--colors")]
        //public ActionResult LazyColors()
        //{
        //    ViewBag.colors = DataService.Colors;
        //    return View();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickHelperPlay.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.R1 = new List<string> { "one" };
            ViewBag.R2 = new List<string>();
            ViewBag.R3 = new List<string> { "one", "two", "three" };
            return View();
        }
        public ActionResult Text()
        {
            return View();
        }
    }
}

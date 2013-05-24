using AttributePlay.Models;
using System.Web.Mvc;

namespace AttributePlay.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success", model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Success(PersonModel model)
        {
            return View(model);
        }
    }
}

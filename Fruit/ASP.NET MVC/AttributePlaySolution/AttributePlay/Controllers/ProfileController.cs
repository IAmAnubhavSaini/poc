using AttributePlay.Models;
using System.Web.Mvc;

namespace AttributePlay.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Home/
        [ActionName("Init")]
        public ActionResult Index()
        {
            return View();
        }
        [ActionName("AddProfile")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveProfile")]
        public ActionResult Add(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Done", model);
            }
            else
            {
                return View(model);
            }
        }
        [ActionName("Done")]
        public ActionResult Success(PersonModel model)
        {
            return View(model);
        }
    }
}

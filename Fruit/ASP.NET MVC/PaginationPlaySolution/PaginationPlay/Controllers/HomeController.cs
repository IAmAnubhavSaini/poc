using PaginationPlay.Models;
using System.Web.Mvc;

namespace PaginationPlay.Controllers
{
    public class HomeController : Controller
    {
        IDataService service;

        public HomeController()
        {
            service = new DataService();
        }

        public ActionResult Index(PageModel model)
        {
            model = (model == null )? new PageModel() : model;
            DataModel dataModel = service.GetDays(model);
            return View(dataModel);
        }

    }
}

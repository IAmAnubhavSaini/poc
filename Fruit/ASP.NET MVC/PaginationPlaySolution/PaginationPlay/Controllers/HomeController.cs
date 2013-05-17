using PaginationPlay.Models;
using System.Web.Mvc;
using Pagination;
namespace PaginationPlay.Controllers
{
    public class HomeController : Controller
    {
        IDataService service;

        public HomeController()
        {
            service = new DataService();
        }

        public ActionResult Index(PageBase model)
        {
            model = (model == null) ? new PageBase() : model;
            DataModel dataModel = service.GetDays(model);
            return View(dataModel);
        }

    }
}

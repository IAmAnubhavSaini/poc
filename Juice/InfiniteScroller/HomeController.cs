using System.Collections.Generic;
using System.Web.Mvc;

namespace InfiniteScroller.Controllers
{
    public class HomeController : Controller
    {
        private class image
        {
            public int id { get; set; }

            public string name { get; set; }

            public image(int i)
            {
                this.id = i;
                this.name = "/images/" +i.ToString() + ".png";
            }
        }

        private image[] imgs = new image[97];

        public HomeController()
        {
            for (int i = 1; i <= 97; i++)
            {
                image ti = new image(i);
                imgs[i - 1] = ti;
            }
        }

        private IEnumerable<image> GetImages(int pageSize = 10, int pageNum = 0)
        {
            for (int i = pageNum * pageSize; i < (pageNum + 1) * pageSize && i < imgs.Length; i++)
            {
                yield return imgs[i];
            }
            yield break;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Photos(int ps = 10, int pn = 0)
        {
            IEnumerable<image> images = GetImages(ps, pn);
            return Json(images, "text/json");
        }
    }
}
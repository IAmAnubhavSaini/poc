using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginationPlay.Models
{
    public class PageModel
    {
        public Pagination Page { get; set; }
        public PageModel()
        {
            Page = new Pagination();
        }
        public PageModel(Pagination page)
        {
            this.Page = new Pagination(page.PageIndex, page.PageSize, page.PageActionLink, page.TotalRecords, page.LinkPageAtATime, page.ShowItemPerPageOption);
            this.Page.PageIndex = (Page.PageIndex > Page.PageCount) ? 1 : Page.PageIndex;
        }

    }
}
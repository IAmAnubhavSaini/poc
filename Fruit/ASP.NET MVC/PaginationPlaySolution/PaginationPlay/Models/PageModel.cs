using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pagination;
namespace PaginationPlay.Models
{
    public class PageModel
    {
        public PageBase Page { get; set; }
        public PageModel()
        {
            Page = new PageBase();
        }
        public PageModel(PageBase page)
        {
            this.Page = new PageBase(page.PageIndex, page.PageSize, page.PageActionLink, page.TotalRecords, page.LinkPageAtATime, page.ShowItemPerPageOption);
            this.Page.PageIndex = (Page.PageIndex > Page.PageCount) ? 1 : Page.PageIndex;
        }

    }
}
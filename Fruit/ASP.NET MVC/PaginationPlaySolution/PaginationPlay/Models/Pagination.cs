using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginationPlay.Models
{
    public class Pagination
    {
        #region private
        
        private const int DEFAULT_PAGE_COUNT = 1;
        private const int DEFAULT_PAGE_SIZE = 10;
        private const int DEFAULT_LINK_PAGE_COUNT = 9;// [1][2][3][4][5][6][7][8][9]

        private int? _pageCount = DEFAULT_PAGE_COUNT;
        private int? _pageSize = DEFAULT_PAGE_SIZE;
        private bool _showItemPerPageOption = false;
        private string _itemPerPageLink = string.Empty;
        private int? _linkPageAtATime = DEFAULT_LINK_PAGE_COUNT;

        #endregion

        #region public

        public const string PAGE_INDEX_STRING = "PageIndex";
        public const string PAGE_COUNT_STRING = "PageCount";
        public const string PAGE_SIZE_STRING = "PageSize";

        /*----------------No calculation properties----------------*/
        public int? PageIndex { get; set; }
        public int? PageSize { get { return _pageSize; } set { _pageSize = value; } }
        public string PageActionLink { get; set; }
        public int? TotalRecords { get; set; }
        public int? LinkPageAtATime { get { return _linkPageAtATime; } set { _linkPageAtATime = value; } }
        public bool ShowItemPerPageOption { get { return _showItemPerPageOption; } set { _showItemPerPageOption = value; } }

        /*----------------Calculating properties---------------------*/

        /// <summary>
        /// PageCount has a dependence upon TotalRecords and PageSize.
        /// </summary>
        public int? PageCount
        {
            get
            {
                if (TotalRecords.HasValue && PageSize.HasValue)
                {
                    return (TotalRecords > 0)
                            ?
                        ((TotalRecords.Value % PageSize.Value == 0) ? TotalRecords.Value / PageSize.Value : TotalRecords.Value / PageSize.Value + 1)
                            :
                            _pageCount;
                }
                else
                {
                    return 1;
                }
            }

        }
        public bool HasPreviousPage
        {
            get
            {
                return PageIndex.HasValue ? (PageIndex.Value > 1) : false;
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex.HasValue && PageSize.HasValue && TotalRecords.HasValue) ? (PageIndex.Value * PageSize.Value) < TotalRecords.Value : false;
            }
        }
        public int PageLinkStartIndex
        {
            get
            {
                if (PageCount.HasValue && PageIndex.HasValue && LinkPageAtATime.HasValue)
                {
                    if (this.PageCount <= LinkPageAtATime)
                    {
                        return 1;
                    }
                    if (this.PageCount.Value - this.PageIndex.Value <= (LinkPageAtATime.Value / 2))
                    {
                        return PageCount.Value - LinkPageAtATime.Value - 1;
                    }
                    return PageIndex.Value - (LinkPageAtATime.Value / 2) <= 1 ? 1 : PageIndex.Value - (LinkPageAtATime.Value / 2);
                }
                else
                {
                    return 1;
                }
            }
        }
        public int PageLinkEndIndex
        {
            get
            {
                return (LinkPageAtATime.HasValue && PageCount.HasValue)
                    ?
                       (PageLinkStartIndex + (LinkPageAtATime.Value - 1) <= PageCount.Value ? PageLinkStartIndex + (LinkPageAtATime.Value - 1) : PageCount.Value)
                    :
                        PageCount.Value;

            }
        }
        public string ItemPerPageLink
        {
            get
            {
                return (_itemPerPageLink != null && _itemPerPageLink != "")
                ?
                     _itemPerPageLink.Replace("&PageSize=10", "")
                                     .Replace("&PageSize=25", "")
                                     .Replace("&PageSize=50", "")
                :
                    _itemPerPageLink;
            }
            set
            {
                _itemPerPageLink = value;
            }
        }

        #endregion

        #region constructor

        public Pagination()
        {
            PageIndex = 1;
            PageSize = _pageSize;
        }
        public Pagination(int? pageIndex) : this(pageIndex, null) { }
        public Pagination(int? pageIndex, int? pageSize) : this(pageIndex, pageSize, null, null, null, false){ }
        public Pagination(int? pageIndex, int? pageSize, string pageActionLink, int? totalRecords, int? linkPageAtATime, bool showItemPerPageOption)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageActionLink = pageActionLink;
            TotalRecords = totalRecords;
            LinkPageAtATime = linkPageAtATime;
            ShowItemPerPageOption = showItemPerPageOption;
        }
        #endregion

        #region Methods

        public Pagination CopyNonCalculationProperties(Pagination page)
        {
            return  new Pagination(page.PageIndex,page.PageSize, page.PageActionLink, page.TotalRecords, page.LinkPageAtATime, page.ShowItemPerPageOption);
        }

        #endregion
    }
}
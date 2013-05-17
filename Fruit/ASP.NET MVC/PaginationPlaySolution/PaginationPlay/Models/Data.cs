using System;
using System.Collections.Generic;
using System.Linq;
using Pagination;
namespace PaginationPlay.Models
{
    public interface IDataService
    {
        DataModel GetAllDays();
        DataModel GetDays(PageBase page);
    }
    public class DataService : IDataService
    {
        public DataModel GetAllDays()
        {
            DataModel model = new DataModel();
            return model;
        }

        public DataModel GetDays(PageBase page)
        {
            DataModel model = new DataModel(page);
            return model;
        }
    }
    public class DataModel
    {
        public List<string> Days { get; set; }
        public PageBase Page { get; set; }
        
        public DataModel()
        {
            Days = Data.GetDaysOfWeek();
            Page = new PageBase();
            Page.TotalRecords = Days.Count;
        }
        public DataModel(PageBase page)
        {
            Days = Data.GetDays(page);
            page.TotalRecords = Data.GetDaysOfWeek().Count;
            Page = page;
        }
    }

    public class Data
    {
        enum DaysOfWeek
        {
            INVALID_DAY,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public static List<string> GetDaysOfWeek()
        {
            return Enum.GetNames(typeof(DaysOfWeek)).ToListString();
        }

        public static List<string> GetDays(PageBase page)
        {
            int skip = page.PageIndex > page.PageCount ? 0 : page.PageSize.Value * (page.PageIndex.Value - 1);

            int pageSize = page.PageSize.Value;

            List<string> data = GetDaysOfWeek()
                .Skip(skip)
                .Take(pageSize)
                .ToList<string>();

            return data;
        }
    }
}
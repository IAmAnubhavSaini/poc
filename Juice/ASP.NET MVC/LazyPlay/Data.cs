using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyPlay.Models
{
    public class Data
    {
        private Lazy<IEnumerable<Nation>> nations;
        public IEnumerable<Nation> Nations { get { return nations.Value; } }

        //private Lazy<SelectList> colors;
        //public SelectList Colors { get { return colors.Value; } }
        
        public Data()
        {
            nations = new Lazy<IEnumerable<Nation>>(() => { return GetNations(); });
            //colors = new Lazy<SelectList>(() => { return new SelectList(GetColors(),"color","val"); });
        }
        //public IEnumerable<string> GetColors()
        //{
        //    IEnumerable<string> list = new List<string>{
        //        "Red","Green","Yellow","Blue", "Orange", "Turquoise"
        //    };
        //    return list;
        //}
        public IEnumerable<Nation> GetNations()
        {
            IEnumerable<Nation> list = new List<Nation>{
                new Nation{ NationName = "India", NationCapitalName="Delhi"},
                new Nation{ NationName = "China", NationCapitalName="Soon to be Delhi"},
                new Nation{ NationName = "Sri Lanka", NationCapitalName ="Soon to be Chennai"},
                new Nation{ NationName = "Pakistan", NationCapitalName="Soon to be Chandigarh"},
                new Nation{ NationName = "Bangladesh", NationCapitalName="Soon to be Kolkata"}
            };

            return list;
        }
    }
    public class Nation
    {
        [Display(Name = "Nation")]
        public string NationName { get; set; }
        [Display(Name = "Capital")]
        public string NationCapitalName { get; set; }
    }
    //public class Color
    //{
    //    public string ColorName { get; set; }
    //}

}
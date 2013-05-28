using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTMLAttributesPlay.Models
{
    public static class DataCache
    {
        public static string[] PlaceholderData = new string[]{
            "Example #1",
            "Example #2",
            "Example #3",
            "Example #4"
        };
    }

    public class Data
    {
        public string Example { get; set; }
    }
}
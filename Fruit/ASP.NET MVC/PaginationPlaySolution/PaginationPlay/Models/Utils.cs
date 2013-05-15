
using System.Collections.Generic;
namespace PaginationPlay.Models
{
    public static class Utils
    {
        public static int? ToInt(this string value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return int.Parse(value);
            }
        }

        public static List<string> ToListString(this string[] values)
        {
            List<string> result = new List<string>();
            foreach (string s in values)
            {
                result.Add(s);
            }
            return result;
        }
    
    }
}
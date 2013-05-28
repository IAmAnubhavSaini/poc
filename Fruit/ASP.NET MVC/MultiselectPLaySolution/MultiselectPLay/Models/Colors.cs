using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MultiselectPLay.Models
{
    public class ColorModel
    {
        public ColorBO Color { get; set; }
        public IEnumerable<ColorBO> Colors { get; set; }

        private Lazy<MultiSelectList> colorList;
        public MultiSelectList ColorList { get { return colorList.Value; } }

        public string ColorId { get; set; }
        public string ColorValue { get; set; }
        public string ColorAttributeId { get; set; }

        public ColorModel()
        {
            colorList = new Lazy<MultiSelectList>(
                () =>
                {
                    return new MultiSelectList(Colors, "ColorId", "ColorValue", ColorAttributeId);
                });
        }
        public ColorModel(string id) { if (string.IsNullOrEmpty(id)) id = Guid.NewGuid().ToString(); ColorId = id; }
        public ColorModel(string id, string value) : this(id) { ColorValue = value; }
    }

    public class ColorBO
    {
        public string ColorId { get; set; }
        public string ColorValue { get; set; }
        public string ColorAttributeId { get; set; }

        public ColorBO() { }
        public ColorBO(string id) { ColorId = id; }
        public ColorBO(string id, string value) : this(id) { ColorValue = value; }
    }

    public class ColorDAL
    {
        public IEnumerable<ColorBO> GetAllColors()
        {
            List<ColorBO> List = Enum.GetNames(typeof(COLORS)).ToListColor();
        }

        public enum COLORS
        {
            BLACK = 0,
            RED = 1,
            GREEN = 2,
            YELLOW = 3,
            BLUE = 4,
            WHITE = 5
        }
    }

    public static class Utils
    {
        public static List<string> ToListString(this string[] values)
        {
            List<string> result = new List<string>();
            foreach (string s in values)
            {
                result.Add(s);
            }
            return result;
        }
        public static List<ColorBO> ToListColor(this ColorBO[] values)
        {
            List<ColorBO> result = new List<ColorBO>();
            ColorBO color = new ColorBO();
            foreach (var b in values)
            {
                color.ColorAttributeId = b.ColorAttributeId;
                color.ColorId = b.ColorId;
                color.ColorValue = b.ColorValue;
                result.Add(color);
                color = new ColorBO();
            }
            return result;
        }
    }
}
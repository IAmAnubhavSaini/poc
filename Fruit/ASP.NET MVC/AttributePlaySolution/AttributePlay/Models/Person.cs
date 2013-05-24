using AttributePlay.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AttributePlay.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Nationality { get; set; }

        /* I know this is a bad place to put these properties, but it's an example */

        [Display(Name="Lower bid")]
        public string LowBid { get; set; }
        [GreaterThan("LowBid")]
        [Display(Name="Higher bid")]
        public string HighBid { get; set; }
    }
}
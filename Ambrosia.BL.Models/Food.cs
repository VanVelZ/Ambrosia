using Ambrosia.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ambrosia.BL.Models
{
    /// <summary>
    /// Food inherits from FoodItem so that we can easily insert it into the database.
    /// </summary>
    public class Food: FoodItem
    {
        public string description { get; set; }
        public string dataType { get; set; }
        public DateTime publicationDate { get; set; }
        public string foodCode { get; set; }
        public List<Nutrient> foodNutrients { get; set; }
    }
}
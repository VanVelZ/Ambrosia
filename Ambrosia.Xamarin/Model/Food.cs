using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ambrosia.Xamarin.Model
{
    public class Food
    {
        public string description { get; set; }
        public Guid Id { get; set; }
        public int FDCId { get; set; }
        public Guid MealId { get; set; }
        public int Quantity { get; set; }
        public List<Nutrient> foodNutrients { get; set; }

        public Food()
        {
            foodNutrients = new List<Nutrient>();
        }
        public override string ToString()
        {
            if (Quantity > 0) return Quantity + " " + description;
            else return description;
        }
    }
}

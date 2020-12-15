using System;
using System.Collections.Generic;

namespace Ambrosia.Xamarin.Model
{
    public class Meal
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public List<Food> FoodItems { get; set; }
        public Meal()
        {
            FoodItems = new List<Food>();
        }
        public override string ToString()
        {
            return Description + " " + Time.ToShortDateString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class Meal
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public List<Food> FoodItems { get; set; }
    }
}

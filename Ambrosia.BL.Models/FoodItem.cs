using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class FoodItem 
    {
        public Guid Id { get; set; }
        public int FDCId { get; set;}
        public Guid MealId { get; set; }
        public int Quantity { get; set; }

    }
}

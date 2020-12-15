using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class Nutrient
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public string UnitName { get; set; }
    }
}

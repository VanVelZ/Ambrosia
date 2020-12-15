using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class WorkoutType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CaloriesPerMinute { get; set; }
    }
}

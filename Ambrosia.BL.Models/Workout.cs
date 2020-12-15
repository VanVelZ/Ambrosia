using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class Workout
    {
        public Guid Id { get; set; }
        public WorkoutType WorkoutType {get; set;}
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string FullNameLast { get { return LastName + " " + FirstName; } }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}

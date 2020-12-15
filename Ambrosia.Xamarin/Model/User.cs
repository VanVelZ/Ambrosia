using System;
using System.Collections.Generic;

namespace Ambrosia.Xamarin.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Workout> Workouts { get; set; }
        public User()
        {
            Meals = new List<Meal>();
            Workouts = new List<Workout>();
        }
    }
}

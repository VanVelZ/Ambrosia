using System;
namespace Ambrosia.Xamarin.Model
{
    public class WorkoutType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CaloriesPerMinute { get; set; }

        public WorkoutType()
        {
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

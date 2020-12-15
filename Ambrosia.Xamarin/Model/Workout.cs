using System;
namespace Ambrosia.Xamarin.Model
{
    public class Workout
    {
        public Guid Id { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int WorkoutTime { get { return (EndTime - StartTime).Minutes; } }
        public int CaloriesBurned { get { return this.WorkoutType.CaloriesPerMinute * WorkoutTime; } }

        public override string ToString()
        {
            return WorkoutType.ToString() + " " + CaloriesBurned + "CAL";
        }

        public Workout()
        {
        }

    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using Ambrosia.Xamarin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Ambrosia.Xamarin.Views
{
    public partial class WorkoutHistory : ContentPage
    {
        private List<Workout> workouts = new List<Workout>();
        public WorkoutHistory()
        {
            InitializeComponent();
            this.IconImageSource = "workout.png";
            Title = "Workouts";
            Reload();
            
        }
        public void Reload()
        {
            lstWorkouts.ItemsSource = null;
            lstWorkouts.ItemsSource = App.user.Workouts;
        }

        void lstWorkouts_ItemSelected(System.Object sender, SelectedItemChangedEventArgs e)
        {
            stkDetails.Children.Clear();
            Workout workout = (Workout)lstWorkouts.SelectedItem;
            stkDetails.Children.Add(new Label { Text = "Workout Type: " + workout.WorkoutType.ToString() });
            stkDetails.Children.Add(new Label { Text = "Date: " + workout.StartTime.ToLongDateString() });
            stkDetails.Children.Add(new Label { Text = "Calories Burned: " + workout.CaloriesBurned });
            stkDetails.Children.Add(new Label { Text = "Elapsed Time: " + workout.WorkoutTime });
        }
    }
}
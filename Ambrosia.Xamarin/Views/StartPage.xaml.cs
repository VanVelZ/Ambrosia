using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Ambrosia.Xamarin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Ambrosia.Xamarin.Views
{
    public partial class StartPage : ContentPage
    {
        private List<Food> foods = new List<Food>();
        private List<Workout> workouts = new List<Workout>();
        private Meal meal = new Meal { UserId = App.user.Id};
        private Workout workout = new Workout { UserId = App.user.Id };
        bool isMealExpanded = false;
        bool isWorkoutExpanded = false;

        //set up controls
        Entry entry = new Entry();
        Entry txtNum = new Entry { Placeholder="How many?", Keyboard=Keyboard.Numeric};
        Entry txtDescription = new Entry { Placeholder = "Describe your meal" };
        ListView lstFood = new ListView();
        Button btnConfirm = new Button();
        Picker picker = new Picker();
        TimePicker timePicker = new TimePicker();
        Button btnSubmit = new Button();

        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            GetWorkoutTypes();
            btnSubmit.Clicked += BtnSubmit_Clicked;

        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            AddMeal();
            btnNewWorkout_Clicked(sender, e);
        }

        void btnNewMeal_Clicked(System.Object sender, System.EventArgs e)
        {
            btnNewMeal.IsEnabled = false;
            if (isWorkoutExpanded) btnNewWorkout_Clicked(sender, e);
            
            if (!isMealExpanded)
            {

                entry.Placeholder = "What did you eat?";
                entry.Completed += Entry_Completed;
                entry.Keyboard = Keyboard.Plain;
                btnConfirm.VerticalOptions = LayoutOptions.Center;
                btnConfirm.Clicked -= WorkoutConfirm_Clicked;
                btnConfirm.Clicked += MealConfirmed_Clicked;
                btnConfirm.Text = "Add Food to Meal";
                btnSubmit.Text = "Save Meal";
                
                lstFood.HeightRequest = 200;
                lstFood.ItemsSource = null;
                lstFood.ItemsSource = foods;

                stkMeal.Children.Add(txtDescription);
                stkMeal.Children.Add(entry);
                stkMeal.Children.Add(lstFood);
                stkMeal.Children.Add(txtNum);
                stkMeal.Children.Add(btnConfirm);
                stkMeal.Children.Add(btnSubmit);
                isMealExpanded = !isMealExpanded;
            }
            else
            {
                txtNum.Text = string.Empty;
                txtDescription.Text = string.Empty;
                entry.Text = string.Empty;
                stkMeal.Children.Remove(btnSubmit);
                stkMeal.Children.Remove(txtDescription);
                stkMeal.Children.Remove(txtNum);
                stkMeal.Children.Remove(btnConfirm);
                stkMeal.Children.Remove(lstFood);
                stkMeal.Children.Remove(entry);
                isMealExpanded = !isMealExpanded;
            }
            btnNewMeal.IsEnabled = true;

        }

        private void GetWorkoutTypes()
        {
            picker.ItemsSource = null;
            HttpClient client = App.InitializeClient();
            HttpResponseMessage response;
            string result;
            dynamic items;

            //call the api
            response = client.GetAsync("WorkoutType").Result;
            result = response.Content.ReadAsStringAsync().Result;
            items = (JArray)JsonConvert.DeserializeObject(result);
            var workoutTypeResults = items.ToObject<List<WorkoutType>>();
            picker.ItemsSource = workoutTypeResults;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            lstFood.ItemsSource = null;
            HttpClient client = App.InitializeClient();
            HttpResponseMessage response;
            string result;
            dynamic items;

            //call the api
            response = client.GetAsync("Food?search=" + entry.Text).Result;
            result = response.Content.ReadAsStringAsync().Result;
            if (result.Contains("error"))
            {
                lstFood.ItemsSource = new String[] { "Could not be found" };
            }
            else {
                items = (JArray)JsonConvert.DeserializeObject(result);
                var foodResults = items.ToObject<List<Food>>();
                lstFood.ItemsSource = foodResults;
            }
        }


        void btnNewWorkout_Clicked(System.Object sender, System.EventArgs e)
        {
            btnNewWorkout.IsEnabled = false;
            if (isMealExpanded) btnNewMeal_Clicked(sender, e);
            if (isWorkoutExpanded == false)
            {
                entry.Placeholder = "How many minutes?";
                entry.Keyboard = Keyboard.Numeric;
                btnConfirm.Text = "Save workout";

                timePicker.Time = DateTime.Now.TimeOfDay;

                btnConfirm.VerticalOptions = LayoutOptions.Center;
                btnConfirm.Clicked -= MealConfirmed_Clicked;
                btnConfirm.Clicked += WorkoutConfirm_Clicked;
                btnConfirm.Text = "Add Workout";

                stkWorkout.Children.Add(picker);
                stkWorkout.Children.Add(timePicker);
                stkWorkout.Children.Add(entry);
                stkWorkout.Children.Add(btnConfirm);

                isWorkoutExpanded = true;
            }
            else
            {
                txtDescription.Text = string.Empty;
                entry.Text = string.Empty;
                stkWorkout.Children.RemoveAt(4);
                stkWorkout.Children.RemoveAt(3);
                stkWorkout.Children.RemoveAt(2);
                stkWorkout.Children.RemoveAt(1);
                isWorkoutExpanded = false;
            }
            btnNewWorkout.IsEnabled = true;
        }

        private void WorkoutConfirm_Clicked(object sender, EventArgs e)
        {
            AddWorkout();
            btnNewWorkout_Clicked(sender, e);
        }

        private void MealConfirmed_Clicked(object sender, EventArgs e)
        {
            Food food = (Food)lstFood.SelectedItem;
            int num = 0;
            int.TryParse(txtNum.Text, out num);
            if (num == 0) num = 1;
            food.Quantity = num;
            meal.FoodItems.Add(food);
            txtNum.Text = string.Empty;
            entry.Text = string.Empty;
            lstFood.ItemsSource = null;
        }
        private void AddWorkout()
        {
            workout.WorkoutType = (WorkoutType)picker.SelectedItem;

            int elapsedTime;
            int.TryParse(entry.Text, out elapsedTime);

            //this is not setting the correct time
            workout.StartTime = DateTime.Today + timePicker.Time;
            workout.EndTime = workout.StartTime.AddMinutes(elapsedTime);

            HttpClient client = App.InitializeClient();
            string serializedObject = JsonConvert.SerializeObject(workout);
            var content = new StringContent(serializedObject);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("Workout", content).Result;
            App.user.Workouts.Add(workout);
            workout = new Workout { UserId = App.user.Id };

    }
        private void AddMeal()
        {
            if (meal.FoodItems.Count > 0)
            {
                HttpClient client = App.InitializeClient();
                meal.Description = txtDescription.Text;
                meal.Time = DateTime.Now;
                string serializedObject = JsonConvert.SerializeObject(meal);
                var content = new StringContent(serializedObject);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("Meal", content).Result;
                App.user.Meals.Add(meal);
                meal = new Meal { UserId = App.user.Id };
            }
        }
        void btnViewHistory_Clicked(System.Object sender, System.EventArgs e)
        {
            if (meal.FoodItems.Count > 0) btnNewMeal_Clicked(sender, e);
            Navigation.PushAsync(new History());
        }

    }
}

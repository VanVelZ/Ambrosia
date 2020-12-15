using System;
using System.Collections.Generic;
using System.Net.Http;
using Ambrosia.Xamarin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Ambrosia.Xamarin.Views
{
    public partial class MealHistory : ContentPage
    {
        private List<Meal> Meals = new List<Meal>();
        private Meal selectedMeal = new Meal();
        private Food selectedFood = new Food();
        Button btnClose = new Button { Text = "minimize" };
        public MealHistory()
        {
            InitializeComponent();
            this.IconImageSource = "food.png";
            Title = "Meals";
            Reload();
        }

        public void Reload()
        {
            lstMeals.ItemsSource = null;
            lstMeals.ItemsSource = App.user.Meals;
        }

        void lstMeals_ItemSelected(System.Object sender, SelectedItemChangedEventArgs e)
        {
            selectedMeal = (Meal)lstMeals.SelectedItem;
            lstFoodItems.ItemsSource = null;
            lstFoodItems.ItemsSource = selectedMeal.FoodItems;
        }

        void lstFoodItems_ItemSelected(System.Object sender, SelectedItemChangedEventArgs e)
        {
            selectedFood = (Food)lstFoodItems.SelectedItem;
            lstFoodItems.HeightRequest = 0;
            lstMeals.HeightRequest = 0;
            stkNutrients.Children.Clear();
            foreach(Nutrient nutrient in selectedFood.foodNutrients)
            {
                if (nutrient.Amount > 0)
                {
                    stkNutrients.Children.Add(new Label
                    {
                        Text = nutrient.ToString()
                    });
                }
            }
            btnClose.Clicked += BtnClose_Clicked;
            stkFrame.Children.Add(btnClose);
        }

        private void BtnClose_Clicked(object sender, EventArgs e)
        {
            stkNutrients.Children.Clear();
            lstFoodItems.HeightRequest = 200;
            lstMeals.HeightRequest = 200;
            stkFrame.Children.Remove(btnClose);
        }
    }
}
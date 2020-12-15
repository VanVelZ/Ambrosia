using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;
using Ambrosia.BL;
using Ambrosia.BL.Models;

namespace Ambrosia.BL.Test
{
    [TestClass]
    public class utMeal
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Meal> meals = new List<Meal>();
            meals = MealManager.Load();
            Assert.AreEqual(5, meals.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            List<User> users = UserManager.Load();
            List<Food> foodItems = FoodItemManager.Load();

            Meal meal = new Meal();
            meal.Id = Guid.NewGuid();
            meal.UserId = users.FirstOrDefault(u => u.FullName == "Leroy Jenkins").Id;
            meal.Description = "Breakfast";
            meal.Time = DateTime.Now;
            meal.FoodItems = foodItems;

            int results = MealManager.Insert(meal, true);
            Assert.IsTrue(results > 0);
        }


        [TestMethod]
        public void UpdateTest()
        {
            List<Meal> meals = MealManager.Load();
            Meal meal = meals.FirstOrDefault(u => u.Description == "Breakfast");

            int results = MealManager.Update(meal, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            List<Meal> meals = MealManager.Load();
            Meal meal = meals.FirstOrDefault(u => u.Description == "Breakfast");

            int results = MealManager.Delete(meal, true);
            Assert.IsTrue(results > 0);
        }
    }
}

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
    public class utFoodItem
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Food> foodItems = new List<Food>();
            foodItems = FoodItemManager.Load();
            Assert.AreEqual(6, foodItems.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            List<Meal> meals = MealManager.Load();
            FoodItem foodItem = new FoodItem();
            foodItem.Id = Guid.NewGuid();
            foodItem.FDCId = 5555555;
            foodItem.MealId = meals.FirstOrDefault(m => m.Description == "Breakfast").Id;
            foodItem.Quantity = 999;

            int results = FoodItemManager.Insert(foodItem, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            List<Food> foodItems = FoodItemManager.Load();
            FoodItem foodItem = foodItems.FirstOrDefault(u => u.FDCId == 1104086);

            foodItem.Quantity = 999;
            int results = FoodItemManager.Update(foodItem, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            List<Food> foodItems = FoodItemManager.Load();
            FoodItem foodItem = foodItems.FirstOrDefault(u => u.FDCId == 1104086);

            int results = FoodItemManager.Delete(foodItem, true);
            Assert.IsTrue(results > 0);
        }
    }
}

using Ambrosia.API;
using Ambrosia.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Ambrosia.BL.Models;
using System.Collections.Generic;

namespace Ambrosia.API.Tests.Controllers
{
    [TestClass]
    public class FoodControllerTest
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            FoodController controller = new FoodController();

            // Act
            IEnumerable<Food> result = controller.Get() as IEnumerable<Food>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsertTest()
        {
            Nutrient n = new Nutrient { Name = "Omega-3", Amount = 9000, Number = 1234, UnitName = "ug" };
            List<Nutrient> nutrients = new List<Nutrient>();
            nutrients.Add(n);
            // Arrange
            MealController controllerm = new MealController();
            // Act
            List<Meal> loadAllM = controllerm.Get() as List<Meal>;
            //grab first result
            Meal meal = loadAllM[0];

            Food f = new Food { FDCId = 999999, dataType = "test", description = "test", publicationDate = System.DateTime.Now , foodCode = "test", foodNutrients = nutrients, Quantity = 2, MealId = meal.Id};


            // Arrange
            FoodController controller = new FoodController();

            // Act
            int result = controller.Post(f);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            FoodController controller = new FoodController();

            // Act
            List<Food> loadAll = controller.Get() as List<Food>;

            //grab first result
            Food f = loadAll[0];

            f.Quantity = 100;

            int results = controller.Post(f);

            Assert.IsTrue(results > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            //always fails because There is a workout that depends on this Foodtype


            // Arrange
            FoodController controller = new FoodController();

            // Act
            List<Food> loadAll = controller.Get() as List<Food>;

            //grab first result
            Food f = loadAll[0];

            int results = controller.Delete(f);

            Assert.IsTrue(results > 0);

        }
    }
}

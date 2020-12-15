using Ambrosia.API;
using Ambrosia.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Ambrosia.BL.Models;
using System.Collections.Generic;

namespace Ambrosia.API.Tests.Controllers
{
    [TestClass]
    public class MealControllerTest
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            MealController controller = new MealController();

            // Act
            IEnumerable<Meal> result = controller.Get() as IEnumerable<Meal>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsertTest()
        {
            // Arrange
            UserController controlleru = new UserController();
            // Act
            List<User> loadAllU = controlleru.Get() as List<User>;
            //grab first result
            User u = loadAllU[0];

            // Arrange
            FoodController controllerf = new FoodController();
            // Act
            List<Food> loadAllF = controllerf.Get() as List<Food>;

            Meal m = new Meal { UserId = u.Id, Description = "Breakfast", FoodItems = loadAllF, Time = System.DateTime.Now };


            // Arrange
            MealController controller = new MealController();

            // Act
            int result = controller.Post(m);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            MealController controller = new MealController();

            // Act
            List<Meal> loadAll = controller.Get() as List<Meal>;

            //grab first result
            Meal m = loadAll[0];

            m.Description = "Lunch";

            int results = controller.Post(m);

            Assert.IsTrue(results > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            //always fails because There is a workout that depends on this Mealtype


            // Arrange
            MealController controller = new MealController();

            // Act
            List<Meal> loadAll = controller.Get() as List<Meal>;

            //grab first result
            Meal m = loadAll[0];

            int results = controller.Delete(m);

            Assert.IsTrue(results > 0);

        }
    }
}

using Ambrosia.API;
using Ambrosia.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Ambrosia.BL.Models;
using System.Collections.Generic;

namespace Ambrosia.API.Tests.Controllers
{
    [TestClass]
    public class WorkoutTypeControllerTest
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            WorkoutTypeController controller = new WorkoutTypeController();

            // Act
            IEnumerable<WorkoutType> result = controller.Get() as IEnumerable<WorkoutType>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsertTest()
        {
            WorkoutType wt = new WorkoutType { Name = "Sitting", CaloriesPerMinute = 0};


            // Arrange
            WorkoutTypeController controller = new WorkoutTypeController();

            // Act
            int result = controller.Post(wt);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            WorkoutTypeController controller = new WorkoutTypeController();

            // Act
            List<WorkoutType> loadAll = controller.Get() as List<WorkoutType>;

            //grab first result
            WorkoutType wt = loadAll[0];

            wt.Name = "Sleeping";

            int results = controller.Put(wt);

            Assert.IsTrue(results > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            //always fails because There is a workout that depends on this Workouttype


            // Arrange
            WorkoutTypeController controller = new WorkoutTypeController();

            // Act
            List<WorkoutType> loadAll = controller.Get() as List<WorkoutType>;

            //grab first result
            WorkoutType wt = loadAll[0];

            int results = controller.Delete(wt);

            Assert.IsTrue(results > 0);

        }
    }
}

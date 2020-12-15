using Ambrosia.API;
using Ambrosia.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Ambrosia.BL.Models;
using System.Collections.Generic;

namespace Ambrosia.API.Tests.Controllers
{
    [TestClass]
    public class WorkoutControllerTest
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            WorkoutController controller = new WorkoutController();

            // Act
            IEnumerable<Workout> result = controller.Get() as IEnumerable<Workout>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsertTest()
        {
            // Arrange
            WorkoutTypeController controllerwt = new WorkoutTypeController();
            // Act
            List<WorkoutType> loadAllWt = controllerwt.Get() as List<WorkoutType>;
            //grab first result
            WorkoutType wt = loadAllWt[0];
            // Arrange
            UserController controlleru = new UserController();
            // Act
            List<User> loadAllU = controlleru.Get() as List<User>;
            //grab first result
            User u = loadAllU[0];

            Workout w = new Workout { WorkoutType = wt, StartTime = System.DateTime.Now, EndTime = new System.DateTime(2020, 11, 18), UserId = u.Id };


            // Arrange
            WorkoutController controller = new WorkoutController();

            // Act
            int result = controller.Post(w);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            WorkoutController controller = new WorkoutController();

            // Act
            List<Workout> loadAll = controller.Get() as List<Workout>;

            //grab first result
            Workout w = loadAll[0];

            w.EndTime = System.DateTime.Now;

            int results = controller.Post(w);

            Assert.IsTrue(results > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            //always fails because There is a workout that depends on this Workouttype


            // Arrange
            WorkoutController controller = new WorkoutController();

            // Act
            List<Workout> loadAll = controller.Get() as List<Workout>;

            //grab first result
            Workout w = loadAll[0];

            int results = controller.Delete(w);

            Assert.IsTrue(results > 0);

        }
    }
}

using Ambrosia.API;
using Ambrosia.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Ambrosia.BL.Models;
using System.Collections.Generic;

namespace Ambrosia.API.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void LoadTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            IEnumerable<User> result = controller.Get() as IEnumerable<User>;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InsertTest()
        {
            User u = new User { FirstName = "Ben", LastName = "Franklin", Username = "benfrank@fakeemail.com", Password = "fakepassword"};


            // Arrange
            UserController controller = new UserController();

            // Act
            int result = controller.Post(u);

            // Assert
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            List<User> loadAll = controller.Get() as List<User>;

            //grab first result
            User u = loadAll[0];

            u.FirstName = "Benjamin";

            int results = controller.Post(u);

            Assert.IsTrue(results > 0);

        }
        [TestMethod]
        public void DeleteTest()
        {
            //always fails because There is a workout that depends on this Workouttype


            // Arrange
            UserController controller = new UserController();

            // Act
            List<User> loadAll = controller.Get() as List<User>;

            //grab first result
            User u = loadAll[0];

            int results = controller.Delete(u);

            Assert.IsTrue(results > 0);

        }
    }
}

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
    public class utUser
    {
        [TestMethod]
        public void LoadTest()
        {
            List<User> users = new List<User>();
            users = UserManager.Load();
            Assert.AreEqual(3, users.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.FirstName = "Bob";
            user.LastName = "Smith";
            user.Username = "fakeemail@fake.com";
            user.Password = "fakepw";
            
            int results = UserManager.Insert(user, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            List<User> users = UserManager.Load();
            User user = users.FirstOrDefault(u => u.FullName == "Leroy Jenkins");

            user.Username = "LEROYJENKINS!!!!@wowemail.com";
            int results = UserManager.Update(user, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            List<User> users = UserManager.Load();
            User user = users.FirstOrDefault(u => u.FullName == "Leroy Jenkins");

            int results = UserManager.Delete(user, true);
            Assert.IsTrue(results > 0);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ambrosia.PL;
using System.Linq;
using System.Data.Entity;

namespace Ambrosia.PL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void InsertTest()
        {
            using(AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblUser row = new tblUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Phillip",
                    LastName = "Fry",
                    Username = "PhillipJFry@hotmail.com",
                    Password = "SeymourAsses1999"
                };
                dc.tblUsers.Add(row);

                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblUser row = dc.tblUsers.FirstOrDefault(u => u.FirstName == "Phillip");
                row.Username = "PhillipJFry@gmail.com";

                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }

        }
        [TestMethod]
        public void LoadTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblUser row = dc.tblUsers.FirstOrDefault(u => u.FirstName == "Phillip");

                Assert.IsTrue(row != null);
                transaction.Rollback();
            }
        }
        [TestMethod]
        public void DeleteTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblUser row = dc.tblUsers.FirstOrDefault(u => u.FirstName == "Phillip");

                dc.tblUsers.Remove(row);
                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ambrosia.PL.Test
{
    [TestClass]
    public class utMeal
    {
        [TestMethod]
        public void InsertTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblMeal row = new tblMeal
                {
                    Id = Guid.NewGuid(),
                    Description = "Ate 4 eggs",
                    Time = DateTime.Now,
                    UserId = dc.tblUsers.FirstOrDefault(m => m.FirstName == "Phillip").Id 
                };
                dc.tblMeals.Add(row);

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
                tblMeal row = dc.tblMeals.FirstOrDefault(m => m.Description == "Ate 4 eggs");
                row.Description = "Changed the row";

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
                tblMeal row = dc.tblMeals.FirstOrDefault(m => m.Description == "Ate 4 eggs");

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
                tblMeal row = dc.tblMeals.FirstOrDefault(m => m.Description == "Ate 4 eggs");

                dc.tblMeals.Remove(row);
                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
    }
}

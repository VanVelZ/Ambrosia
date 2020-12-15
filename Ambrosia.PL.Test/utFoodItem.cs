using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ambrosia.PL.Test
{
    [TestClass]
    public class utFoodItem
    {
        [TestMethod]
        public void InsertTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblFoodItem row = new tblFoodItem
                {
                    Id = Guid.NewGuid(),
                    FDCId = 1,
                    MealId = dc.tblMeals.FirstOrDefault(m => m.Description == "Ate 4 eggs").Id,
                    Quantity = 1
                };
                dc.tblFoodItems.Add(row);

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
                tblFoodItem row = dc.tblFoodItems.FirstOrDefault(fi => fi.FDCId == 1);
                row.FDCId = 1;

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
                tblFoodItem row = dc.tblFoodItems.FirstOrDefault(fi => fi.FDCId == 1);

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
                tblFoodItem row = dc.tblFoodItems.FirstOrDefault(fi => fi.FDCId == 1);

                dc.tblFoodItems.Remove(row);
                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
    }
}

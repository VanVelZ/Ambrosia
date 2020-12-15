using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ambrosia.PL.Test
{
    [TestClass]
    public class utWorkoutType
    {
        [TestMethod]
        public void InsertTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblWorkoutType row = new tblWorkoutType
                {
                    Id = Guid.NewGuid(),
                    Name = "Computer Programming",
                    CaloriesPerMinute = 0
                };
                dc.tblWorkoutTypes.Add(row);

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
                tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(w => w.Name == "Computer Programming");
                row.CaloriesPerMinute = 1;

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
                tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(w => w.Name == "Computer Programming");

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
                tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(w => w.Name == "Computer Programming");

                dc.tblWorkoutTypes.Remove(row);
                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
    }
}

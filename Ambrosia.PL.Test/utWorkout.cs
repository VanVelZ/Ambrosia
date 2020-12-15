using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ambrosia.PL.Test
{
    [TestClass]
    public class utWorkout
    {
        [TestMethod]
        public void InsertTest()
        {
            using (AmbrosiaEntities dc = new AmbrosiaEntities())
            {
                DbContextTransaction transaction = null;
                tblWorkout row = new tblWorkout
                {
                    Id = Guid.NewGuid(),
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    UserId = dc.tblUsers.FirstOrDefault(u => u.FirstName == "Phillip").Id,
                    WorkoutTypeId = dc.tblWorkoutTypes.FirstOrDefault(w => w.Name == "Computer Programming").Id
                };
                dc.tblWorkouts.Add(row);

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
                tblWorkout row = dc.tblWorkouts
                    .FirstOrDefault(w => w.UserId == dc.tblUsers.FirstOrDefault(u => u.FirstName == "Phillip").Id);
                row.EndTime = DateTime.Now;

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
                tblWorkout row = dc.tblWorkouts.FirstOrDefault();

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
                tblWorkout row = dc.tblWorkouts.FirstOrDefault();

                dc.tblWorkouts.Remove(row);
                Assert.IsTrue(dc.SaveChanges() == 1);
                transaction.Rollback();
            }
        }
    }
}

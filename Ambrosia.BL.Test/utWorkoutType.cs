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
    public class utWorkoutType
    {
        [TestMethod]
        public void LoadTest()
        {
            List<WorkoutType> workoutTypes = new List<WorkoutType>();
            workoutTypes = WorkoutTypeManager.Load();
            Assert.AreEqual(3, workoutTypes.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            WorkoutType workoutType = new WorkoutType();
            workoutType.Id = Guid.NewGuid();
            workoutType.Name = "Testing";
            workoutType.CaloriesPerMinute = 50;

            int results = WorkoutTypeManager.Insert(workoutType, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            List<WorkoutType> workoutTypes = WorkoutTypeManager.Load();
            WorkoutType workoutType = workoutTypes.FirstOrDefault(u => u.Name == "Running");

            workoutType.CaloriesPerMinute = 12;
            int results = WorkoutTypeManager.Update(workoutType, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            List<WorkoutType> workoutTypes = WorkoutTypeManager.Load();
            WorkoutType workoutType = workoutTypes.FirstOrDefault(u => u.Name == "Running");

            int results = WorkoutTypeManager.Delete(workoutType, true);
            Assert.IsTrue(results > 0);
        }
    }
}

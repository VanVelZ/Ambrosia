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
    public class utWorkout
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Workout> workouts = new List<Workout>();
            workouts = WorkoutManager.Load();
            Assert.AreEqual(4, workouts.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            List<WorkoutType> workoutTypes = WorkoutTypeManager.Load();
            List<User> users = UserManager.Load();

            Workout workout = new Workout();
            workout.Id = Guid.NewGuid();
            workout.WorkoutType = workoutTypes.FirstOrDefault(wt => wt.Name == "Running");
            workout.StartTime = DateTime.Now;
            workout.EndTime = new DateTime(2020, 11, 18);
            workout.UserId = users.FirstOrDefault(u=> u.FullName == "Leroy Jenkins").Id;

            int results = WorkoutManager.Insert(workout, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            List<Workout> workouts = WorkoutManager.Load();
            List<WorkoutType> workoutTypes = WorkoutTypeManager.Load();

            Workout workout = workouts.FirstOrDefault(u => u.WorkoutType == workoutTypes.FirstOrDefault(wt => wt.Name == "Running"));

            workout.EndTime = new DateTime(2020, 11, 19);
            int results = WorkoutManager.Update(workout, true);
            Assert.IsTrue(results > 0);
        }
        [TestMethod]
        public void DeleteTest()
        {
            List<Workout> workouts = WorkoutManager.Load();
            List<WorkoutType> workoutTypes = WorkoutTypeManager.Load();

            Workout workout = workouts.FirstOrDefault(u => u.WorkoutType == workoutTypes.FirstOrDefault(wt => wt.Name == "Running"));

            int results = WorkoutManager.Delete(workout, true);
            Assert.IsTrue(results > 0);
        }
    }
}

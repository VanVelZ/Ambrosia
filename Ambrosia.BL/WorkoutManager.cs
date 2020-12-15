using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambrosia.PL;
using Ambrosia.BL;
using Ambrosia.BL.Models;

namespace Ambrosia.BL
{
    public static class WorkoutManager
    {
        public static int Insert(Workout workout, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblWorkout row = new tblWorkout();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.WorkoutTypeId = workout.WorkoutType.Id;
                    row.StartTime = workout.StartTime;
                    row.EndTime = workout.EndTime;
                    row.UserId = workout.UserId;


                    // Back fill the Id on the  object (parameter)
                    workout.Id = row.Id;

                    // Insert the row
                    dc.tblWorkouts.Add(row);

                    results = dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Workout workout, bool rollback = false)
        {
            //Update Row
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblWorkout row = dc.tblWorkouts.FirstOrDefault(g => g.Id == workout.Id);

                    if (row != null)
                    {
                        //Set properties
                        row.WorkoutTypeId = workout.WorkoutType.Id;
                        row.StartTime = workout.StartTime;
                        row.EndTime = workout.EndTime;
                        row.UserId = workout.UserId;
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found!!");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Delete(Workout workout, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblWorkout row = dc.tblWorkouts.FirstOrDefault(g => g.Id == workout.Id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblWorkouts.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found!!");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Workout> Load()
        {
            //Retrieve all the rows in a list
            try
            {
                List<Workout> rows = new List<Workout>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblWorkouts
                        .ToList()
                        .ForEach(g => rows.Add(new Workout
                        {
                            Id = g.Id,
                            WorkoutType = WorkoutTypeManager.LoadById(g.WorkoutTypeId),
                            StartTime = g.StartTime,
                            EndTime = g.EndTime,
                            UserId = g.UserId
                        }));
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Workout> Load(Guid userId)
        {
            //Retrieve all the rows in a list
            try
            {
                List<Workout> rows = new List<Workout>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblWorkouts
                        .Where(w => w.UserId == userId)
                        .ToList()
                        .ForEach(g => rows.Add(new Workout
                        {
                            Id = g.Id,
                            WorkoutType = WorkoutTypeManager.LoadById(g.WorkoutTypeId),
                            StartTime = g.StartTime,
                            EndTime = g.EndTime,
                            UserId = g.UserId
                        }));
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Workout LoadById(Guid id)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblWorkout row = dc.tblWorkouts.FirstOrDefault(g => g.Id == id);
                    if (row != null)
                    {
                        Workout workout = new Workout
                        {
                            Id = row.Id,
                            WorkoutType = WorkoutTypeManager.LoadById(row.WorkoutTypeId),
                            StartTime = row.StartTime,
                            EndTime = row.EndTime,
                            UserId = row.UserId
                        };
                        return workout;
                    }
                    else
                    {
                        throw new Exception("Row was not found!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

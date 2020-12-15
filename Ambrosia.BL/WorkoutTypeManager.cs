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
    public static class WorkoutTypeManager
    {
        public static int Insert(WorkoutType workoutType, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblWorkoutType row = new tblWorkoutType();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.Name = workoutType.Name;
                    row.CaloriesPerMinute = workoutType.CaloriesPerMinute;


                    // Back fill the Id on the  object (parameter)
                    workoutType.Id = row.Id;

                    // Insert the row
                    dc.tblWorkoutTypes.Add(row);

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

        public static int Update(WorkoutType workoutType, bool rollback = false)
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
                    tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(g => g.Id == workoutType.Id);

                    if (row != null)
                    {
                        //Set properties
                        row.Name = workoutType.Name;
                        row.CaloriesPerMinute = workoutType.CaloriesPerMinute;

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

        public static int Delete(WorkoutType workoutType, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(g => g.Id == workoutType.Id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblWorkoutTypes.Remove(row);
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

        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(g => g.Id == id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblWorkoutTypes.Remove(row);
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
        public static List<WorkoutType> Load()
        {
            //Retrieve all the rows in a list
            try
            {
                List<WorkoutType> rows = new List<WorkoutType>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblWorkoutTypes
                        .ToList()
                        .ForEach(g => rows.Add(new WorkoutType
                        {
                            Id = g.Id,
                            Name = g.Name,
                            CaloriesPerMinute = g.CaloriesPerMinute
                        }));
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static WorkoutType LoadById(Guid id)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblWorkoutType row = dc.tblWorkoutTypes.FirstOrDefault(g => g.Id == id);
                    if (row != null)
                    {
                        WorkoutType workoutType = new WorkoutType
                        {
                            Id = row.Id,
                            Name = row.Name,
                            CaloriesPerMinute = row.CaloriesPerMinute
                        };
                        return workoutType;
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

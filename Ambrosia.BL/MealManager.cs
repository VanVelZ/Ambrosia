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
    public static class MealManager
    {
        public static int Insert(Meal meal, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblMeal row = new tblMeal();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.UserId = meal.UserId;
                    row.Description = meal.Description;
                    row.Time = meal.Time;
                    

                    // Back fill the Id on the  object (parameter)
                    meal.Id = row.Id;

                    // Insert the row
                    dc.tblMeals.Add(row);
                    results = dc.SaveChanges();

                    //insert the food items
                    FoodItemManager.InsertList(meal.FoodItems, meal.Id);

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Meal meal, bool rollback = false)
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
                    tblMeal row = dc.tblMeals.FirstOrDefault(g => g.Id == meal.Id);

                    if (row != null)
                    {
                        //Set properties
                        row.UserId = meal.UserId;
                        row.Description = meal.Description;
                        row.Time = meal.Time;
                        results = dc.SaveChanges();
                        meal.FoodItems.ForEach(f => FoodItemManager.Update(f));
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

        public static int Delete(Meal meal, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblMeal row = dc.tblMeals.FirstOrDefault(g => g.Id == meal.Id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblMeals.Remove(row);
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

        public static List<Meal> Load()
        {
            //Retrieve all the rows in a list
            try
            {
                List<Meal> rows = new List<Meal>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblMeals
                        .ToList()
                        .ForEach(g => rows.Add(new Meal
                        {
                            Id = g.Id,
                            UserId = g.UserId,
                            Description = g.Description,
                            Time = g.Time,
                            FoodItems = FoodItemManager.Load(g.Id)
                        }));
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Meal LoadById(Guid id)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblMeal row = dc.tblMeals.FirstOrDefault(g => g.Id == id);
                    if (row != null)
                    {
                        Meal meal = new Meal
                        {
                            Id = row.Id,
                            UserId = row.UserId,
                            Description = row.Description,
                            Time = row.Time,
                            FoodItems = FoodItemManager.Load(row.Id)
                        };
                        return meal;
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
        //changed this method to return a List. Also renamed 
        public static List<Meal> Load(Guid userId)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    List<Meal> meals = new List<Meal>();
                    dc.tblMeals
                        .Where(r => r.UserId == userId)
                        .ToList()
                        .ForEach(g => meals.Add(new Meal { 
                        Id = g.Id,
                        UserId = g.UserId,
                        Description = g.Description,
                        Time = g.Time,
                        FoodItems = FoodItemManager.Load(g.Id)
                    }));
                        return meals;
                    }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

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
    public static class FoodItemManager
    {
        public static int Insert(FoodItem foodItem, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblFoodItem row = new tblFoodItem();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.FDCId = foodItem.FDCId;
                    row.Quantity = foodItem.Quantity;
                    row.MealId = foodItem.MealId;


                    // Back fill the Id on the  object (parameter)
                    foodItem.Id = row.Id;

                    // Insert the row
                    dc.tblFoodItems.Add(row);

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

        public static int Insert(FoodItem foodItem, Guid mealid, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblFoodItem row = new tblFoodItem();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.FDCId = foodItem.FDCId;
                    row.Quantity = foodItem.Quantity;
                    row.MealId = mealid;


                    // Back fill the Id on the  object (parameter)
                    foodItem.Id = row.Id;

                    // Insert the row
                    dc.tblFoodItems.Add(row);
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

        public static void InsertList(List<Food> foodItems, Guid mealid, bool rollback = false)
        {
            try
            {

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    foreach (Food foodItem in foodItems)
                    {
                        tblFoodItem row = new tblFoodItem();

                        // Set the properties
                        row.Id = Guid.NewGuid();
                        row.FDCId = foodItem.FDCId;
                        row.Quantity = foodItem.Quantity;
                        row.MealId = mealid;


                        // Back fill the Id on the  object (parameter)
                        foodItem.Id = row.Id;

                        // Insert the row
                        dc.tblFoodItems.Add(row);

                        if (rollback) transaction.Rollback();
                    }
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update(FoodItem foodItem, bool rollback = false)
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
                    tblFoodItem row = dc.tblFoodItems.FirstOrDefault(g => g.Id == foodItem.Id);

                    if (row != null)
                    {
                        //Set properties
                        row.FDCId = foodItem.FDCId;
                        row.MealId = foodItem.MealId;
                        row.Quantity = foodItem.Quantity;

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

        public static int Delete(FoodItem foodItem, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblFoodItem row = dc.tblFoodItems.FirstOrDefault(g => g.Id == foodItem.Id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblFoodItems.Remove(row);
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

        public static List<Food> Load()
        {
            //Retrieve all the rows in a list
            try
            {
                List<FoodItem> rows = new List<FoodItem>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblFoodItems
                        .ToList()
                        .ForEach(g => rows.Add(new FoodItem
                        {
                            Id = g.Id,
                            FDCId = g.FDCId,
                            MealId = g.MealId,
                            Quantity = g.Quantity
                        }));
                    List<Food> foods = new List<Food>();
                    foreach(FoodItem foodItem in rows)
                    {
                        foods.Add(fdcFoodManager.Search(foodItem));
                    }
                    return foods; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Food> Load(Guid mealId)
        {
            //Retrieve all the rows in a list
            try
            {
                List<FoodItem> rows = new List<FoodItem>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblFoodItems
                        .Where(g => g.MealId == mealId)
                        .ToList()
                        .ForEach(g => rows.Add(new FoodItem
                        {
                            Id = g.Id,
                            FDCId = g.FDCId,
                            MealId = g.MealId,
                            Quantity = g.Quantity
                        }));
                    List<Food> foods = new List<Food>();
                    foreach (FoodItem foodItem in rows)
                    {
                        foods.Add(fdcFoodManager.Search(foodItem));
                    }
                    return foods;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Food LoadById(Guid id)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblFoodItem row = dc.tblFoodItems.FirstOrDefault(g => g.Id == id);
                    if (row != null)
                    {
                        FoodItem foodItem = new FoodItem
                        {
                            Id = row.Id,
                            FDCId = row.FDCId,
                            MealId = row.MealId,
                            Quantity = row.Quantity
                        };
                        return fdcFoodManager.Search(foodItem);
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
        public static Food LoadById(int fdcid)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblFoodItem row = dc.tblFoodItems.FirstOrDefault(g => g.FDCId == fdcid);
                    if (row != null)
                    {
                        FoodItem foodItem = new FoodItem
                        {
                            Id = row.Id,
                            FDCId = row.FDCId,
                            MealId = row.MealId,
                            Quantity = row.Quantity
                        };
                        return fdcFoodManager.Search(foodItem);
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

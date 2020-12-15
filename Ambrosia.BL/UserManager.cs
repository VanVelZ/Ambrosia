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
    public static class UserManager
    {
        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results;

                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    // Make a new row
                    tblUser row = new tblUser();

                    // Set the properties
                    row.Id = Guid.NewGuid();
                    row.FirstName = user.FirstName;
                    row.LastName = user.LastName;
                    row.Username = user.Username;
                    row.Password = GetHash(user.Password);


                    // Back fill the Id on the  object (parameter)
                    user.Id = row.Id;
                    

                    // Insert the row
                    dc.tblUsers.Add(row);

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

        public static int Update(User user, bool rollback = false)
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
                    tblUser row = dc.tblUsers.FirstOrDefault(g => g.Id == user.Id);

                    if (row != null)
                    {
                        //Set properties
                        row.FirstName = user.FirstName;
                        row.LastName = user.LastName;
                        row.Username = user.Username;
                        //removed password from the standard edit so that the password does not get repeatedly hashed if it is not changed
                        //row.Password = user.Password;
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

        public static int Delete(User user, bool rollback = false)
        {
            try
            {
                int results;
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    DbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    //New Table Object for row
                    tblUser row = dc.tblUsers.FirstOrDefault(g => g.Id == user.Id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblUsers.Remove(row);
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
                    tblUser row = dc.tblUsers.FirstOrDefault(g => g.Id == id);

                    if (row != null)
                    {
                        //Delete object
                        dc.tblUsers.Remove(row);
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


        public static List<User> Load()
        {
            //Retrieve all the rows in a list
            try
            {
                List<User> rows = new List<User>();
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    dc.tblUsers
                        .ToList()
                        .ForEach(g => rows.Add(new User
                        {
                            Id = g.Id,
                            FirstName = g.FirstName,
                            LastName = g.LastName,
                            Username = g.Username,
                            Password = g.Password,
                            Meals = MealManager.Load(g.Id),
                            Workouts = WorkoutManager.Load(g.Id)
                        }));
                    
                    return rows;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static User LoadById(Guid id)
        {
            try
            {
                using (AmbrosiaEntities dc = new AmbrosiaEntities())
                {
                    tblUser row = dc.tblUsers.FirstOrDefault(g => g.Id == id);
                    if (row != null)
                    {
                        User user = new User
                        {
                            Id = row.Id,
                            FirstName = row.FirstName,
                            LastName = row.LastName,
                            Username = row.Username,
                            Password = row.Password,
                            Meals = MealManager.Load(row.Id),
                            Workouts = WorkoutManager.Load(row.Id)
                        };
                        return user;
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
        public static string GetHash(string passcode)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(passcode);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username.ToString()))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (AmbrosiaEntities dc = new AmbrosiaEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.Username == user.Username);
                            if (tblUser != null)
                            {
                                //Check password
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    //User could login
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    user.Id = tblUser.Id;
                                    user.Meals = MealManager.Load(user.Id);
                                    user.Workouts = WorkoutManager.Load(user.Id);

                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Could not login with these credentials");
                                }
                            }
                            else
                            {
                                throw new Exception("UserId could not be found");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set");
                    }
                }
                else
                {
                    throw new Exception("UserId was not set");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

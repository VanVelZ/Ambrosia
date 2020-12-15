using Ambrosia.BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ambrosia.BL
{
    /// <summary>
    ///  This class is used to hit the FDC API. 
    /// </summary>
    public static class fdcFoodManager
    {
        /// <summary>
        /// Queries the API using a string and returns a list of all possible results. This is to be used when a user is trying to add Food to a meal via search. Not to be used when
        /// trying to convert FoodItem objects into Food object 
        /// </summary>
        /// <param name="search">Can be name, fdcId, or code</param>
        /// <returns>A list of Food objects.</returns>
        public static List<Food> Search(string search)
        {
            List<Food> foods = new List<Food>();

            string API_KEY = "api_key=EJ8O1ux4t3aF0xXO7NkbE1gQICD9aztOMaDObqF1";
            string QUERY = "query=" + search;
            //Declare api
            HttpClient client = InitializeClient();
            HttpResponseMessage httpResponse;
            string result;

            //Fill activation list
            httpResponse = client.GetAsync("foods/list/?" + QUERY + "&" + API_KEY).Result;
            result = httpResponse.Content.ReadAsStringAsync().Result;
            foods = JsonConvert.DeserializeObject<List<Food>>(result);

            return foods;

        }
        /// <summary>
        /// Gets a single food when passed in an fdcId
        /// </summary>
        /// <param name="fdcId"></param>
        /// <returns></returns>
        public static Food Search(int fdcId)
        {
            List<Food> foods = new List<Food>();

            string API_KEY = "api_key=EJ8O1ux4t3aF0xXO7NkbE1gQICD9aztOMaDObqF1";
            string QUERY = "query=" + fdcId;
            //Declare api
            HttpClient client = InitializeClient();
            HttpResponseMessage httpResponse;
            string result;

            //Fill activation list
            httpResponse = client.GetAsync("foods/list/?" + QUERY + "&" + API_KEY).Result;
            result = httpResponse.Content.ReadAsStringAsync().Result;
            foods = JsonConvert.DeserializeObject<List<Food>>(result);

            return foods.FirstOrDefault(f => f.FDCId == fdcId);

        }
        /// <summary>
        /// Converts a FoodItem object into a Food object and populates the necessary information. 
        /// </summary>
        /// <param name="foodItem"></param>
        /// <returns>An upgraded version of the food item</returns>
        public static Food Search(FoodItem foodItem)
        {

            Food food = Search(foodItem.FDCId);
            food.Id = foodItem.Id;
            food.MealId = foodItem.MealId;
            food.Quantity = foodItem.Quantity;

            return food;

        }
        /// <summary>
        /// Converts a list of FoodItems into a list of Foods 
        /// </summary>
        /// <param name="foodItems"></param>
        /// <returns></returns>
        public static List<Food> Search(List<FoodItem> foodItems)
        {
            List<Food> foods = new List<Food>();

            foreach (FoodItem foodItem in foodItems)
            {
                string API_KEY = "api_key=EJ8O1ux4t3aF0xXO7NkbE1gQICD9aztOMaDObqF1";
                string QUERY = "query=" + foodItem.FDCId;
                //Declare api
                HttpClient client = InitializeClient();
                HttpResponseMessage httpResponse;
                string result;

                //Fill activation list
                httpResponse = client.GetAsync("foods/list/?" + QUERY + "&" + API_KEY).Result;
                result = httpResponse.Content.ReadAsStringAsync().Result;
                foods = JsonConvert.DeserializeObject<List<Food>>(result);


                Food food = foods.FirstOrDefault(f => f.FDCId == foodItem.FDCId);
                food.Id = foodItem.Id;
                food.MealId = foodItem.MealId;
                food.Quantity = foodItem.Quantity;
                foods.Add(food);
            
            }
            return foods;

        }
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();

            UriBuilder builder = new UriBuilder("https://api.nal.usda.gov/fdc/v1/");

            client.BaseAddress = builder.Uri;
            return client;
        }
    }
}

using Ambrosia.BL;
using Ambrosia.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ambrosia.API.Controllers
{
    public class FoodController : ApiController
    {
        // GET api/values
        public IEnumerable<Food> Get()
        {
            return FoodItemManager.Load();
        }

        // GET api/values/5
        public Food Get(Guid id)
        {
            return FoodItemManager.LoadById(id);
        }
        public List<Food> Get(string search)
        {
            return fdcFoodManager.Search(search);
        }
        public Food Get(int fdcid)
        {
            return fdcFoodManager.Search(fdcid);
        }

        // POST api/values
        public int Post([FromBody] Food value)
        {
            return FoodItemManager.Insert(value);
        }

        // PUT api/values/5
        public int Put(int id, [FromBody] Food value)
        {
            return FoodItemManager.Update(value);
        }

        // DELETE api/values/5
        public int Delete([FromBody] Food value)
        {
            return FoodItemManager.Delete(value);
        }
    }
}

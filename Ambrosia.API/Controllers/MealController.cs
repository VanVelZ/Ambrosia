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
    public class MealController : ApiController
    {
        // GET api/values
        public IEnumerable<Meal> Get()
        {
            return MealManager.Load();
        }
        public IEnumerable<Meal> Get(Guid userid)
        {
            return MealManager.Load(userid);
        }

        // POST api/values
        public int Post([FromBody] Meal value)
        {
            return MealManager.Insert(value);
        }

        // PUT api/values/5
        public int Put(int id, [FromBody] Meal value)
        {
            return MealManager.Update(value);
        }

        // DELETE api/values/5
        public int Delete([FromBody] Meal value)
        {
            return MealManager.Delete(value);
        }
    }
}

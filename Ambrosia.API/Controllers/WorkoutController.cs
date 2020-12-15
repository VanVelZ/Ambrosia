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
    public class WorkoutController : ApiController
    {
            // GET api/values
            public IEnumerable<Workout> Get()
            {
                return WorkoutManager.Load();
            }

            // GET api/values/5
            public IEnumerable<Workout> Get(Guid userid)
            {
                return WorkoutManager.Load(userid);
            }

            // POST api/values
            public int Post([FromBody] Workout value)
            {
                return WorkoutManager.Insert(value);
            }

            // PUT api/values/5
            public int Put(int id, [FromBody] Workout value)
            {
                return WorkoutManager.Update(value);
            }

            // DELETE api/values/5
            public int Delete([FromBody] Workout value)
            {
                return WorkoutManager.Delete(value);
            }
        }
}

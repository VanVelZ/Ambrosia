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
    public class WorkoutTypeController : ApiController
    {
        // GET api/values
        public IEnumerable<WorkoutType> Get()
        {
            return WorkoutTypeManager.Load();
        }

        // GET api/values/5
        public WorkoutType Get(Guid id)
        {
            return WorkoutTypeManager.LoadById(id);
        }

        // POST api/values
        public int Post([FromBody] WorkoutType value)
        {
            return WorkoutTypeManager.Insert(value);
        }

        // PUT api/values/5
        public int Put([FromBody] WorkoutType value)
        {
            return WorkoutTypeManager.Update(value);
        }

        // DELETE api/values/5
        public int Delete(Guid id)
        {
            return WorkoutTypeManager.Delete(id);
        }
        // DELETE api/values/5
        public int Delete([FromBody] WorkoutType value)
        {
            return WorkoutTypeManager.Delete(value);
        }
    }
}

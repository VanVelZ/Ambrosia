
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
    public class UserController : ApiController
    {
        // GET api/values
        public IEnumerable<User> Get()
        {
            return UserManager.Load();
        }
        public Guid Login(string username, string password){

            User user = new User { Username = username, Password = password };
            if (UserManager.Login(user))
            {
                return user.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        // GET api/values/5
        public User Get(Guid id)
        {
            return UserManager.LoadById(id);
        }

        // POST api/values
        public int Post([FromBody] User value)
        {
            return UserManager.Insert(value);
        }

        // PUT api/values/5
        public int Put(int id, [FromBody] User value)
        {
            return UserManager.Update(value);
        }

        // DELETE api/values/5
        public int Delete(Guid id)
        {
            return UserManager.Delete(id);
        }
        // DELETE api/values/5
        public int Delete([FromBody] User value)
        {
            return UserManager.Delete(value);
        }
    }
}

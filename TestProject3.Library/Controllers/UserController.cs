using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject3.Repo.Repository;

namespace TestProject3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public Repository Repo { get; set; }

        public UserController(Repository repo)
        {
            Repo = repo;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<Users> GetUsertable()
        {
            var User = Repo.GetUsertable();
            return User;
        }
        
    }
}

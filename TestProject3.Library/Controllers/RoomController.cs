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
    public class RoomController : ControllerBase
    {
        public Repository Repo { get; set; }

        public RoomController(Repository repo)
        {
            Repo = repo;
        }

        // GET: api/Room
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //}

        // GET: api/Room/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Room
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

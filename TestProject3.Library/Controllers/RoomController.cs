using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject3.Repo.Repository;


namespace TestProject3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        public Repository Repo { get; set; }

        public RoomController(Repository repo)
        {
            Repo = repo;
        }

        // GET: api/Room
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            var rooms = Repo.GetRoomtable();

            return rooms;
        }



       

    }
}

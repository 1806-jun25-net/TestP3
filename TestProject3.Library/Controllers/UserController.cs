using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestProject3.Repo.Repository;
using Microsoft.Extensions.Logging;

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
        //[HttpGet]
        //public string GetUsertable()
        //{
        //    var connectionString = "Endpoint = sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        //    var queuename = "messenger1";
        //    string b = "hola";
        //    var client = QueueClient.CreateFromConnectionString(connectionString, queuename);

        //    client.OnMessage(message =>
        //    b = message.GetBody<string>()

        //    );
        //    //var User = Repo.GetUsertable();
        //    return b;
        //}

        [HttpGet]
        public IEnumerable<Users> GetError()
        {
                var User = Repo.GetError();
                return User;
        }
        
    }
}

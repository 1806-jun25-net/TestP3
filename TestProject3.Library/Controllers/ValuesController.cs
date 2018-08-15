using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.Services;

namespace TestProject3.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //const string connectionString = "Endpoint = sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        //const string queuename = "messenger1";
        //static IQueueClient queueClient;

        //// GET api/values
        //[HttpGet]
        //public async Task Get()
        //{

        //    const int numberOfMessages = 1;


        //    queueClient = new QueueClient(connectionString, queuename);
        //    string a = "hi";

        //    /// send message 
        //    await SendMessagesAsync(numberOfMessages);

        //    await queueClient.CloseAsync();
            
        //}

        //static async Task SendMessagesAsync(int numberOfMessagesToSend)
        //{
        //    try
        //    {
        //        for (var i = 0; i < numberOfMessagesToSend; i++)
        //        {
        //            // Create a new message to send to the queue.
        //            string messageBody = $"Message {i}";
        //            var message = new Message(Encoding.UTF8.GetBytes(messageBody));


        //            // Send the message to the queue.
        //            await queueClient.SendAsync(message);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        //Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
        //    }

            
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestProject3.Repo.Repository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using System;
using System.Text;

namespace TestProject3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        const string connectionString = "Endpoint = sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        const string queuename = "messenger1";
        static IQueueClient queueClient;

        public Repository Repo { get; set; }

        public UserController(Repository repo)
        {
            Repo = repo;
        }

        public  async  Task<ActionResult> Receiver()
        {

            queueClient = new QueueClient(connectionString, queuename);

            RegisterOnMessageHandlerAndReceiveMessages();

            await queueClient.CloseAsync();

            return Ok();
        }

        void RegisterOnMessageHandlerAndReceiveMessages()
        {

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
               
                MaxConcurrentCalls = 1,

                
                AutoComplete = false
            };

       
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            
            return Task.CompletedTask;
        }

        async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {


            string messagebody = Encoding.UTF8.GetString(message.Body);
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);

            GetMessage(messagebody);
        }




        //GET: api/User
       [HttpGet]
        public string GetMessage(string messageBody)
        {

            return  $"Message: {messageBody}";
        }

        [HttpGet]
        public IEnumerable<Users> GetError()
        {
                var User = Repo.GetError();
                return User;
        }
        
    }
}

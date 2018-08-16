using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace TestProject3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        const string ServiceBusConnectionString = "Endpoint=sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        const string QueueName = "messenger1";
        static IQueueClient queueClient;

        public ActionResult<string> Index()
        {
            Sender().GetAwaiter().GetResult();

            return "Message sent";
        }


        static async Task Sender()
        {
            const int numberOfMessages = 1;
            queueClient = new Microsoft.Azure.ServiceBus.QueueClient(ServiceBusConnectionString, QueueName);

            // Send Messages
            await SendMessagesAsync(numberOfMessages);

            //Console.ReadKey();

            await queueClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the queue
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    BrokeredMessage brokeredMessage = new BrokeredMessage(messageBody);


                    // Send the message to the queue
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
            }
        }

    }
}
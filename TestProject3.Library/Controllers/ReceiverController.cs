using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;


namespace TestProject3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        const string ServiceBusConnectionString = "Endpoint=sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        const string QueueName = "messenger1";
        static IQueueClient queueClient;

        public async Task<ActionResult<string>> Index()
        {
            string msg = await Send();
           


            //string messages = ($"Received message: SequenceNumber:{mes.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(mes.Body)}");


            return msg;
        }

        public async Task<string> Send()
        {


            //MainAsync().GetAwaiter().GetResult();
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);


            //queueClient.Receive();
            string msg = "message";


            queueClient.RegisterMessageHandler(
              async (message, token) =>
              {

                  // Process the message
                  Debug.WriteLine("/n");
                  Debug.WriteLine("/n");
                  Debug.WriteLine("/n");
                  Debug.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
                  Debug.WriteLine("/n");
                  Debug.WriteLine("/n");
                  Debug.WriteLine("/n");
                  msg = Encoding.UTF8.GetString(message.Body);
                  // Complete the message so that it is not received again.
                  // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
                  await queueClient.CompleteAsync(message.SystemProperties.LockToken);
              },
              async (exceptionEvent) =>
              {
                  // Process the exception
                  Debug.WriteLine("Exception = " + exceptionEvent.Exception);
              });

            return msg;
        }



        //static async Task MainAsync()
        //{
        //    queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
        //    RegisterOnMessageHandlerAndReceiveMessages();
        //    await queueClient.CloseAsync();
        //}

        //static void RegisterOnMessageHandlerAndReceiveMessages()
        //{
        //    // Configure the MessageHandler Options in terms of exception handling, number of concurrent messages to deliver etc.
        //    var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        //    {
        //        // Maximum number of Concurrent calls to the callback `ProcessMessagesAsync`, set to 1 for simplicity.
        //        // Set it according to how many messages the application wants to process in parallel.
        //        MaxConcurrentCalls = 1,

        //        // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
        //        // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
        //        AutoComplete = false
        //    };

        //    // Register the function that will process messages
        //    queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        //}

        //static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        //{
        //    // Process the message
        //    Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
        //    string messages = ($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

        //    // Complete the message so that it is not received again.
        //    // This can be done only if the queueClient is created in ReceiveMode.PeekLock mode (which is default).
        //    await queueClient.CompleteAsync(message.SystemProperties.LockToken);

        //    // Note: Use the cancellationToken passed as necessary to determine if the queueClient has already been closed.
        //    // If queueClient has already been Closed, you may chose to not call CompleteAsync() or AbandonAsync() etc. calls 
        //    // to avoid unnecessary exceptions.
        //}

        ////public ActionResult<string> Print(string mess)
        ////{
        ////    return ;
        ////}

        //static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        //{
        //    //Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
        //    var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
        //    //Console.WriteLine("Exception context for troubleshooting:");
        //    //Console.WriteLine($"- Endpoint: {context.Endpoint}");
        //    //Console.WriteLine($"- Entity Path: {context.EntityPath}");
        //    //Console.WriteLine($"- Executing Action: {context.Action}");
        //    return Task.CompletedTask;
        //}
    }
}
    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using System.Text;

namespace TestProject3.Library
{
    public class Program
        {
 // Connection String for the namespace can be obtained from the Azure portal under the 
 // 'Shared Access policies' section.
    const string ServiceBusConnectionString = "Endpoint = sb://project3-messagebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5yYCWYA76BT9QPA7/pnWBYXcqgG6X/ZCDQi43dE93cs=";
        const string QueueName = "messenger1";
        static IQueueClient queueClient;

    static void Main(string[] args)
    {
        MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
        const int numberOfMessages = 10;
        queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

        //Console.WriteLine("======================================================");
        //Console.WriteLine("Press ENTER key to exit after receiving all the messages.");
        //Console.WriteLine("======================================================");

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

                // Write the body of the message to the console
                //Console.WriteLine($"Sending message: {messageBody}");

                // Send the message to the queue
                await queueClient.SendAsync(message);
            }
        }
        catch (Exception exception)
        {
            //Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
        }
    }
}
}

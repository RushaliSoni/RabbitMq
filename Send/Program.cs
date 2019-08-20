//RabbitMQ is a message broker: it accepts and forwards messages. You can think about it as a post office
//Producing means nothing more than sending. A program that sends messages is a producer


using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Program
    {
       static void Main()
        {
           
            //Create a Connection To the server 
            //ConnectionFactroy for construnt object
            var factory = new ConnectionFactory() { HostName = "LocalHost" };
            using (var connection = factory.CreateConnection())
            {
                //Create a Channel 
                using (var channel = connection.CreateModel())
                {
                    //Declare a Queue for us to send
                    //queue name must be same
                    channel.QueueDeclare(queue: "Hello",
                                          durable:false,
                                          exclusive:false,
                                          autoDelete:false,
                                          arguments:null);


                    //string message = "Hello From  Rushali !";
                    Console.WriteLine("Enter Your Message u want to send ");
                    string message = Console.ReadLine();
                    var body = Encoding.UTF8.GetBytes(message);
                    //Publish a message to the queue

                    channel.BasicPublish(exchange: "",
                                         routingKey:"Hello",
                                         basicProperties:null,
                                         body:body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
          }
    }
}

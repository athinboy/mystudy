using System;
using System.Text;
using RabbitMQ.Client;

namespace org.fgq.study.dotnet.rabbitmq.One
{
    public class SenderOne
    {

        ConnectionFactory factory;
        IConnection connection;
        IModel channel;

        IBasicProperties properties;


        public void Exit()
        {
            channel.Dispose();
            connection.Dispose();

        }

        public void LoopSend(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string message = i.ToString();
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }



        public void Ready()
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();

            channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            properties = channel.CreateBasicProperties();
            properties.Persistent = true;



        }
    }
}
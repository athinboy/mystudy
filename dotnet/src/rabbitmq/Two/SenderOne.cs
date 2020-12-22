using System;
using System.Text;
using org.fgq.study.dotnet.rabbitmq.Core;
using RabbitMQ.Client;

namespace org.fgq.study.dotnet.rabbitmq.One
{
    public class SenderOne
    {

        ConnectionFactory factory;
        IConnection connection;
        IModel channel;

        Config config;

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
                                     routingKey: config.QueueName2,
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }



        public void Ready()
        {
            config = Config.GetInstance();
            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();

            channel = connection.CreateModel();

 

            properties = channel.CreateBasicProperties();
            properties.Persistent = true;



        }
    }
}
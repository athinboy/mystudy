using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using org.fgq.study.dotnet.rabbitmq.Core;
using System.Threading;

namespace org.fgq.study.dotnet.rabbitmq.One
{
    public class ReceiverOne
    {


        public string Sgin { get; set; }
        ConnectionFactory factory;
        IConnection connection;
        IModel channel;

        private int receivedCount = 0;

        private static Random random = new Random();

        public ReceiverOne(string sgin)
        {
            Sgin = sgin ?? throw new ArgumentNullException(nameof(sgin));
        }

        public void Exit()
        {
            channel.Dispose();
            connection.Dispose();
            Console.WriteLine("Sgin:{0}  count:{1}", Sgin, (receivedCount++).ToString());//通过receivedCount可以发现, rabbitmq将尽量保证每个客户端处理相同数量的消息

        }


        public void Ready()
        {

            Config config = Config.GetInstance();


            factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();

            channel = connection.CreateModel();

            channel.QueueDeclare(queue: config.QueueName2,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(0, 1, false);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Sgin:{0}  Receive:{1}   count:{2}", Sgin, message, (receivedCount++).ToString());

                    Thread.Sleep(1000 * (1 + int.Parse(Sgin)));
                    channel.BasicAck(ea.DeliveryTag, false);


                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }

            };
            channel.BasicConsume(queue: config.QueueName2,
                                 autoAck: false,
                                 consumer: consumer);





        }
    }
}
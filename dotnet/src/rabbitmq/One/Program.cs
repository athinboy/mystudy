using System;
using System.Collections.Generic;

namespace org.fgq.study.dotnet.rabbitmq.One
{
    class Program
    {
        static void Main(string[] args)
        {
            int rcount = 20;

            List<ReceiverOne> receivers = new List<ReceiverOne>();
            for (int i = 0; i < rcount; i++)
            {

                ReceiverOne receiver = new ReceiverOne(i.ToString());
                receiver.Ready();
                receivers.Add(receiver);

            }


            SenderOne sender = new SenderOne();
            sender.Ready();
            sender.LoopSend(100);




            Console.WriteLine("Hello World!");
            Console.ReadLine();

            receivers.ForEach(x => { x.Exit(); });
            sender.Exit();
        }
    }
}

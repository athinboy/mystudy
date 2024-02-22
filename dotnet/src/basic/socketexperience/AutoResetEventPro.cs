using System;
using System.Runtime.InteropServices;

namespace MyApp // Note: actual namespace depends on the project name.
{

    internal class AutoResetEventPro
    {

        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);


        static int finishcount = 0;

        static Random random = new Random(34);


        static void Main(string[] args)
        {


            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(ThreadPro);
                thread.Start(i);

            }

            while (finishcount != 10)
            {
                System.Console.WriteLine("finishcount:"+finishcount.ToString());
                Thread.Sleep(random.Next(1000, 3000));
                autoResetEvent.Set();
            }
            System.Console.WriteLine("all finish!");

        }

        private static void ThreadPro(object? i)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            System.Console.WriteLine(threadId.ToString() + ":wait!");
            autoResetEvent.WaitOne();
            System.Console.WriteLine(threadId.ToString() + ":go!");

            Interlocked.Add(ref finishcount, 1);


        }




    }
}
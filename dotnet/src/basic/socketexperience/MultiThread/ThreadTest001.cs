using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MultiThread
{
    public class ThreadTest001
    {

        static int sign = 0;

        static void Main(string[] args)
        {
         
  
            TaskFactory taskFactory = new TaskFactory(TaskScheduler.Current);
             
            ThreadPool.SetMinThreads(100, 1);
            ThreadPool.SetMaxThreads(200, 2);


            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {

                var t = taskFactory.StartNew(() =>
                   {

                       Thread.Sleep(Random.Shared.Next(100, 1000));

                       while (0 == Interlocked.CompareExchange(ref sign, 1, 0))
                       {
                           Thread.Sleep(100);
                       }
                       Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
                       sign = 0;
                   });
                tasks.Add(t);

            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("all finish");
            Console.ReadKey();
        }
    }
}

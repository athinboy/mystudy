using System;
using System.Runtime.InteropServices;

namespace MyApp // Note: actual namespace depends on the project name.
{

    internal class MutexPro
    {



        static void Main(string[] args)
        {

            Random random=new Random(324);
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem((statue) =>
                {
                    string ss=statue?.ToString();
                    Console.WriteLine(ss+"start");
                    bool created=false;
                    Mutex mutex=new Mutex(false,"mutex",out created);
                    if(mutex.WaitOne()){
                    Console.WriteLine(ss+"getmutex");
                        Thread.Sleep(random.Next(100,300));
                        mutex.ReleaseMutex();
                    Console.WriteLine(ss+"end");

                    }

                }, i);

            }
            Console.ReadKey();

        }
    }

}
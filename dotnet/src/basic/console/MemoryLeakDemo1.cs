using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fgq.console
{
    internal class MemoryLeakDemo1
    {
        public static void Run()
        {

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Object lockObj = new Object();
            TaskFactory factory = new TaskFactory(token);
            Random rnd = new Random();
            int iii = 1;
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                iii = taskCtr + 1;
                tasks.Add(factory.StartNew(() => {
                    int value;
                    int[] values = new int[10];

                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + "iteration:" + iteration + "  iii:" + iii);
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                            Thread.Sleep(value);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));
                Console.WriteLine("outside:" + iteration);
            }
            Thread.Sleep(10000);

        }

        private void SSS()
        {

        }

    }
}

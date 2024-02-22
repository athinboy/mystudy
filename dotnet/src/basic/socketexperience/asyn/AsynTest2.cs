using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.asyn
{
    internal class AsynTest2
    {
        static int Main(string[] args)
        {

 

            Console.WriteLine("start:" + DateTime.Now.ToString("HH:mm:ss"));
            Task<int> task = GetSomeThing(-1);
            if (task.IsCompleted)
            {
                Console.WriteLine($"{task.Result}" + DateTime.Now.ToString("HH:mm:ss"));
            }
            else
            {
                Console.WriteLine(task.Status.ToString() + DateTime.Now.ToString("HH:mm:ss"));
            }
            Console.WriteLine("start:" + DateTime.Now.ToString("HH:mm:ss"));
            string a = "fewfw";
            DateTime b = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                if (System.IO.File.Exists(@"c:\1\1.txt"))
                {
                    a = i.ToString();
                    b = DateTime.Now;
                    try
                    {
                        System.IO.File.Open("wefwf", FileMode.Open);
                    }
                    finally
                    {
                        Console.WriteLine();

                    }
                }


            }


            Console.WriteLine("end:" + DateTime.Now.ToString("HH:mm:ss"));
            Console.ReadKey();

            return 1;
        }


        async static Task<int> GetSomeThing(int i)
        {
            Console.WriteLine("sleep:" + i.ToString());
            await Task.Delay(2000);
            Console.WriteLine(nameof(GetSomeThing));

            return i;
        }


        async static void DoSomeThing()
        {
            Console.WriteLine(nameof(DoSomeThing));
            return;
        }
    }
}

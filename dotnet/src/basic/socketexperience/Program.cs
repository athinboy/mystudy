using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Program.pro);
                thread.Start(i);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Hello World!");
        }

        internal static void pro(object? s)
        {
            Console.WriteLine(s?.ToString());
        }
    }



}
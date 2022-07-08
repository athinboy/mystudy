using System;

namespace org.fgq.autofacstudy.One
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if(args[0] == "one")
                {
                    org.fgq.autofacstudy.One.Sample.Run();
                }

                return;
            }

            Console.WriteLine("Hello World!");
        }
    }
}
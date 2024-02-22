using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.linq
{
    internal class LINQTest
    {
        static void Main(string[] args)
        {

            List<string> strings = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                strings.Add(i.ToString());
            }
            var sf = (from s in strings
                      where s.Length > 0
                      select s);
            
            Console.WriteLine(string.Join<string>(",", sf));
            Console.ReadLine();

        }
    }
}

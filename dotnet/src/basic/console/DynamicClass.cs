using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace console
{
    internal class DynamicClass
    {
        static void Main(string[] args)
        {
            dynamic obj1 = new
            {
                userId = 100,
                id = 1,
                title = "hello world",
                completed = false,
            };
            dynamic obj2 = new System.Dynamic.ExpandoObject();
            obj2.userId = 100;
            obj2.id = 1;
            obj2.title = "hello world";
            obj2.completed = false;



            Console.WriteLine("---obj1---");
            Console.WriteLine(obj1.userId);
            Console.WriteLine(obj1.id);
            Console.WriteLine(obj1.title);
            Console.WriteLine(obj1.completed);

            Console.WriteLine("\n---obj2---");
            Console.WriteLine(obj2.userId);
            Console.WriteLine(obj2.id);
            Console.WriteLine(obj2.title);
            Console.WriteLine(obj2.completed);


            Console.WriteLine(obj1.userId);
            Type t = obj1.GetType();
            PropertyInfo[] pi = t.GetProperties();
            foreach (PropertyInfo p in pi)
            {

                var key = p.Name;
                var value = p.GetValue(obj1, null);
                Console.WriteLine(key + ": " + value);

            }


        }
    }
}



using System;
using System.Reflection;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            if (args != null && args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("argument" + i.ToString());
                    Console.WriteLine(args[i]);
                }

            }



            string projectOutputPath = args[0];
            string typename = args[1];
            string methodname = args[2];
            string isstatic = args[3];

            Assembly assembly = null;
            try
            {

                assembly = Assembly.LoadFile(projectOutputPath);
                if (assembly == null)
                {
                    Console.WriteLine("can not load assemble:" + projectOutputPath);
                    return;
                }

                Type type = assembly.GetType(typename, false, true);

                if (type == null)
                {
                    Console.WriteLine("can not get type:" + typename);
                    return;
                }

                MethodInfo methodinfo = type.GetMethod(methodname);
                if (methodinfo == null)
                {
                    Console.WriteLine("can not find method:" + methodname);
                    return;
                }
                if (bool.Parse(isstatic))
                {
                    methodinfo.Invoke(null, null);
                }
                else
                {
                    Object o = assembly.CreateInstance(typename);
                    methodinfo.Invoke(o, null);
                }
                Console.WriteLine("run func finish!");

            }
            catch (Exception ex)
            {
                Console.Write(ex);

            }
            finally
            {
                if (assembly != null)
                {

                }
            }





        }
    }
}

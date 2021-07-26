using GenerateUtilCore;
using RazorEngineCore;
using System;
using System.IO;

namespace RazorUtilCore
{
    class Program
    {
        static void Main(string[] args)
        {
            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

            string result = template.Run(new
            {
                Name = "Alexander"
            });

            Console.WriteLine(result);

            string curDir = System.Environment.CurrentDirectory;
            string path = string.Format("{0}{1}{2}{1}{3}"
                , curDir
                , System.IO.Path.DirectorySeparatorChar
                , "template"
                , "SqlSugarEntity.txt");
            string content = File.ReadAllText(path);
            template = razorEngine.Compile(content);
            Console.WriteLine(template.Run(new GenerateConfig()));
       



        }


    }
}

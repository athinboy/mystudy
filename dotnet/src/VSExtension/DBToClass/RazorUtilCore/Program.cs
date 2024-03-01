﻿
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Dispatch;
using RazorEngineCore;
using System;
using System.IO;

namespace Org.FGQ.CodeGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.Error.WriteLine("need config!");

            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];
                    string v;
                    switch (arg)
                    {
                        case "-c":
                            if (i == args.Length - 1)
                            {
                                Console.Error.WriteLine("need config file");
                                break;
                            }
                            i++;
                            v = args[i];
                            string configFilePath = v;
                            configFilePath = FileUtil.GetAbsoluteFilePath(System.Environment.CurrentDirectory, configFilePath);
                            GenerateConfig? generateConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<GenerateConfig>(File.ReadAllText(configFilePath));
                            if (generateConfig == null)
                            {
                                Console.Error.WriteLine("error");
                                break;
                            }
                            DefaultDispatch defaultDispatch = new DefaultDispatch();
                            defaultDispatch.Dispatch(generateConfig);
                            break;
                        default:
                            Console.Error.WriteLine("error");
                            break;
                    }
                }
            }
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

            Console.Read();


        }


    }
}

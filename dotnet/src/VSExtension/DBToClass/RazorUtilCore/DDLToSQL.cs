using Org.FGQ.CodeGenerate.Config;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate
{
    public class DDLToSQL
    {

        private static string templateOracleRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "OracleDDL.txt";
        private static string templateMysqlRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "MysqlDDL.txt";

        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        ConcurrentDictionary<string, IRazorEngine> razorEngines =
             new ConcurrentDictionary<string, IRazorEngine>();


        ConcurrentDictionary<string, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTable>>> templates =
            new ConcurrentDictionary<string, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTable>>>();
        void init(DDLConfig.DBType myDBType)
        {
            if (razorEngines.ContainsKey(myDBType.ToString()))
            {
                return;
            }
            lock (this)
            {
                if (razorEngines.ContainsKey(myDBType.ToString()))
                {
                    return;
                }

                string templateRelatePath = string.Empty;
                switch (myDBType)
                {
                    case DDLConfig.DBType.MySql:
                        templateRelatePath = templateMysqlRelatePath;
                        break;
                    case DDLConfig.DBType.Oracle:
                        templateRelatePath = templateOracleRelatePath;
                        break;
                    default:
                        throw new ArgumentNullException(nameof(myDBType));
                }


                string templatePath = Environment.CurrentDirectory + templateRelatePath;
                logger.Info(templatePath);
                string templateContent = File.ReadAllText(templatePath);
                IRazorEngine razorEngine = new RazorEngine();
                razorEngines[myDBType.ToString()]=razorEngine;

                IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTable>> template 
                    = razorEngine.Compile<RazorEngineTemplateBase<DDLTable>>(templateContent, builder =>
        {
            //builder.AddAssemblyReferenceByName("System.Security"); // by name
            //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
            //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
            builder.AddAssemblyReferenceByName("System.Collections");
        });

                templates[myDBType.ToString()]=template;


                //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

            }
        }


        public void GenerateSql(DDLConfig dDLConfig, string outputpath)
        {

            init(dDLConfig.MyDBType);

            dDLConfig.Prepare();

            string result = String.Empty;
            dDLConfig.Tables.ForEach(t =>
            {
                result += templates[dDLConfig.MyDBType.ToString()].Run(instance =>
                {
                    instance.Model = t;
                });
            });




            Console.WriteLine(result);


            if (File.Exists(outputpath))
            {
                File.Delete(outputpath);
            }


            File.WriteAllText(outputpath, result, new UTF8Encoding(false));




        }





    }
}

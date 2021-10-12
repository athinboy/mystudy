using Org.FGQ.CodeGenerate.Config;
using RazorEngineCore;
using System;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate
{
    public class DDLToSQL
    {

        private static string templateRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "OracleDDL.txt";

        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        IRazorEngine razorEngine = null;
        IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTable>> template = null;
        void init()
        {
            if (razorEngine != null)
            {
                return;
            }
            lock (this)
            {
                if (razorEngine != null)
                {
                    return;
                }

                string templatePath = Environment.CurrentDirectory + templateRelatePath;
                logger.Info(templatePath);
                string templateContent = File.ReadAllText(templatePath);
                razorEngine = new RazorEngine();
                template = razorEngine.Compile<RazorEngineTemplateBase<DDLTable>>(templateContent, builder =>
        {
            //builder.AddAssemblyReferenceByName("System.Security"); // by name
            //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
            //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
            builder.AddAssemblyReferenceByName("System.Collections");
        });

                //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

            }
        }


        public void GenerateSql(DDLConfig dDLConfig, string outputpath)
        {

            init();

            dDLConfig.Prepare();






            string result = String.Empty;
            dDLConfig.Tables.ForEach(t =>
            {
                result += template.Run(instance =>
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

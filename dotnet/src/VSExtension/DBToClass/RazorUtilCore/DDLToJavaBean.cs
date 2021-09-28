using Org.FGQ.CodeGenerate.config;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate
{
    public class DDLToJavaBean
    {

        private static string templateRelatePath = Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + "DDLToJavaBean.txt";


        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();


        public void GenerateBean(JavaBeanConfig javaBeanConfig)
        {

            string templatePath = Environment.CurrentDirectory + templateRelatePath;


            logger.Info(templatePath);



            string templateContent = File.ReadAllText(templatePath);



            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> template
                = razorEngine.Compile<RazorEngineTemplateBase<JavaClass>>(templateContent, builder =>
                {
                    //builder.AddAssemblyReferenceByName("System.Security"); // by name
                    //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                    //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
                    builder.AddAssemblyReferenceByName("System.Collections");
                });

            //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

             javaBeanConfig.DDLConfig.Prepare();



            string rootDir = javaBeanConfig.JavaDiretory + (javaBeanConfig.JavaDiretory.EndsWith(Path.DirectorySeparatorChar) ? "" : Path.DirectorySeparatorChar);

            if (false == Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            string[] packageParts = javaBeanConfig.PackageName.Split(".");
            for (int i = 0; i < packageParts.Length; i++)
            {
                string packagePart = packageParts[i];

                if (string.IsNullOrEmpty(packagePart))
                {
                    continue;
                }
                rootDir += (packagePart + Path.DirectorySeparatorChar);

                if (false == Directory.Exists(rootDir))
                {
                    Directory.CreateDirectory(rootDir);
                }
            }

            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = template.Run(instance =>
                {
                    javaBeanConfig.Table = t;
                    instance.Model = JavaClass.Create(t, javaBeanConfig) ;
                });
                Console.WriteLine(result);
                string filePath = rootDir + Path.DirectorySeparatorChar + CodeUtil.GetClassName(javaBeanConfig, t.TableName) + ".java";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, Encoding.UTF8);


            });




        }


    }
}

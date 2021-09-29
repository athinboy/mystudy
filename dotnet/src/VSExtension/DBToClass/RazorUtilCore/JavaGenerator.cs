using Org.FGQ.CodeGenerate.Config;
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
    public class JavaGenerator
    {

        private static string javaBeanTemplateRelatePath = Path.DirectorySeparatorChar + "template" +
            Path.DirectorySeparatorChar + "JavaBean.txt";


        private static string javaDaoTemplateRelatePath = Path.DirectorySeparatorChar + "template" +
            Path.DirectorySeparatorChar + "JavaDao.txt";



        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();


        public void GenerateBean(JavaBeanConfig javaBeanConfig)
        {

            string templatePath = Environment.CurrentDirectory + javaBeanTemplateRelatePath;


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



            string rootDir = CodeUtil.PrepareJavaRoot(javaBeanConfig);

            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = template.Run(instance =>
                {
                    javaBeanConfig.Table = t;
                    t.CreatedJavaBean = JavaClass.Create(t, javaBeanConfig);
                    instance.Model = t.CreatedJavaBean;
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

        public void GenerateDao(JavaDaoConfig javaDaoConfig, JavaClass javaClass)
        {

            string templatePath = Environment.CurrentDirectory + javaDaoTemplateRelatePath;


            logger.Info(templatePath);



            string templateContent = File.ReadAllText(templatePath);



            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoConfig>> template
                = razorEngine.Compile<RazorEngineTemplateBase<JavaDaoConfig>>(templateContent, builder =>
                {
                    builder.AddAssemblyReferenceByName("System.Collections");
                    builder.AddAssemblyReference(typeof(CodeUtil)); // by type
                });


            string rootDir  ;


            string result = String.Empty;



            Action action = () =>
             {
                 result = template.Run(instance =>
                 {
                     javaDaoConfig.JavaClass = javaClass;
                     instance.Model = javaDaoConfig;
                 });
                 Console.WriteLine(result);
                 rootDir = CodeUtil.PrepareJavaRoot(javaDaoConfig);

                 string filePath = rootDir + Path.DirectorySeparatorChar + javaDaoConfig.DaoName + ".java";

                 if (File.Exists(filePath))
                 {
                     File.Delete(filePath);
                 }
                 File.WriteAllText(filePath, result, Encoding.UTF8);

             };


            if (javaDaoConfig.SplitReadWrite)
            {
                javaDaoConfig.ForRead = true;
                javaDaoConfig.ForWrite = false;

                action();


                javaDaoConfig.ForWrite = true;
                javaDaoConfig.ForRead = false;
                action();


            }
            else
            {
                action();

            }










        }






    }
}

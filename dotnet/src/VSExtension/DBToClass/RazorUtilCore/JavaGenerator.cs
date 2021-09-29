using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.RazorTag;
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

        private static string javaMapperTemplateRelatePath = Path.DirectorySeparatorChar + "template" +
            Path.DirectorySeparatorChar + "JavaMapper.txt";



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



            string beanRootDir = CodeUtil.PrepareJavaRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareJavaRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);


            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = template.Run(instance =>
                {
                    javaBeanConfig.Table = t;
                    t.CreatedJavaBean = JavaClass.CreateBoClass(t, javaBeanConfig, true);
                    instance.Model = t.CreatedJavaBean;
                });
                Console.WriteLine(result);
                string filePath = beanRootDir + Path.DirectorySeparatorChar + t.CreatedJavaBean.ClassName + ".java";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, Encoding.UTF8);


                result = template.Run(instance =>
                {
                    instance.Model = t.CreatedJavaBean.JavaVoClass;
                });
                Console.WriteLine(result);
                filePath = voRootDir + Path.DirectorySeparatorChar + t.CreatedJavaBean.JavaVoClass.ClassName + ".java";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, Encoding.UTF8);


            });




        }

        public void GenerateDao(JavaDaoConfig javaDaoConfig, JavaClass javaClass, JavaMapperConfig javaMapperConfig)
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

            string rootDir;
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

                 GenerateMapper(javaMapperConfig, javaClass);

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

        private void GenerateMapper(JavaMapperConfig javaMapperConfig, JavaClass createdJavaBean)
        {
            string templatePath = Environment.CurrentDirectory + javaMapperTemplateRelatePath;
            logger.Info(templatePath);
            string templateContent = File.ReadAllText(templatePath);

            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperConfig>> template
                = razorEngine.Compile<RazorEngineTemplateBase<JavaMapperConfig>>(templateContent, builder =>
                {
                    builder.AddAssemblyReferenceByName("System.Collections");
                    builder.AddAssemblyReference(typeof(CodeUtil)); // by type
                    builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
                });


            string rootDir = javaMapperConfig.MapperDirectory;
            string mapperDir = rootDir;
            string result = String.Empty;

            Action action = () =>
            {
                result = template.Run(instance =>
                {

                    javaMapperConfig.JavaClass = createdJavaBean;
                    instance.Model = javaMapperConfig;
                });
                Console.WriteLine(result);


                string filePath = mapperDir + Path.DirectorySeparatorChar + javaMapperConfig.MapperName + ".xml";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, Encoding.UTF8);

            };


            if (javaMapperConfig.SplitReadWrite)
            {
                if (javaMapperConfig.DaoConfig.ForRead)
                {
                    mapperDir = rootDir + "\\read";
                    javaMapperConfig.ForRead = true;
                    javaMapperConfig.ForWrite = false;

                    action();
                }
                if (javaMapperConfig.DaoConfig.ForWrite)
                {

                    mapperDir = rootDir + "\\write";
                    javaMapperConfig.ForWrite = true;
                    javaMapperConfig.ForRead = false;
                    action();
                }


            }
            else
            {
                action();

            }


        }
    }
}

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

        private static string javaCodeTemplateRelatePath = Path.DirectorySeparatorChar + "template" +
            Path.DirectorySeparatorChar + "JavaCode.txt";

        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();


        private IRazorEngine razorEngine = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> beanTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoConfig>> daoTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperConfig>> mapperTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> codeTemplate = null;
        private void init()
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

                razorEngine = new RazorEngine();

                string templatePath = Environment.CurrentDirectory + javaBeanTemplateRelatePath;
                string templateContent = File.ReadAllText(templatePath);

                beanTemplate = razorEngine.Compile<RazorEngineTemplateBase<JavaClass>>(templateContent, builder =>
{
    //builder.AddAssemblyReferenceByName("System.Security"); // by name
    //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
    //builder.AddAssemblyReference(Assembly.Load("source")); // by reference
    builder.AddAssemblyReferenceByName("System.Collections");
});



                templatePath = Environment.CurrentDirectory + javaDaoTemplateRelatePath;
                templateContent = File.ReadAllText(templatePath);
                daoTemplate = razorEngine.Compile<RazorEngineTemplateBase<JavaDaoConfig>>(templateContent, builder =>
 {
     builder.AddAssemblyReferenceByName("System.Collections");
     builder.AddAssemblyReference(typeof(CodeUtil)); // by type
 });

                templatePath = Environment.CurrentDirectory + javaMapperTemplateRelatePath;

                templateContent = File.ReadAllText(templatePath);


                mapperTemplate
                       = razorEngine.Compile<RazorEngineTemplateBase<JavaMapperConfig>>(templateContent, builder =>
                       {
                           builder.AddAssemblyReferenceByName("System.Collections");
                           builder.AddAssemblyReference(typeof(CodeUtil)); // by type
                           builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
                       });


                templatePath = Environment.CurrentDirectory + javaCodeTemplateRelatePath;

                templateContent = File.ReadAllText(templatePath);




                codeTemplate = razorEngine.Compile<RazorEngineTemplateBase<JavaCodeConfig>>(templateContent, builder =>
{
    builder.AddAssemblyReferenceByName("System.Collections");
    builder.AddAssemblyReference(typeof(CodeUtil)); // by type
    builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
});


            }

        }




        public void GenerateBean(JavaBeanConfig javaBeanConfig)
        {

            init();

            //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

            javaBeanConfig.DDLConfig.Prepare();



            string beanRootDir = CodeUtil.PrepareJavaRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareJavaRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);


            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = beanTemplate.Run(instance =>
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
                File.WriteAllText(filePath, result, new UTF8Encoding(false));


                result = beanTemplate.Run(instance =>
                {
                    instance.Model = t.CreatedJavaBean.JavaVoClass;
                });
                Console.WriteLine(result);
                filePath = voRootDir + Path.DirectorySeparatorChar + t.CreatedJavaBean.JavaVoClass.ClassName + ".java";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));


            });




        }

        public void GenerateDao(JavaDaoConfig javaDaoConfig, JavaMapperConfig javaMapperConfig)
        {
            init();


            string rootDir;
            string result = String.Empty;

            Action action = () =>
             {
                 result = daoTemplate.Run(instance =>
                 {

                     instance.Model = javaDaoConfig;
                 });
                 Console.WriteLine(result);
                 rootDir = CodeUtil.PrepareJavaRoot(javaDaoConfig);

                 string filePath = rootDir + Path.DirectorySeparatorChar + javaDaoConfig.DaoName + ".java";

                 if (File.Exists(filePath))
                 {
                     File.Delete(filePath);
                 }
                 File.WriteAllText(filePath, result, new UTF8Encoding(false));

                 javaMapperConfig.JavaClass = javaDaoConfig.JavaClass;
                 GenerateMapper(javaMapperConfig);

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

        private void GenerateMapper(JavaMapperConfig javaMapperConfig)
        {

            init();

            string rootDir = javaMapperConfig.MapperDirectory;
            if (false == Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            string mapperDir = rootDir;
            string result = String.Empty;

            Action action = () =>
            {
                result = mapperTemplate.Run(instance =>
                {


                    instance.Model = javaMapperConfig;
                });
                Console.WriteLine(result);


                string filePath = mapperDir + Path.DirectorySeparatorChar + javaMapperConfig.MapperName + ".xml";
                if (false == Directory.Exists(mapperDir))
                {
                    Directory.CreateDirectory(mapperDir);
                }
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));

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

        public void GenerateCode(JavaCodeConfig javaCodeConfig, JavaClass createdJavaBean)
        {
            init();

            javaCodeConfig.JavaClass = createdJavaBean;
            string rootDir = String.Empty;

            string result = String.Empty;

            string fileName = string.Empty;

            Action action = () =>
            {
                result = codeTemplate.Run(instance =>
                {
                    instance.Model = javaCodeConfig;
                });
                Console.WriteLine(result);


                string filePath = rootDir + Path.DirectorySeparatorChar + fileName + ".java";


                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));

            };


            javaCodeConfig.Reset();
            javaCodeConfig.ForModel = true;
            rootDir = CodeUtil.PrepareJavaRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ModelPackageName);
            fileName = javaCodeConfig.ModelName;
            action();


            javaCodeConfig.Reset();
            javaCodeConfig.ForService = true;
            rootDir = CodeUtil.PrepareJavaRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ServicePackageName);
            fileName = javaCodeConfig.ServiceName;
            action();

            javaCodeConfig.Reset();
            javaCodeConfig.ForServiceImpl = true;
            rootDir = CodeUtil.PrepareJavaRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ServiceImplPackageName);
            fileName = javaCodeConfig.ServiceImplName;
            action();


            javaCodeConfig.Reset();
            javaCodeConfig.ForController = true;
            rootDir = CodeUtil.PrepareJavaRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ControllerPackageName);
            fileName = javaCodeConfig.ControllerName;
            action();


        }

    }
}

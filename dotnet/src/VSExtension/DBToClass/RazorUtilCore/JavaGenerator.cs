using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate
{

    public class Template
    {

        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> beanTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoConfig>> daoTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperConfig>> mapperTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> modelTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> serviceTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> serviceImplTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> controllerTemplate = null;

        internal Template Clone()
        {
            Template newTemplate = new Template();
            newTemplate.beanTemplate = beanTemplate;
            newTemplate.daoTemplate = daoTemplate;
            newTemplate.mapperTemplate = mapperTemplate;
            newTemplate.modelTemplate = modelTemplate;
            newTemplate.serviceTemplate = serviceTemplate;
            newTemplate.serviceImplTemplate = serviceImplTemplate;
            newTemplate.controllerTemplate = controllerTemplate;
            return newTemplate;
        }

    }


    public class JavaGenerator
    {

        public static string GetTemplateFilePath(string filename)
        {
            return Environment.CurrentDirectory + Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + filename;
        }



        private static string javaBeanTemplateRelatePath = GetTemplateFilePath("JavaBean.cshtml");

        private static string javaDaoTemplateRelatePath = GetTemplateFilePath("JavaDao.cshtml");

        private static string javaMapperTemplateRelatePath = GetTemplateFilePath("JavaMapper.cshtml");

        private static string javaCodeTemplateRelatePath = GetTemplateFilePath("JavaCode.cshtml");

        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();


        private IRazorEngine razorEngine = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> beanTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoConfig>> daoTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperConfig>> mapperTemplate = null;

        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> codeTemplate = null;


        private Template defaultTemplate = null;
        private ConcurrentDictionary<JavaCodeConfig, Template> templateCache = new ConcurrentDictionary<JavaCodeConfig, Template>();

        private Template GetTemplate(JavaCodeConfig javaCodeConfig)
        {
            initDefault();

            if (string.IsNullOrEmpty(javaCodeConfig.ServiceCodeTemplateFile)
                && string.IsNullOrEmpty(javaCodeConfig.ServiceImplCodeTemplateFile)
                && string.IsNullOrEmpty(javaCodeConfig.ControllerCodeTemplateFile))
            {
                return defaultTemplate;
            }

            Template template = templateCache[javaCodeConfig];
            if (template != null) return template;

            template = defaultTemplate.Clone();


            if (false == string.IsNullOrEmpty(javaCodeConfig.ServiceCodeTemplateFile))
            {
                template.serviceTemplate = GetTemplate<JavaCodeConfig>(GetTemplateFilePath(javaCodeConfig.ServiceCodeTemplateFile));
            }
            if (false == string.IsNullOrEmpty(javaCodeConfig.ServiceImplCodeTemplateFile))
            {
                template.serviceImplTemplate = GetTemplate<JavaCodeConfig>(GetTemplateFilePath(javaCodeConfig.ServiceImplCodeTemplateFile));
            }
            if (false == string.IsNullOrEmpty(javaCodeConfig.ControllerCodeTemplateFile))
            {
                template.controllerTemplate = GetTemplate<JavaCodeConfig>(GetTemplateFilePath(javaCodeConfig.ControllerCodeTemplateFile));
            }


            return template;


        }

        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> GetTemplate<T>(string filepath)
        {
            razorEngine = new RazorEngine();

            string templatePath = Environment.CurrentDirectory + filepath;
            string templateContent = File.ReadAllText(templatePath);

            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> razorTemplate =
                razorEngine.Compile<RazorEngineTemplateBase<T>>(templateContent, builder =>
            {
                //builder.AddAssemblyReferenceByName("System.Security"); // by name
                //builder.AddAssemblyReference(typeof(System.IO.File)); // by type
                //builder.AddAssemblyReference(Assembly.Load("source")); // by reference

                builder.AddAssemblyReferenceByName("System.Collections");
                builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
                builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type

            });

            return razorTemplate;



        }




        private void initDefault()
        {
            if (defaultTemplate != null)
            {
                return;
            }

            lock (this)
            {
                if (defaultTemplate == null)
                {
                    defaultTemplate = new Template();
                }
                else
                {
                    return;
                }

                razorEngine = new RazorEngine();

                beanTemplate = GetTemplate<JavaClass>(javaBeanTemplateRelatePath);
                daoTemplate = GetTemplate<JavaDaoConfig>(javaDaoTemplateRelatePath);
                mapperTemplate = GetTemplate<JavaMapperConfig>(javaMapperTemplateRelatePath);

                codeTemplate = GetTemplate<JavaCodeConfig>(javaCodeTemplateRelatePath);

                defaultTemplate.beanTemplate = beanTemplate;
                defaultTemplate.daoTemplate = daoTemplate;
                defaultTemplate.mapperTemplate = mapperTemplate;
                defaultTemplate.serviceTemplate = codeTemplate;
                defaultTemplate.modelTemplate = codeTemplate;
                defaultTemplate.serviceImplTemplate = codeTemplate;
                defaultTemplate.controllerTemplate = codeTemplate;

            }


        }


        private  void GenerateBean(JavaBeanConfig javaBeanConfig)
        {

            initDefault();

            //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

            javaBeanConfig.DDLConfig.Prepare();



            string beanRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);


            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = beanTemplate.Run(instance =>
                {
                    javaBeanConfig.Table = t;
                    t.RelatedClsss = JavaClass.CreateBoClass(t, javaBeanConfig, true);
                    instance.Model = t.RelatedClsss as JavaClass;
                });
                Console.WriteLine(result);
                string filePath = beanRootDir + Path.DirectorySeparatorChar + t.RelatedClsss.ClassName + ".java";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));


                result = beanTemplate.Run(instance =>
                {
                    instance.Model = (t.RelatedClsss as JavaClass).JavaVoClass;
                });
                Console.WriteLine(result);
                filePath = voRootDir + Path.DirectorySeparatorChar + (t.RelatedClsss as JavaClass).JavaVoClass.ClassName + ".java";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));


            });




        }

        public void GenerateDao(JavaDaoConfig javaDaoConfig, JavaMapperConfig javaMapperConfig)
        {
            initDefault();


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

            initDefault();

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
            Template template = GetTemplate(javaCodeConfig);
            IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> codeTemplate = null;

            lock (this)
            {

                javaCodeConfig.JavaClass = createdJavaBean;

                string rootDir = String.Empty;

                string result = String.Empty;

                string fileName = string.Empty;

                Action action = () =>
                {
                    codeTemplate = null;
                    codeTemplate = codeTemplate ?? (javaCodeConfig.ForModel ? template.modelTemplate : null);
                    codeTemplate = codeTemplate ?? (javaCodeConfig.ForService ? template.serviceTemplate : null);
                    codeTemplate = codeTemplate ?? (javaCodeConfig.ForServiceImpl ? template.serviceImplTemplate : null);
                    codeTemplate = codeTemplate ?? (javaCodeConfig.ForController ? template.controllerTemplate : null);
                    if (codeTemplate == null)
                    {
                        Console.WriteLine("");
                    }



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

                if (javaCodeConfig.GeneralModel)
                {
                    javaCodeConfig.Reset();
                    javaCodeConfig.ForModel = true;
                    rootDir = CodeUtil.PrepareCodeRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ModelPackageName);
                    fileName = javaCodeConfig.ModelName;
                    action();
                }

                if (javaCodeConfig.GeneralService)
                {
                    javaCodeConfig.Reset();
                    javaCodeConfig.ForService = true;
                    rootDir = CodeUtil.PrepareCodeRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ServicePackageName);
                    fileName = javaCodeConfig.ServiceName;
                    action();
                }

                if (javaCodeConfig.GeneralServiceImpl)
                {
                    javaCodeConfig.Reset();
                    javaCodeConfig.ForServiceImpl = true;
                    rootDir = CodeUtil.PrepareCodeRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ServiceImplPackageName);
                    fileName = javaCodeConfig.ServiceImplName;
                    action();
                }

                if (javaCodeConfig.GeneralController)
                {
                    javaCodeConfig.Reset();
                    javaCodeConfig.ForController = true;
                    rootDir = CodeUtil.PrepareCodeRoot(javaCodeConfig.ModelJavaDiretory, javaCodeConfig.ControllerPackageName);
                    fileName = javaCodeConfig.ControllerName;
                    action();
                }

            }
        }


    }
}

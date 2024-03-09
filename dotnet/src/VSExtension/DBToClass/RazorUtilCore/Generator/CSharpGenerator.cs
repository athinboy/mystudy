using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Pipe.CSharp;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Generator
{

    public class CSharpTemplate
    {

        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<CSharpClass>> beanTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoModel>> daoTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperModel>> mapperTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> modelTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> serviceTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> serviceImplTemplate = null;
        public IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> controllerTemplate = null;

        internal CSharpTemplate Clone()
        {
            CSharpTemplate newTemplate = new CSharpTemplate();
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


    public class CSharpGenerator : GeneratorBase
    {

        private static string GetTemplateFilePath(string filename)
        {
            return Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + filename;
        }



        private static string javaBeanTemplateRelatePath = GetTemplateFilePath("JavaBean.cshtml");

        private static string javaDaoTemplateRelatePath = GetTemplateFilePath("JavaDao.cshtml");

        private static string javaMapperTemplateRelatePath = GetTemplateFilePath("JavaMapper.cshtml");

        private static string javaCodeTemplateRelatePath = GetTemplateFilePath("JavaCode.cshtml");

        static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();


        private IRazorEngine razorEngine = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<CSharpClass>> beanTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaDaoModel>> daoTemplate = null;
        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaMapperModel>> mapperTemplate = null;

        private IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaCodeConfig>> codeTemplate = null;


        private CSharpTemplate defaultTemplate = null;
        private ConcurrentDictionary<JavaCodeConfig, CSharpTemplate> templateCache = new ConcurrentDictionary<JavaCodeConfig, CSharpTemplate>();

        private CSharpTemplate GetTemplate(JavaCodeConfig javaCodeConfig)
        {
            initDefault();

            if (string.IsNullOrEmpty(javaCodeConfig.ServiceCodeTemplateFile)
                && string.IsNullOrEmpty(javaCodeConfig.ServiceImplCodeTemplateFile)
                && string.IsNullOrEmpty(javaCodeConfig.ControllerCodeTemplateFile))
            {
                return defaultTemplate;
            }

            CSharpTemplate template = templateCache[javaCodeConfig];
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
                    defaultTemplate = new CSharpTemplate();
                }
                else
                {
                    return;
                }

                razorEngine = new RazorEngine();

                beanTemplate = GetTemplate<CSharpClass>(javaBeanTemplateRelatePath);
                daoTemplate = GetTemplate<JavaDaoModel>(javaDaoTemplateRelatePath);
                mapperTemplate = GetTemplate<JavaMapperModel>(javaMapperTemplateRelatePath);

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


        public void GenerateBean(CSharpBeanModel beanConfig)
        {

            initDefault();

            //IRazorEngineCompiledTemplate template = razorEngine.Compile(templateContent);// "Hello @Model.Name");

            beanConfig.DDL.Prepare();



            string beanRootDir = CodeUtil.PrepareCodeRoot(beanConfig.CodeDiretory, beanConfig.NamespacePath);

            string result = string.Empty;
            beanConfig.DDL.Tables.ForEach(t =>
            {
                result = beanTemplate.Run(instance =>
                {
                    beanConfig.Table = t;
                    t.RelatedClsss = CSharpClass.CreateEntityClass(t, beanConfig, true);
                    instance.Model = t.RelatedClsss as CSharpClass;
                });
                Console.WriteLine(result);
                string filePath = beanRootDir + Path.DirectorySeparatorChar + t.RelatedClsss.ClassName + ".java";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));


                //result = beanTemplate.Run(instance =>
                //{
                //    instance.Model = t.CreatedClass.JavaVoClass;
                //});
                //Console.WriteLine(result);
                //filePath = voRootDir + Path.DirectorySeparatorChar + t.CreatedClass.JavaVoClass.ClassName + ".java";
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
                //File.WriteAllText(filePath, result, new UTF8Encoding(false));


            });




        }

        public void GenerateDao(JavaDaoModel javaDaoConfig, JavaMapperModel javaMapperConfig)
        {
            initDefault();


            string rootDir;
            string result = string.Empty;

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

        private void GenerateMapper(JavaMapperModel javaMapperConfig)
        {

            initDefault();

            string rootDir = javaMapperConfig.MapperDirectory;
            if (false == Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            string mapperDir = rootDir;
            string result = string.Empty;

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

        public override Work.Work CreateWork(GenerateConfig generateConfig)
        {
            
            CSharpWork cSharpWork=new CSharpWork(generateConfig);

            DBToDDLPipe dBToDDLPipe = new DBToDDLPipe();
            cSharpWork.InPipes.Add(dBToDDLPipe);

            CSharpBeanPipe cSharpBeanPipe = new CSharpBeanPipe();
            cSharpWork.OutPipes.Add(cSharpBeanPipe);

            return cSharpWork;
        }

        public override bool ValidateConfig()
        {
            throw new NotImplementedException();
        }
    }
}

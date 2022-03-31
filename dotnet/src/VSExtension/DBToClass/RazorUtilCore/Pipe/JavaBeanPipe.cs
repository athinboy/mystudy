using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class JavaBeanPipe : WorkPipeBaseT<JavaWorkModel, JavaClass>
    {



        public override void GenerateT(JavaWorkModel work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> template, JavaClass t)
        {

            JavaBeanModel javaBeanConfig = work.BeanConfig;

            string beanRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);

            JavaClass javaClass = t as JavaClass;

            string result = String.Empty;
            string filePath;
            if (javaClass.JavaBoClass == null)
            {
                result = template.Run(instance =>
                {
                    instance.Model = javaClass;
                });
                Console.WriteLine(result);
                filePath = beanRootDir + Path.DirectorySeparatorChar + javaClass.ClassName + ".java";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));
            }

            if (javaClass.JavaVoClass == null)
            {

                result = template.Run(instance =>
                {
                    instance.Model = javaClass;
                });
                Console.WriteLine(result);
                filePath = voRootDir + Path.DirectorySeparatorChar + javaClass.ClassName + ".java";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.WriteAllText(filePath, result, new UTF8Encoding(false));

            }



        }

        public override string getRazorFilePath(Work work)
        {
            return GenerateUtil.GetInternalTemplateFilePath("JavaBean.cshtml");
        }

        public override void PrePareModel(Work work, PipeBase pipe)
        {
            (work as JavaWorkModel).BeanConfig.DDLConfig.Prepare();
        }

        public override void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            base.AddTemplateReference(builder);


            builder.AddAssemblyReferenceByName("System.Collections");
            builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
            builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
        }

        public override IEnumerable<object> GetModels(Work work, PipeBase pipe)
        {
            JavaBeanModel javaBeanConfig = (work as JavaWorkModel).BeanConfig;

            List<ClassBase> models = new List<ClassBase>();

            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                javaBeanConfig.Table = t;
                t.RelatedClsss = JavaClass.CreateBoClass(t, javaBeanConfig, true);
                models.Add(t.RelatedClsss as JavaClass);
                models.Add((t.RelatedClsss as JavaClass).JavaVoClass);

            });

            return models;


        }
    }
}

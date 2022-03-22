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



        public override void Generate(JavaWorkModel work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> template)
        {

            JavaBeanConfig javaBeanConfig = work.BeanConfig;

            string beanRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);


            string result = String.Empty;
            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                result = template.Run(instance =>
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


                result = template.Run(instance =>
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

        public override string getRazorFilePath(JavaWorkModel work)
        {
            return JavaGenerator.GetTemplateFilePath("JavaBean.cshtml");
        }

        internal override void PrePareModel(JavaWorkModel work)
        {
            work.BeanConfig.DDLConfig.Prepare();
        }

        public override void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            base.AddTemplateReference(builder);


            builder.AddAssemblyReferenceByName("System.Collections");
            builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
            builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
        }

    }
}

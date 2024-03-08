using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Work;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe.Java
{
    public class JavaBeanPipe : TemplatePipeBaseT<JavaWork, JavaClass>
    {



        public override void GenerateT(JavaWork work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<JavaClass>> template, JavaClass t)
        {

            JavaBeanModel javaBeanConfig = work.BeanConfig;

            string beanRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
            string voRootDir = CodeUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);

            JavaClass javaClass = t as JavaClass;

            string result = string.Empty;
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
         
        public override void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            base.AddTemplateReference(builder);


            builder.AddAssemblyReferenceByName("System.Collections");
            builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
            builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
        }

    }
}

using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe.Java
{
	public class JavaBeanPipe<T, M> : TemplatePipeBaseT<JavaWork, T, M>
		where T : JavaBeanModel
		where M : BaseModel
	{



		public override void GenerateT(JavaWork work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T t)
		{

			JavaBeanModel javaBeanConfig = work.BeanConfig;

			string beanRootDir = Util.FileUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.PackageName);
			string voRootDir = Util.FileUtil.PrepareCodeRoot(javaBeanConfig.JavaDiretory, javaBeanConfig.VOPackageName);

			JavaClass javaClass = t as JavaClass;

			string result = string.Empty;
			string filePath;
			if (javaClass.JavaBoClass == null)
			{
				result = template.Run(instance =>
				{
					instance.Model = t;
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
					instance.Model = t;
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

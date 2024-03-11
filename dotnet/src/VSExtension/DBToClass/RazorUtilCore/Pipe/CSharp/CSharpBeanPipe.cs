using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe.CSharp
{
	public class CSharpBeanPipe : TemplatePipeBaseT<CSharpWork, CSharpBeanModel, BaseModel>
	{


		private const string fileSuffix = ".cs";

		public CSharpBeanPipe() : base()
		{

		}


		public override void GenerateT(CSharpWork work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<CSharpBeanModel>> template,
			CSharpBeanModel t)
		{

			CSharpBeanModel cSharpBeanModel = work.BeanConfig;

			string beanRootDir = CodeUtil.PrepareCodeRoot(cSharpBeanModel.CodeDiretory, cSharpBeanModel.NamespacePath);


			string result = string.Empty;
			string filePath;

			result = template.Run(instance =>
			{
				instance.Model = t;
			});
			filePath = beanRootDir + Path.DirectorySeparatorChar + t.CSharpClass.ClassName + fileSuffix;

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
			File.WriteAllText(filePath, result, new UTF8Encoding(false));




		}

		protected override string GetInternalTplFileName()
		{
			return "CSharpBean.cshtml";
		}

		public void PrePareModel(Work.Work work)
		{
			(work as JavaWork).BeanConfig.DDLConfig.Prepare();
			JavaBeanModel javaBeanConfig = (work as JavaWork).BeanConfig;

			List<ClassBase> models = new List<ClassBase>();

			javaBeanConfig.DDLConfig.EntityTables.ForEach(t =>
			{
				javaBeanConfig.Table = t;
				t.RelatedClsss = JavaClass.CreateBoClass(t, javaBeanConfig, true);
				models.Add(t.RelatedClsss as JavaClass);
				models.Add((t.RelatedClsss as JavaClass).JavaVoClass);

			});
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

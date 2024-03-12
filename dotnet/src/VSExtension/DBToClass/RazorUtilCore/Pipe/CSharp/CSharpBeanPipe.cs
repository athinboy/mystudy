using FluentValidation;
using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Config.CSharp;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe.CSharp
{
	public class CSharpBeanPipe<T, M> : TemplatePipeBaseT<CSharpWork, T, M>
		where T : CSharpBeanModel
		where M : BaseModel
	{

		protected CodeConfig _codeConfig = null;
		protected const string fileSuffix = ".cs";
		protected string CodeRootPath { get; set; }
		protected string FullNamespace { get; set; }
		protected string NamespacePath { get; set; }

		public CSharpBeanPipe() : base()
		{

		}



		public override void GenerateT(CSharpWork work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template,
			T beanModel)
		{


			string beanRootDir = Util.FileUtil.PrepareCodeRoot(beanModel.CodeDiretory, beanModel.NamespacePath);


			string result = string.Empty;
			string filePath;

			result = template.Run(instance =>
			{
				instance.Model = beanModel;
			});
			filePath = beanRootDir + Path.DirectorySeparatorChar + beanModel.CSharpClass.ClassName + fileSuffix;

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


		public override void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
		{
			base.AddTemplateReference(builder);


			builder.AddAssemblyReferenceByName("System.Collections");
			builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
			builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
		}


		public override void PrepareOutput(Work.Work work, M model)
		{
			base.PrepareOutput(work, model);
		}

		public override T ReceiptModel(Work.Work work, M model)
		{
			if (model is not EntityTableModel)
			{
				throw new ArgumentException(nameof(model));
			}
			CSharpClass cclass = CSharpClass.CreateEntityClass((model as EntityTableModel).Table, _codeConfig, _work.GenerateConfig);
			CSharpBeanModel beanModel = new CSharpBeanModel(work.DDLModel, cclass, CodeRootPath, FullNamespace, NamespacePath);
			return null;
		}

		public override void FinishOutput(Work.Work work, M model)
		{
			base.FinishOutput(work, model);
		}

		public override T PrepareVar(Work.Work work, M model)
		{

			CodeRootPath = _codeConfig.CSharpConfig.BeanConfig.ProjectRoot;
			CodeRootPath = Path.Combine(CodeRootPath, _codeConfig.CSharpConfig.BeanConfig.CodeRootRelation);
			FullNamespace = CSharpUtil.CombineNamespace(_codeConfig.CSharpConfig.NamespaceName, _codeConfig.CSharpConfig.BeanConfig.BeanNamespaceName);
			NamespacePath = CSharpUtil.GetNamespacePath(FullNamespace, _codeConfig.CSharpConfig.NamespacePathOmmit);

			return base.PrepareVar(work, model);
		}

		public override void DoOutput(Work.Work work, M model)
		{
			base.DoOutput(work, model);
		}

		public override void Init(Work.Work work)
		{
			base.Init(work);
			_codeConfig = work?.GenerateConfig?.CodeConfig;


			BeanConfigValidator beanConfigValidator = new BeanConfigValidator();
			beanConfigValidator.ValidateAndThrow(_codeConfig.CSharpConfig.BeanConfig);
		}


		protected class BeanConfigValidator : AbstractValidator<CSharpBeanConfig>
		{
			public BeanConfigValidator()
			{
				RuleFor(bc => bc.ProjectRoot).NotEmpty();

			}
		}
	}


}

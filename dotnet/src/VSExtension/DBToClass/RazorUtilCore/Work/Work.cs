using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using Org.FGQ.CodeGenerate.Pipe.CSharp;
using Org.FGQ.CodeGenerate.Pipe.Delegate;
using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Org.FGQ.CodeGenerate.Work
{


 

	public class Work
	{
		public Work(GenerateConfig generateConfig)
		{
			GenerateConfig = generateConfig;
 
		}

		public WareDDL DDLModel { get; set; }

		public List<IOutputPipe<BaseModel, BaseModel>> OutPipes { get; set; } = new List<IOutputPipe<BaseModel, BaseModel>>();

		public List<InputPipe> InPipes { get; set; } = new List<InputPipe> { };

		public WorkAction PrepareAction { get; set; } = null;

		public WorkAction1 PrepareModelAction { get; set; } = delegate (Work w)
		{

			List<BaseModel> models = new List<BaseModel>();
			foreach (var entityTable in w.DDLModel.EntityTables)
			{
				models.Add(new EntityTableModel(entityTable));
			}
			return models;
		};

		public GenerateConfig GenerateConfig { get; protected set; }

		internal List<BaseModel> PrepareModel()
		{
			if (DDLModel == null)
			{
				throw new Exception("DDL is null");
			}

			if (PrepareModelAction != null)
			{
				return PrepareModelAction(this);
			}
			else
			{
				throw new ArgumentNullException(nameof(PrepareModelAction));
			}

		}

		internal void Prepare()
		{
			bool? vr = GenerateConfig.Validate();
			if ((vr ?? false) == false)
			{
				throw new Exception("config has some wrong！");
			}
			if (PrepareAction != null)
			{
				PrepareAction(this);
			}
		}
	}
}

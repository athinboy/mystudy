using FluentValidation;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Util.DB;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Org.FGQ.CodeGenerate.Pipe
{
	/// <summary>
	///  load db to ddl .
	/// </summary>
	public class DBToDDLPipe : InputPipe
	{
		protected DBConfig dBConfig = null;
		public DBToDDLPipe() : base()
		{

		}

		public override void Finish()
		{
			base.Finish();
		}

		public override void Input()
		{
			DB db = LoadDBMeta();
			if (db == null)
			{
				return;
			}
			List<Util.DB.Table> tables = db.Tables.FindAll(x =>
			x.TableName.StartsWith(_work.GenerateConfig.TableNameFilter) || Regex.IsMatch(x.TableName, _work.GenerateConfig.TableNameFilter));
			if (tables.Count == 0)
			{
				return;
			}
			WareDDL ddlModel = new WareDDL();
			EntityTable newtable;
			FieldColumn Column;
			foreach (var table in tables)
			{
				newtable = new EntityTable(db.DBName, table.TableName, table.Comment);
				ddlModel.EntityTables.Add(newtable);
				foreach (var column in table.Columns)
				{
					Column = new FieldColumn(column.Comment, column.ColName, column.ColumnType);
					newtable.FieldColumns.Add(Column);

				}
			}
			_work.WareDDL = ddlModel;
		}

		public override void PrepareInput()
		{
			base.PrepareInput();
		}

		public override void PrepareVar(Work.Work work)
		{
			base.PrepareVar(work);


		}

		public override void Init(Work.Work work)
		{
			base.Init(work);

			dBConfig = work.GenerateConfig.DBConfig ?? new DBConfig();
			BeanConfigValidator beanConfigValidator = new BeanConfigValidator();
			beanConfigValidator.ValidateAndThrow(dBConfig);
		}

		protected class BeanConfigValidator : AbstractValidator<DBConfig>
		{
			public BeanConfigValidator()
			{
				RuleFor(bc => bc.DataBaseName).NotEmpty();
				RuleFor(bc => bc.MySqlDBConfig).NotNull().SetValidator(new MysqlDBConfigValidator());
			}
		}
		protected class MysqlDBConfigValidator : AbstractValidator<MySqlDBConfig>
		{
			public MysqlDBConfigValidator()
			{


				RuleFor(bc => bc.Pwd).NotEmpty();
				RuleFor(bc => bc.UserId).NotEmpty();
				RuleFor(bc => bc.Port).NotNull().NotEmpty();
				RuleFor(bc => bc.Server).NotEmpty();
				 

			}
		}



		internal DB LoadDBMeta()
		{

			// https://learn.microsoft.com/zh-CN/dotnet/csharp/language-reference/preprocessor-directives
#if (NET)
			MySqlDBConfig mySqlDBConfig = _work.GenerateConfig.DBConfig?.MySqlDBConfig ?? throw new ArgumentNullException(nameof(_work.GenerateConfig.DBConfig));
#else
            MySqlDBConfig mySqlDBConfig = generateConfig.dbConfig?.MySqlDBConfig ?? throw new ArgumentNullException(nameof(generateConfig.dbConfig));
#endif



			MySqlUtil mySqlUtil = MySqlUtil.GetOne(mySqlDBConfig.Server, mySqlDBConfig.Port, mySqlDBConfig.UserId, mySqlDBConfig.Pwd);
			List<DB> dbs = mySqlUtil.LoadMeta();
			return dbs.Find(x => x.DBName == _work.GenerateConfig.DBConfig.DataBaseName);
		}

	}
}

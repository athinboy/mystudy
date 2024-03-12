using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Util.Code;
using System;

namespace Org.FGQ.CodeGenerate.Code
{
	public class CSharpClass : ClassBase
	{


		public CSharpClass(string namespaceName, EntityTable Table) : base(namespaceName, Table)
		{

		}


		protected static new string GetFildTypeStr(FieldBase filedBase)
		{
			switch (filedBase.FieldType)
			{
				case FieldTypes.String:
					return "String";
				case FieldTypes.Decimal:
					return "BigDecimal";
				case FieldTypes.Int32:
					return "Integer";
				case FieldTypes.Long:
					return "Long";
				case FieldTypes.Float:
					return "Float";
				case FieldTypes.Double:
					return "Double";
				case FieldTypes.DateTime:
					return "Date";
				case FieldTypes.Bool:
					return "Boolean";
				default:
					throw new ArgumentException(nameof(filedBase.FieldType));
			}
		}

		public static CSharpClass CreateEntityClass(EntityTable table, CodeConfig codeConfig,GenerateConfig generateConfig)
		{

			CSharpClass cSharpClass = new CSharpClass(codeConfig.CSharpConfig.NamespaceName, table);



			table.FieldColumns.ForEach(c =>
			{
				if (false == c.Validate())
				{
					return;
				}
				FieldBase filedBase;
				cSharpClass.Fields.Add(filedBase = FieldBase.Create(c));
				filedBase.FiledTypeStr = GetFildTypeStr(filedBase);


			});

			cSharpClass.Desc = table.Desc;

			cSharpClass.ClassName = table.ClassName.Length == 0 ? CodeUtil.GetClassName(generateConfig, table.TableName) : table.ClassName;

			return cSharpClass;
		}
	}
}

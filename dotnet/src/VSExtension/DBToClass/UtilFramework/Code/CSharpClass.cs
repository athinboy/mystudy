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
				case FieldDataTypes.String:
					return "String";
				case FieldDataTypes.Decimal:
					return "BigDecimal";
				case FieldDataTypes.Int32:
					return "Integer";
				case FieldDataTypes.Long:
					return "Long";
				case FieldDataTypes.Float:
					return "Float";
				case FieldDataTypes.Double:
					return "Double";
				case FieldDataTypes.DateTime:
					return "Date";
				case FieldDataTypes.Bool:
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

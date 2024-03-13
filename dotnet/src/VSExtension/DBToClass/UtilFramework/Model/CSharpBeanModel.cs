
using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Model.DDL;
using System;

namespace Org.FGQ.CodeGenerate.Model
{
	public class CSharpBeanModel : EntityModel
	{
		public CSharpBeanModel(WareDDL wareDDL, CSharpClass cSharpClass, string codeDiretory, string classNameSpace, string namespacePath)
		{
			WareDDL = wareDDL ?? throw new ArgumentNullException(nameof(wareDDL));
			CSharpClass = cSharpClass ?? throw new ArgumentNullException(nameof(cSharpClass));
			CodeDiretory = codeDiretory ?? throw new ArgumentNullException(nameof(codeDiretory));
			NamespacePath = namespacePath ?? throw new ArgumentNullException(nameof(namespacePath));
			FullNamespace = classNameSpace ?? throw new ArgumentNullException(nameof(classNameSpace));
		}

		public WareDDL WareDDL { get; private set; }

		public CSharpClass CSharpClass { get; set; }

		public string CodeDiretory { get; set; }

		/// <summary>
		/// 
		/// for example:  
		/// namespace :System.Xml.Serialize 
		/// NamespacePath:xml.serialize;
		/// </summary>
		public string NamespacePath { get; set; }
		public string FullNamespace { get; private set; }
	}
}

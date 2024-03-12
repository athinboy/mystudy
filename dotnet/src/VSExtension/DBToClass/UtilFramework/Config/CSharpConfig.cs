using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config.CSharp
{

	/// <summary>
	/// 
	/// </summary>
	public class CSharpConfig : ConfigBase
	{

		/// <summary>
		/// namespace(c++,c#) 
		/// </summary>
		public string NamespaceName { get; set; } = "";

		/// <summary>
		/// NamespaceName:System.Xml.Serialize;
		/// NamespacePathOmmit: System;
		/// CodePath:xml/serialize ;
		/// </summary>    
		public string NamespacePathOmmit { get; set; } = "";

		/// <summary>
		/// whether to change  code path to lower case ?
		/// </summary>
		public bool NamespacePathLowerCase { get; set; } = true;

		public CSharpBeanConfig BeanConfig { get; set; }

		public override bool Validate()
		{

			bool? v = BeanConfig?.Validate();
			if (string.IsNullOrEmpty(NamespaceName))
			{
				throw new ArgumentException(nameof(NamespaceName));
			}
			if (string.IsNullOrEmpty(NamespaceName))
			{
				throw new ArgumentException(nameof(NamespaceName));
			}
			return v ?? true;
		}


	}

	public class CSharpBeanConfig : ConfigBase
	{
		/// <summary>
		///  
		/// </summary>
		public string BeanNamespaceName { get; set; } = "Bean";

		public string ProjectRoot { get; set; }

		/// <summary>
		/// the relation path between  the code root path  and the project root;
		/// <seealso cref="ProjectRoot"/>
		/// </summary>
		public string CodeRootRelation { get; set; }

		public override bool Validate()
		{
			bool? v = base.Validate();
			return v ?? true;
		}
	}
}

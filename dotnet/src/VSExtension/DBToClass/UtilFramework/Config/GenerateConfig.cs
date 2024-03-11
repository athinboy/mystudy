using System;

namespace Org.FGQ.CodeGenerate.Config
{
	public class GenerateConfig : ConfigBase
	{

		public DBConfig DBConfig { get; set; } = new DBConfig();

		public CodeConfig CodeConfig { get; set; } = new CodeConfig();


		/// <summary>
		/// table name filter,
		/// 1.prefix of table names.
		/// 2.the regular express of.
		/// </summary>
		public string TableNameFilter { get; set; } = string.Empty;

		public GenerateMode Mode { get; set; } = GenerateMode.DBToCode;


		public override bool Validate()
		{

			bool? v = DBConfig?.Validate();
			v = CodeConfig.Validate();
			return v ?? true;
		}

	}
	/// <summary>
	/// 
	/// </summary>
	public class DBConfig : ConfigBase
	{

		public string DataBaseName { get; set; }
		public MySqlDBConfig MySqlDBConfig { get; set; } = null;

		public override bool Validate()
		{
			bool? v = MySqlDBConfig?.Validate();
			if (string.IsNullOrEmpty(DataBaseName))
			{
				throw new ArgumentException(nameof(DataBaseName));
			}
			return v ?? true;

		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CodeConfig : ConfigBase
	{


		public CSharpConfig CSharpConfig { get; set; } = null;

		public JavaConfig JavaConfig { get; set; } = null;

	}

	/// <summary>
	/// 
	/// </summary>
	public class JavaConfig : ConfigBase
	{
		/// <summary>
		///  packagename
		/// </summary>
		public string PackageName { get; set; } = "";
	}

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
	}

}

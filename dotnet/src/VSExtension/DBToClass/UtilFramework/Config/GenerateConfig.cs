using System;
using Org.FGQ.CodeGenerate.Config.CSharp;
namespace Org.FGQ.CodeGenerate.Config
{
	public class GenerateConfig : ConfigBase
	{

		public DBConfig DBConfig { get; set; } = new DBConfig();

		public CodeConfig CodeConfig { get; set; } = new CodeConfig();

		/// <summary>
		/// perfix that should to ommit,a string separated by commas
		/// like: order,user,
		/// </summary>
		public string OmmitPrefix { get; set; } = string.Empty;

		/// <summary>
		/// Regex string without ^ $ .
		/// </summary>
		public string TableNameRegex { get; set; } = string.Empty;


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
 
			return  true;

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



}

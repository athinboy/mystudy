namespace Org.FGQ.CodeGenerate.Config
{
    public class GenerateConfig
    {

        public DBConfig dbConfig { get; set; } = new DBConfig();

        public CodeConfig codeConfig { get; set; } = new CodeConfig();


        /// <summary>
        /// table name filter,
        /// 1.prefix of table names.
        /// 2.the regular express of.
        /// </summary>
        public string TableNameFilter { get; set; } = string.Empty;

        public GenerateMode Mode { get; set; } = GenerateMode.DBToCode;
    }
    /// <summary>
    /// 
    /// </summary>
    public class DBConfig
    {

        public string DataBaseName { get; set; }
        public MySqlDBConfig MySqlDBConfig { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class CodeConfig
    {


        public CSharpConfig CSharpConfig { get; set; } = null;

        public JavaConfig JavaConfig { get; set; } = null;

    }

    /// <summary>
    /// 
    /// </summary>
    public class JavaConfig
    {
        /// <summary>
        ///  packagename
        /// </summary>
        public string PackageName { get; set; } = "";
    }

    /// <summary>
    /// 
    /// </summary>
    public class CSharpConfig
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

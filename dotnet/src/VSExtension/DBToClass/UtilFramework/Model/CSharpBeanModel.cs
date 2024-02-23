namespace Org.FGQ.CodeGenerate.Config
{
    public class CSharpBeanModel : EntityModel
    {
        public DDLModel DDLConfig { get; set; }

        

        public string CodeDiretory { get; set; }

        /// <summary>
        /// for example:
        /// System.Xml.Serialize;
        /// </summary>
        /// <seealso cref="NamespacePath"/>
        public string NamespaceName { get; set; }

        /// <summary>
        /// for example: 
        /// xml.serialize;
        /// </summary>
        public string NamespacePath { get; set; }
    }
}

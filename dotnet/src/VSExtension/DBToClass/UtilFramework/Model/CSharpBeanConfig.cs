namespace Org.FGQ.CodeGenerate.Config
{
    public class CSharpBeanConfig : EntityModel
    {
        public DDLModel DDLConfig { get; set; }
        public string NamespaceName { get; set; }        
        public string CodeDiretory { get; set; }
        public string NamespacePath { get; set; }
    }
}

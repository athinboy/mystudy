namespace Org.FGQ.CodeGenerate.Config
{
    public class CSharpBeanConfig : BeanConfig
    {
        public DDLConfig DDLConfig { get; set; }
        public string NamespaceName { get; set; }
        public string OmmitPrefix { get; set; }
        public string CodeDiretory { get; set; }
        public string NamespacePath { get; set; }
    }
}

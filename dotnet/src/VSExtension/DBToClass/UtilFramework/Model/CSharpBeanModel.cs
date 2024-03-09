
using Org.FGQ.CodeGenerate.Model.DDL;

namespace Org.FGQ.CodeGenerate.Model
{
    public class CSharpBeanModel : EntityModel
    {
        public WareDDL DDL { get; set; }

        

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

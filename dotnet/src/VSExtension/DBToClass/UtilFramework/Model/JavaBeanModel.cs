using Org.FGQ.CodeGenerate.Util.Code;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;

namespace Org.FGQ.CodeGenerate.Model
{
    public class JavaBeanModel : JavaModel
    {

        public WareDDL DDLConfig { get; set; }


        public EntityTable Table { get; set; }
        public ClassBase ClassBase { get; set; }
        public string VOPackageName { get; set; }
    }
}

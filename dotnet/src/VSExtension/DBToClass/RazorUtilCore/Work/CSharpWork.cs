using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;

namespace Org.FGQ.CodeGenerate.Work
{
    public class CSharpWork : Work
    {
        public CSharpWork(GenerateConfig generateConfig):base(generateConfig)
        {
             
        }

        public CSharpBeanModel BeanConfig { get; internal set; }
       
    }
}

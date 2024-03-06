using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Generator;

namespace Org.FGQ.CodeGenerate.Dispatch
{

    public class DefaultDispatch : DispatchBase
    {

        void DispatchBase.Dispatch(GenerateConfig generateConfig)
        {
            
           

            if (generateConfig.codeConfig.CSharpConfig != null)
            {
                CSharpGenerator cSharpGenerator = new CSharpGenerator();
                cSharpGenerator.Generate(generateConfig);

            }
        }
    }
}

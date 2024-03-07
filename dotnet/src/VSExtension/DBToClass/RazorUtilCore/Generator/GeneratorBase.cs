using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Work;

namespace Org.FGQ.CodeGenerate.Generator
{
    public abstract class GeneratorBase
    {
        public abstract bool ValidateConfig();

        public abstract Work.Work CreateWork(GenerateConfig generateConfig);
    }
}

using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public delegate Object CodeGenerateAction(Work work);


    public delegate IEnumerable<object> CodeGenerateAction2(Work work);

    public delegate void AddTemplateReferenceAction(IRazorEngineCompilationOptionsBuilder builder);

}

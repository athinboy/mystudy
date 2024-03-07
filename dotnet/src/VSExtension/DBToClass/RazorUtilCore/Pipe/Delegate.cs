using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe.Delegate
{

    public delegate Object Action(Work.Work work, PipeBase pipe);

    public delegate IEnumerable<object> Action2(Work.Work work, PipeBase p);

    public delegate void Action3(Work.Work work, PipeBase pipe);

    public delegate void Action4(Work.Work work, PipeBase pipe,Object model);

    public delegate void AddTemplateReferenceAction(IRazorEngineCompilationOptionsBuilder builder);

    public delegate void WorkAction(Work.Work work);



}

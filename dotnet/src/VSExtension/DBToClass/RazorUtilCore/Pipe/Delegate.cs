﻿using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public delegate Object CodeGenerateAction(Work.Work work,PipeBase pipe);


    public delegate IEnumerable<object> CodeGenerateAction2(Work.Work work, PipeBase p);

    public delegate void CodeGenerateAction3(Work.Work work, PipeBase pipe);

    public delegate void CodeGenerateAction4(Work.Work work, PipeBase pipe,Object model);

    public delegate void AddTemplateReferenceAction(IRazorEngineCompilationOptionsBuilder builder);

    public delegate void WorkAction(Work.Work work);



}

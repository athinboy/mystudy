using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using RazorEngineCore;
using System;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe.Delegate
{

	public delegate Object Action(Work.Work work, PipeBase pipe);

	public delegate IEnumerable<object> Action2(Work.Work work, PipeBase p);

	public delegate void Action3(Work.Work work, PipeBase pipe);

	public delegate BaseModel Action4(Work.Work work, PipeBase pipe, BaseModel model);

	public delegate T Action4T<out T, in M>(Work.Work work, PipeBase pipe, M model) where M : BaseModel where T : BaseModel;

	public delegate void AddTemplateReferenceAction(IRazorEngineCompilationOptionsBuilder builder);

	public delegate void WorkAction(Work.Work work);

	public delegate List<BaseModel> WorkAction1(Work.Work work);


}

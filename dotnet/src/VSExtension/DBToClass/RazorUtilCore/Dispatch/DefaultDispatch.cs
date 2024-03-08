using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Pipe;
using System.Collections.Generic;


namespace Org.FGQ.CodeGenerate.Dispatch
{

    public class DefaultDispatch : DispatchBase
    {

        void DispatchBase.Dispatch(GenerateConfig generateConfig)
        {
            if (generateConfig.codeConfig.CSharpConfig != null)
            {
                CSharpGenerator cSharpGenerator = new CSharpGenerator();
                Work.Work work = cSharpGenerator.CreateWork(generateConfig);
                DispathWork(work);
            }
        }

        public static void DispathWork(Work.Work work)
        {
            work.Prepare();
            List<OutputPipe> outpipes = work.OutPipes;
            List<InputPipe> inpipes = work.InPipes;
            foreach (InputPipe inpipe in inpipes)
            {
                inpipe.Init(work);
                inpipe.PrepareVar(work);
                inpipe.PrepareInput();
                inpipe.Input();
                inpipe.Finish();
            }
            List<BaseModel> models = work.GetModel();
            foreach (var model in models)
            {
                BaseModel currentBox = model;
                foreach (OutputPipe outpipe in outpipes)
                {
                    outpipe.Init(work);
                    currentBox = outpipe.PrepareVar(work, model);
                    currentBox = outpipe.PrepareModel(work, model);
                    outpipe.PrepareOutput(work, model);
                    outpipe.DoOutput(work, model);
                    outpipe.FinishOutput(work, model);

                }
            }


        }
    }
}

using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using System.Collections.Generic;
using System.Reflection;


namespace Org.FGQ.CodeGenerate.Dispatch
{

    public class DefaultDispatch : DispatchBase
    {

        void DispatchBase.Dispatch(GenerateConfig generateConfig)
        {
            if (generateConfig.CodeConfig.CSharpConfig != null)
            {
                CSharpGenerator cSharpGenerator = new CSharpGenerator();
                Work.Work work = cSharpGenerator.CreateWork(generateConfig);
                DispathWork(work);
            }
        }

        public static void DispathWork(Work.Work work)
        {
            work.Prepare();
            List<IOutputPipe<BaseModel,BaseModel>> outpipes = work.OutPipes;
            List<InputPipe> inpipes = work.InPipes;
            foreach (InputPipe inpipe in inpipes)
            {
                inpipe.Init(work);
                inpipe.PrepareVar(work);
                inpipe.PrepareInput();
                inpipe.Input();
                inpipe.Finish();
            }
            List<BaseModel> models = work.PrepareModel();

			foreach (IOutputPipe<BaseModel, BaseModel> outpipe in outpipes)
			{
				outpipe.Init(work);
			}

			foreach (BaseModel model in models)
            {
                BaseModel currentBox = model;
                foreach (IOutputPipe<BaseModel, BaseModel> outpipe in outpipes)
                {                     
                    currentBox = outpipe.PrepareVar(work, model);
                    currentBox = outpipe.ReceiptModel(work, model);
                    outpipe.PrepareOutput(work, model);
                    outpipe.DoOutput(work, model);
                    outpipe.FinishOutput(work, model);

                }
            }


        }
    }
}

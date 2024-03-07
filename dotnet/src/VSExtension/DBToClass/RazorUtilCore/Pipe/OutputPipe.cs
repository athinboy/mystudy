using Org.FGQ.CodeGenerate.Pipe.Delegate;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class OutputPipe : PipeBase
    {

        protected OutputPipe()
        {

        }

        public string OutputPath { get; set; }

        public string RazorTplFilePath { get; set; }

        public Action2 GetModelsAction { get; set; } = null;
        public Action3 PrepareModelAction { get; set; } = null;


        public Action4 BeforeEachModelAction { get; set; } = null;

        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null;

        public abstract string getRazorFilePath(Work.Work work);

        public Action PickCurrent { get; set; }

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            builder.AddAssemblyReferenceByName("System.Collections");

            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public abstract void PrePareModel(Work.Work work, PipeBase pipe);

        public virtual IEnumerable<object> GetModels(Work.Work work)
        {
            if (GetModelsAction != null)
            {
                return GetModelsAction(work, this);
            }
            else
            {
                return null;
            }

        }

        internal abstract object PrepareTemplate(IRazorEngine razorEngine, string templateContent);

        public virtual void BeforeEachModel(Work.Work work, object t)
        {
            if (BeforeEachModelAction != null)
            {
                BeforeEachModelAction(work, this, t);
            }
        }







    }
}

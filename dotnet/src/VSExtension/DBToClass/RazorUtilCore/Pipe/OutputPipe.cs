using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.Collections.Generic;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class OutputPipe:PipeBase
    {

        protected OutputPipe()
        {

        }

        public string OutputPath { get; set; }

        public string RazorTplFilePath { get; set; }

        public CodeGenerateAction2 GetModelsAction { get; set; } = null;
        public CodeGenerateAction3 PrepareModelAction { get; set; } = null;

        public CodeGenerateAction3 PrepareVarAction { get; set; } = null;
        public CodeGenerateAction4 BeforeEachModelAction { get; set; } = null;

        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null;

        public abstract string getRazorFilePath(Work.Work work);

        public CodeGenerateAction PickCurrent { get; set; }

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            builder.AddAssemblyReferenceByName("System.Collections");

            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public abstract void PrePareModel(Work.Work work, PipeBase pipe);

        public virtual IEnumerable<object> GetModels(Work.Work work, PipeBase pipe)
        {
            if (GetModelsAction != null)
            {
                return GetModelsAction(work, pipe);
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

   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="work"></param>
        /// <param name="pipe"></param>
        /// <remarks>子类都需要调用基类的此方法。</remarks>
        public virtual void PrepareVar(Work.Work work, PipeBase pipe)
        {
            if (PrepareVarAction != null)
            {
                PrepareVarAction(work, pipe);
            }
        }

 

    }
}

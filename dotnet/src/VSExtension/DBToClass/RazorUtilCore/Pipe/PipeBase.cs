using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{

    public abstract class PipeBase
    {



        protected PipeBase()
        {

        }

        public string OutputPath { get; set; }

        public string RazorTplFilePath { get; set; }

        public CodeGenerateAction2 GetModelsAction { get; set; } = null;
        public CodeGenerateAction3 PrepareModelAction { get; set; } = null;

        public CodeGenerateAction3 PrepareVarAction { get; set; } = null;

        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null;

        public abstract string getRazorFilePath(Work work);

        public CodeGenerateAction PickCurrent { get; set; }

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            builder.AddAssemblyReferenceByName("System.Collections");

            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public abstract void PrePareModel(Work work, PipeBase pipe);

        public virtual IEnumerable<object> GetModels(Work work, PipeBase pipe)
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

        public abstract void Generate(Work work, object template, object t);

        public virtual void PrepareVar(Work work, PipeBase pipe)
        {
            if (PrepareVarAction != null)
            {
                PrepareVarAction(work, pipe);
            }
        }



    }
}

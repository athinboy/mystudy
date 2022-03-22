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

        public string OutputPath { get; protected set; }

        public string RazorTplFilePath { get; protected set; }

        public CodeGenerateAction2 GetModelsAction { get; set; } = null;

        public AddTemplateReferenceAction AddTemplateReferenceFunc { get; set; } = null; 

        public CodeGenerateAction PickCurrent { get; set; }         

        public virtual void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            
            if (AddTemplateReferenceFunc != null)
            {
                AddTemplateReferenceFunc(builder);
            }
        }

        public virtual IEnumerable<object> GetModels(Work work)
        {
            if (GetModelsAction != null)
            {
                return GetModelsAction(work);
            }
            else
            {
                throw new ArgumentException(nameof(GetModelsAction));
            }

        }
    }
}

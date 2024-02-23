using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Util;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class DefaultPipe<T> : WorkPipeBaseT<Work, T>
    {

        public DefaultPipe(string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {

        }

        public DefaultPipe() : base()
        {
        }

        public override void GenerateT(Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T w)
        {
            string result = "";
            if (string.IsNullOrWhiteSpace(OutputPath))
            {
                throw new CodeGenerateException("OutputPath为空！");
            }

            result += template.Run(x =>
            {
                x.Model = w;                

            });

            Util.FileUtil.PrepareDirectory(OutputPath);
            if (File.Exists(OutputPath))
            {
                File.Delete(OutputPath);
            }
            File.AppendAllText(OutputPath, result, new UTF8Encoding(false));
        }

        public override string getRazorFilePath(Work work)
        {
            return RazorTplFilePath;
        }

        public override void PrePareModel(Work work, PipeBase pipe)
        {
            if (PrepareModelAction != null)
            {
                PrepareModelAction(work, pipe);
            }
        }

        public override void PrepareVar(Work work, PipeBase pipe)
        {
            base.PrepareVar(work, pipe);
        }
    }
}

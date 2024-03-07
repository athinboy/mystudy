using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class DefaultFilePipe<T> : WorkPipeBaseT<Work.Work, T>
    {

        public DefaultFilePipe(string templatefilepath, string outputPath) : base(templatefilepath, outputPath)
        {

        }

        public DefaultFilePipe() : base()
        {
        }

        public override void GenerateT(Work.Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<T>> template, T w)
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

        public override string getRazorFilePath(Work.Work work)
        {
            return RazorTplFilePath;
        }

        public override void PrePareModel(Work.Work work, PipeBase pipe)
        {
            if (PrepareModelAction != null)
            {
                PrepareModelAction(work, pipe);
            }
        }

        public override void PrepareVar(Work.Work work)
        {
            base.PrepareVar(work);
        }
    }
}

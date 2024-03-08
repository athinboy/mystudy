using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Exceptions;
using Org.FGQ.CodeGenerate.Work;
using RazorEngineCore;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class DefaultFilePipe<T> : TemplatePipeBaseT<Work.Work, T> where T : BaseModel
    {

        public DefaultFilePipe( string templatefilepath, string outputPath) : base( templatefilepath, outputPath)
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

 

         
    }
}

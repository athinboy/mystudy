using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Work;
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
    /// <summary>
    ///  the pipe to  generate sql .
    /// </summary>
    public class SQLWorkPipe : WorkPipeBaseT<Work.Work, DDLTable>
    {

        private static string templateOracleRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "OracleDDL.cshtml";
        private static string templateMysqlRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "MysqlDDL.cshtml";


        public SQLWorkPipe(string outputPath) : base()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
        }

        public override IEnumerable<object> GetModels(Work.Work work, PipeBase pipe)
        {
            return work.ddlModel.Tables;
        }

        public override void GenerateT(Work.Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTable>> template, DDLTable table)
        {
            string result = "";

            result += template.Run(x =>
               {
                   x.Model = table;

               });

            Util.FileUtil.PrepareDirectory(OutputPath);
            File.AppendAllText(OutputPath, result, new UTF8Encoding(false));

        }


        public override string getRazorFilePath(Work.Work work)
        {
            string templateRelatePath = string.Empty;
            switch (work.ddlModel.MyDBType)
            {
                case DDLModel.DBType.MySql:
                    templateRelatePath = templateMysqlRelatePath;
                    break;
                case DDLModel.DBType.Oracle:
                    templateRelatePath = templateOracleRelatePath;
                    break;
                default:
                    throw new ArgumentNullException(nameof(work.ddlModel.MyDBType));
            }


            string templatePath = Environment.CurrentDirectory + templateRelatePath;
            return templatePath;
        }

        public override void PrePareModel(Work.Work work, PipeBase pipe)
        {
            work.ddlModel.Prepare();
        }

        public override void PrepareVar(Work.Work work, PipeBase pipe)
        {
            base.PrepareVar(work, pipe);
            if (File.Exists(OutputPath))
            {
                File.Delete(OutputPath);
            }
        }
    }
}

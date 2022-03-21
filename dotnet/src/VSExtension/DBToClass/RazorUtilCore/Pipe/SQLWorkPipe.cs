using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Pipe
{
    public class SQLWorkPipe: WorkPipeBase<Work, Work> 
    {

        private static string templateOracleRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "OracleDDL.cshtml";
        private static string templateMysqlRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "MysqlDDL.cshtml";


        public SQLWorkPipe(string outputPath) : base()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
        }


        public override void Generate(Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<Work>> template)
        {
            string result = "";
            work.ddlModel.Tables.ForEach(t =>
            {

                work.CurrentTable = t;

                result += template.Run(x =>
                   {
                       x.Model = work;

                   });

            });

            if (File.Exists(OutputPath))
            {
                File.Delete(OutputPath);
            }

            File.WriteAllText(OutputPath, result, new UTF8Encoding(false));


        }


        public override string getRazorFilePath(Work work)
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

        internal override void PrePareModel(Work work)
        {
            work.ddlModel.Prepare();
        }
    }
}

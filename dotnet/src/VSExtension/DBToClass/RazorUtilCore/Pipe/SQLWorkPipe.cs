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
using Org.FGQ.CodeGenerate.Model;

namespace Org.FGQ.CodeGenerate.Pipe
{
    /// <summary>
    ///  the pipe to  generate sql .
    /// </summary>
    public class SQLWorkPipe : TemplatePipeBaseT<Work.Work, DDLTableModel>
    {

        private static string templateOracleRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "OracleDDL.cshtml";
        private static string templateMysqlRelatePath = System.IO.Path.DirectorySeparatorChar + "template" + System.IO.Path.DirectorySeparatorChar + "MysqlDDL.cshtml";


        public SQLWorkPipe(string outputPath) : base()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
        }

        protected override string GetInternalTplFileName()
        {
            return null;
        }

        internal override void Init(Work.Work work)
        {
            base.Init(work);
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
            RazorTplFilePath = templatePath;

        }

        public override void GenerateT(Work.Work work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<DDLTableModel>> template, DDLTableModel model)
        {
            string result = "";

            result += template.Run(x =>
               {
                   x.Model = model;

               });

            Util.FileUtil.PrepareDirectory(OutputPath);
            File.AppendAllText(OutputPath, result, new UTF8Encoding(false));

        }




        public override BaseModel PrepareModel(Work.Work work, BaseModel model)
        {
            work.ddlModel.Prepare();
            return model;
        }

        internal override BaseModel PrepareVar(Work.Work work, BaseModel model)
        {
            base.PrepareVar(work, model);
            if (File.Exists(OutputPath))
            {
                File.Delete(OutputPath);
            }
            return model;
        }
    }
}

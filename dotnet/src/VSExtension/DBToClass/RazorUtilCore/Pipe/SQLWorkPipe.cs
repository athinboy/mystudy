using Org.FGQ.CodeGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Engine
{
    public class SQLWorkPipe : WorkPipeBase
    {
        public SQLWorkPipe(string outputPath) : base()
        {
            OutputPath = (string.IsNullOrEmpty(outputPath) ? null : outputPath) ?? throw new ArgumentNullException(nameof(outputPath));
        }


        public override void Generate(Work work)
        {
            DDLToSQL ddlToSql = new DDLToSQL();

            ddlToSql.GenerateSql(work.ddlModel, this.OutputPath);

        }


        public override string getRazorFilePath(Work work)
        {
            throw new NotImplementedException();
        }
    }
}

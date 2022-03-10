using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.FGQ.CodeGenerate.Util.Code;

namespace Org.FGQ.CodeGenerate.Model
{
    public class Work
    {

        /// <summary>
        /// whether to generate DB table create sql.
        /// </summary>
        public bool GenerateDBTableSQL { get; set; }=true;

        public DDLModel ddlModel { get; set; }

    }
}

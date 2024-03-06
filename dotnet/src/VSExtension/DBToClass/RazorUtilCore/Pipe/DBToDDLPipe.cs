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
    ///  load db to ddl .
    /// </summary>
    public class DBToDDLPipe : InputPipe
    {

        public DBToDDLPipe() : base()
        {

        }

        public override void Generate(Work.Work work, object template, object t)
        {
            throw new NotImplementedException();
        }
    }
}

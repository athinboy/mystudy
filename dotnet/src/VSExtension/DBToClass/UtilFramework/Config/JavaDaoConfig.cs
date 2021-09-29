using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
    public class JavaDaoConfig : JavaConfigBase
    {
        private bool splitReadWrite = true;

        public bool SplitReadWrite
        {
            get { return splitReadWrite; }
            set
            {
                splitReadWrite = value;
                if (!value)
                {
                    ForRead = true;
                    ForWrite = true;

                }
            }
        }

        public bool ForRead { get; set; } = true;
        public bool ForWrite { get; set; } = true;

        public string DaoPackageName
        {
            get
            {
                if (SplitReadWrite && ForRead)
                {
                    return this.PackageName + ".read";
                }
                if (SplitReadWrite && ForWrite)
                {
                    return this.PackageName + ".write";
                }
                return this.PackageName;
            }
        }



        public string DaoName
        {
            get
            {

                if (SplitReadWrite && ForRead)
                {
                    return this.JavaClass.ClassName + "ReadDao";
                }
                if (SplitReadWrite && ForWrite)
                {
                    return this.JavaClass.ClassName + "WriteDao";
                }
                return this.JavaClass.ClassName + "Dao";

            }

        }
    }
}

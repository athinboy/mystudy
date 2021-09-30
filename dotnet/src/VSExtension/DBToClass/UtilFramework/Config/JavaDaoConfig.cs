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

        public JavaDaoConfig(JavaClass javaClass)
        {
            this.JavaClass = javaClass;

        }


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
                    return ReadDaoPackageName;
                }
                if (SplitReadWrite && ForWrite)
                {
                    return WriteDaoPackageName;
                }
                return this.PackageName;
            }
        }


        public string ReadDaoPackageName
        {
            get
            {
                return this.PackageName + ".read";
            }

        }
        public string WriteDaoPackageName
        {
            get
            {
                return this.PackageName + ".write";
            }
        }



        public string DaoName
        {
            get
            {

                if (SplitReadWrite && ForRead)
                {
                    return ReadDaoName;
                }
                if (SplitReadWrite && ForWrite)
                {
                    return WriteDaoName;
                }
                return this.JavaClass.ClassName + "Dao";

            }

        }

        public string ReadDaoName
        {
            get
            {
                return this.JavaClass.ClassName + "ReadDao";
            }

        }
        public string WriteDaoName
        {
            get
            {
                return this.JavaClass.ClassName + "WriteDao";
            }
        }



        public string VoClassName
        {
            get
            {
                return this.JavaClass.JavaVoClass.ClassName;
            }
        }
        public string VoClassFullName
        {
            get
            {
                return this.JavaClass.JavaVoClass.FullName;
            }
        }

        public string BoClassName
        {
            get
            {
                return this.JavaClass.ClassName;
            }
        }

        public string BoClassFullName
        {
            get
            {
                return this.JavaClass.FullName;
            }
        }
    }
}

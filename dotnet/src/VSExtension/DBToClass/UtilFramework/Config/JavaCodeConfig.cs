using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
    public class JavaCodeConfig : JavaConfigBase
    {
        public JavaCodeConfig(JavaDaoConfig daoConfig)
        {
            DaoConfig = daoConfig ?? throw new ArgumentNullException(nameof(daoConfig));
            this.JavaClass = daoConfig.JavaClass;
        }

        public JavaDaoConfig DaoConfig { get; set; }

        public bool ForModel { get; set; } = false;

        public string ModelPackageName { get; set; }

        public string ModelJavaDiretory { get; set; }


        public bool ForService { get; set; } = false;

        public string ServicePackageName { get; set; }

        public string ServiceJavaDiretory { get; set; }

        public bool ForServiceImpl { get; set; } = false;

        public string ServiceImplPackageName { get; set; }

        public string ServiceImplJavaDiretory { get; set; }
        public bool ForController { get; set; } = false;

        public string ControllerPackageName { get; set; }

        public string ControllerJavaDiretory { get; set; }


        public void Reset()
        {
            ForModel = false;
            ForService = false;
            ForServiceImpl = false;
            ForController = false;
        }

        public string ModelName
        {
            get
            {
                return this.JavaClass.ClassName + "Model";
            }
        }

        public string ServiceName
        {
            get
            {
                return this.JavaClass.ClassName + "Service";
            }
        }

        public string ServiceImplName
        {
            get
            {
                return this.JavaClass.ClassName + "ServiceImpl";
            }
        }


        public string ControllerName
        {
            get
            {
                return this.JavaClass.ClassName + "Controller";
            }
        }

    }
}

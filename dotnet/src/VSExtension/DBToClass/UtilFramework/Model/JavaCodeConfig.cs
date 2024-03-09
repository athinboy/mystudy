using System;

namespace Org.FGQ.CodeGenerate.Model
{
    public class JavaCodeConfig : JavaModel
    {
        public JavaCodeConfig(JavaDaoModel daoConfig)
        {
            DaoConfig = daoConfig ?? throw new ArgumentNullException(nameof(daoConfig));
            this.JavaClass = daoConfig.JavaClass;
        }

        public JavaDaoModel DaoConfig { get; set; }

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

        public string ServiceCodeTemplateFile { get; set; } = null;

        public string ServiceImplCodeTemplateFile { get; set; } = null;

        public string ControllerCodeTemplateFile { get; set; } = null;


        public bool GeneralModel { get; set; } = true;
        public bool GeneralService { get; set; } = true;
        public bool GeneralServiceImpl { get; set; } = true;
        public bool GeneralController { get; set; } = true;

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

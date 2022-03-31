using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;


namespace Org.FGQ.CodeGenerate.Pipe
{
    public class JavaWorkModel : Work
    {


        public JavaBeanModel BeanConfig { get; set; }

        //public JavaCodeConfig CodeConfig { get; set; }

        //public JavaMapperConfig MapperConfig { get; set; }
        //public JavaDaoConfig DaoConfig { get; set; }

        public string DaoJavaDiretory { get; set; }
        public string DaoPackageName { get; set; }

        public string MapperDirectory { get; set; }

        public string ModelPackageName { get; set; }

        public string ModelJavaDiretory { get; set; }

        public string ServicePackageName { get; set; }

        public string ServiceJavaDiretory { get; set; }


        public string ServiceImplPackageName { get; set; }

        public string ServiceImplJavaDiretory { get; set; }


        public string ControllerPackageName { get; set; }

        public string ControllerJavaDiretory { get; set; }

    }
}

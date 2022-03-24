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


        public JavaBeanConfig BeanConfig { get; set; }

        public JavaCodeConfig CodeConfig { get; set; }

        public JavaMapperConfig MapperConfig { get; set; }
        public JavaDaoConfig DaoConfig { get; set; }
    }
}

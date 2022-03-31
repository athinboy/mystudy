using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
    public class JavaMapperModel : JavaDaoModel
    {

        private JavaMapperModel(JavaClass javaClass):base(javaClass)
        {
            this.JavaClass = javaClass;
        }

        public JavaMapperModel(JavaDaoModel javaDaoConfig):base(javaDaoConfig.JavaClass)
        {
            this.DaoConfig = javaDaoConfig;
        }

        public string MapperDirectory { get; set; }

        public JavaDaoModel DaoConfig { get; set; }


        public string MapperName
        {
            get
            {
                if (SplitReadWrite && ForRead)
                {
                    return this.JavaClass.ClassName + "ReadMapper";
                }
                if (SplitReadWrite && ForWrite)
                {
                    return this.JavaClass.ClassName + "WriteMapper";
                }
                return this.JavaClass.ClassName + "Mapper";
            }
        }


        public string VoFullName
        {
            get
            {
                return this.JavaClass.JavaVoClass.FullName;
            }
        }



        public List<FieldBase> ClasssFields
        {
            get
            {
                return this.JavaClass.Fields;
            }
        }

        public string DBTableName
        {
            get
            {
                return this.JavaClass.DDLTable == null ? "丢失的数据表名称" : this.JavaClass.DDLTable.TableName;
            }
        }



    }
}

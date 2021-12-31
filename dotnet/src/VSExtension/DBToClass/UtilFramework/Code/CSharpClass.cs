using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Code
{
    public class CSharpClass : ClassBase
    {
        private CSharpBeanConfig beanConfig;

        public CSharpClass(string namespaceName, DDLTable dDLTable) : base(namespaceName, dDLTable)
        {

        }

        public CSharpClass(string namespaceName, DDLTable dDLTable, CSharpBeanConfig beanConfig) : this(namespaceName, dDLTable)
        {
            this.beanConfig = beanConfig;
        }

        protected static new string GetFildTypeStr(FieldBase filedBase)
        {
            switch (filedBase.FieldType)
            {
                case FieldTypes.String:
                    return "String";
                case FieldTypes.Decimal:
                    return "BigDecimal";
                case FieldTypes.Int32:
                    return "Integer";
                case FieldTypes.Long:
                    return "Long";
                case FieldTypes.Float:
                    return "Float";
                case FieldTypes.Double:
                    return "Double";
                case FieldTypes.DateTime:
                    return "Date";
                case FieldTypes.Bool:
                    return "Boolean";
                default:
                    throw new ArgumentException(nameof(filedBase.FieldType));
            }
        }

        public static ClassBase CreateEntityClass(DDLTable table, CSharpBeanConfig beanConfig, bool createVo)
        {
            CSharpClass cSharpClass = new CSharpClass(beanConfig.NamespaceName, table, beanConfig);



            table.Columns.ForEach(c =>
            {
                if (false == c.Validate())
                {
                    return;
                }
                FieldBase filedBase;
                cSharpClass.Fields.Add(filedBase = FieldBase.Create(c));
                filedBase.FiledTypeStr = GetFildTypeStr(filedBase);


            });

            cSharpClass.Desc = table.Desc;

            cSharpClass.ClassName = table.ClassName.Length == 0 ? CodeUtil.GetClassName(beanConfig, table.TableName) : table.ClassName;

            if (createVo)
            {
                //javaClass.JavaVoClass = JavaClass.CreateVo(javaBeanConfig.VOPackageName, javaClass);
                throw new NotImplementedException();
            }
            return cSharpClass;
        }
    }
}

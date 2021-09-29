using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class JavaClass : ClassBase
    {
        public JavaClass(string packageName, DDLTable dDLTable) : base(packageName, dDLTable)
        {

        }

        public JavaClass(string packageName, DDLTable ddLTable, JavaBeanConfig javaBeanConfig) : this(packageName, ddLTable)
        {
            JavaBeanConfig = javaBeanConfig;
        }

        public JavaBeanConfig JavaBeanConfig { get; }
        public string Desc { get; private set; }


        public static JavaClass Create(DDLTable table, JavaBeanConfig javaBeanConfig)
        {
            JavaClass javaClass = new JavaClass(javaBeanConfig.PackageName, table, javaBeanConfig);



            table.Columns.ForEach(c =>
            {
                if (false == c.Validate())
                {
                    return;
                }
                FieldBase filedBase;
                javaClass.Fields.Add(filedBase = FieldBase.Create(c));
                filedBase.FiledTypeStr = GetFildTypeStr(filedBase);


            });

            javaClass.Desc = table.Desc;

            javaClass.ClassName = CodeUtil.GetClassName(javaBeanConfig, table.TableName);

            return javaClass;
        }

        private static string GetFildTypeStr(FieldBase filedBase)
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
    }
}

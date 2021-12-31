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

        public JavaClass(string packageName, string className) : base(packageName, className)
        {

        }


        public string PackageName
        {
            get
            {
                return NamespaceName;
            }
            private set { }
        }

        public string FullName
        {
            get
            {
                return NamespaceName + "." + ClassName;
            }
            private set { }
        }



        /// <summary>
        /// Bo类
        /// </summary>
        public JavaClass JavaBoClass { get; set; } = null;

        /// <summary>
        /// Vo类
        /// </summary>
        public JavaClass JavaVoClass { get; set; } = null;


        public JavaClass(string packageName, DDLTable ddLTable, JavaBeanConfig javaBeanConfig) : this(packageName, ddLTable)
        {
            JavaBeanConfig = javaBeanConfig;
        }

        public JavaBeanConfig JavaBeanConfig { get; }


        public static JavaClass CreateBoClass(DDLTable table, JavaBeanConfig javaBeanConfig, bool createVo)
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

            javaClass.ClassName = table.ClassName.Length == 0 ? CodeUtil.GetClassName(javaBeanConfig, table.TableName) : table.ClassName;

            if (createVo)
            {
                javaClass.JavaVoClass = JavaClass.CreateVo(javaBeanConfig.VOPackageName, javaClass);
            }
            return javaClass;
        }

        public static JavaClass CreateVo(string packageName, JavaClass boClass)
        {
            JavaClass javaClass = new JavaClass(packageName, boClass.ClassName + "Vo");
            javaClass.JavaBoClass = boClass;
            return javaClass;

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
    }
}

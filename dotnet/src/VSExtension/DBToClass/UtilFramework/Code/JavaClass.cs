using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class JavaClass : ClassBase
    {
        public JavaClass(string packageName, EntityTable table) : base(packageName, table)
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


        public JavaClass(string packageName, EntityTable Table, JavaBeanModel javaBeanConfig) : this(packageName, Table)
        {
            JavaBeanConfig = javaBeanConfig;
        }

        public JavaBeanModel JavaBeanConfig { get; }


        public static JavaClass CreateBoClass(EntityTable table, JavaBeanModel javaBeanConfig, bool createVo)
        {
            JavaClass javaClass = new JavaClass(javaBeanConfig.PackageName, table, javaBeanConfig);



            table.FieldColumns.ForEach(c =>
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

            //javaClass.ClassName = table.ClassName.Length == 0 ? CodeUtil.GetClassName(javaBeanConfig, table.TableName) : table.ClassName;

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
                case FieldDataTypes.String:
                    return "String";
                case FieldDataTypes.Decimal:
                    return "BigDecimal";
                case FieldDataTypes.Int32:
                    return "Integer";
                case FieldDataTypes.Long:
                    return "Long";
                case FieldDataTypes.Float:
                    return "Float";
                case FieldDataTypes.Double:
                    return "Double";
                case FieldDataTypes.DateTime:
                    return "Date";
                case FieldDataTypes.Bool:
                    return "Boolean";
                default:
                    throw new ArgumentException(nameof(filedBase.FieldType));
            }
        }
    }
}

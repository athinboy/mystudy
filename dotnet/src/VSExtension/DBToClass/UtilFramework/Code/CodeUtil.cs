using Org.FGQ.CodeGenerate.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Code
{
    public class CodeUtil
    {

        public static string GetClassName(JavaBeanConfig javaBeanConfig, string tableName)
        {
            if (javaBeanConfig.OmmitPrefix != null || tableName.StartsWith(javaBeanConfig.OmmitPrefix.Trim()))
            {
                tableName = tableName.Substring(javaBeanConfig.OmmitPrefix.Trim().Length);
            }
            while (tableName.StartsWith("_"))
            {
                tableName = tableName.Substring(1);
            }
            if (tableName.Length == 0)
            {
                throw new ArgumentException(nameof(tableName));
            }

            string[] tableNameParts = tableName.Split('_');
            string result = "";
            for (int i = 0; i < tableNameParts.Length; i++)
            {
                string partStr = tableNameParts[i];
                if (string.IsNullOrEmpty(partStr))
                {
                    continue;
                }
                result += (partStr.Substring(0, 1).ToUpper() + (partStr.Length == 1 ? "" : partStr.Substring(1)));

            }
            return result;
        }

        internal static string GetFieldName(DDLColumn c)
        {
            string columnName = c.Name;
            string[] parts = columnName.Split('_');
            string result = "";
            for (int i = 0; i < parts.Length; i++)
            {
                string partStr = parts[i];
                if (string.IsNullOrEmpty(partStr))
                {
                    continue;
                }
                if (i == 0)
                {
                    result += partStr;
                }
                else
                {
                    result += (partStr.Substring(0, 1).ToUpper() + (partStr.Length == 1 ? "" : partStr.Substring(1)));
                }


            }
            return result;

        }

        public static string PrepareJavaRoot(JavaDaoConfig javaDaoConfig)
        {

            return PrepareJavaRoot(javaDaoConfig.JavaDiretory, javaDaoConfig.DaoPackageName);
        }

        public static string PrepareJavaRoot(string javaDiretory, string packageName)
        {
            string rootDir = javaDiretory + (javaDiretory.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString());

            if (false == Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            string[] packageParts = packageName.Split('.');
            for (int i = 0; i < packageParts.Length; i++)
            {
                string packagePart = packageParts[i];

                if (string.IsNullOrEmpty(packagePart))
                {
                    continue;
                }
                rootDir += (packagePart + Path.DirectorySeparatorChar);

                if (false == Directory.Exists(rootDir))
                {
                    Directory.CreateDirectory(rootDir);
                }
            }
            return rootDir;
        }


        public static string GetJavaKeyFieldsParaStr(JavaClass javaClass, bool withType, bool withParam)
        {
            if (false == javaClass.HasKeyField)
            {
                return string.Empty;
            }
            return string.Join(", ", javaClass.KeyFields.ConvertAll<string>(x => (withType ? (withParam ? String.Format("@Param(\"{0}\") ", x.Name) : "") + x.FiledTypeStr + " " : "") + x.Name));

        }

        public static string GetJavaKeyFieldsParaStr(JavaClass javaClass, bool withType)
        {
            return GetJavaKeyFieldsParaStr(javaClass, withType, withType ? true : false);

        }



        public static string GetJavaParaName(string className)
        {
            string result = className.Substring(0, 1).ToLower();
            className = className.Substring(1);

            while (className.Length > 1 && char.IsUpper(className.ToCharArray()[1]))
            {
                result += className.Substring(0, 1).ToLower();
                className = className.Substring(1);

            }
            if (className.Length > 1)
            {
                result += className;
            }
            else
            {
                result += className.Length < 0 ? className.ToLower() : "";
            }

            return result;
        }


        public static string GetDBColNameJoinStr(JavaClass javaClass)
        {
            if (false == javaClass.HasKeyField)
            {
                return string.Empty;
            }
            return string.Join(",", javaClass.Fields.ConvertAll<string>(x => x.DBColName));

        }

        public static string GetJavaMapKeyParaType(JavaClass javaClass)
        {
            if (javaClass.HasKeyField == false)
            {
                return "错误，没有主键";
            }
            if (javaClass.KeyFields.Count == 1)
            {
                return "java.lang." + javaClass.KeyFields[0].FiledTypeStr;
            }
            else
            {
                return "map";
            }


        }


    }
}

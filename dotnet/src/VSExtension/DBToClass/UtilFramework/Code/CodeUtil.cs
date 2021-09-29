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


        public static string PrepareJavaRoot(JavaConfigBase javaConfig)
        {
            return PrepareJavaRoot(javaConfig.JavaDiretory, javaConfig.PackageName);
        }


        private static string PrepareJavaRoot(string javaDiretory, string packageName)
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


        public static string GetJavaKeyFieldsParaStr(JavaClass javaClass)
        {
            if (false == javaClass.HasKeyField)
            {
                return string.Empty;
            }
            return string.Join(",", javaClass.KeyFileds.ConvertAll<string>(x => x.FiledTypeStr + " " + x.Name));

        }


    }
}

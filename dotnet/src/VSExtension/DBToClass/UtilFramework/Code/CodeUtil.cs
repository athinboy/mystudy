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

        public static string GetClassName(BaseModel baseConfig, string tableName)
        {
            if (baseConfig.OmmitPrefix != null || tableName.StartsWith(baseConfig.OmmitPrefix.Trim()))
            {
                tableName = tableName.Substring(baseConfig.OmmitPrefix.Trim().Length);
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

        /// <summary>
        /// user_name   ->  userName
        /// userName    ->  userName
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static string GetFieldName(DDLColumn c)
        {
            DDLModel ddlconfig = c.DDLTable.DDLConfig;

            if (ddlconfig.UnifyName) return c.Name;

            string columnName = c.NameSql;
            string[] parts = columnName.Split(ddlconfig.DBColSeparator[0]);
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

            return PrepareCodeRoot(javaDaoConfig.JavaDiretory, javaDaoConfig.DaoPackageName);
        }
        public static string PrepareJavaRoot(string javaDiretory, string DaoPackageName)
        {
            return PrepareCodeRoot(javaDiretory, DaoPackageName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeDiretory"></param>
        /// <param name="pathName">小数点.分隔的路径</param>
        /// <returns></returns>
        public static string PrepareCodeRoot(string codeDiretory, string pathName)
        {
            string rootDir = codeDiretory + (codeDiretory.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString());

            if (false == Directory.Exists(rootDir))
            {
                Directory.CreateDirectory(rootDir);
            }
            string[] packageParts = pathName.Split('.');
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


        public static string GetJavaPrimaryKeyFieldsParaStr(JavaClass javaClass, bool withType, bool withParam)
        {
            if (false == javaClass.HasPrimaryKeyField)
            {
                return string.Empty;
            }
            return string.Join(", ", javaClass.PrimaryKeyFields.ConvertAll<string>(x => (withType ? (withParam ? String.Format("@Param(\"{0}\") ", x.Name) : "") + x.FiledTypeStr + " " : "") + x.Name));

        }

        public static string GetJavaPrimaryKeyFieldsParaStr(JavaClass javaClass, bool withType)
        {
            return GetJavaPrimaryKeyFieldsParaStr(javaClass, withType, withType ? true : false);

        }

        public static string GetJavaUniqueKeyFieldsParaStr(JavaClass javaClass, bool withType, bool withParam)
        {
            if (false == javaClass.HasUniqueKeyField)
            {
                return string.Empty;
            }
            return string.Join(", ", javaClass.UniqueKeyFields.ConvertAll<string>(x => (withType ? (withParam ? String.Format("@Param(\"{0}\") ", x.Name) : "") + x.FiledTypeStr + " " : "") + x.Name));

        }

        public static string GetJavaUniqueKeyFieldsParaStr(JavaClass javaClass, bool withType)
        {
            return GetJavaUniqueKeyFieldsParaStr(javaClass, withType, withType ? true : false);

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
            return string.Join(",", javaClass.Fields.ConvertAll<string>(x => x.DBColName));

        }

        public static string GetJavaMapPrimaryKeyParaType(JavaClass javaClass)
        {
            if (javaClass.HasKeyField == false)
            {
                return "错误，没有主键";
            }
            if (javaClass.PrimaryKeyFields.Count == 1)
            {
                return "java.lang." + javaClass.PrimaryKeyFields[0].FiledTypeStr;
            }
            else
            {
                return "map";
            }


        }

        public static string GetJavaMapUniqueKeyParaType(JavaClass javaClass)
        {
            if (javaClass.HasUniqueKeyField == false)
            {
                return "错误，没有唯一主键";
            }
            if (javaClass.UniqueKeyFields.Count == 1)
            {
                return "java.lang." + javaClass.UniqueKeyFields[0].FiledTypeStr;
            }
            else
            {
                return "map";
            }


        }


    }
}

using Org.FGQ.CodeGenerate.config;
using System;
using System.Collections.Generic;
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
    }
}

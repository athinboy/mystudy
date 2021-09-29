using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.DB
{
    internal class DBUtil
    {
        internal static string AnalysisJDBCType(FieldTypes fieldType)
        {

            switch (fieldType)
            {
                case FieldTypes.String:
                    return JDBCTypes.VARCHAR.ToString();
                case FieldTypes.Decimal:
                    return JDBCTypes.DECIMAL.ToString();
                case FieldTypes.Int32:
                    return JDBCTypes.INTEGER.ToString();
                case FieldTypes.Long:
                    return JDBCTypes.BIGINT.ToString();
                case FieldTypes.DateTime:
                    return JDBCTypes.TIMESTAMP.ToString();
                case FieldTypes.Float:
                case FieldTypes.Double:
                case FieldTypes.Bool:
                    return "暂时不支持的数据类型";

                default:
                    throw new ArgumentException(nameof(fieldType));
            }

        }
    }
}

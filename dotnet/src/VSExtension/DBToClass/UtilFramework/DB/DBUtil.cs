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
        internal static string AnalysisJDBCType(FieldDataTypes fieldType)
        {

            switch (fieldType)
            {
                case FieldDataTypes.String:
                    return JDBCTypes.VARCHAR.ToString();
                case FieldDataTypes.Decimal:
                    return JDBCTypes.DECIMAL.ToString();
                case FieldDataTypes.Int32:
                    return JDBCTypes.INTEGER.ToString();
                case FieldDataTypes.Long:
                    return JDBCTypes.BIGINT.ToString();
                case FieldDataTypes.DateTime:
                    return JDBCTypes.TIMESTAMP.ToString();
                case FieldDataTypes.Float:
                case FieldDataTypes.Double:
                case FieldDataTypes.Bool:
                    return "暂时不支持的数据类型";

                default:
                    throw new ArgumentException(nameof(fieldType));
            }

        }
    }
}

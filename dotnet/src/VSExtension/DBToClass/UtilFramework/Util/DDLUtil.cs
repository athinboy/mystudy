using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Util
{
    internal class DDLUtil
    {

        internal static FieldTypes AnalysisFieldType(config.DDLColumn c)
        {

            if (c.TypeName.ToUpper().Contains("VARCHAR") || c.TypeName.ToUpper().Contains("字符"))
            {
                return FieldTypes.String;
            }

            if (c.TypeName.ToUpper().Contains("BIGINT")
                || c.TypeName.ToUpper().Contains("LONG")
                || c.TypeName.ToUpper().Contains("长整数"))
            {
                return FieldTypes.Long;
            }
            if (c.TypeName.ToUpper().Contains("INT") || c.TypeName.ToUpper().Contains("整数"))
            {
                return FieldTypes.Int32;
            }
            if (c.TypeName.ToUpper().Contains("NUMBER") || c.TypeName.ToUpper().Contains("数字") || c.TypeName.ToUpper().Contains("数值"))
            {
                return FieldTypes.Decimal;
            }

            if (c.TypeName.ToUpper().Contains("DateTime")
                || c.TypeName.ToUpper().Contains("时间")
                || c.TypeName.ToUpper().Contains("日期"))
            {
                return FieldTypes.DateTime;
            }
            if (c.TypeName.ToUpper().Contains("是否") || c.TypeName.ToUpper().Contains("布尔"))
            {
                return FieldTypes.Bool;
            }
            return FieldTypes.String;

        }


    }
}

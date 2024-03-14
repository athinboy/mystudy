using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Model;using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Util.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util.Util
{
    public class DDLUtil
    {

        public static FieldDataTypes AnalysisFieldType(FieldColumn c)
        {
            string longstr = null;
            string type = c.DataTypeDesc;
            if (type.Contains("("))
            {

                if (type.IndexOf(")") - type.IndexOf("(") <= 1)
                {
                    throw new ArgumentException(nameof(type) + ":" + type);
                }

                longstr = type.Substring(type.IndexOf("(") + 1, type.IndexOf(")") - type.IndexOf("(") - 1);

            }

            if (c.DataTypeDesc.ToUpper().Contains("VARCHAR") || c.DataTypeDesc.ToUpper().Contains("字符"))
            {
                return FieldDataTypes.String;
            }

            if (c.DataTypeDesc.ToUpper().Contains("BIGINT")
                || c.DataTypeDesc.ToUpper().Contains("LONG")
                || c.DataTypeDesc.ToUpper().Contains("长整数"))
            {
                return FieldDataTypes.Long;
            }
            if (c.DataTypeDesc.ToUpper().Contains("INT") || c.DataTypeDesc.ToUpper().Contains("整数"))
            {
                if (longstr != null && int.Parse(longstr) >= 10)
                {
                    return FieldDataTypes.Long;
                }
                return FieldDataTypes.Int32;
            }
            if (c.DataTypeDesc.ToUpper().Contains("NUMBER") || c.DataTypeDesc.ToUpper().Contains("数字") || c.DataTypeDesc.ToUpper().Contains("数值"))
            {
                return FieldDataTypes.Decimal;
            }

            if (c.DataTypeDesc.ToLower().Contains("datetime")
                || c.DataTypeDesc.ToUpper().Contains("时间")
                || c.DataTypeDesc.ToUpper().Contains("日期"))
            {
                return FieldDataTypes.DateTime;
            }
            if (c.DataTypeDesc.ToUpper().Contains("是否") || c.DataTypeDesc.ToUpper().Contains("布尔"))
            {
                return FieldDataTypes.Bool;
            }
            return FieldDataTypes.String;

        }

        private static string ToColPart(string x)
        {
            bool allUpper = true;
            for (int i = 0; i < x.Length; i++)
            {
                if (char.IsLower(x[i]))
                {
                    allUpper = false;
                }
            }
            return allUpper ? x : x.ToLower();
        }




        /// <summary>
        /// User_Name   ->   User_Name      <br/>
        /// user_name   ->   user_name      <br/>
        /// userName    ->   user_name      <br/>
        /// UserName    ->   user_name      <br/>
        /// Urlabc      ->   urlabc         <br/>
        /// webUrl      ->   web_url        <br/>
        /// abcABCName  ->   abc_ABC_name   <br/>
        /// abcABC      ->   abc_ABC        <br/>
        /// ABC         ->   ABC            <br/>
        /// Abc         ->   abc            <br/>
        /// A           ->   a              <br/>
        /// a           ->   a              <br/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        /// <remarks></remarks>
        /// <returns></returns>
        public static string InferColName(string name, bool unifyName, string dbColSeparator)
        {

            if (unifyName)
            {
                return name;
            }

            if (name.Contains(dbColSeparator))
            {
                return name;
            }
            else
            {
                if (name.ToLower() == name)
                {
                    return name;
                }
                string result = string.Empty;

                if(name.Length==1) return name.ToLower();

                while (name.Length > 0)
                {
                    if (name.ToLower() == name)
                    {
                        result += ((result.Length > 0 ? dbColSeparator : "") + ToColPart(name));
                        break;
                    }
                    else
                    {
                        bool shoudCut = false;
                        for (int i = 0; i < name.Length; i++)
                        {
                            if (i == name.Length - 1)
                            {
                                result += ((result.Length > 0 ? dbColSeparator : "") + ToColPart(name));
                                name = String.Empty;
                                break;
                            }

                            shoudCut = false;
                            if (i > 0 && char.IsUpper(name[i]))
                            {
                                if (char.IsLower(name[i - 1]))
                                {
                                    shoudCut = true;
                                }
                                if (i + 1 < name.Length && char.IsLower(name[i + 1]))
                                {
                                    shoudCut = true;
                                }

                            }

                            if (shoudCut)
                            {
                                result += ((result.Length > 0 ? dbColSeparator : "") + ToColPart(name.Substring(0, i)));
                                name = name.Substring(i);
                                break;
                            }

                        }
                    }


                }
                return result;


            }
        }


    }
}

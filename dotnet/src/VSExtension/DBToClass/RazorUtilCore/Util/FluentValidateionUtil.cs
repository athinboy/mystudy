using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Util
{
	internal class FluentValidateionUtil
	{

		public static void Init()
		{
			ValidatorOptions.Global.PropertyNameResolver = delegate (Type t, MemberInfo s, System.Linq.Expressions.LambdaExpression e)
			{
				return t.Name + "." + s.Name;
			};
			ValidatorOptions.Global.DisplayNameResolver = delegate (Type t, MemberInfo s, System.Linq.Expressions.LambdaExpression e)
			{
				return t.Name + "." + s.Name;
			};
		}
	}
}

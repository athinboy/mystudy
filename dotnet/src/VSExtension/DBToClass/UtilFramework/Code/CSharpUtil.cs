using System;

namespace Org.FGQ.CodeGenerate.Code
{
	public class CSharpUtil
	{
		/// <summary>
		/// merge namespace .
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static string CombineNamespace(string v1, string v2)
		{
			v1 = (v1 ?? "");
			v2 = (v2 ?? "");

			string r = v1 + "." + v2;
			r = r.Replace("..", ".");
			return TrimNamespace(r);
		}


		public static string GetNamespacePath(string fullNamespace, string namespacePathOmmit)
		{
			fullNamespace = fullNamespace ?? "";
			namespacePathOmmit = namespacePathOmmit ?? "";
			string r;
			if (fullNamespace.StartsWith(namespacePathOmmit))
			{
				r = fullNamespace.Substring(namespacePathOmmit.Length);
			}
			else
			{
				r = fullNamespace;
			}

			return TrimNamespace(r);
		}
		public static string TrimNamespace(string r)
		{
			r = r ?? "";
			r = r.Trim();
			if (r.StartsWith("."))
			{
				r = r.Substring(1);
			}
			if (r.EndsWith("."))
			{
				r = r.Remove(r.Length - 1);
			}
			return r;

		}
	}
}

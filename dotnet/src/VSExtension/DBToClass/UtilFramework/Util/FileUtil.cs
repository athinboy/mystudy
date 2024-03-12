using System;
using System.IO;

namespace Org.FGQ.CodeGenerate.Util
{
	public class FileUtil
    {
        public static void PrepareDirectory(string path)
        {
            if (path.LastIndexOf(System.IO.Path.DirectorySeparatorChar) == -1)
            {
                throw new ArgumentException(nameof(path));
            }
            string temp = path.Substring(0, path.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            if (false == Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
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
	}
}

using System;
using System.IO;

namespace Org.FGQ.CodeGenerate
{
    public class FileUtil
    {
        public static string GetInternalTemplateFilePath(string filename)
        {
            return Environment.CurrentDirectory + Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + filename;
        }

        internal static string GetAbsoluteFilePath(string rootPath, string relatePath)
        {
            return Path.GetFullPath(relatePath, rootPath);

        }
    }

}


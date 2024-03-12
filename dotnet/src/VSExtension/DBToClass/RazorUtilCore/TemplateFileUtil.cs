using System;
using System.IO;

namespace Org.FGQ.CodeGenerate
{
    public class TemplateFileUtil
    {
        public static string GetInternalTemplateFilePath(string filename)
        {
            filename = (string.IsNullOrEmpty(filename) ? null : filename) ?? throw new ArgumentNullException(nameof(filename));
            return Environment.CurrentDirectory + Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + filename;
        }

        internal static string GetAbsoluteFilePath(string rootPath, string relatePath)
        {
            return Path.GetFullPath(relatePath, rootPath);

        }
    }

}


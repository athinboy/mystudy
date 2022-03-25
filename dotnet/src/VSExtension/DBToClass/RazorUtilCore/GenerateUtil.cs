using System;
using System.IO;

namespace Org.FGQ.CodeGenerate
{
    public class GenerateUtil
    {
        public static string GetInternalTemplateFilePath(string filename)
        {
            return Environment.CurrentDirectory + Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + filename;
        }

    }

}


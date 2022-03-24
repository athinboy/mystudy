using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

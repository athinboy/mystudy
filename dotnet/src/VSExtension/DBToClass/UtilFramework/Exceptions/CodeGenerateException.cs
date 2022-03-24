using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Exceptions
{
    public class CodeGenerateException : Exception
    {
        public CodeGenerateException(string message) : base(message)
        {
        }
    }
}

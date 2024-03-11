using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.FGQ.CodeGenerate.Config
{
	public abstract class ConfigBase
	{
		public virtual bool Validate()
		{
			return true;
		}
	}
}

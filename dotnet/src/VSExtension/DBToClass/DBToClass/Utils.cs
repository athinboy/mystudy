using EnvDTE;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBToClass
{
    static class Utils
    {
		public static IWpfTextViewHost GetCurrentViewHost(IServiceProvider serviceProvider)
		{
			IVsTextManager txtMgr = (IVsTextManager)serviceProvider.GetService(typeof(SVsTextManager));
			if (txtMgr == null)
			{
				return null;
			}

			IVsTextView vTextView = null;
			int mustHaveFocus = 1;
			txtMgr.GetActiveView(mustHaveFocus, null, out vTextView);
			IVsUserData userData = vTextView as IVsUserData;
			if (userData == null)
				return null;

			object holder;
			Guid guidViewHost = DefGuidList.guidIWpfTextViewHost;
			userData.GetData(ref guidViewHost, out holder);

			return holder as IWpfTextViewHost;
		}
		public static string GetProjectOutputAssembly(Project project, Microsoft.CodeAnalysis.Project roslynProject)
		{
			ThreadHelper.ThrowIfNotOnUIThread();
		 

			string outputFileName = Path.GetFileName(roslynProject.OutputFilePath);

			// Get the directory path based on the project file.
			string projectPath = Path.GetDirectoryName(project.FullName);

			// Get the output path based on the active configuration
			string projectOutputPath = project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();

			// Combine the project path and output path to get the bin path
			if ((projectPath != null) && (projectOutputPath != null) && (outputFileName != null))
				return Path.Combine(projectPath, projectOutputPath, outputFileName);

			return null;
		}

	}
}

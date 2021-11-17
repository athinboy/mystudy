 
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Globalization;

namespace DBToClass
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(DBToClassPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(SettingWin),Style =VsDockStyle.Float,Orientation =ToolWindowOrientation.none)] 
    public sealed class DBToClassPackage : AsyncPackage
    {
        /// <summary>
        /// DBToClassPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "fae93d00-fe1f-4056-93cd-73a0b3c0c2db";

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await RunCommand.InitializeAsync(this);        
            await SettingWinCommand.InitializeAsync(this);
            await DBToClass.RunFunc.RunFuncCommand.InitializeAsync(this);

            var componentModel = (IComponentModel)await GetServiceAsync(typeof(SComponentModel));
            Assumes.Present(componentModel);

            this.workspace = componentModel.GetService<VisualStudioWorkspace>();
            Assumes.Present(workspace);


        }

        #endregion

        VisualStudioWorkspace workspace;
        public VisualStudioWorkspace Workspace => workspace;

        public EnvDTE80.DTE2 DTE => (EnvDTE80.DTE2)GetGlobalService(typeof(EnvDTE.DTE));


        public void ShowMessage(string format, params object[] items)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            ShowMessage(OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, format, items);
        }

        public void ShowMessage(OLEMSGICON icon, string format, params object[] items)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            ShowMessage(OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, icon, format, items);
        }

        public int ShowMessage(OLEMSGBUTTON buttons, OLEMSGDEFBUTTON defaultButton, OLEMSGICON icon, string format, params object[] items)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            if (uiShell == null)
            {
                return 0;
            }

            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(
                uiShell.ShowMessageBox(
                    0,
                    ref clsid,
                    "ILSpy AddIn",
                    string.Format(CultureInfo.CurrentCulture, format, items),
                    string.Empty,
                    0,
                    buttons,
                    defaultButton,
                    icon,
                    0,        // false
                    out result
                )
            );

            return result;
        }

    }
}


using System;
using System.ComponentModel.Design;
using System.Globalization;
using Task = System.Threading.Tasks.Task;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using System.Linq;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using Mono.Cecil;
using ICSharpCode.ILSpy.AddIn;
using DTEConstants = EnvDTE.Constants;
using System.Diagnostics;
using Microsoft.Build.Evaluation;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

namespace DBToClass.RunFunc
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class RunFuncCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4132;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("{80DFFED1-B16A-4E9F-92E7-5FBC5899DDB7}");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        protected DBToClassPackage owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunFuncCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private RunFuncCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            this.owner = package as DBToClassPackage;
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);


        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static RunFuncCommand Instance
        {
            get;
            private set;
        }

        private IVsOutputWindowPane outputWindowPane;

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {

            // Switch to the main thread - the call to AddCommand in RunFuncCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new RunFuncCommand(package, commandService);
            Instance.outputWindowPane = (package as DBToClassPackage).CreateOutputPane(new Guid(), "Created Pane", true, false);
        }





        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "RunFuncCommand";

            //// Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this.package,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            OnExecute(sender, e);
        }


        protected async void OnExecute(object send, EventArgs e)
        {
            try
            {
                string result = await RunExecuteAsync(send, e);
                if (false == string.IsNullOrEmpty(result))
                {
                    VSOutput(result);
                }


            }
            catch (Exception ex)
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                outputWindowPane.Activate();
                outputWindowPane.OutputStringThreadSafe(ex.ToString());
            }
        }

        private async Task<string> RunExecuteAsync(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var textView = Utils.GetCurrentViewHost(owner)?.TextView;
            if (textView == null)
            {
                return "textView == null";
            }
            SnapshotPoint caretPosition = textView.Caret.Position.BufferPosition;
            var roslynDocument = GetRoslynDocument();
            if (roslynDocument == null)
            {
                //owner.ShowMessage("This element is not analyzable in current view.");
                return "roslynDocument == null";
            }
            var ast = await roslynDocument.GetSyntaxRootAsync().ConfigureAwait(false);
            var model = await roslynDocument.GetSemanticModelAsync().ConfigureAwait(false);
            var node = ast.FindNode(new TextSpan(caretPosition.Position, 0), false, true);
            if (node == null)
            {
                //owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return "node == null";

            }
            bool isstatic = false;
            bool ispublic = false;
            if (node is Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax)
            {
                Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax mdy = node as Microsoft.CodeAnalysis.CSharp.Syntax.MethodDeclarationSyntax;

                foreach (var modifier in mdy.Modifiers)
                {
                    Debug.WriteLine(modifier.Text);//public  static
                    if ("public" == modifier.Text.ToLower())
                    {
                        ispublic = true;
                    }
                    if ("static" == modifier.Text.ToLower())
                    {
                        isstatic = true;
                    }

                }

            }
            else
            {
                //owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "只支持c#,请针对方法！");
                return "只支持c#,请针对方法！";
            }

            if (false == ispublic)
            {
                //owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "只支持public方法！");
                return "只支持public方法！";
            }


            var symbol = GetSymbolResolvableByILSpy(model, node);
            if (symbol == null)
            {
                //owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return "symbol == null";
            }

            Debug.WriteLine(symbol.MetadataName); //                                 Run
            Debug.WriteLine(symbol.ContainingAssembly); //                           console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
            Debug.WriteLine(symbol.ContainingModule);//                              console.dll
            Debug.WriteLine(symbol.ContainingNamespace); //                          fgq.console
            Debug.WriteLine(symbol.ContainingSymbol);//                              fgq.console.MemoryLeakDemo1
            Debug.WriteLine(symbol.ContainingType);//                                fgq.console.MemoryLeakDemo1
            Debug.WriteLine(symbol.Name);//                                          Run




            var roslynProject = roslynDocument.Project;
            var refsmap = GetReferences(roslynProject);
            var symbolAssemblyName = symbol.ContainingAssembly?.Identity?.Name;

            // Add our own project as well (not among references)
            var project = FindProject(owner.DTE.Solution.Projects.OfType<EnvDTE.Project>(), roslynProject.FilePath);

            if (project == null)
            {
                //owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return "project == null";
            }

            string assemblyName = roslynDocument.Project.AssemblyName;
            string projectOutputPath = Utils.GetProjectOutputAssembly(project, roslynProject);
            //Debug.WriteLine("fgq" + nameof(assemblyName) + ":" + assemblyName);
            //Debug.WriteLine("fgq" + nameof(projectOutputPath) + ":" + projectOutputPath);
            //Debug.WriteLine("fgq project.name" + ":" + project.Name);
            //Debug.WriteLine("fgq project.FileName" + ":" + project.FileName);
            //Debug.WriteLine("fgq project.FullName" + ":" + project.FullName);


            try
            {
                using (ProjectCollection projectCollection = new ProjectCollection())
                {
                    Microsoft.Build.Definition.ProjectOptions projectOptions = new Microsoft.Build.Definition.ProjectOptions();


                    Microsoft.Build.Evaluation.Project buildproject = projectCollection.LoadProject(project.FullName);

                    bool isNetCoreProject = IsNetCoreProject(buildproject);


                    bool buildresult = buildproject.Build();
                    Debug.WriteLine(buildresult);
                    Assembly assembly = Assembly.LoadFile(projectOutputPath);
                    Debug.WriteLine("System.Reflection.Assembly.GetEntryAssembly().FullName:" + Assembly.GetEntryAssembly()?.FullName);
                    Debug.WriteLine("System.Reflection.Assembly.GetExecutingAssembly().FullName:" + Assembly.GetExecutingAssembly()?.FullName);

                    string cmdPath = GetCmdPath(isNetCoreProject);

                    Debug.WriteLine(cmdPath);

                    VSOutput("----------------------------------------------------------------------");
                    VSOutput("start invoke");


                    Type type = assembly.GetType(symbol.ContainingType.ToString(), false, true);
                    Object o = assembly.CreateInstance(symbol.ContainingType.Name);

                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    processStartInfo.UseShellExecute = false; ;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.Arguments = string.Format("{0} {1} {2} {3}", projectOutputPath, symbol.ContainingType.ToString(), symbol.Name, isstatic.ToString());

                    processStartInfo.FileName = cmdPath;
                    Process process = Process.Start(processStartInfo);


                    TextReader textReader = process.StandardOutput;


                    process.WaitForExit();

                    //while (false == process.HasExited)
                    //{
                    //}
                    Debug.WriteLine(process.ExitCode);

                    string output = await textReader.ReadToEndAsync();

                    VSOutput(output);



                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ex.ToString();


            }
            return "";


        }

        private async void VSOutput(string output)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            outputWindowPane.Activate();
            outputWindowPane.OutputString(DateTime.Now.ToString() + output+"\r\n");
        }

        private bool IsNetCoreProject(Microsoft.Build.Evaluation.Project buildproject)
        {
            ICollection<ProjectProperty> projectProperties = buildproject.Properties;
            foreach (var projectProperty in projectProperties)
            {
                Debug.WriteLine(projectProperty.Name + ":" + projectProperty.EvaluatedValue);
                if (projectProperty.Name.ToUpper() == "TargetFramework".ToUpper())
                {
                    if (projectProperty.EvaluatedValue.ToUpper().Contains("net5".ToUpper()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetCmdPath(bool isNetCoreProject)
        {
            Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Debug.WriteLine(nameof(executingAssembly.Location) + executingAssembly.Location);//Locationc:\users\fengguoqiang\appdata\local\microsoft\visualstudio\17.0_6b6c739bexp\extensions\guoqiang feng\dbtoclass\1.0\DBToClass.dll
            Debug.WriteLine(nameof(executingAssembly.CodeBase) + executingAssembly.CodeBase);//CodeBasefile:///c:/users/fengguoqiang/appdata/local/microsoft/visualstudio/17.0_6b6c739bexp/extensions/guoqiang feng/dbtoclass/1.0/DBToClass.dll

            return executingAssembly.Location.Substring(0, executingAssembly.Location.LastIndexOf(Path.DirectorySeparatorChar) + 1) + (isNetCoreProject ? ("RunProcessFile" + Path.DirectorySeparatorChar + "RunProcess.Core.exe") : "RunProcess.FW.exe");//RunProcess.Core.exe
        }

        public class DetectedReference
        {
            public DetectedReference(string name, string assemblyFile, bool isProjectReference)
            {
                this.Name = name;
                this.AssemblyFile = assemblyFile;
                this.IsProjectReference = isProjectReference;
            }

            public string Name { get; private set; }
            public string AssemblyFile { get; private set; }
            public bool IsProjectReference { get; private set; }
        }


        protected Dictionary<string, DetectedReference> GetReferences(Microsoft.CodeAnalysis.Project parentProject)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var dict = new Dictionary<string, DetectedReference>();
            foreach (var reference in parentProject.MetadataReferences)
            {
                using (var assemblyDef = AssemblyDefinition.ReadAssembly(reference.Display))
                {
                    string assemblyName = assemblyDef.Name.Name;
                    string resolvedAssemblyFile = AssemblyFileFinder.FindAssemblyFile(assemblyDef, reference.Display);
                    dict.Add(assemblyName, new DetectedReference(assemblyName, resolvedAssemblyFile, false));
                }
            }
            foreach (var projectReference in parentProject.ProjectReferences)
            {
                var roslynProject = owner.Workspace.CurrentSolution.GetProject(projectReference.ProjectId);
                if (roslynProject != null)
                {
                    var project = FindProject(owner.DTE.Solution.Projects.OfType<EnvDTE.Project>(), roslynProject.FilePath);
                    if (project != null)
                    {
                        dict.Add(roslynProject.AssemblyName,
                            new DetectedReference(roslynProject.AssemblyName, Utils.GetProjectOutputAssembly(project, roslynProject), true));
                    }
                }
            }
            return dict;
        }

        protected EnvDTE.Project FindProject(IEnumerable<EnvDTE.Project> projects, string projectFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (var project in projects)
            {
                switch (project.Kind)
                {
                    case DTEConstants.vsProjectKindSolutionItems:
                        // This is a solution folder -> search in sub-projects
                        var subProject = FindProject(
                            project.ProjectItems.OfType<EnvDTE.ProjectItem>().Select(pi => pi.SubProject).OfType<EnvDTE.Project>(),
                            projectFile);
                        if (subProject != null)
                            return subProject;
                        break;

                    case DTEConstants.vsProjectKindUnmodeled:
                        // Skip unloaded projects completely
                        break;

                    default:
                        // Match by project's file name
                        if (project.FileName == projectFile)
                            return project;
                        break;
                }
            }

            return null;
        }

        ISymbol GetSymbolResolvableByILSpy(SemanticModel model, SyntaxNode node)
        {
            var current = node;
            while (current != null)
            {
                var symbol = model.GetSymbolInfo(current).Symbol;
                if (symbol == null)
                {
                    symbol = model.GetDeclaredSymbol(current);
                }

                // ILSpy can only resolve some symbol types, so allow them, discard everything else
                if (symbol != null)
                {
                    switch (symbol.Kind)
                    {
                        case SymbolKind.ArrayType:
                        case SymbolKind.Event:
                        case SymbolKind.Field:
                        case SymbolKind.Method:
                        case SymbolKind.NamedType:
                        case SymbolKind.Namespace:
                        case SymbolKind.PointerType:
                        case SymbolKind.Property:
                            break;
                        default:
                            symbol = null;
                            break;
                    }
                }

                if (symbol != null)
                    return symbol;

                current = current is IStructuredTriviaSyntax
                    ? ((IStructuredTriviaSyntax)current).ParentTrivia.Token.Parent
                    : current.Parent;
            }

            return null;
        }



        private Microsoft.CodeAnalysis.Document GetRoslynDocument()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var document = owner.DTE.ActiveDocument;
            var id = owner.Workspace.CurrentSolution.GetDocumentIdsWithFilePath(document.FullName).FirstOrDefault();
            if (id == null)
                return null;

            return owner.Workspace.CurrentSolution.GetDocument(id);
        }

    }
}
